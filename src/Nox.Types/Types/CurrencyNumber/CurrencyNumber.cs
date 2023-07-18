using System;
using System.Collections.Generic;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="CurrencyNumber"/> type and value object.
/// Supports ETL Process's and allows to get the proper <see cref="CurrencyCode"/>
/// </summary>    
[Serializable]
public sealed class CurrencyNumber : ValueObject<short, CurrencyNumber>
{
    private static HashSet<short> _currecyNumbers = new HashSet<short>()
    {
        784, 971, 8, 51 , 532, 973, 32 , 36 , 533, 944, 977, 52 , 50,
        975, 48, 108, 60, 96, 68, 986, 44, 64, 72, 974, 84, 124, 324,
        976, 756, 152, 156, 170, 188, 931, 192, 132, 203, 262, 208, 270,
        214, 12 , 818, 232, 230, 978, 242, 238, 826, 981, 936, 292, 352,
        320, 328, 344, 340, 191, 332, 348, 360, 376, 356, 368, 364, 418,
        388, 400, 392, 404, 417, 116, 174, 408, 410, 414, 136, 398, 478,
        422, 144, 430, 426, 434, 504, 498, 969, 807, 104, 496, 446, 512,
        480, 462, 454, 484, 458, 943, 516, 566, 558, 578, 524, 554, 682,
        590, 604, 598, 608, 586, 985, 600, 634, 946, 941, 643, 646, 748,
        90 , 690, 938, 752, 702, 654, 694, 706, 968, 930, 222, 760, 858,
        764, 972, 934, 788, 776, 949, 780, 901, 834, 980, 800, 840, 894,
        860, 704, 548, 882, 950, 951, 952, 953, 886, 710
    };

    /// <summary>
    /// Creates a new instance of <see cref="CurrencyNumber"/>
    /// </summary>
    /// <param name="value">The string to create the <see cref="CurrencyNumber"/> with</param>
    /// <returns></returns>
    /// <exception cref="ValidationException">If the currencyCode3 is invalid.</exception>
    public static new CurrencyNumber From(short value)
    {
        var newObject = new CurrencyNumber
        {
            Value = value
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates the <see cref="CurrencyNumber"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="CurrencyNumber"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!_currecyNumbers.Contains(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox CurrencyNumber type with unsupported value '{Value}'."));
        }

        return result;
    }

    public override string ToString()
    {
        int intValue = (int)Value;

        if (Enum.IsDefined(typeof(CurrencyCode), intValue))
        {
            return Enum.GetName(typeof(CurrencyCode), intValue);
        }
        
        return  "Unknown currency" ;
    }
}
