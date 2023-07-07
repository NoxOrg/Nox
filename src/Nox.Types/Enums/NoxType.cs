namespace Nox.Types;

public enum NoxType
{
    /// <summary>
    /// Client Project custom Nox Type
    /// </summary>
    //Custom = 1,

    // Complex types
    @Array = 2,
    @Collection = 3,
    @Object = 4,
    

    // Compound Types - requires multiple fields to persist
    [CompoundType] Entity = 4,
    [CompoundType] LatLong = 5,
    [CompoundType] Money = 6,
    [CompoundType] StreetAddress = 7,
    [CompoundType] TranslatedText = 8,
    [CompoundType] DateTimeRange = 9,
    [CompoundType]  VatNumber = 10,

    // Simple Types
    Area = 11,
    AutoNumber = 12,
    Boolean = 13,
    Color = 14,
    Colour = 15,
    CountryCode2 = 16,
    CountryCode3 = 17,
    CountryNumber = 18,
    CultureCode = 19,
    CurrencyCode = 20,
    CurrencyNumber = 21,
    Date = 22,
    Month = 23,
    Year = 24,
    DateTime = 25,
    DateTimeDuration = 26,
    DateTimeSchedule = 27,
    DayOfTheWeek = 60,
    Distance = 28,
    Email = 29,
    EncryptedText = 30,
    File = 31,
    Formula = 32,
    Guid = 33,
    HashedText = 34,
    Html = 35,
    Image = 36,
    InternetDomain = 37,
    IpAddress = 38,
    Json = 39,
    JwtToken = 40,
    LanguageCode = 41,
    Length = 42,
    MacAddress = 43,
    Markdown = 44,
    Nuid = 45,
    Number = 46,
    Password = 47,
    Percentage = 48,
    PhoneNumber = 49,
    Temperature = 50,
    Text = 51,
    Time = 52,
    TimeZoneCode = 53,
    Uri = 54,
    Url = 55,
    User = 56,
    Volume = 57,
    Weight = 58,
    Yaml = 59
}