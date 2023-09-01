// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Vending machine currency order and related data.
/// </summary>
public partial class VendingMachineOrder : AuditableEntityBase
{
    /// <summary>
    /// Vending machine's order unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

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
    /// VendingMachineOrder Vending machine's orders ExactlyOne VendingMachines
    /// </summary>
    public virtual VendingMachine VendingMachine { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity VendingMachine
    /// </summary>
    public Nox.Types.DatabaseGuid VendingMachineId { get; set; } = null!;

    /// <summary>
    /// VendingMachineOrder Reviewed by employee ExactlyOne Employees
    /// </summary>
    public virtual Employee Employee { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Employee
    /// </summary>
    public Nox.Types.DatabaseNumber EmployeeId { get; set; } = null!;
}