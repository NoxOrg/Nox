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
/// Static methods for the SecondTestEntityOwnedRelationshipZeroOrOne class.
/// </summary>
public partial class SecondTestEntityOwnedRelationshipZeroOrOneMetadata
{
    
        /// <summary>
        /// Type options for property 'TextTestField2'
        /// </summary>
        public static Nox.Types.TextTypeOptions TextTestField2TypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'TextTestField2'
        /// </summary>
        public static Nox.Types.Text CreateTextTestField2(System.String value)
            => Nox.Types.Text.From(value, TextTestField2TypeOptions);
        
        /// <summary>
        /// User Interface for property 'TextTestField2'
        /// </summary>
        public static TypeUserInterface? TextTestField2UiOptions {get; private set;} = null; 
}