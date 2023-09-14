// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class CashStockOrder:CashStockOrderBase
{

}
/// <summary>
/// Record for CashStockOrder created event.
/// </summary>
public record CashStockOrderCreated(CashStockOrder CashStockOrder) : IDomainEvent;
/// <summary>
/// Record for CashStockOrder updated event.
/// </summary>
public record CashStockOrderUpdated(CashStockOrder CashStockOrder) : IDomainEvent;
/// <summary>
/// Record for CashStockOrder deleted event.
/// </summary>
public record CashStockOrderDeleted(CashStockOrder CashStockOrder) : IDomainEvent;

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public abstract class CashStockOrderBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Vending machine's order unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Order amount (Required).
    /// </summary>
    public Nox.Types.Money Amount { get; set; } = null!;

    /// <summary>
    /// Order requested delivery date (Required).
    /// </summary>
    public Nox.Types.Date RequestedDeliveryDate { get; set; } = null!;

    /// <summary>
    /// Order delivery date (Optional).
    /// </summary>
    public Nox.Types.DateTime? DeliveryDateTime { get; set; } = null!;

    /// <summary>
    /// Order status (Optional).
    /// </summary>
    public string? Status
    { 
        get { return DeliveryDateTime != null ? "delivered" : "ordered"; }
        private set { }
    }

    /// <summary>
    /// CashStockOrder for ExactlyOne VendingMachines
    /// </summary>
    public virtual VendingMachine CashStockOrderForVendingMachine { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity VendingMachine
    /// </summary>
    public Nox.Types.DatabaseGuid CashStockOrderForVendingMachineId { get; set; } = null!;

    /// <summary>
    /// CashStockOrder reviewed by ExactlyOne Employees
    /// </summary>
    public virtual Employee CashStockOrderReviewedByEmployee { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}