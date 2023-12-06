// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the Language class.
/// </summary>
public partial class LanguageMetadata
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
        /// Type options for property 'Region'
        /// </summary>
        public static Nox.Types.TextTypeOptions RegionTypeOptions {get; private set;} = new ()
        {
            MinLength = 0,
            MaxLength = 255,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Region'
        /// </summary>
        public static Nox.Types.Text CreateRegion(System.String value)
            => Nox.Types.Text.From(value, RegionTypeOptions);
        

        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Language")
                .GetAttributeByName("Name")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CountryIsoNumeric'
        /// </summary>
        public static TypeUserInterface? CountryIsoNumericUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Language")
                .GetAttributeByName("CountryIsoNumeric")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CountryIsoAlpha3'
        /// </summary>
        public static TypeUserInterface? CountryIsoAlpha3UiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Language")
                .GetAttributeByName("CountryIsoAlpha3")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Region'
        /// </summary>
        public static TypeUserInterface? RegionUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Language")
                .GetAttributeByName("Region")?
                .UserInterface;
}