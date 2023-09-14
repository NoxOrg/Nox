// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the Country class.
/// </summary>
public partial class Country
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.CountryCode2 CreateId(System.String value)
        => Nox.Types.CountryCode2.From(value);
    

    /// <summary>
    /// Type options and factory for property 'Name'
    /// </summary>
    public static Nox.Types.TextTypeOptions NameTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateName(System.String value)
        => Nox.Types.Text.From(value, NameTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'OfficialName'
    /// </summary>
    public static Nox.Types.TextTypeOptions OfficialNameTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateOfficialName(System.String value)
        => Nox.Types.Text.From(value, OfficialNameTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'CountryIsoNumeric'
    /// </summary>
    public static Nox.Types.CountryNumber CreateCountryIsoNumeric(System.UInt16 value)
        => Nox.Types.CountryNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CountryIsoAlpha3'
    /// </summary>
    public static Nox.Types.CountryCode3 CreateCountryIsoAlpha3(System.String value)
        => Nox.Types.CountryCode3.From(value);
    

    /// <summary>
    /// Type options and factory for property 'GeoCoords'
    /// </summary>
    public static Nox.Types.LatLong CreateGeoCoords(ILatLong value)
        => Nox.Types.LatLong.From(value);
    

    /// <summary>
    /// Type options and factory for property 'FlagEmoji'
    /// </summary>
    public static Nox.Types.TextTypeOptions FlagEmojiTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateFlagEmoji(System.String value)
        => Nox.Types.Text.From(value, FlagEmojiTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'FlagSvg'
    /// </summary>
    public static Nox.Types.Image CreateFlagSvg(IImage value)
        => Nox.Types.Image.From(value);
    

    /// <summary>
    /// Type options and factory for property 'FlagPng'
    /// </summary>
    public static Nox.Types.Image CreateFlagPng(IImage value)
        => Nox.Types.Image.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CoatOfArmsSvg'
    /// </summary>
    public static Nox.Types.Image CreateCoatOfArmsSvg(IImage value)
        => Nox.Types.Image.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CoatOfArmsPng'
    /// </summary>
    public static Nox.Types.Image CreateCoatOfArmsPng(IImage value)
        => Nox.Types.Image.From(value);
    

    /// <summary>
    /// Type options and factory for property 'GoogleMapsUrl'
    /// </summary>
    public static Nox.Types.Url CreateGoogleMapsUrl(System.String value)
        => Nox.Types.Url.From(value);
    

    /// <summary>
    /// Type options and factory for property 'OpenStreetMapsUrl'
    /// </summary>
    public static Nox.Types.Url CreateOpenStreetMapsUrl(System.String value)
        => Nox.Types.Url.From(value);
    

    /// <summary>
    /// Type options and factory for property 'StartOfWeek'
    /// </summary>
    public static Nox.Types.DayOfWeek CreateStartOfWeek(System.UInt16 value)
        => Nox.Types.DayOfWeek.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CountryTimeZoneId'
    /// </summary>
    public static Nox.Types.AutoNumber CreateCountryTimeZoneId(System.Int64 value)
        => Nox.Types.AutoNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'HolidayId'
    /// </summary>
    public static Nox.Types.AutoNumber CreateHolidayId(System.Int64 value)
        => Nox.Types.AutoNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CurrencyId'
    /// </summary>
    public static Nox.Types.CurrencyCode3 CreateCurrencyId(System.String value)
        => Nox.Types.CurrencyCode3.From(value);
    

}