// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;
using Nox;

namespace CryptocashIntegration.Domain;

/// <summary>
/// Static methods for the CountryQueryToTable class.
/// </summary>
public partial class CountryQueryToTableMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.Number CreateId(System.Int32 value)
            => Nox.Types.Number.From(value);
        
    
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
        /// Factory for property 'Population'
        /// </summary>
        public static Nox.Types.Number CreatePopulation(System.Int32 value)
            => Nox.Types.Number.From(value);
        
        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions {get; private set;} = null; 
        /// <summary>
        /// User Interface for property 'Population'
        /// </summary>
        public static TypeUserInterface? PopulationUiOptions {get; private set;} = null; 
}