using System.Collections.Generic;

namespace Nox.Types;

/// <summary>
/// Class for three-letters currency code (ISO 4217).
/// </summary>
public sealed class CurrencyCode3 : ValueObject<string, CurrencyCode3>
{
    private readonly static HashSet<string> _currencyCodes = new HashSet<string>()
    {
        "AED", "AFN", "ALL", "AMD", "ANG", "AOA", "ARS", "AUD", "AWG", "AZN",
        "BAM", "BBD", "BDT", "BGN", "BHD", "BIF", "BMD", "BND", "BOB", "BRL",
        "BSD", "BTC", "BTN", "BWP", "BYR", "BYN", "BZD", "CAD", "CDF", "CHF",
        "CLP", "CNY", "COP", "CRC", "CUC", "CUP", "CVE", "CZK", "DJF", "DKK",
        "DOP", "DZD", "EGP", "ERN", "ETB", "EUR", "FJD", "FKP", "GBP", "GEL",
        "GHS", "GIP", "GMD", "GNF", "GTQ", "GYD", "HKD", "HNL", "HRK", "HTG",
        "HUF", "IDR", "ILS", "INR", "IQD", "IRR", "ISK", "JMD", "JOD", "JPY",
        "KES", "KGS", "KHR", "KMF", "KPW", "KRW", "KWD", "KYD", "KZT", "LAK",
        "LBP", "LKR", "LRD", "LSL", "LYD", "MAD", "MDL", "MGA", "MKD", "MMK",
        "MNT", "MOP", "MRO", "MTL", "MUR", "MVR", "MWK", "MXN", "MYR", "MZN",
        "NAD", "NGN", "NIO", "NOK", "NPR", "NZD", "OMR", "PAB", "PEN", "PGK",
        "PHP", "PKR", "PLN", "PYG", "QAR", "RON", "RSD", "RUB", "RWF", "SAR",
        "SBD", "SCR", "SDD", "SDG", "SEK", "SGD", "SHP", "SLL", "SOS", "SRD",
        "STD", "SVC", "SYP", "SZL", "THB", "TJS", "TMT", "TND", "TOP", "TRY",
        "TTD", "TVD", "TWD", "TZS", "UAH", "UGX", "USD", "UYU", "UZS", "VEB",
        "VEF", "VND", "VUV", "WST", "XAF", "XCD", "XBT", "XOF", "XPF", "YER",
        "ZAR", "ZMW", "WON"
    };

    /// <summary>
    /// Creates a new instance of <see cref="CurrencyCode3"/>
    /// </summary>
    /// <param name="value">The string to create the <see cref="CurrencyCode3"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException">If the currencyCode3 is invalid.</exception>
    public new static CurrencyCode3 From(string value)
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