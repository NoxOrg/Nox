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
/// Static methods for the Transaction class.
/// </summary>
public partial class TransactionMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.Guid CreateId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
    
        /// <summary>
        /// Type options for property 'TransactionType'
        /// </summary>
        public static Nox.Types.TextTypeOptions TransactionTypeTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'TransactionType'
        /// </summary>
        public static Nox.Types.Text CreateTransactionType(System.String value)
            => Nox.Types.Text.From(value, TransactionTypeTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'ProcessedOnDateTime'
        /// </summary>
        public static Nox.Types.DateTime CreateProcessedOnDateTime(System.DateTimeOffset value)
            => Nox.Types.DateTime.From(value);
        
    
        /// <summary>
        /// Factory for property 'Amount'
        /// </summary>
        public static Nox.Types.Money CreateAmount(IMoney value)
            => Nox.Types.Money.From(value);
        
    
        /// <summary>
        /// Type options for property 'Reference'
        /// </summary>
        public static Nox.Types.TextTypeOptions ReferenceTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Reference'
        /// </summary>
        public static Nox.Types.Text CreateReference(System.String value)
            => Nox.Types.Text.From(value, ReferenceTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'CustomerId'
        /// </summary>
        public static Nox.Types.Guid CreateCustomerId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
        /// <summary>
        /// User Interface for property 'TransactionType'
        /// </summary>
        public static TypeUserInterface? TransactionTypeUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            InputOrder = 0,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
        /// <summary>
        /// User Interface for property 'ProcessedOnDateTime'
        /// </summary>
        public static TypeUserInterface? ProcessedOnDateTimeUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            InputOrder = 0,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
        /// <summary>
        /// User Interface for property 'Amount'
        /// </summary>
        public static TypeUserInterface? AmountUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            InputOrder = 0,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
        /// <summary>
        /// User Interface for property 'Reference'
        /// </summary>
        public static TypeUserInterface? ReferenceUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            InputOrder = 0,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
}