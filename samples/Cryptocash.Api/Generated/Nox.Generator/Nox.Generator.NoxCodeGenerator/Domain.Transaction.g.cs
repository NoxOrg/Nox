// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;

internal partial class Transaction : TransactionBase, IEntityHaveDomainEvents
{
	///<inheritdoc/>
	public void RaiseCreateEvent()
	{
		InternalRaiseCreateEvent(this);
	}
	///<inheritdoc/>
	public void RaiseDeleteEvent()
	{
		InternalRaiseDeleteEvent(this);
	}
	///<inheritdoc/>
	public void RaiseUpdateEvent()
	{
		InternalRaiseUpdateEvent(this);
	}
}
/// <summary>
/// Record for Transaction created event.
/// </summary>
internal record TransactionCreated(Transaction Transaction) : IDomainEvent;
/// <summary>
/// Record for Transaction updated event.
/// </summary>
internal record TransactionUpdated(Transaction Transaction) : IDomainEvent;
/// <summary>
/// Record for Transaction deleted event.
/// </summary>
internal record TransactionDeleted(Transaction Transaction) : IDomainEvent;

/// <summary>
/// Customer transaction log and related data.
/// </summary>
internal abstract partial class TransactionBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Customer transaction unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

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
	/// Domain events raised by this entity.
	/// </summary>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
	protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Transaction transaction)
	{
		InternalDomainEvents.Add(new TransactionCreated(transaction));
	}
	
	protected virtual void InternalRaiseUpdateEvent(Transaction transaction)
	{
		InternalDomainEvents.Add(new TransactionUpdated(transaction));
	}
	
	protected virtual void InternalRaiseDeleteEvent(Transaction transaction)
	{
		InternalDomainEvents.Add(new TransactionDeleted(transaction));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

    /// <summary>
    /// Transaction for ExactlyOne Customers
    /// </summary>
    public virtual Customer TransactionForCustomer { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Customer
    /// </summary>
    public Nox.Types.AutoNumber TransactionForCustomerId { get; set; } = null!;

    public virtual void CreateRefToTransactionForCustomer(Customer relatedCustomer)
    {
        TransactionForCustomer = relatedCustomer;
    }

    public virtual void DeleteRefToTransactionForCustomer(Customer relatedCustomer)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTransactionForCustomer()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Transaction for ExactlyOne Bookings
    /// </summary>
    public virtual Booking TransactionForBooking { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Booking
    /// </summary>
    public Nox.Types.Guid TransactionForBookingId { get; set; } = null!;

    public virtual void CreateRefToTransactionForBooking(Booking relatedBooking)
    {
        TransactionForBooking = relatedBooking;
    }

    public virtual void DeleteRefToTransactionForBooking(Booking relatedBooking)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTransactionForBooking()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}