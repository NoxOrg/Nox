// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class Transaction:TransactionBase
{

}
/// <summary>
/// Record for Transaction created event.
/// </summary>
public record TransactionCreated(Transaction Transaction) : IDomainEvent;

/// <summary>
/// Record for Transaction updated event.
/// </summary>
public record TransactionUpdated(Transaction Transaction) : IDomainEvent;

/// <summary>
/// Record for Transaction deleted event.
/// </summary>
public record TransactionDeleted(Transaction Transaction) : IDomainEvent;

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public abstract class TransactionBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Customer transaction unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Transaction type (Required).
    /// </summary>
    public Nox.Types.Text TransactionType { get; set; } = null!;

    /// <summary>
    /// Transaction processed datetime (Required).
    /// </summary>
    public Nox.Types.DateTime ProcessedOnDateTime { get; set; } = null!;

    /// <summary>
    /// Transaction amount (Required).
    /// </summary>
    public Nox.Types.Money Amount { get; set; } = null!;

    /// <summary>
    /// Transaction external reference (Required).
    /// </summary>
    public Nox.Types.Text Reference { get; set; } = null!;

    /// <summary>
    /// Transaction for ExactlyOne Customers
    /// </summary>
    public virtual Customer TransactionForCustomer { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Customer
    /// </summary>
    public Nox.Types.AutoNumber TransactionForCustomerId { get; set; } = null!;

    /// <summary>
    /// Transaction for ExactlyOne Bookings
    /// </summary>
    public virtual Booking TransactionForBooking { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Booking
    /// </summary>
    public Nox.Types.DatabaseGuid TransactionForBookingId { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}