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
/// Static methods for the EntityUniqueConstraintsWithForeignKey class.
/// </summary>
public partial class EntityUniqueConstraintsWithForeignKeyMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.Guid CreateId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
    
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
        /// Factory for property 'SomeUniqueId'
        /// </summary>
        public static Nox.Types.Number CreateSomeUniqueId(System.Int32 value)
            => Nox.Types.Number.From(value);
        
    
        /// <summary>
        /// Factory for property 'EntityUniqueConstraintsRelatedForeignKeyId'
        /// </summary>
        public static Nox.Types.Number CreateEntityUniqueConstraintsRelatedForeignKeyId(System.Int32 value)
            => Nox.Types.Number.From(value);
        
        /// <summary>
        /// User Interface for property 'TextField'
        /// </summary>
        public static TypeUserInterface? TextFieldUiOptions {get; private set;} = null; 
        /// <summary>
        /// User Interface for property 'SomeUniqueId'
        /// </summary>
        public static TypeUserInterface? SomeUniqueIdUiOptions {get; private set;} = null; 
}