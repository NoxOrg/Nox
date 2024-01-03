// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;
using Nox;

namespace TestWebApp.Domain;

/// <summary>
/// Static methods for the TestEntityZeroOrMany class.
/// </summary>
public partial class TestEntityZeroOrManyMetadata
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
        /// Type options for property 'TextTestField'
        /// </summary>
        public static Nox.Types.TextTypeOptions TextTestFieldTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'TextTestField'
        /// </summary>
        public static Nox.Types.Text CreateTextTestField(System.String value)
            => Nox.Types.Text.From(value, TextTestFieldTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'SecondTestEntityZeroOrManyId'
        /// </summary>
        public static Nox.Types.TextTypeOptions SecondTestEntityZeroOrManyIdTypeOptions {get; private set;} = new ()
        {
            MinLength = 2,
            MaxLength = 2,
            IsUnicode = false,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'SecondTestEntityZeroOrManyId'
        /// </summary>
        public static Nox.Types.Text CreateSecondTestEntityZeroOrManyId(System.String value)
            => Nox.Types.Text.From(value, SecondTestEntityZeroOrManyIdTypeOptions);
        
        /// <summary>
        /// User Interface for property 'TextTestField'
        /// </summary>
        public static TypeUserInterface? TextTestFieldUiOptions {get; private set;} = null; 
}