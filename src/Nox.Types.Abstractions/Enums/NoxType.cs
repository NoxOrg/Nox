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
    // Entity depends on the concrete instance and if it supports multiple keys or not!
    [CompoundComponent("Type", typeof(string))]
    [CompoundComponent("Id", typeof(uint))]
    Entity = 2276495181,

    [CompoundType]
    [CompoundComponent("Latitude",typeof(double))]
    [CompoundComponent("Longitude",typeof(double))]
    LatLong = 4061881939,
    
    [CompoundType]
    [CompoundComponent("Amount", typeof(decimal))]
    [CompoundComponent("CurrencyCode", typeof(CurrencyCode))]
    Money = 3500951620,

    [CompoundType]
    [CompoundComponent("StreetNumber",typeof(int))]
    [CompoundComponent("AddressLine1", typeof(string))]
    [CompoundComponent("AddressLine2", typeof(string))]    
    [CompoundComponent("Route", typeof(string))]
    [CompoundComponent("Locality", typeof(string))]
    [CompoundComponent("Neighborhood", typeof(string))]
    [CompoundComponent("AdministrativeArea1", typeof(string))]
    [CompoundComponent("AdministrativeArea2", typeof(string))]
    [CompoundComponent("PostalCode", typeof(string))]
    [CompoundComponent("CountryId", typeof(string))]
    StreetAddress = 499179285,
    
    [CompoundType] 
    [CompoundComponent("CultureCode", typeof(string))]
    [CompoundComponent("Phrase", typeof(string))]
    TranslatedText = 967269030,
    
    [CompoundType] 
    [CompoundComponent("From", typeof(DateTimeOffset))]
    [CompoundComponent("To", typeof(DateTimeOffset))]
    DateTimeRange = 3837929056,

    [CompoundType]
    [CompoundComponent("Number", typeof(string))]
    [CompoundComponent("CountryCode2", typeof(string))]
    VatNumber = 1055627262,

    [CompoundType]
    [CompoundComponent("Url", typeof(string))]
    [CompoundComponent("PrettyName", typeof(string))]
    [CompoundComponent("SizeInBytes", typeof(ulong))]
    File = 612041382,

    // Simple Types

    [SimpleType(typeof(decimal))]
    Area = 998304025,

    [SimpleType(typeof(long))] 
    DatabaseNumber = 963275927,
    
    [SimpleType(typeof(bool))]
    Boolean = 2157507194,
    
    [SimpleType(typeof(string))]
    Color = 1567592592,

    [SimpleType(typeof(string))]
    CountryCode2 = 1658687977,

    [SimpleType(typeof(string))]
    CountryCode3 = 1150137395,

    [SimpleType(typeof(short))]
    CountryNumber = 2635883247,
    
    [SimpleType(typeof(string))]
    CultureCode = 1724900727,

    [SimpleType(typeof(string))]
    CurrencyCode3 = 2794068101,
    
    [SimpleType(typeof(short))]
    CurrencyNumber = 2377452890,

    [SimpleType(typeof(DateTime))]
    Date = 463099971,

    [SimpleType(typeof(byte))]
    Month = 4186740261,

    [SimpleType(typeof(short))]
    Year = 3709785124,
    
    [SimpleType(typeof(DateTimeOffset))]
    DateTime = 2998644573,

    [SimpleType(typeof(TimeSpan))]
    DateTimeDuration = 2070327063,

    // Propose to store DateTimeSchedule as iCal
    // - https://www.rfc-editor.org/rfc/rfc5545
    // - https://github.com/rianjs/ical.net

    [SimpleType(typeof(string))]
    DateTimeSchedule = 3271762546,

    [SimpleType(typeof(byte))]
    DayOfWeek = 491349974,
    
    [SimpleType(typeof(double))] 
    Distance = 1460893529,

    [SimpleType(typeof(string))]
    Email = 3393987164,
    
    [SimpleType(typeof(string), Read = false, Update = false)]
    EncryptedText = 1841598137,
    
    [SimpleType(typeof(string))]
    Formula = 2602269623,
    
    [SimpleType(typeof(Guid))]
    Guid = 1043908053,

    [CompoundType(Read = false, Update = false)]
    [CompoundComponent("HashText", typeof(string))]
    [CompoundComponent("Salt", typeof(string))]
    HashedText = 3656553818,
    
    [SimpleType(typeof(string))]
    Html = 2477180992,
    
    [CompoundType] 
    [CompoundComponent("Url", typeof(string))]
    [CompoundComponent("PrettyName", typeof(string))]
    [CompoundComponent("SizeInBytes", typeof(int))]
    Image = 3650429592,
    
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
    
    [SimpleType(typeof(double))]
    Length = 1024984906,

    [SimpleType(typeof(string))]
    MacAddress = 404844511,
    
    [SimpleType(typeof(string))]
    Markdown = 2745254000,
    
    [SimpleType(typeof(uint))]
    Nuid = 3304944825,

    [SimpleType(typeof(NumberTypeComponentsDiscover))]
    Number = 4223714796,

    [CompoundType(Read = false, Update = false)]
    [CompoundComponent("HashedPassword", typeof(string))]
    [CompoundComponent("Salt", typeof(string))]
    Password = 1755902638,

    [SimpleType(typeof(float))]
    Percentage = 3986447473,

    [SimpleType(typeof(string))]
    PhoneNumber = 3655711066,
    
    [SimpleType(typeof(float))]
    Temperature = 1744108624,
    
    [SimpleType(typeof(string))]
    Text = 1432028016,

    [SimpleType(typeof(DateTimeOffset))] 
    Time = 2288042805,
    
    [SimpleType(typeof(string))]
    TimeZoneCode = 906030230,
    
    [SimpleType(typeof(string))] 
    Uri = 2293621128,
    
    [SimpleType(typeof(string))]
    Url = 2010611594,
    
    [SimpleType(typeof(string))]
    User = 2972321043,

    [SimpleType(typeof(double))]
    Volume = 1729151620,

    [SimpleType(typeof(double))]
    Weight = 760317285,
    
    [SimpleType(typeof(string))]
    Yaml = 3788751714
}