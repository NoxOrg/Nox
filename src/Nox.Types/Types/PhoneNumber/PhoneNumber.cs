using System.Text.RegularExpressions;
using System;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="PhoneNumber"/> type and value object.
/// </summary>
public sealed class PhoneNumber : ValueObject<string, PhoneNumber>
{
    private static readonly Regex _phoneNumberRegex = new(@"^(?:\+\d{1,3}[\s\-]?)?(?:\(\d{1,4}\)|\d{1,4})\s*\-?\s*(?:\d{1,4}\s*\-?\s*){1,4}$", RegexOptions.Compiled, TimeSpan.FromSeconds(1));
    private static readonly int _maxPhoneNumberLength = 30;

    /// <summary>
    /// Validates a <see cref="PhoneNumber"/> object.
    /// </summary>
    /// <returns>true if the <see cref="PhoneNumber"/> value is valid .</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!_phoneNumberRegex.IsMatch(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox PhoneNumber type with invalid value '{Value}'."));
        }

        if(Value.Length > _maxPhoneNumberLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox PhoneNumber type because the maximum length should be {_maxPhoneNumberLength}."));
        }

        return result;
    }
}