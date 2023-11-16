// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

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
        public static TypeUserInterface? AutoNumberFieldWithOptionsUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForAutoNumberUsages")
                .GetAttributeByName("AutoNumberFieldWithOptions")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'AutoNumberFieldWithoutOptions'
        /// </summary>
        public static TypeUserInterface? AutoNumberFieldWithoutOptionsUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForAutoNumberUsages")
                .GetAttributeByName("AutoNumberFieldWithoutOptions")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'TextField'
        /// </summary>
        public static TypeUserInterface? TextFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForAutoNumberUsages")
                .GetAttributeByName("TextField")?
                .UserInterface;
}