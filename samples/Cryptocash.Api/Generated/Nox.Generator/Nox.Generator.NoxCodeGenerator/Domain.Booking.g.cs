// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Exchange booking and related data.
/// </summary>
public partial class Booking : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Booking unique identifier (Required).
    /// </summary>
    public DatabaseGuid Id { get; set; } = null!;

    /// <summary>
    /// Booking's amount exchanged from (Required).
    /// </summary>
    public Nox.Types.Money AmountFrom { get; set; } = null!;

    /// <summary>
    /// Booking's amount exchanged to (Required).
    /// </summary>
    public Nox.Types.Money AmountTo { get; set; } = null!;

    /// <summary>
    /// Booking's requested pick up date (Required).
    /// </summary>
    public Nox.Types.DateTimeRange RequestedPickUpDate { get; set; } = null!;

    /// <summary>
    /// Booking's actual pick up date (Optional).
    /// </summary>
    public Nox.Types.DateTimeRange? PickedUpDateTime { get; set; } = null!;

    /// <summary>
    /// Booking's expiry date (Optional).
    /// </summary>
    public Nox.Types.DateTime? ExpiryDateTime { get; set; } = null!;

    /// <summary>
    /// Booking's cancelled date (Optional).
    /// </summary>
    public Nox.Types.DateTime? CancelledDateTime { get; set; } = null!;

    /// <summary>
    /// Booking's status (Optional).
    /// </summary>
    public String? Status
    { 
        get { return CancelledDateTime != null ? "cancelled" : (PickedUpDateTime != null ? "picked-up" : (ExpiryDateTime != null ? "expired" : "booked")); }
        private set { }
    }

    /// <summary>
    /// Booking's related vat number (Optional).
    /// </summary>
    public Nox.Types.VatNumber? VatNumber { get; set; } = null!;

    /// <summary>
    /// Booking for ExactlyOne Customers
    /// </summary>
    public virtual Customer BookingForCustomer { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Customer
    /// </summary>
    public Nox.Types.AutoNumber BookingForCustomerId { get; set; } = null!;

    /// <summary>
    /// Booking related to ExactlyOne VendingMachines
    /// </summary>
    public virtual VendingMachine BookingRelatedVendingMachine { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity VendingMachine
    /// </summary>
    public Nox.Types.DatabaseGuid BookingRelatedVendingMachineId { get; set; } = null!;

    /// <summary>
    /// Booking fees for ExactlyOne Commissions
    /// </summary>
    public virtual Commission BookingFeesForCommission { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Commission
    /// </summary>
    public Nox.Types.AutoNumber BookingFeesForCommissionId { get; set; } = null!;

    /// <summary>
    /// Booking related to ExactlyOne Transactions
    /// </summary>
    public virtual Transaction BookingRelatedTransaction { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}