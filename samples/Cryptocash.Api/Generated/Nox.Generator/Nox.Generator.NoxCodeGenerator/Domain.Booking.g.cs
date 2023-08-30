// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace CryptocashApi.Domain;

/// <summary>
/// Exchange booking and related data.
/// </summary>
public partial class Booking : AuditableEntityBase
{
    /// <summary>
    /// The booking unique identifier (Required).
    /// </summary>
    public DatabaseGuid Id { get; set; } = null!;

    /// <summary>
    /// The booking's amount exchanged from (Required).
    /// </summary>
    public Nox.Types.Money AmountFrom { get; set; } = null!;

    /// <summary>
    /// The booking's amount exchanged to (Required).
    /// </summary>
    public Nox.Types.Money AmountTo { get; set; } = null!;

    /// <summary>
    /// The booking's requested pick up date (Required).
    /// </summary>
    public Nox.Types.DateTimeRange RequestedPickUpDate { get; set; } = null!;

    /// <summary>
    /// The booking's actual pick up date (Optional).
    /// </summary>
    public Nox.Types.DateTimeRange? PickedUpDateTime { get; set; } = null!;

    /// <summary>
    /// The booking's expiry date (Required).
    /// </summary>
    public Nox.Types.DateTime ExpiryDateTime { get; set; } = null!;

    /// <summary>
    /// The booking's cancelled date (Optional).
    /// </summary>
    public Nox.Types.DateTime? CancelledDateTime { get; set; } = null!;

    /// <summary>
    /// The booking's status (Required).
    /// </summary>
    public String Status
    { 
        get { return CancelledDateTime == null ? "cancelled" : (PickedUpDateTime == null ? "picked-up" : "booked"); }
        private set { }
    }

    /// <summary>
    /// The booking's related vat number (Optional).
    /// </summary>
    public Nox.Types.VatNumber? VatNumber { get; set; } = null!;

    /// <summary>
    /// Booking The booking's related customer ExactlyOne Customers
    /// </summary>
    public virtual Customer Customer { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Customer
    /// </summary>
    public Nox.Types.DatabaseNumber CustomerId { get; set; } = null!;

    /// <summary>
    /// Booking The booking's related vending machine ExactlyOne VendingMachines
    /// </summary>
    public virtual VendingMachine VendingMachine { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity VendingMachine
    /// </summary>
    public Nox.Types.DatabaseGuid VendingMachineId { get; set; } = null!;

    /// <summary>
    /// Booking The booking's related fee ExactlyOne Commissions
    /// </summary>
    public virtual Commission Commission { get; set; } = null!;

    public Commission Fee => Commission;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Commission
    /// </summary>
    public Nox.Types.DatabaseNumber CommissionId { get; set; } = null!;

    /// <summary>
    /// Booking The transaction's related booking OneOrMany CustomerTransactions
    /// </summary>
    public virtual List<CustomerTransaction> CustomerTransactions { get; set; } = new();

    public List<CustomerTransaction> CustomerTransaction => CustomerTransactions;
}