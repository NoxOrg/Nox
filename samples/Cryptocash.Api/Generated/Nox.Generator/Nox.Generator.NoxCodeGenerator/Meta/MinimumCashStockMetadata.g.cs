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
/// Static methods for the MinimumCashStock class.
/// </summary>
public partial class MinimumCashStockMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Factory for property 'Amount'
        /// </summary>
        public static Nox.Types.Money CreateAmount(IMoney value)
            => Nox.Types.Money.From(value);
        
    
        /// <summary>
        /// Factory for property 'VendingMachineId'
        /// </summary>
        public static Nox.Types.Guid CreateVendingMachineId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
    
        /// <summary>
        /// Factory for property 'CurrencyId'
        /// </summary>
        public static Nox.Types.CurrencyCode3 CreateCurrencyId(System.String value)
            => Nox.Types.CurrencyCode3.From(value);
        
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
}