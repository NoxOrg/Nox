using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="VatNumber"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class VatNumber : ValueObject<(string Number, CountryCode CountryCode), VatNumber>, IVatNumber
{

    #region VatNumber Regex

    private static readonly IDictionary<CountryCode, string[]> _vatNumberRegex = new Dictionary<CountryCode, string[]>()
    {
        { CountryCode.UA, new string[] { @"^UA\d{8,12}$" } },                                                                                               // Ukraine
        { CountryCode.ZA, new string[] { @"^ZA4\d{9}$" } },                                                                                                 // South Africa
        { CountryCode.PT, new string[] { @"^PT\d{9}$" } },                                                                                                  // Portugal
        { CountryCode.PL, new string[] { @"^PL\d{10}$" } },                                                                                                 // Poland
        { CountryCode.IT, new string[] { @"^IT\d{11}$" } },                                                                                                 // Italy
        { CountryCode.NL, new string[] { @"^NL\d{9}B\d{2}$" } },                                                                                            // Netherlands
        { CountryCode.MX, new string[] { @"^MX[A-Z&�]{3}[0-9]{6}[1-9A-V][1-9A-Z][0-9A]$" } },                                                               // Mexico
        { CountryCode.DE, new string[] { @"^DE[1-9]\d{8}$" } },                                                                                             // Germany
        { CountryCode.FR, new string[] { @"^FR\d{11}$" } },                                                                                                 // France
        { CountryCode.IN, new string[] { @"^IN\d{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[0-9A-Z]{3}$" } },                                                               // India
        { CountryCode.CO, new string[] { @"^CO[CJ]{0,1}[0-9]{9,10}[CJ]{0,1}$" } },                                                                          // Colombia
        { CountryCode.AU, new string[] { @"^AU([a-zA-Z]{2})?\d{11}$" } },                                                                                   // Australia
        { CountryCode.BE, new string[] { @"^BE0?\d{9}$" } },                                                                                                // Belgium
        { CountryCode.BR, new string[] { @"^BR\d{14}$" } },                                                                                                 // Brazil
        { CountryCode.CA, new string[] { @"^CA\d{9}$" } },                                                                                                  // Canada
        { CountryCode.CH, new string[] { @"^(CH(E-)?)?E?[0-9]{9}(MWST|IVA|TVA)?$" } },                                                                      // Switzerland
        { CountryCode.GB, new string[] { @"^GBGA[5-9]\d{2}$", @"^GBHA[0-4]\d{2}$", @"^GB\d{9}$" } },                                                        // United Kingdom
        { CountryCode.ES, new string[] { @"^ES[K|L|M|X]\d{7}[A-Z]$", @"^ES[0-9|Y|Z]\d{7}[A-Z]$", @"^ES[A-H|J|U|V]\d{8}$", @"^ES[A-H|N-S|W]\d{7}[A-J]$" } }, // Spain
        { CountryCode.DK, new string[] { @"^DK[1-9]\d{7}$" } },                                                                                             // Denmark
        { CountryCode.AT, new string[] { @"^ATU\d{8}$" } },                                                                                                 // Austria
        { CountryCode.JP, new string[] { @"^JP\d{12}$" } },                                                                                                 // Japan
        { CountryCode.CN, new string[] { @"^CN[159Y]{1}[1239]{1}[0-9]{6}[^_IOZSVa-z\W]{10}$" } },                                                           // China
        { CountryCode.TR, new string[] { @"^TR\d{10}$" } },                                                                                                 // Turkey
        { CountryCode.SE, new string[] { @"^SE\d{10}$" } },                                                                                                 // Sweden
        { CountryCode.IL, new string[] { @"^IL\d{9}$" } },                                                                                                  // Israel
        { CountryCode.TH, new string[] { @"^TH\d{13}$" } },                                                                                                 // Thailand
        { CountryCode.AE, new string[] { @"^AE\d{15}$" } },                                                                                                 // United Arab Emirates
        { CountryCode.MY, new string[] { @"^MY(CS|D|E|F|FA|PT|TA|TC|TN|TR|TP|TJ|LE)?\d{10}$" } },                                                           // Malaysia
        { CountryCode.FI, new string[] { @"^FI\d{8}$" } },                                                                                                  // Finland
        { CountryCode.SG, new string[] { @"^SG\d{9}M$" } },                                                                                                 // Singapore
        { CountryCode.NO, new string[] { @"^NO\d{9}$" } },                                                                                                  // Norway
        { CountryCode.RU, new string[] { @"^RU(\d{10}|\d{12})$" } },                                                                                        // Russia
        { CountryCode.NZ, new string[] { @"^NZ\d{8}$" } },                                                                                                  // New Zealand
        { CountryCode.SA, new string[] { @"^SA3\d{14}$" } },                                                                                                // Saudi Arabia
        { CountryCode.PH, new string[] { @"^PH\d{12}V?$" } },                                                                                               // Philippines
        { CountryCode.ID, new string[] { @"^ID\d{15}$" } },                                                                                                 // Indonesia
        { CountryCode.HK, new string[] { @"^HK[a-zA-Z]\d{6}[a-zA-Z]$" } },                                                                                  // Hong Kong
        { CountryCode.HU, new string[] { @"^HU\d{8}$" } },                                                                                                  // Hungary
        { CountryCode.RO, new string[] { @"^RO\d{2,10}$"} },                                                                                                // Romania
        { CountryCode.SK, new string[] { @"^SK\d{10}$"} },                                                                                                  // Slovakia
        { CountryCode.BG, new string[] { @"^BG\d{9,10}$"} },                                                                                                // Bulgaria
        { CountryCode.GR, new string[] { @"^EL\d{9}$"} },                                                                                                   // Greece
        { CountryCode.SI, new string[] { @"^SI\d{8}$"} },                                                                                                   // Slovenia
        { CountryCode.LT, new string[] { @"^LT(\d{9}|\d{12})$"} },                                                                                          // Lithuania
        { CountryCode.EE, new string[] { @"^EE\d{9}$"} },                                                                                                   // Estonia
        { CountryCode.IE, new string[] { @"^IE\d{7}[A-Z]{1,2}$", @"^IE\d[A-Z]\d{5}[A-Z$" } },                                                               // Ireland
        { CountryCode.CZ, new string[] { @"^CZ\d{8,10}$"} },                                                                                                // Czech Republic
        { CountryCode.CY, new string[] { @"^CY\d{8}[A-Z]$"} },                                                                                              // Cyprus
        { CountryCode.MT, new string[] { @"^MT\d{8}$"} },                                                                                                   // Malta
        { CountryCode.LU, new string[] { @"^LU\d{8}$"} },                                                                                                   // Luxembourg
        { CountryCode.LV, new string[] { @"^LV\d{11}$"} },                                                                                                  // Latvia
    };

    #endregion

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

            throw new NoxTypeValidationException(result.Errors);
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

        if (!_vatNumberRegex.ContainsKey(Value.CountryCode))
        {
            result.Errors.Add(new ValidationFailure(
                nameof(Value),
                $"Could not create a Nox VatNumber type with unsupported CountryCode '{Value.CountryCode}'."
                ));
            return result;
        }

        var regexes = _vatNumberRegex[Value.CountryCode];
        if (!Array.Exists(regexes, regex => Regex.IsMatch(Value.Number, regex, RegexOptions.IgnoreCase, Regex_Default_Timeout_Miliseconds)))
        {
            result.Errors.Add(new ValidationFailure(
                nameof(Value),
                $"Could not create a Nox VatNumber type with unsupported value '{Value.Number}' for CountryCode '{Value.CountryCode}'."
                ));
        }

        return result;
    }

    /// <summary>
    /// Returns a string representation of the <see cref="VatNumber"/> object.
    /// </summary>
    /// <returns>A string representation of the <see cref="VatNumber"/> object.</returns>
    public override string ToString()
        => Value.Number;

}
