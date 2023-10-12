// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;

/// <summary>
/// Static methods for the TestEntityTwoRelationshipsManyToMany class.
/// </summary>
public partial class TestEntityTwoRelationshipsManyToManyMetadata
{
    
        /// <summary>
        /// Type options for property 'Id'
        /// </summary>
        public static Nox.Types.TextTypeOptions IdTypeOptions {get; private set;} = new ()
        {
            MinLength = 2,
            MaxLength = 2,
            IsUnicode = false,
            IsLocalized = true,
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
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'TextTestField'
        /// </summary>
        public static Nox.Types.Text CreateTextTestField(System.String value)
            => Nox.Types.Text.From(value, TextTestFieldTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'SecondTestEntityTwoRelationshipsManyToManyId'
        /// </summary>
        public static Nox.Types.TextTypeOptions SecondTestEntityTwoRelationshipsManyToManyIdTypeOptions {get; private set;} = new ()
        {
            MinLength = 2,
            MaxLength = 2,
            IsUnicode = false,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'SecondTestEntityTwoRelationshipsManyToManyId'
        /// </summary>
        public static Nox.Types.Text CreateSecondTestEntityTwoRelationshipsManyToManyId(System.String value)
            => Nox.Types.Text.From(value, SecondTestEntityTwoRelationshipsManyToManyIdTypeOptions);
        

        /// <summary>
        /// User Interface for property 'TextTestField'
        /// </summary>
        public static TypeUserInterface? TextTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityTwoRelationshipsManyToMany")
                .GetAttributeByName("TextTestField")?
                .UserInterface;
}