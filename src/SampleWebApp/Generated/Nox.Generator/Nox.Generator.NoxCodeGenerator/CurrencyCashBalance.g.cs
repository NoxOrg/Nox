// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// The cash balance in Store.
/// </summary>
public partial class CurrencyCashBalance : AuditableEntityBase
{
    
    /// <summary>
    /// (Required)
    /// </summary>
    public Text StoreId { get; set; } = null!;
    public Store Store { get; set; } = null!;
    
    /// <summary>
    /// (Required)
    /// </summary>
    public Text CurrencyId { get; set; } = null!;
    public Currency Currency { get; set; } = null!;
    
    /// <summary>
    /// The amount (required).
    /// </summary>
    public Number Amount { get; set; } = null!;
    
    /// <summary>
    /// The Operation Limit (optional).
    /// </summary>
    public Number? OperationLimit { get; set; } = null!;
}
