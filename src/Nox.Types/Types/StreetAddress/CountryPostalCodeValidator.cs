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
            ("AC", @"^[Aa][Ss][Cc][Nn]\s{0,1}[1][Zz][Zz]$"),
            ("AD", @"^(?:AD)*(\d{3})$"),
            ("AF", @"^\d{4}$"),
            ("AI", @"^[Aa][I][-][2][6][4][0]$"),
            ("AL", @"^\d{4}$"),
            ("AM", @"^(\d{6})$"),
            ("AR", @"^([A-Z]\d{4}[A-Z]{3})$"),
            ("AS", @"^\d{5}(-{1}\d{4,6})$"),
            ("AT", @"^(\d{4})$"),
            ("AU", @"^(\d{4})$"),
            ("AX", @"^\d{5}$"),
            ("AZ", @"^(?:AZ)*(\d{4})$"),
            ("BA", @"^(\d{5})$"),
            ("BB", @"^(?:BB)*(\d{5})$"),
            ("BD", @"^(\d{4})$"),
            ("BE", @"^(\d{4})$"),
            ("BG", @"^(\d{4})$"),
            ("BH", @"^(\d{3}\d?)$"),
            ("BL", @"^97133$"),
            ("BM", @"^([A-Z]{2}\d{2})$"),
            ("BN", @"^([A-Z]{2}\d{4})$"),
            ("BO", @"^\d{4}$"),
            ("BR", @"^(\d{8})$"),
            ("BT", @"^\d{5}$"),
            ("BY", @"^(\d{6})$"),
            ("CA", @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ]) ?(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$"),
            ("CC", @"^\d{4}$"),
            ("CD", @"^[Cc][Dd]$"),
            ("CH", @"^(\d{4})$"),
            ("CL", @"^(\d{7})$"),
            ("CN", @"^(\d{6})$"),
            ("CO", @"^\d{6}$"),
            ("CR", @"^(\d{4})$"),
            ("CU", @"^(?:CP)*(\d{5})$"),
            ("CV", @"^(\d{4})$"),
            ("CX", @"^(\d{4})$"),
            ("CY", @"^(\d{4})$"),
            ("CZ", @"^(\d{5})$"),
            ("DE", @"^\d{4}$"),
            ("DE", @"^\d{5}$"),
            ("DE", @"^(\d{5})$"),
            ("DK", @"^(\d{4})$"),
            ("DO", @"^(\d{5})$"),
            ("DZ", @"^(\d{5})$"),
            ("EC", @"^([a-zA-Z]\d{4}[a-zA-Z])$"),
            ("EE", @"^(\d{5})$"),
            ("EG", @"^(\d{5})$"),
            ("ES", @"^(\d{5})$"),
            ("ET", @"^(\d{4})$"),
            ("FI", @"^(?:FI)*(\d{5})$"),
            ("FK", @"^[Ff][Ii][Qq]{2}\s{0,1}[1][Zz]{2}$"),
            ("FM", @"^\d{5}$"),
            ("FM", @"^(\d{5})$"),
            ("FO", @"^(?:FO)*(\d{3})$"),
            ("FR", @"^(\d{5})$"),
            ("GA", @"^\d{2}\s[a-zA-Z-_ ]\s\d{2}$"),
            ("GB",
                @"^(([A-Z]\d{2}[A-Z]{2})|([A-Z]\d{3}[A-Z]{2})|([A-Z]{2}\d{2}[A-Z]{2})|([A-Z]{2}\d{3}[A-Z]{2})|([A-Z]\d[A-Z]\d[A-Z]{2})|([A-Z]{2}\d[A-Z]\d[A-Z]{2})|(GIR0AA))$"),
            ("GE", @"^(\d{4})$"),
            ("GF", @"^((97|98)3\d{2})$"),
            ("GG",
                @"^(([A-Z]\d{2}[A-Z]{2})|([A-Z]\d{3}[A-Z]{2})|([A-Z]{2}\d{2}[A-Z]{2})|([A-Z]{2}\d{3}[A-Z]{2})|([A-Z]\d[A-Z]\d[A-Z]{2})|([A-Z]{2}\d[A-Z]\d[A-Z]{2})|(GIR0AA))$"),
            ("GI", @"^[Gg][Xx][1]{2}\s{0,1}[1][Aa]{2}$"),
            ("GL", @"^(\d{4})$"),
            ("GP", @"^((97|98)\d{3})$"),
            ("GR", @"^(\d{5})$"),
            ("GS", @"^[Ss][Ii][Qq]{2}\s{0,1}[1][Zz]{2}$"),
            ("GT", @"^(\d{5})$"),
            ("GU", @"^(969\d{2})$"),
            ("GW", @"^(\d{4})$"),
            ("HM", @"^\d{4}$"),
            ("HN", @"^([A-Z]{2}\d{4})$"),
            ("HR", @"^(?:HR)*(\d{5})$"),
            ("HT", @"^(?:HT)*(\d{4})$"),
            ("HU", @"^(\d{4})$"),
            ("ID", @"^(\d{5})$"),
            ("IL", @"^(\d{5})$"),
            ("IM",
                @"^(([A-Z]\d{2}[A-Z]{2})|([A-Z]\d{3}[A-Z]{2})|([A-Z]{2}\d{2}[A-Z]{2})|([A-Z]{2}\d{3}[A-Z]{2})|([A-Z]\d[A-Z]\d[A-Z]{2})|([A-Z]{2}\d[A-Z]\d[A-Z]{2})|(GIR0AA))$"),
            ("IN", @"^(\d{6})$"),
            ("IO", @"^[Bb]{2}[Nn][Dd]\s{0,1}[1][Zz]{2}$"),
            ("IQ", @"^(\d{5})$"),
            ("IR", @"^(\d{10})$"),
            ("IS", @"^(\d{3})$"),
            ("IT", @"^(\d{5})$"),
            ("JE",
                @"^(([A-Z]\d{2}[A-Z]{2})|([A-Z]\d{3}[A-Z]{2})|([A-Z]{2}\d{2}[A-Z]{2})|([A-Z]{2}\d{3}[A-Z]{2})|([A-Z]\d[A-Z]\d[A-Z]{2})|([A-Z]{2}\d[A-Z]\d[A-Z]{2})|(GIR0AA))$"),
            ("JM", @"^\d{2}$"),
            ("JO", @"^(\d{5})$"),
            ("JP", @"^(\d{7})$"),
            ("KE", @"^(\d{5})$"),
            ("KG", @"^(\d{6})$"),
            ("KH", @"^(\d{5})$"),
            ("KP", @"^(\d{6})$"),
            ("KR", @"^\d{6}\s\(\d{3}-\d{3}\)$"),
            ("KR", @"^(?:SEOUL)*(\d{6})$"),
            ("KW", @"^(\d{5})$"),
            ("KY", @"^[Kk][Yy]\d[-\s]{0,1}\d{4}$"),
            ("KZ", @"^(\d{6})$"),
            ("LA", @"^(\d{5})$"),
            ("LB", @"^(\d{4}(\d{4})?)$"),
            ("LI", @"^(\d{4})$"),
            ("LK", @"^(\d{5})$"),
            ("LR", @"^(\d{4})$"),
            ("LS", @"^(\d{3})$"),
            ("LT", @"^(?:LT)*(\d{5})$"),
            ("LU", @"^(\d{4})$"),
            ("LV", @"^(?:LV)*(\d{4})$"),
            ("LY", @"^\d{5}$"),
            ("MA", @"^(\d{5})$"),
            ("MC", @"^(\d{5})$"),
            ("MD", @"^(?:MD)*(\d{4})$"),
            ("ME", @"^(\d{5})$"),
            ("MF", @"^97150$"),
            ("MG", @"^(\d{3})$"),
            ("MH", @"^\d{5}$"),
            ("MK", @"^(\d{4})$"),
            ("MM", @"^(\d{5})$"),
            ("MN", @"^(\d{6})$"),
            ("MP", @"^\d{5}$"),
            ("MQ", @"^(\d{5})$"),
            ("MS", @"^[Mm][Ss][Rr]\s{0,1}\d{4}$"),
            ("MT", @"^([A-Z]{3}\d{2}\d?)$"),
            ("MV", @"^(\d{5})$"),
            ("MX", @"^(\d{5})$"),
            ("MY", @"^(\d{5})$"),
            ("MZ", @"^(\d{4})$"),
            ("NA", @"^\d{5}$"),
            ("NC", @"^(\d{5})$"),
            ("NE", @"^(\d{4})$"),
            ("NF", @"^\d{4}$"),
            ("NG", @"^(\d{6})$"),
            ("NI", @"^(\d{7})$"),
            ("NL", @"^(\d{4}[A-Z]{2})$"),
            ("NO", @"^(\d{4})$"),
            ("NP", @"^(\d{5})$"),
            ("NZ", @"^(\d{4})$"),
            ("OM", @"^(\d{3})$"),
            ("PA", @"^\d{6}$"),
            ("PE", @"^(\d{5})$"),
            ("PF", @"^((97|98)7\d{2})$"),
            ("PG", @"^(\d{3})$"),
            ("PH", @"^(\d{4})$"),
            ("PK", @"^(\d{5})$"),
            ("PL", @"^(\d{5})$"),
            ("PM", @"^(97500)$"),
            ("PN", @"^[Pp][Cc][Rr][Nn]\s{0,1}[1][Zz]{2}$"),
            ("PR", @"^(\d{9})$"),
            ("PT", @"^\d{4}[- ]{0,1}\d{3}$"),
            ("PT", @"^(\d{7})$"),
            ("PW", @"^(96940)$"),
            ("PY", @"^(\d{4})$"),
            ("RE", @"^((97|98)(4|7|8)\d{2})$"),
            ("RO", @"^(\d{6})$"),
            ("RS", @"^\d{5}$"),
            ("RS", @"^(\d{6})$"),
            ("RU", @"^(\d{6})$"),
            ("SA", @"^(\d{5})$"),
            ("SD", @"^(\d{5})$"),
            ("SE", @"^(?:SE)*(\d{5})$"),
            ("SG", @"^\d{4}$"),
            ("SG", @"^\d{6}$"),
            ("SG", @"^(\d{6})$"),
            ("SH", @"^[Tt][Dd][Cc][Uu]\s{0,1}[1][Zz]{2}$"),
            ("SH", @"^(STHL1ZZ)$"),
            ("SI", @"^(?:SI)*(\d{4})$"),
            ("SJ", @"^\d{4}$"),
            ("SK", @"^(\d{5})$"),
            ("SM", @"^(4789\d)$"),
            ("SN", @"^(\d{5})$"),
            ("SO", @"^([A-Z]{2}\d{5})$"),
            ("SV", @"^(?:CP)*(\d{4})$"),
            ("SZ", @"^([A-Z]\d{3})$"),
            ("TC", @"^(TKCA 1ZZ)$"),
            ("TD", @"^\d{5}$"),
            ("TH", @"^(\d{5})$"),
            ("TJ", @"^(\d{6})$"),
            ("TM", @"^(\d{6})$"),
            ("TN", @"^(\d{4})$"),
            ("TR", @"^(\d{5})$"),
            ("TT", @"^\d{6}$"),
            ("TW", @"^(\d{5})$"),
            ("UA", @"^(\d{5})$"),
            ("US", @"^\d{5}(-\d{4})?$"),
            ("UY", @"^(\d{5})$"),
            ("UZ", @"^(\d{6})$"),
            ("VA", @"^120$"),
            ("VC", @"^[Vv][Cc]\d{4}$"),
            ("VE", @"^(\d{4})$"),
            ("VG", @"^[Vv][Gg]\d{4}$"),
            ("VI", @"^\d{5}$"),
            ("VN", @"^(\d{6})$"),
            ("WF", @"^(986\d{2})$"),
            ("XK", @"^\d{5}$"),
            ("YT", @"^(\d{5})$"),
            ("ZA", @"^(\d{4})$"),
            ("ZM", @"^(\d{5})$"),
        });
}