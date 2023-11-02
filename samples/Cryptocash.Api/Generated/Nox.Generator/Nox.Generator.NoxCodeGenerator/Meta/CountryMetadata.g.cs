// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the Country class.
/// </summary>
public partial class CountryMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.CountryCode2 CreateId(System.String value)
            => Nox.Types.CountryCode2.From(value);
        
    
        /// <summary>
        /// Type options for property 'Name'
        /// </summary>
        public static Nox.Types.TextTypeOptions NameTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Name'
        /// </summary>
        public static Nox.Types.Text CreateName(System.String value)
            => Nox.Types.Text.From(value, NameTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'OfficialName'
        /// </summary>
        public static Nox.Types.TextTypeOptions OfficialNameTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'OfficialName'
        /// </summary>
        public static Nox.Types.Text CreateOfficialName(System.String value)
            => Nox.Types.Text.From(value, OfficialNameTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'CountryIsoNumeric'
        /// </summary>
        public static Nox.Types.CountryNumber CreateCountryIsoNumeric(System.UInt16 value)
            => Nox.Types.CountryNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'CountryIsoAlpha3'
        /// </summary>
        public static Nox.Types.CountryCode3 CreateCountryIsoAlpha3(System.String value)
            => Nox.Types.CountryCode3.From(value);
        
    
        /// <summary>
        /// Factory for property 'GeoCoords'
        /// </summary>
        public static Nox.Types.LatLong CreateGeoCoords(ILatLong value)
            => Nox.Types.LatLong.From(value);
        
    
        /// <summary>
        /// Type options for property 'FlagEmoji'
        /// </summary>
        public static Nox.Types.TextTypeOptions FlagEmojiTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'FlagEmoji'
        /// </summary>
        public static Nox.Types.Text CreateFlagEmoji(System.String value)
            => Nox.Types.Text.From(value, FlagEmojiTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'FlagSvg'
        /// </summary>
        public static Nox.Types.Image CreateFlagSvg(IImage value)
            => Nox.Types.Image.From(value);
        
    
        /// <summary>
        /// Factory for property 'FlagPng'
        /// </summary>
        public static Nox.Types.Image CreateFlagPng(IImage value)
            => Nox.Types.Image.From(value);
        
    
        /// <summary>
        /// Factory for property 'CoatOfArmsSvg'
        /// </summary>
        public static Nox.Types.Image CreateCoatOfArmsSvg(IImage value)
            => Nox.Types.Image.From(value);
        
    
        /// <summary>
        /// Factory for property 'CoatOfArmsPng'
        /// </summary>
        public static Nox.Types.Image CreateCoatOfArmsPng(IImage value)
            => Nox.Types.Image.From(value);
        
    
        /// <summary>
        /// Factory for property 'GoogleMapsUrl'
        /// </summary>
        public static Nox.Types.Url CreateGoogleMapsUrl(System.String value)
            => Nox.Types.Url.From(value);
        
    
        /// <summary>
        /// Factory for property 'OpenStreetMapsUrl'
        /// </summary>
        public static Nox.Types.Url CreateOpenStreetMapsUrl(System.String value)
            => Nox.Types.Url.From(value);
        
    
        /// <summary>
        /// Factory for property 'StartOfWeek'
        /// </summary>
        public static Nox.Types.DayOfWeek CreateStartOfWeek(System.UInt16 value)
            => Nox.Types.DayOfWeek.From(value);
        
    
        /// <summary>
        /// Factory for property 'CountryTimeZoneId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateCountryTimeZoneId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Factory for property 'HolidayId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateHolidayId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Factory for property 'CurrencyId'
        /// </summary>
        public static Nox.Types.CurrencyCode3 CreateCurrencyId(System.String value)
            => Nox.Types.CurrencyCode3.From(value);
        

        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Country")
                .GetAttributeByName("Name")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'OfficialName'
        /// </summary>
        public static TypeUserInterface? OfficialNameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Country")
                .GetAttributeByName("OfficialName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CountryIsoNumeric'
        /// </summary>
        public static TypeUserInterface? CountryIsoNumericUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Country")
                .GetAttributeByName("CountryIsoNumeric")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CountryIsoAlpha3'
        /// </summary>
        public static TypeUserInterface? CountryIsoAlpha3UiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Country")
                .GetAttributeByName("CountryIsoAlpha3")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'GeoCoords'
        /// </summary>
        public static TypeUserInterface? GeoCoordsUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Country")
                .GetAttributeByName("GeoCoords")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'FlagEmoji'
        /// </summary>
        public static TypeUserInterface? FlagEmojiUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Country")
                .GetAttributeByName("FlagEmoji")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'FlagSvg'
        /// </summary>
        public static TypeUserInterface? FlagSvgUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Country")
                .GetAttributeByName("FlagSvg")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'FlagPng'
        /// </summary>
        public static TypeUserInterface? FlagPngUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Country")
                .GetAttributeByName("FlagPng")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CoatOfArmsSvg'
        /// </summary>
        public static TypeUserInterface? CoatOfArmsSvgUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Country")
                .GetAttributeByName("CoatOfArmsSvg")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CoatOfArmsPng'
        /// </summary>
        public static TypeUserInterface? CoatOfArmsPngUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Country")
                .GetAttributeByName("CoatOfArmsPng")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'GoogleMapsUrl'
        /// </summary>
        public static TypeUserInterface? GoogleMapsUrlUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Country")
                .GetAttributeByName("GoogleMapsUrl")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'OpenStreetMapsUrl'
        /// </summary>
        public static TypeUserInterface? OpenStreetMapsUrlUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Country")
                .GetAttributeByName("OpenStreetMapsUrl")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'StartOfWeek'
        /// </summary>
        public static TypeUserInterface? StartOfWeekUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Country")
                .GetAttributeByName("StartOfWeek")?
                .UserInterface;
}