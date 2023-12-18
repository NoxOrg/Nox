// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;

namespace Cryptocash.Domain;

internal partial class Booking : BookingBase, IEntityHaveDomainEvents
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
/// Record for Booking created event.
/// </summary>
internal record BookingCreated(Booking Booking) :  IDomainEvent, INotification;
/// <summary>
/// Record for Booking updated event.
/// </summary>
internal record BookingUpdated(Booking Booking) : IDomainEvent, INotification;
/// <summary>
/// Record for Booking deleted event.
/// </summary>
internal record BookingDeleted(Booking Booking) : IDomainEvent, INotification;

/// <summary>
/// Exchange booking and related data.
/// </summary>
internal abstract partial class BookingBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Booking unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Guid Id {get; private set;} = null!;
        /// <summary>
        /// Ensures that a Guid Id is set or will be generate a new one
        /// </summary>
    	public virtual void EnsureId(System.Guid? guid)
    	{
    		if(guid is null || System.Guid.Empty.Equals(guid))
    		{
    			Id = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			Id = Nox.Types.Guid.From(guid!.Value);
    		}
    	}

    /// <summary>
    /// Booking's amount exchanged from    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Money AmountFrom { get;  set; } = null!;

    /// <summary>
    /// Booking's amount exchanged to    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Money AmountTo { get;  set; } = null!;

    /// <summary>
    /// Booking's requested pick up date    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.DateTimeRange RequestedPickUpDate { get;  set; } = null!;

    /// <summary>
    /// Booking's actual pick up date    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.DateTimeRange? PickedUpDateTime { get;  set; } = null!;

    /// <summary>
    /// Booking's expiry date    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.DateTime? ExpiryDateTime { get;  set; } = null!;

    /// <summary>
    /// Booking's cancelled date    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.DateTime? CancelledDateTime { get;  set; } = null!;

    /// <summary>
    /// Booking's status    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public string? Status
        { 
            get { return CancelledDateTime != null ? "cancelled" : (PickedUpDateTime != null ? "picked-up" : (ExpiryDateTime != null ? "expired" : "booked")); }
            private set { }
        }

    /// <summary>
    /// Booking's related vat number    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.VatNumber? VatNumber { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Booking booking)
	{
		InternalDomainEvents.Add(new BookingCreated(booking));
    }
	
	protected virtual void InternalRaiseUpdateEvent(Booking booking)
	{
		InternalDomainEvents.Add(new BookingUpdated(booking));
    }
	
	protected virtual void InternalRaiseDeleteEvent(Booking booking)
	{
		InternalDomainEvents.Add(new BookingDeleted(booking));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// Booking for ExactlyOne Customers
    /// </summary>
    public virtual Customer Customer { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Customer
    /// </summary>
    public Nox.Types.Guid CustomerId { get; set; } = null!;

    public virtual void CreateRefToCustomer(Customer relatedCustomer)
    {
        Customer = relatedCustomer;
    }

    public virtual void DeleteRefToCustomer(Customer relatedCustomer)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToCustomer()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Booking related to ExactlyOne VendingMachines
    /// </summary>
    public virtual VendingMachine VendingMachine { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity VendingMachine
    /// </summary>
    public Nox.Types.Guid VendingMachineId { get; set; } = null!;

    public virtual void CreateRefToVendingMachine(VendingMachine relatedVendingMachine)
    {
        VendingMachine = relatedVendingMachine;
    }

    public virtual void DeleteRefToVendingMachine(VendingMachine relatedVendingMachine)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToVendingMachine()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Booking fees for ExactlyOne Commissions
    /// </summary>
    public virtual Commission Commission { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Commission
    /// </summary>
    public Nox.Types.Guid CommissionId { get; set; } = null!;

    public virtual void CreateRefToCommission(Commission relatedCommission)
    {
        Commission = relatedCommission;
    }

    public virtual void DeleteRefToCommission(Commission relatedCommission)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToCommission()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Booking related to ExactlyOne Transactions
    /// </summary>
    public virtual Transaction Transaction { get; private set; } = null!;

    public virtual void CreateRefToTransaction(Transaction relatedTransaction)
    {
        Transaction = relatedTransaction;
    }

    public virtual void DeleteRefToTransaction(Transaction relatedTransaction)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTransaction()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}