// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace CryptocashIntegration.Domain;

/// <summary>
/// Static methods for the CountryJsonToTable class.
/// </summary>
public partial class CountryJsonToTableMetadata
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
        /// Factory for property 'CreateDate'
        /// </summary>
        public static Nox.Types.DateTime CreateCreateDate(System.DateTimeOffset value)
            => Nox.Types.DateTime.From(value);
        
    
        /// <summary>
        /// Factory for property 'EditDate'
        /// </summary>
        public static Nox.Types.DateTime CreateEditDate(System.DateTimeOffset value)
            => Nox.Types.DateTime.From(value);
        

        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("CountryJsonToTable")
                .GetAttributeByName("Name")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Population'
        /// </summary>
        public static TypeUserInterface? PopulationUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("CountryJsonToTable")
                .GetAttributeByName("Population")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CreateDate'
        /// </summary>
        public static TypeUserInterface? CreateDateUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("CountryJsonToTable")
                .GetAttributeByName("CreateDate")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'EditDate'
        /// </summary>
        public static TypeUserInterface? EditDateUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("CountryJsonToTable")
                .GetAttributeByName("EditDate")?
                .UserInterface;
}