// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace CryptocashApi.Domain;

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public partial class CustomerTransaction : AuditableEntityBase
{
    /// <summary>
    /// The customer transaction unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The transaction type (Required).
    /// </summary>
    public Nox.Types.Text TransactionType { get; set; } = null!;

    /// <summary>
    /// The transaction processed datetime (Required).
    /// </summary>
    public Nox.Types.DateTime ProcessedOnDateTime { get; set; } = null!;

    /// <summary>
    /// The transaction amount (Required).
    /// </summary>
    public Nox.Types.Money Amount { get; set; } = null!;

    /// <summary>
    /// The transaction external reference (Required).
    /// </summary>
    public Nox.Types.Text Reference { get; set; } = null!;

    /// <summary>
    /// CustomerTransaction The transaction's related customer ExactlyOne Customers
    /// </summary>
    public virtual Customer Customer { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Customer
    /// </summary>
    public Nox.Types.DatabaseNumber CustomerId { get; set; } = null!;

    /// <summary>
    /// CustomerTransaction The transaction's related booking ExactlyOne Bookings
    /// </summary>
    public virtual Booking Booking { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Booking
    /// </summary>
    public Nox.Types.DatabaseNumber BookingId { get; set; } = null!;
}