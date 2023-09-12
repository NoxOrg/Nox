// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public partial class MinimumCashStock : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Vending machine cash stock unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Cash stock amount (Required).
    /// </summary>
    public Nox.Types.Money Amount { get; set; } = null!;

    /// <summary>
    /// MinimumCashStock required by ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachine> MinimumCashStocksRequiredByVendingMachines { get; set; } = new();

    /// <summary>
    /// MinimumCashStock related to ExactlyOne Currencies
    /// </summary>
    public virtual Currency MinimumCashStockRelatedCurrency { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Currency
    /// </summary>
    public Nox.Types.CurrencyCode3 MinimumCashStockRelatedCurrencyId { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}