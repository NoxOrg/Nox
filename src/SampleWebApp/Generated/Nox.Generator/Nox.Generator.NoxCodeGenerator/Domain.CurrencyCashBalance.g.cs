// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace SampleWebApp.Domain;

/// <summary>
/// The cash balance in Store.
/// </summary>
public partial class CurrencyCashBalance : AuditableEntityBase, IConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text StoreId { get; set; } = null!;
    
        public virtual Store Store { get; set; } = null!;
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nuid CurrencyId { get; set; } = null!;
    
        public virtual Currency Currency { get; set; } = null!;

    /// <summary>
    /// The amount (Required).
    /// </summary>
    public Nox.Types.Money Amount { get; set; } = null!;

    /// <summary>
    /// The Operation Limit (Optional).
    /// </summary>
    public Nox.Types.Number? OperationLimit { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public Nox.Types.Guid Etag { get; set; } = Nox.Types.Guid.NewGuid();
}