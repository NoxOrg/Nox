using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Validates Postal Code against country postal code formats.
/// </summary>
public static class CountryPostalCodeValidator
{
    private const int PostCodeMaxLength = 15;

    /// <summary>
    /// Checks whether given Postal Code matches  country postal code pattern.
    /// </summary>
    /// <param name="countryCode">Input Country Code.</param>
    /// <param name="postalCode">Input Postal Code.</param>
    /// <returns>True if postal code matches pattern.</returns>
    public static bool IsValid(string countryCode, string? postalCode)
    {
        if (string.IsNullOrEmpty(postalCode))
        {
            return true;
        }
        if (postalCode.Length > PostCodeMaxLength)
        {
            return false;
        }

        var patterns = PostalCodesMapping
            .Where(x => x.CountryCode == countryCode)
            .Select(x => x.Pattern)
            .ToList();

        var isValid = true;

        foreach (var pattern in patterns)
        {
            var isMath = Regex.IsMatch(postalCode, pattern, RegexOptions.None,
                ValueObject.Regex_Default_Timeout_Miliseconds);

            if (!isMath)
            {
                isValid = false;
                break;
            }
        }

        return isValid;
    }

    /// <summary>
    /// Map between Country and regex for postal codes
    /// </summary>
    private static readonly ImmutableList<(string CountryCode, string Pattern)> PostalCodesMapping =
        ImmutableList.CreateRange(new[]
        {
            ("AD", @"^(?:AD)*(\d{3})$"),
            ("AR", @"^([A-Z]\d{4}[A-Z]{3})$"),
            ("AM", @"^(\d{6})$"),
            ("AU", @"^(\d{4})$"),
            ("AT", @"^(\d{4})$"),
            ("AZ", @"^(?:AZ)*(\d{4})$"),
            ("BE", @"^(\d{4})$"),
            ("BD", @"^(\d{4})$"),
            ("BG", @"^(\d{4})$"),
            ("BH", @"^(\d{3}\d?)$"),
            ("BA", @"^(\d{5})$"),
            ("SH", @"^(STHL1ZZ)$"),
            ("BY", @"^(\d{6})$"),
            ("BM", @"^([A-Z]{2}\d{2})$"),
            ("BR", @"^(\d{8})$"),
            ("BB", @"^(?:BB)*(\d{5})$"),
            ("BN", @"^([A-Z]{2}\d{4})$"),
            ("CA", @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ]) ?(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$"),
            ("CH", @"^(\d{4})$"),
            ("CL", @"^(\d{7})$"),
            ("CN", @"^(\d{6})$"),
            ("CV", @"^(\d{4})$"),
            ("CR", @"^(\d{4})$"),
            ("CU", @"^(?:CP)*(\d{5})$"),
            ("CX", @"^(\d{4})$"),
            ("CY", @"^(\d{4})$"),
            ("CZ", @"^(\d{5})$"),
            ("DE", @"^(\d{5})$"),
            ("DK", @"^(\d{4})$"),
            ("DO", @"^(\d{5})$"),
            ("DZ", @"^(\d{5})$"),
            ("EC", @"^([a-zA-Z]\d{4}[a-zA-Z])$"),
            ("EG", @"^(\d{5})$"),
            ("ES", @"^(\d{5})$"),
            ("EE", @"^(\d{5})$"),
            ("ET", @"^(\d{4})$"),
            ("FI", @"^(?:FI)*(\d{5})$"),
            ("FR", @"^(\d{5})$"),
            ("FO", @"^(?:FO)*(\d{3})$"),
            ("FM", @"^(\d{5})$"),
            ("GB",
                @"^(([A-Z]\d{2}[A-Z]{2})|([A-Z]\d{3}[A-Z]{2})|([A-Z]{2}\d{2}[A-Z]{2})|([A-Z]{2}\d{3}[A-Z]{2})|([A-Z]\d[A-Z]\d[A-Z]{2})|([A-Z]{2}\d[A-Z]\d[A-Z]{2})|(GIR0AA))$"),
            ("GE", @"^(\d{4})$"),
            ("GG",
                @"^(([A-Z]\d{2}[A-Z]{2})|([A-Z]\d{3}[A-Z]{2})|([A-Z]{2}\d{2}[A-Z]{2})|([A-Z]{2}\d{3}[A-Z]{2})|([A-Z]\d[A-Z]\d[A-Z]{2})|([A-Z]{2}\d[A-Z]\d[A-Z]{2})|(GIR0AA))$"),
            ("GP", @"^((97|98)\d{3})$"),
            ("GW", @"^(\d{4})$"),
            ("GR", @"^(\d{5})$"),
            ("GL", @"^(\d{4})$"),
            ("GT", @"^(\d{5})$"),
            ("GF", @"^((97|98)3\d{2})$"),
            ("GU", @"^(969\d{2})$"),
            ("HN", @"^([A-Z]{2}\d{4})$"),
            ("HR", @"^(?:HR)*(\d{5})$"),
            ("HT", @"^(?:HT)*(\d{4})$"),
            ("HU", @"^(\d{4})$"),
            ("ID", @"^(\d{5})$"),
            ("IM",
                @"^(([A-Z]\d{2}[A-Z]{2})|([A-Z]\d{3}[A-Z]{2})|([A-Z]{2}\d{2}[A-Z]{2})|([A-Z]{2}\d{3}[A-Z]{2})|([A-Z]\d[A-Z]\d[A-Z]{2})|([A-Z]{2}\d[A-Z]\d[A-Z]{2})|(GIR0AA))$"),
            ("IN", @"^(\d{6})$"),
            ("IR", @"^(\d{10})$"),
            ("IQ", @"^(\d{5})$"),
            ("IS", @"^(\d{3})$"),
            ("IL", @"^(\d{5})$"),
            ("IT", @"^(\d{5})$"),
            ("JE",
                @"^(([A-Z]\d{2}[A-Z]{2})|([A-Z]\d{3}[A-Z]{2})|([A-Z]{2}\d{2}[A-Z]{2})|([A-Z]{2}\d{3}[A-Z]{2})|([A-Z]\d[A-Z]\d[A-Z]{2})|([A-Z]{2}\d[A-Z]\d[A-Z]{2})|(GIR0AA))$"),
            ("JO", @"^(\d{5})$"),
            ("JP", @"^(\d{7})$"),
            ("KZ", @"^(\d{6})$"),
            ("KE", @"^(\d{5})$"),
            ("KG", @"^(\d{6})$"),
            ("KH", @"^(\d{5})$"),
            ("KR", @"^(?:SEOUL)*(\d{6})$"),
            ("KW", @"^(\d{5})$"),
            ("LA", @"^(\d{5})$"),
            ("LB", @"^(\d{4}(\d{4})?)$"),
            ("LR", @"^(\d{4})$"),
            ("LI", @"^(\d{4})$"),
            ("LK", @"^(\d{5})$"),
            ("LS", @"^(\d{3})$"),
            ("LT", @"^(?:LT)*(\d{5})$"),
            ("LU", @"^(\d{4})$"),
            ("LV", @"^(?:LV)*(\d{4})$"),
            ("MA", @"^(\d{5})$"),
            ("MC", @"^(\d{5})$"),
            ("MD", @"^(?:MD)*(\d{4})$"),
            ("MG", @"^(\d{3})$"),
            ("MV", @"^(\d{5})$"),
            ("MX", @"^(\d{5})$"),
            ("MK", @"^(\d{4})$"),
            ("MT", @"^([A-Z]{3}\d{2}\d?)$"),
            ("MM", @"^(\d{5})$"),
            ("ME", @"^(\d{5})$"),
            ("MN", @"^(\d{6})$"),
            ("MZ", @"^(\d{4})$"),
            ("MQ", @"^(\d{5})$"),
            ("MY", @"^(\d{5})$"),
            ("YT", @"^(\d{5})$"),
            ("NC", @"^(\d{5})$"),
            ("NE", @"^(\d{4})$"),
            ("NG", @"^(\d{6})$"),
            ("NI", @"^(\d{7})$"),
            ("NL", @"^(\d{4}[A-Z]{2})$"),
            ("NO", @"^(\d{4})$"),
            ("NP", @"^(\d{5})$"),
            ("NZ", @"^(\d{4})$"),
            ("OM", @"^(\d{3})$"),
            ("PK", @"^(\d{5})$"),
            ("PE", @"^(\d{5})$"),
            ("PH", @"^(\d{4})$"),
            ("PW", @"^(96940)$"),
            ("PG", @"^(\d{3})$"),
            ("PL", @"^(\d{5})$"),
            ("PR", @"^(\d{9})$"),
            ("KP", @"^(\d{6})$"),
            ("PT", @"^(\d{7})$"),
            ("PY", @"^(\d{4})$"),
            ("PF", @"^((97|98)7\d{2})$"),
            ("RE", @"^((97|98)(4|7|8)\d{2})$"),
            ("RO", @"^(\d{6})$"),
            ("RU", @"^(\d{6})$"),
            ("SA", @"^(\d{5})$"),
            ("SD", @"^(\d{5})$"),
            ("SN", @"^(\d{5})$"),
            ("SG", @"^(\d{6})$"),
            ("SV", @"^(?:CP)*(\d{4})$"),
            ("SM", @"^(4789\d)$"),
            ("SO", @"^([A-Z]{2}\d{5})$"),
            ("PM", @"^(97500)$"),
            ("RS", @"^(\d{6})$"),
            ("SK", @"^(\d{5})$"),
            ("SI", @"^(?:SI)*(\d{4})$"),
            ("SE", @"^(?:SE)*(\d{5})$"),
            ("SZ", @"^([A-Z]\d{3})$"),
            ("TC", @"^(TKCA 1ZZ)$"),
            ("TH", @"^(\d{5})$"),
            ("TJ", @"^(\d{6})$"),
            ("TM", @"^(\d{6})$"),
            ("TN", @"^(\d{4})$"),
            ("TR", @"^(\d{5})$"),
            ("TW", @"^(\d{5})$"),
            ("UA", @"^(\d{5})$"),
            ("UY", @"^(\d{5})$"),
            ("US", @"^\d{5}(-\d{4})?$"),
            ("UZ", @"^(\d{6})$"),
            ("VE", @"^(\d{4})$"),
            ("VN", @"^(\d{6})$"),
            ("WF", @"^(986\d{2})$"),
            ("ZA", @"^(\d{4})$"),
            ("ZM", @"^(\d{5})$"),
        });
}