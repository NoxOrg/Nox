namespace Nox.Types;

public enum NoxType
{
    /// <summary>
    /// Client Project custom Nox Type
    /// </summary>
    //Custom = ??,

    // Complex types
    Array = 822289380,
    Collection = 2120066569,
    Object = 377382163,
    VatNumber = 1091856386,


    // Compound Types - requires multiple fields to persist
    [CompoundType] Entity = 129011533,
    [CompoundType] LatLong = 1914398291,
    [CompoundType] Money = 1353467972,
    [CompoundType] StreetAddress = 1648304363,
    [CompoundType] TranslatedText = 1180214618,
    [CompoundType] DateTimeRange = 1690445408,


    // Simple Types
    Area = 1149179623,
    AutoNumber = 2122704081,
    Boolean = 10023546,
    Color = 579891056,
    CountryCode2 = 488795671,
    CountryCode3 = 997346253,
    CountryNumber = 488399599,
    CultureCode = 422582921,
    CurrencyCode = 1014761430,
    CurrencyNumber = 229969242,
    Date = 1684383677,
    Month = 2039256613,
    Year = 1562301476,
    DateTime = 851160925,
    DateTimeDuration = 77156585,
    DateTimeSchedule = 1124278898,
    DayOfWeek = 1656133674,
    Distance = 686590119,
    Email = 1246503516,
    EncryptedText = 305885511,
    File = 1535442266,
    Formula = 454785975,
    Guid = 1103575595,
    HashedText = 1509070170,
    Html = 329697344,
    Image = 1502945944,
    InternetDomain = 326044736,
    IpAddress = 1704429651,
    Json = 1053181407,
    JwtToken = 329979938,
    LanguageCode = 1506896666,
    Length = 1122498742,
    MacAddress = 1742639137,
    Markdown = 597770352,
    Nuid = 1157461177,
    Number = 2076231148,
    Password = 391581010,
    Percentage = 1838963825,
    PhoneNumber = 1508227418,
    Temperature = 403375024,
    Text = 715455632,
    Time = 140559157,
    TimeZoneCode = 1241453418,
    Uri = 146137480,
    Url = 136872054,
    User = 824837395,
    Volume = 418332028,
    Weight = 1387166363,
    Yaml = 1641268066
}