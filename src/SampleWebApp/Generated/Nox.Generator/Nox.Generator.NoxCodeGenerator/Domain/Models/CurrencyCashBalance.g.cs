// generated

#nullable enable

using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// The cash balance in Store.
/// </summary>
public partial class CurrencyCashBalance : AuditableEntityBase
{
    
    /// <summary>
    /// The amount (required).
    /// </summary>
    public Number Amount { get; set; } = null!;
    
    /// <summary>
    /// The Operation Limit (optional).
    /// </summary>
    public Number? OperationLimit { get; set; } = null!;
}
