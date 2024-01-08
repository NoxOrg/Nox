// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;
using Nox;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the TenantContact class.
/// </summary>
public partial class TenantContactMetadata
{
    
        /// <summary>
        /// Type options for property 'Name'
        /// </summary>
        public static Nox.Types.TextTypeOptions NameTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Name'
        /// </summary>
        public static Nox.Types.Text CreateName(System.String value)
            => Nox.Types.Text.From(value, NameTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'Description'
        /// </summary>
        public static Nox.Types.TextTypeOptions DescriptionTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 255,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Description'
        /// </summary>
        public static Nox.Types.Text CreateDescription(System.String value)
            => Nox.Types.Text.From(value, DescriptionTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'Email'
        /// </summary>
        public static Nox.Types.Email CreateEmail(System.String value)
            => Nox.Types.Email.From(value);
        
        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions {get; private set;} = null; 
        /// <summary>
        /// User Interface for property 'Description'
        /// </summary>
        public static TypeUserInterface? DescriptionUiOptions {get; private set;} = null; 
        /// <summary>
        /// User Interface for property 'Email'
        /// </summary>
        public static TypeUserInterface? EmailUiOptions {get; private set;} = null; 
}