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
        784,971,8,51,532,973,32,36,533,944,977,52,50,975,48,108,60,96,68,984,
        986,44,64,72,933,84,124,976,947,756,948,990,152,170,970,188,931,192,
        132,203,262,208,214,12,818,232,230,978,242,238,826,981,936,292,270,
        324,320,328,344,340,332,348,360,376,356,368,364,352,388,400,392,404,
        417,116,174,408,410,414,136,398,418,422,144,430,426,434,504,498,969,
        807,104,496,446,929,480,462,454,484,979,458,943,516,566,558,578,524,
        554,512,590,604,598,608,586,985,600,634,946,941,156,643,646,682,90,
        690,938,752,702,654,925,694,706,968,728,930,222,760,748,764,972,934,
        788,776,949,780,901,834,980,800,840,997,940,858,927,860,926,928,704,
        548,882,950,961,959,955,956,957,958,951,960,952,964,953,962,994,963,
        965,999,886,710,967,932
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
            return Enum.GetName(typeof(CurrencyCode), intValue)!;
        }
        
        return  "Unknown currency" ;
    }
}