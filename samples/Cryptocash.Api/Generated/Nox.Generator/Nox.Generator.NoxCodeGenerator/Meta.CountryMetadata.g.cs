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
            IsLocalized = true,
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
            IsLocalized = true,
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
            IsLocalized = true,
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
            => Nox.Types.AutoNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'HolidayId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateHolidayId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'CurrencyId'
        /// </summary>
        public static Nox.Types.CurrencyCode3 CreateCurrencyId(System.String value)
            => Nox.Types.CurrencyCode3.From(value);
        

        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public TypeUserInterface? NameUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Country")?
                .Attributes?.FirstOrDefault(a => a.Name == "Name")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'OfficialName'
        /// </summary>
        public TypeUserInterface? OfficialNameUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Country")?
                .Attributes?.FirstOrDefault(a => a.Name == "OfficialName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CountryIsoNumeric'
        /// </summary>
        public TypeUserInterface? CountryIsoNumericUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Country")?
                .Attributes?.FirstOrDefault(a => a.Name == "CountryIsoNumeric")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CountryIsoAlpha3'
        /// </summary>
        public TypeUserInterface? CountryIsoAlpha3UserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Country")?
                .Attributes?.FirstOrDefault(a => a.Name == "CountryIsoAlpha3")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'GeoCoords'
        /// </summary>
        public TypeUserInterface? GeoCoordsUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Country")?
                .Attributes?.FirstOrDefault(a => a.Name == "GeoCoords")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'FlagEmoji'
        /// </summary>
        public TypeUserInterface? FlagEmojiUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Country")?
                .Attributes?.FirstOrDefault(a => a.Name == "FlagEmoji")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'FlagSvg'
        /// </summary>
        public TypeUserInterface? FlagSvgUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Country")?
                .Attributes?.FirstOrDefault(a => a.Name == "FlagSvg")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'FlagPng'
        /// </summary>
        public TypeUserInterface? FlagPngUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Country")?
                .Attributes?.FirstOrDefault(a => a.Name == "FlagPng")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CoatOfArmsSvg'
        /// </summary>
        public TypeUserInterface? CoatOfArmsSvgUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Country")?
                .Attributes?.FirstOrDefault(a => a.Name == "CoatOfArmsSvg")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CoatOfArmsPng'
        /// </summary>
        public TypeUserInterface? CoatOfArmsPngUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Country")?
                .Attributes?.FirstOrDefault(a => a.Name == "CoatOfArmsPng")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'GoogleMapsUrl'
        /// </summary>
        public TypeUserInterface? GoogleMapsUrlUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Country")?
                .Attributes?.FirstOrDefault(a => a.Name == "GoogleMapsUrl")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'OpenStreetMapsUrl'
        /// </summary>
        public TypeUserInterface? OpenStreetMapsUrlUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Country")?
                .Attributes?.FirstOrDefault(a => a.Name == "OpenStreetMapsUrl")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'StartOfWeek'
        /// </summary>
        public TypeUserInterface? StartOfWeekUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Country")?
                .Attributes?.FirstOrDefault(a => a.Name == "StartOfWeek")?
                .UserInterface;
}