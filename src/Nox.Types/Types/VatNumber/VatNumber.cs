using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="VatNumber"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class VatNumber : ValueObject<(string Number, CountryCode CountryCode), VatNumber>, IVatNumber
{

    #region VatNumber Regex

    private static readonly IDictionary<string, string> _vatNumberRegex = new Dictionary<string, string>()
    {
        { "AT", "^U[0-9]{8}$" },                                 // Austria
        { "BE", "^0[0-9]{9}$" },                                 // Belgium
        { "BG", "^[0-9]{9,10}$" },                               // Bulgaria
        { "CY", "^[0-9]{8}L$" },                                 // Cyprus
        { "CZ", "^[0-9]{8,10}$" },                               // Czech Republic
        { "DE", "^[0-9]{9}$" },                                  // Germany
        { "DK", "^[0-9]{8}$" },                                  // Denmark
        { "EE", "^[0-9]{9}$" },                                  // Estonia
        { "EL", "^[0-9]{9}$" },                                  // Greece
        { "GR", "^[0-9]{9}$" },                                  // Greece
        { "ES", "^[0-9A-Z][0-9]{7}[0-9A-Z]$" },                  // Spain
        { "FI", "^[0-9]{8}$" },                                  // Finland
        { "FR", "^[0-9A-Z]{2}[0-9]{9}$" },                       // France
        { "GB", "^([0-9]{9}([0-9]{3})?|[A-Z]{2}[0-9]{3})$" },    // United Kingdom
        { "HU", "^[0-9]{8}$" },                                  // Hungary
        { "IE", "^[0-9]S[0-9]{5}L$" },                           // Ireland
        { "IT", "^[0-9]{11}$" },                                 // Italy
        { "LT", "^([0-9]{9}|[0-9]{12})$" },                      // Lithuania
        { "LU", "^[0-9]{8}$" },                                  // Luxembourg
        { "LV", "^[0-9]{11}$" },                                 // Latvia
        { "MT", "^[0-9]{8}$" },                                  // Malta
        { "NL", "^[0-9]{9}B[0-9]{2}$" },                         // Netherlands
        { "PL", "^[0-9]{10}$" },                                 // Poland
        { "PT", "^[0-9]{9}$" },                                  // Portugal
        { "RO", "^[0-9]{2,10}$" },                               // Romania
        { "SE", "^[0-9]{12}$" },                                 // Sweden
        { "SI", "^[0-9]{8}$" },                                  // Slovenia
        { "SK", "^[0-9]{10}$" },                                 // Slovakia
    };

    #endregion

    private VatNumberTypeOptions _typeOptions = new();

    public string Number
    {
        get => Value.Number;
        private set => Value = (value, Value.CountryCode);
    }

    public CountryCode CountryCode
    {
        get => Value.CountryCode;
        private set => Value = (Value.Number, value);
    }

    public static VatNumber From(IVatNumber value)
        => From(value.Number, value.CountryCode);

    public static VatNumber From(IVatNumber value, VatNumberTypeOptions options)
        => From(value.Number, options);

    /// <summary>
    /// Creates a new instance of the <see cref="VatNumber"/> class with the specified values.
    /// </summary>
    /// <param name="value">The VAT number value.</param>
    /// <param name="countryCode">The two-letter country codes (ISO alpha-2).</param>
    /// <returns>A new instance of the <see cref="VatNumber"/> class.</returns>
    public static VatNumber From(string value, CountryCode countryCode) => 
        From((value, countryCode));

    public static VatNumber From(string value, VatNumberTypeOptions typeOptions) =>
        From(value, typeOptions.CountryCode);

    public static VatNumber From(string value, string countryCode)
    {
        if (!Enum.TryParse(countryCode, out CountryCode code))
        {
            var result = new ValidationResult();

            result.Errors.Add(new ValidationFailure(nameof(countryCode), $"Invalid alpha-2 country code specified ('{countryCode}')."));

            throw new TypeValidationException(result.Errors);
        }
        return From(value, code);
    }

    /// <summary>
    /// Validates a <see cref="VatNumber"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="VatNumber"/> value is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!_vatNumberRegex.ContainsKey(Value.CountryCode.ToString()))
        {
            result.Errors.Add(new ValidationFailure(
                nameof(Value), 
                $"Could not create a Nox VatNumber type with unsupported CountryCode '{Value.CountryCode}'."
                ));
            return result;
        }

        var regex = _vatNumberRegex[Value.CountryCode.ToString()];
        if (!Regex.IsMatch(Value.Number, regex, RegexOptions.IgnoreCase))
        {
            result.Errors.Add(new ValidationFailure(
                nameof(Value), 
                $"Could not create a Nox VatNumber type with unsupported value '{Value.CountryCode}{Value.Number}'."
                ));
        }

        return result;
    }

    /// <summary>
    /// Returns a string representation of the <see cref="VatNumber"/> object.
    /// </summary>
    /// <returns>A string representation of the <see cref="VatNumber"/> object.</returns>
    public override string ToString()
        => $"{Value.CountryCode}{Value.Number}";

}
