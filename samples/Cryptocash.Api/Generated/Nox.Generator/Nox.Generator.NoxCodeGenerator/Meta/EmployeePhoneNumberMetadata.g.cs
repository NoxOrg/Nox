// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;
using Nox;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the EmployeePhoneNumber class.
/// </summary>
public partial class EmployeePhoneNumberMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Type options for property 'PhoneNumberType'
        /// </summary>
        public static Nox.Types.TextTypeOptions PhoneNumberTypeTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'PhoneNumberType'
        /// </summary>
        public static Nox.Types.Text CreatePhoneNumberType(System.String value)
            => Nox.Types.Text.From(value, PhoneNumberTypeTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'PhoneNumber'
        /// </summary>
        public static Nox.Types.PhoneNumber CreatePhoneNumber(System.String value)
            => Nox.Types.PhoneNumber.From(value);
        
        /// <summary>
        /// User Interface for property 'PhoneNumberType'
        /// </summary>
        public static TypeUserInterface? PhoneNumberTypeUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            InputOrder = 0,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
        /// <summary>
        /// User Interface for property 'PhoneNumber'
        /// </summary>
        public static TypeUserInterface? PhoneNumberUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            InputOrder = 0,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
}