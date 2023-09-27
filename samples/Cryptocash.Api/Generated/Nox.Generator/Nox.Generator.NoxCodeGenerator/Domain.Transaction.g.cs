// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
internal partial class Transaction:TransactionBase
{

}
/// <summary>
/// Record for Transaction created event.
/// </summary>
public record TransactionCreated(TransactionBase Transaction) : IDomainEvent;
/// <summary>
/// Record for Transaction updated event.
/// </summary>
public record TransactionUpdated(TransactionBase Transaction) : IDomainEvent;
/// <summary>
/// Record for Transaction deleted event.
/// </summary>
public record TransactionDeleted(TransactionBase Transaction) : IDomainEvent;

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public abstract class TransactionBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new TransactionCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TransactionUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TransactionDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
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