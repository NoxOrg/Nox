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
/// Static methods for the TestEntityForAutoNumberUsages class.
/// </summary>
public partial class TestEntityForAutoNumberUsagesMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Factory for property 'AutoNumberFieldWithOptions'
        /// </summary>
        public static Nox.Types.AutoNumber CreateAutoNumberFieldWithOptions(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Factory for property 'AutoNumberFieldWithoutOptions'
        /// </summary>
        public static Nox.Types.AutoNumber CreateAutoNumberFieldWithoutOptions(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Type options for property 'TextField'
        /// </summary>
        public static Nox.Types.TextTypeOptions TextFieldTypeOptions {get; private set;} = new ()
        {
            MinLength = 1,
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
        /// User Interface for property 'AutoNumberFieldWithOptions'
        /// </summary>
        public static TypeUserInterface? AutoNumberFieldWithOptionsUiOptions {get; private set;} = null; 
        /// <summary>
        /// User Interface for property 'AutoNumberFieldWithoutOptions'
        /// </summary>
        public static TypeUserInterface? AutoNumberFieldWithoutOptionsUiOptions {get; private set;} = null; 
        /// <summary>
        /// User Interface for property 'TextField'
        /// </summary>
        public static TypeUserInterface? TextFieldUiOptions {get; private set;} = null; 
}