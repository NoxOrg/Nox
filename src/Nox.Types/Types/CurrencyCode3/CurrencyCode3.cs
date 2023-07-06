using System;
using System.Linq;

namespace Nox.Types;

/// <summary>
/// Class for three-letters currency code (ISO 4217).
/// </summary>
public sealed class CurrencyCode3 : ValueObject<string, CurrencyCode3>
{
    private readonly static string[] _currencyCodes = Enum.GetNames(typeof(CurrencyCode));

    /// <summary>
    /// Creates a new instance of <see cref="CurrencyCode3"/>
    /// </summary>
    /// <param name="value">The string to create the <see cref="CurrencyCode3"/> with</param>
    /// <returns></returns>
    /// <exception cref="ValidationException">If the currencyCode3 is invalid.</exception>
    public static new CurrencyCode3 From(string value)
    {
        var newObject = new CurrencyCode3
        {
            Value = value.ToUpperInvariant()
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates the <see cref="CurrencyCode3"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="CurrencyCode3"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!_currencyCodes.Contains(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox CurrencyCode3 type with unsupported value '{Value}'."));
        }

        return result;
    }
}