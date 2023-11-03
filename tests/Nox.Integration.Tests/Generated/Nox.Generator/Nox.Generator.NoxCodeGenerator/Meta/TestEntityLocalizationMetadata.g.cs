// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;

/// <summary>
/// Static methods for the TestEntityLocalization class.
/// </summary>
public partial class TestEntityLocalizationMetadata
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
        /// Type options for property 'TextFieldToLocalize'
        /// </summary>
        public static Nox.Types.TextTypeOptions TextFieldToLocalizeTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'TextFieldToLocalize'
        /// </summary>
        public static Nox.Types.Text CreateTextFieldToLocalize(System.String value)
            => Nox.Types.Text.From(value, TextFieldToLocalizeTypeOptions);
        
    
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
        /// User Interface for property 'TextFieldToLocalize'
        /// </summary>
        public static TypeUserInterface? TextFieldToLocalizeUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityLocalization")
                .GetAttributeByName("TextFieldToLocalize")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'NumberField'
        /// </summary>
        public static TypeUserInterface? NumberFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityLocalization")
                .GetAttributeByName("NumberField")?
                .UserInterface;
}