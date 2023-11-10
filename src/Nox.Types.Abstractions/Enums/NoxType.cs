using System;

namespace Nox.Types;

public enum NoxType : uint
{
    // Complex types
    Array = 1325194268,
    Collection = 27417079,
    Object = 2524865811,

    // Compound Types - requires multiple fields to persist

    [CompoundType]
    [CompoundComponent("Start", typeof(DateTimeOffset))]
    [CompoundComponent("End", typeof(DateTimeOffset))]
    DateTimeRange = 3837929056,

    [CompoundType]
    // Entity depends on the concrete instance and if it supports multiple keys or not!
    [CompoundComponent("Type", typeof(string))]
    [CompoundComponent("Id", typeof(uint))]
    EntityId = 2768006308,

    [CompoundType]
    [CompoundComponent("Url", typeof(string))]
    [CompoundComponent("PrettyName", typeof(string))]
    [CompoundComponent("SizeInBytes", typeof(ulong))]
    File = 612041382,

    [CompoundType(Read = false, Update = false)]
    [CompoundComponent("HashText", typeof(string))]
    [CompoundComponent("Salt", typeof(string))]
    HashedText = 3656553818,

    [CompoundType]
    [CompoundComponent("Url", typeof(string))]
    [CompoundComponent("PrettyName", typeof(string))]
    [CompoundComponent("SizeInBytes", typeof(int))]
    Image = 3650429592,

    [CompoundType]
    [CompoundComponent("Latitude",typeof(double))]
    [CompoundComponent("Longitude",typeof(double))]
    LatLong = 4061881939,

    [CompoundType]
    [CompoundComponent("Amount", typeof(decimal))]
    [CompoundComponent("CurrencyCode", typeof(CurrencyCode))]
    Money = 3500951620,

    [CompoundType(Read = false, Update = false)]
    [CompoundComponent("HashedPassword", typeof(string))]
    [CompoundComponent("Salt", typeof(string))]
    Password = 1755902638,

    [CompoundType]
    [CompoundComponent("StreetNumber",typeof(string), false)]
    [CompoundComponent("AddressLine1", typeof(string))]
    [CompoundComponent("AddressLine2", typeof(string), false)]
    [CompoundComponent("Route", typeof(string), false)]
    [CompoundComponent("Locality", typeof(string), false)]
    [CompoundComponent("Neighborhood", typeof(string), false)]
    [CompoundComponent("AdministrativeArea1", typeof(string), false)]
    [CompoundComponent("AdministrativeArea2", typeof(string), false)]
    [CompoundComponent("PostalCode", typeof(string))]
    [CompoundComponent("CountryId", typeof(CountryCode))]
    StreetAddress = 499179285,

    [CompoundType]
    [CompoundComponent("CultureCode", typeof(string))]
    [CompoundComponent("Phrase", typeof(string))]
    TranslatedText = 967269030,

    [CompoundType]
    [CompoundComponent("Number", typeof(string))]
    [CompoundComponent("CountryCode", typeof(CountryCode))]
    VatNumber = 1055627262,

    // Simple Types

    [SimpleType(typeof(decimal))]
    Area = 998304025,

    [SimpleType(typeof(bool))]
    Boolean = 2157507194,

    [SimpleType(typeof(string))]
    Color = 1567592592,

    [SimpleType(typeof(string))]
    CountryCode2 = 1658687977,

    [SimpleType(typeof(string))]
    CountryCode3 = 1150137395,

    [SimpleType(typeof(ushort))]
    CountryNumber = 2635883247,

    [SimpleType(typeof(string))]
    CultureCode = 1724900727,

    [SimpleType(typeof(string))]
    CurrencyCode3 = 2794068101,

    [SimpleType(typeof(short))]
    CurrencyNumber = 2377452890,

    [SimpleType(typeof(long), Update = false)]
    AutoNumber = 24779567,

    [SimpleType(typeof(DateTime))]
    Date = 463099971,

    [SimpleType(typeof(DateTimeOffset))]
    DateTime = 2998644573,

    [SimpleType(typeof(long))]
    DateTimeDuration = 2070327063,

    // Propose to store DateTimeSchedule as iCal
    // - https://www.rfc-editor.org/rfc/rfc5545
    // - https://github.com/rianjs/ical.net

    [SimpleType(typeof(string))]
    DateTimeSchedule = 3271762546,

    [SimpleType(typeof(ushort))]
    DayOfWeek = 491349974,

    [SimpleType(typeof(decimal))]
    Distance = 1460893529,

    [SimpleType(typeof(string))]
    Email = 3393987164,

    [SimpleType(typeof(byte[]), Read = false, Update = false)]
    EncryptedText = 1841598137,

    [SimpleType(typeof(int))]
    Enumeration = 3545666060,

    [SimpleType(typeof(string), Update = false)]
    Formula = 2602269623,

    [SimpleType(typeof(Guid))]
    Guid = 1043908053,

    [SimpleType(typeof(string))]
    Html = 2477180992,

    [SimpleType(typeof(string))]
    InternetDomain = 1821438912,

    [SimpleType(typeof(string))]
    IpAddress = 443053997,

    [SimpleType(typeof(string))]
    Json = 3200665055,

    [SimpleType(typeof(string))]
    JwtToken = 2477463586,

    [SimpleType(typeof(string))]
    LanguageCode = 3654380314,

    [SimpleType(typeof(decimal))]
    Length = 1024984906,

    [SimpleType(typeof(string))]
    MacAddress = 404844511,

    [SimpleType(typeof(string))]
    Markdown = 2745254000,

    [SimpleType(typeof(byte))]
    Month = 4186740261,

    [SimpleType(typeof(uint))]
    Nuid = 3304944825,

    [SimpleType(typeof(NumberTypeComponentsDiscover))]
    Number = 4223714796,

    [SimpleType(typeof(float))]
    Percentage = 3986447473,

    [SimpleType(typeof(string))]
    PhoneNumber = 3655711066,

    [SimpleType(typeof(decimal))]
    Temperature = 1744108624,

    [SimpleType(typeof(string))]
    Text = 1432028016,

    [SimpleType(typeof(DateTime))]
    Time = 2288042805,

    [SimpleType(typeof(string))]
    TimeZoneCode = 906030230,

    [SimpleType(typeof(string))]
    Uri = 2293621128,

    [SimpleType(typeof(string))]
    Url = 2010611594,

    [SimpleType(typeof(string))]
    User = 2972321043,

    [SimpleType(typeof(decimal))]
    Volume = 1729151620,

    [SimpleType(typeof(decimal))]
    Weight = 760317285,

    [SimpleType(typeof(string))]
    Yaml = 3788751714,

    [SimpleType(typeof(ushort))]
    Year = 3709785124,
}