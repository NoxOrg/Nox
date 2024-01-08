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
/// Static methods for the BankNote class.
/// </summary>
public partial class BankNoteMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Type options for property 'CashNote'
        /// </summary>
        public static Nox.Types.TextTypeOptions CashNoteTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'CashNote'
        /// </summary>
        public static Nox.Types.Text CreateCashNote(System.String value)
            => Nox.Types.Text.From(value, CashNoteTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'Value'
        /// </summary>
        public static Nox.Types.Money CreateValue(IMoney value)
            => Nox.Types.Money.From(value);
        
        /// <summary>
        /// User Interface for property 'CashNote'
        /// </summary>
        public static TypeUserInterface? CashNoteUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            InputOrder = 0,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
        /// <summary>
        /// User Interface for property 'Value'
        /// </summary>
        public static TypeUserInterface? ValueUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            InputOrder = 0,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
}