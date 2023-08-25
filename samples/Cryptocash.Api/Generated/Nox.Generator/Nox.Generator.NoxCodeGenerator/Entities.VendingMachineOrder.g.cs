// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace CryptocashApi.Domain;

/// <summary>
/// Vending machine currency order and related data.
/// </summary>
public partial class VendingMachineOrder : AuditableEntityBase
{
    /// <summary>
    /// The vending machine's order unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The order's amount (Required).
    /// </summary>
    public Nox.Types.Money Amount { get; set; } = null!;

    /// <summary>
    /// The order's requested delivery date (Optional).
    /// </summary>
    public Nox.Types.Date? RequestedDeliveryDate { get; set; } = null!;

    /// <summary>
    /// The order's delivery date (Optional).
    /// </summary>
    public Nox.Types.DateTime? DeliveryDateTime { get; set; } = null!;

    /// <summary>
    /// VendingMachineOrder The order's related vending machine ExactlyOne VendingMachines
    /// </summary>
    public virtual VendingMachine VendingMachine { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity VendingMachine
    /// </summary>
    public Nox.Types.DatabaseGuid VendingMachineId { get; set; } = null!;
}