// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class MinimumCashStock:MinimumCashStockBase
{

}
/// <summary>
/// Record for MinimumCashStock created event.
/// </summary>
public record MinimumCashStockCreated(MinimumCashStock MinimumCashStock) : IDomainEvent;
/// <summary>
/// Record for MinimumCashStock updated event.
/// </summary>
public record MinimumCashStockUpdated(MinimumCashStock MinimumCashStock) : IDomainEvent;
/// <summary>
/// Record for MinimumCashStock deleted event.
/// </summary>
public record MinimumCashStockDeleted(MinimumCashStock MinimumCashStock) : IDomainEvent;

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public abstract class MinimumCashStockBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Vending machine cash stock unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Cash stock amount (Required).
    /// </summary>
    public Nox.Types.Money Amount { get; set; } = null!;

    /// <summary>
    /// MinimumCashStock required by ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachine> MinimumCashStocksRequiredByVendingMachines { get; set; } = new();

    public virtual void CreateRefToVendingMachine(VendingMachine relatedVendingMachine)
    {
        MinimumCashStocksRequiredByVendingMachines.Add(relatedVendingMachine);
    }

    /// <summary>
    /// MinimumCashStock related to ExactlyOne Currencies
    /// </summary>
    public virtual Currency MinimumCashStockRelatedCurrency { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Currency
    /// </summary>
    public Nox.Types.CurrencyCode3 MinimumCashStockRelatedCurrencyId { get; set; } = null!;

    public virtual void CreateRefToCurrency(Currency relatedCurrency)
    {
        MinimumCashStockRelatedCurrency = relatedCurrency;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}