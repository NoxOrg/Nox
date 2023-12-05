using System;
using System.Linq;
using YamlDotNet.Core.Tokens;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="ReferenceNumber"/> type and value object.
/// </summary>
public sealed class ReferenceNumber : ValueObject<string, ReferenceNumber>
{
    public ReferenceNumber()
    {
        Value = string.Empty;
    }

    /// <summary>
    /// <see cref="ReferenceNumber"/> object can only be created with <see cref="ValueObject{T,TValueObject}.FromDatabase"/>.
    /// </summary>
    public new static ReferenceNumber From(string _) => throw new InvalidOperationException($"{nameof(ReferenceNumber)} can only be loaded using {nameof(FromDatabase)} or needs to be creaed from a number and options.");

    public static ReferenceNumber From(string _, ReferenceNumberTypeOptions __) => throw new InvalidOperationException($"{nameof(ReferenceNumber)} can only be loaded using {nameof(FromDatabase)} or needs to be creaed from a number and options.");

    /// <summary>
    /// Computes the ReferenceNumber from the given sequence number and type options.
    /// Uses Luhn algorithm to compute the check digit.
    /// </summary>
    /// <param name="sequenceNumber"></param>    
    /// <returns>Reference Number Object</returns>
    public static ReferenceNumber From(long sequenceNumber , ReferenceNumberTypeOptions typeOptions)
    {
        ArgumentNullException.ThrowIfNull(typeOptions, nameof(typeOptions));

        string referenceNumber= string.Empty;

        if (typeOptions.SuffixCheckSumDigit)
        { 
            var checkDigit = ComputeCheckDigit(sequenceNumber);
            referenceNumber = $"{typeOptions.Prefix}{sequenceNumber}{checkDigit}";
        }
        else
        {
            referenceNumber = $"{typeOptions.Prefix}{sequenceNumber}";
        }

        var newObject = new ReferenceNumber
        {
            Value = referenceNumber
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new NoxTypeValidationException(validationResult.Errors);
        }

        return newObject;
    }
    private static int ComputeCheckDigit(long number)
    {
        var digits = number.ToString().Select(c => int.Parse(c.ToString())).ToList();
        int sum = 0;
        bool doubleDigit = true;

        for (int i = digits.Count - 1; i >= 0; i--)
        {
            int digit = digits[i];

            if (doubleDigit)
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit -= 9;
                }
            }

            sum += digit;
            doubleDigit = !doubleDigit;
        }

        int remainder = sum % 10;

        return (remainder == 0) ? 0 : 10 - remainder;
    }    
}