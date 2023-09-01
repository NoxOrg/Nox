﻿// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace SampleWebApp.Domain;

/// <summary>
/// The cash balance in Store.
/// </summary>
public partial class CurrencyCashBalance : AuditableEntityBase
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text StoreId { get; set; } = null!;
    
        public virtual Store Store { get; set; } = null!;
    /// <summary>
    ///  (Required).
    /// </summary>
    public DatabaseNumber CurrencyId { get; set; } = null!;
    
        public virtual Currency Currency { get; set; } = null!;

    /// <summary>
    /// The amount (Required).
    /// </summary>
    public Nox.Types.Money Amount { get; set; } = null!;

    /// <summary>
    /// The Operation Limit (Optional).
    /// </summary>
    public Nox.Types.Number? OperationLimit { get; set; } = null!;
}