﻿// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;

/// <summary>
/// Static methods for the ThirdTestEntityZeroOrMany class.
/// </summary>
public partial class ThirdTestEntityZeroOrManyMetadata
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
        /// Type options for property 'ThirdTestEntityOneOrManyId'
        /// </summary>
        public static Nox.Types.TextTypeOptions ThirdTestEntityOneOrManyIdTypeOptions {get; private set;} = new ()
        {
            MinLength = 2,
            MaxLength = 2,
            IsUnicode = false,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'ThirdTestEntityOneOrManyId'
        /// </summary>
        public static Nox.Types.Text CreateThirdTestEntityOneOrManyId(System.String value)
            => Nox.Types.Text.From(value, ThirdTestEntityOneOrManyIdTypeOptions);
        

        /// <summary>
        /// User Interface for property 'TextTestField2'
        /// </summary>
        public static TypeUserInterface? TextTestField2UiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("ThirdTestEntityZeroOrMany")
                .GetAttributeByName("TextTestField2")?
                .UserInterface;
}