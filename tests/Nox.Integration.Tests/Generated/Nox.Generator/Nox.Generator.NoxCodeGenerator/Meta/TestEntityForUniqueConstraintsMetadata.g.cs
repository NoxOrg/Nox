// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;

/// <summary>
/// Static methods for the TestEntityForUniqueConstraints class.
/// </summary>
public partial class TestEntityForUniqueConstraintsMetadata
{
    
        /// <summary>
        /// Type options for property 'Id'
        /// </summary>
        public static Nox.Types.TextTypeOptions IdTypeOptions {get; private set;} = new ()
        {
            MinLength = 2,
            MaxLength = 2,
            IsUnicode = false,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.Text CreateId(System.String value)
            => Nox.Types.Text.From(value, IdTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'TextField'
        /// </summary>
        public static Nox.Types.TextTypeOptions TextFieldTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'TextField'
        /// </summary>
        public static Nox.Types.Text CreateTextField(System.String value)
            => Nox.Types.Text.From(value, TextFieldTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'NumberField'
        /// </summary>
        public static Nox.Types.NumberTypeOptions NumberFieldTypeOptions {get; private set;} = new ()
        {
            MinValue = 4m,
            MaxValue = 894m,
            DecimalDigits = 0,
        };
    
    
        /// <summary>
        /// Factory for property 'NumberField'
        /// </summary>
        public static Nox.Types.Number CreateNumberField(System.Int16 value)
            => Nox.Types.Number.From(value, NumberFieldTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'UniqueNumberField'
        /// </summary>
        public static Nox.Types.NumberTypeOptions UniqueNumberFieldTypeOptions {get; private set;} = new ()
        {
            MinValue = 4m,
            MaxValue = 894m,
            DecimalDigits = 0,
        };
    
    
        /// <summary>
        /// Factory for property 'UniqueNumberField'
        /// </summary>
        public static Nox.Types.Number CreateUniqueNumberField(System.Int16 value)
            => Nox.Types.Number.From(value, UniqueNumberFieldTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'UniqueCountryCode'
        /// </summary>
        public static Nox.Types.CountryCode2 CreateUniqueCountryCode(System.String value)
            => Nox.Types.CountryCode2.From(value);
        
    
        /// <summary>
        /// Factory for property 'UniqueCurrencyCode'
        /// </summary>
        public static Nox.Types.CurrencyCode3 CreateUniqueCurrencyCode(System.String value)
            => Nox.Types.CurrencyCode3.From(value);
        

        /// <summary>
        /// User Interface for property 'TextField'
        /// </summary>
        public static TypeUserInterface? TextFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForUniqueConstraints")
                .GetAttributeByName("TextField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'NumberField'
        /// </summary>
        public static TypeUserInterface? NumberFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForUniqueConstraints")
                .GetAttributeByName("NumberField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'UniqueNumberField'
        /// </summary>
        public static TypeUserInterface? UniqueNumberFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForUniqueConstraints")
                .GetAttributeByName("UniqueNumberField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'UniqueCountryCode'
        /// </summary>
        public static TypeUserInterface? UniqueCountryCodeUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForUniqueConstraints")
                .GetAttributeByName("UniqueCountryCode")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'UniqueCurrencyCode'
        /// </summary>
        public static TypeUserInterface? UniqueCurrencyCodeUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForUniqueConstraints")
                .GetAttributeByName("UniqueCurrencyCode")?
                .UserInterface;
}