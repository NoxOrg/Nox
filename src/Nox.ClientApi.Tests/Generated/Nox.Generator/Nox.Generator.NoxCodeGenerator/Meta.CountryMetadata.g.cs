﻿// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the Country class.
/// </summary>
public partial class CountryMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
    
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
        /// Factory for property 'Population'
        /// </summary>
        public static Nox.Types.Number CreatePopulation(System.Int32 value)
            => Nox.Types.Number.From(value);
        
    
        /// <summary>
        /// Factory for property 'CountryDebt'
        /// </summary>
        public static Nox.Types.Money CreateCountryDebt(IMoney value)
            => Nox.Types.Money.From(value);
        
    
        /// <summary>
        /// Factory for property 'FirstLanguageCode'
        /// </summary>
        public static Nox.Types.LanguageCode CreateFirstLanguageCode(System.String value)
            => Nox.Types.LanguageCode.From(value);
        
    
        /// <summary>
        /// Type options for property 'ShortDescription'
        /// </summary>
        public static Nox.Types.FormulaTypeOptions ShortDescriptionTypeOptions {get; private set;} = new ()
        {
            Expression = "$\"{Name} has a population of {Population} people.\"",
            Returns = Nox.Types.FormulaReturnType.@string,
        };
    
    
        /// <summary>
        /// Factory for property 'ShortDescription'
        /// </summary>
        public static Nox.Types.Formula CreateShortDescription(System.String value)
            => Nox.Types.Formula.From(value, ShortDescriptionTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'CountryLocalNameId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateCountryLocalNameId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
}