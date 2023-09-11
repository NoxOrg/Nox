// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public partial class CashStockOrder : AuditableEntityBase, IEntityConcurrent
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
    public String? Status
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