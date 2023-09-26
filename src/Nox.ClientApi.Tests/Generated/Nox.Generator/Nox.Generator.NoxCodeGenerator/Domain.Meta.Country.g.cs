// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the Country class.
/// </summary>
public partial class Country
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
        /// Type options for property 'Population'
        /// </summary>
        public static Nox.Types.NumberTypeOptions PopulationTypeOptions {get; private set;} = new ()
        {
            MinValue = -999999999m,
            MaxValue = 1500000000m,
            DecimalDigits = 0,
        };
    
    
        /// <summary>
        /// Factory for property 'Population'
        /// </summary>
        public static Nox.Types.Number CreatePopulation(System.Int32 value)
            => Nox.Types.Number.From(value, PopulationTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'CountryDebt'
        /// </summary>
        public static Nox.Types.MoneyTypeOptions CountryDebtTypeOptions {get; private set;} = new ()
        {
            DecimalDigits = 4,
            IntegerDigits = 9,
            MinValue = 100000m,
            MaxValue = 999999999.9999m,
            DefaultCurrency = Nox.Types.CurrencyCode.USD,
        };
    
    
        /// <summary>
        /// Factory for property 'CountryDebt'
        /// </summary>
        public static Nox.Types.Money CreateCountryDebt(IMoney value)
            => Nox.Types.Money.From(value, CountryDebtTypeOptions);
        
    
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
        /// Factory for property 'GoogleMapsUrl'
        /// </summary>
        public static Nox.Types.Url CreateGoogleMapsUrl(System.String value)
            => Nox.Types.Url.From(value);
        
    
        /// <summary>
        /// Factory for property 'StartOfWeek'
        /// </summary>
        public static Nox.Types.DayOfWeek CreateStartOfWeek(System.UInt16 value)
            => Nox.Types.DayOfWeek.From(value);
        
    
        /// <summary>
        /// Factory for property 'CountryLocalNameId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateCountryLocalNameId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
}