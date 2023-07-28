// Generated

#nullable enable

using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityForTypes : AuditableEntityBase
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Text TextTestField { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Number NumberTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Money? MoneyTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public CountryCode2? CountryCode2TestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public StreetAddress? StreetAddressTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public CurrencyCode3? CurrencyCode3TestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.DayOfWeek? DayOfWeekTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Area? AreaTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public TimeZoneCode? TimeZoneCodeTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public CountryCode3? CountryCode3TestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public HashedText? HashedTextTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public MacAddress? MacAddressTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Month? MonthTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Password? PasswordTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public TranslatedText? TranslatedTextTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public CultureCode? CultureCodeTestField { get; set; } = null!;

    public Email? EmailTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public LanguageCode? LanguageCodeTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public DateTimeDuration? DateTimeDurationTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Json? JsonTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Yaml? YamlTestField { get; set; } = null!;
}