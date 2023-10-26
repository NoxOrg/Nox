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
        /// Type options for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumberTypeOptions IdTypeOptions {get; private set;} = new ()
        {
            StartsAt = 10,
            IncrementsBy = 2,
        };
    
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value, IdTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'AutoNumberField'
        /// </summary>
        public static Nox.Types.AutoNumberTypeOptions AutoNumberFieldTypeOptions {get; private set;} = new ()
        {
            StartsAt = 20,
            IncrementsBy = 2,
        };
    
    
        /// <summary>
        /// Factory for property 'AutoNumberField'
        /// </summary>
        public static Nox.Types.AutoNumber CreateAutoNumberField(System.Int64 value)
            => Nox.Types.AutoNumber.From(value, AutoNumberFieldTypeOptions);
        
    
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
        /// User Interface for property 'AutoNumberField'
        /// </summary>
        public static TypeUserInterface? AutoNumberFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForAutoNumberUsages")
                .GetAttributeByName("AutoNumberField")?
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