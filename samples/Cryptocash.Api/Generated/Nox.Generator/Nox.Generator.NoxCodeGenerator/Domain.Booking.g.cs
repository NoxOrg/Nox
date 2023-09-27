// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
internal partial class Booking:BookingBase
{

}
/// <summary>
/// Record for Booking created event.
/// </summary>
public record BookingCreated(BookingBase Booking) : IDomainEvent;
/// <summary>
/// Record for Booking updated event.
/// </summary>
public record BookingUpdated(BookingBase Booking) : IDomainEvent;
/// <summary>
/// Record for Booking deleted event.
/// </summary>
public record BookingDeleted(BookingBase Booking) : IDomainEvent;

/// <summary>
/// Exchange booking and related data.
/// </summary>
public abstract class BookingBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
{
    /// <summary>
    /// Booking unique identifier (Required).
    /// </summary>
    public Nox.Types.Guid Id {get; set;} = null!;
    
    	public virtual void EnsureId(System.Guid guid)
    	{
    		if(System.Guid.Empty.Equals(guid))
    		{
    			Id = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			var currentGuid = Nox.Types.Guid.From(guid);
    			if(Id != currentGuid)
    			{
    				throw new NoxGuidTypeException("Immutable guid property Id value is different since it has been initialized");
    			}
    		}
    	}

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
    public string? Status
    { 
        get { return CancelledDateTime != null ? "cancelled" : (PickedUpDateTime != null ? "picked-up" : (ExpiryDateTime != null ? "expired" : "booked")); }
        private set { }
    }

    /// <summary>
    /// Booking's related vat number (Optional).
    /// </summary>
    public Nox.Types.VatNumber? VatNumber { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new BookingCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new BookingUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new BookingDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// Booking for ExactlyOne Customers
    /// </summary>
    public virtual Customer BookingForCustomer { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Customer
    /// </summary>
    public Nox.Types.AutoNumber BookingForCustomerId { get; set; } = null!;

    public virtual void CreateRefToBookingForCustomer(Customer relatedCustomer)
    {
        BookingForCustomer = relatedCustomer;
    }

    public virtual void DeleteRefToBookingForCustomer(Customer relatedCustomer)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToBookingForCustomer()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Booking related to ExactlyOne VendingMachines
    /// </summary>
    public virtual VendingMachine BookingRelatedVendingMachine { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity VendingMachine
    /// </summary>
    public Nox.Types.Guid BookingRelatedVendingMachineId { get; set; } = null!;

    public virtual void CreateRefToBookingRelatedVendingMachine(VendingMachine relatedVendingMachine)
    {
        BookingRelatedVendingMachine = relatedVendingMachine;
    }

    public virtual void DeleteRefToBookingRelatedVendingMachine(VendingMachine relatedVendingMachine)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToBookingRelatedVendingMachine()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Booking fees for ExactlyOne Commissions
    /// </summary>
    public virtual Commission BookingFeesForCommission { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Commission
    /// </summary>
    public Nox.Types.AutoNumber BookingFeesForCommissionId { get; set; } = null!;

    public virtual void CreateRefToBookingFeesForCommission(Commission relatedCommission)
    {
        BookingFeesForCommission = relatedCommission;
    }

    public virtual void DeleteRefToBookingFeesForCommission(Commission relatedCommission)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToBookingFeesForCommission()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Booking related to ExactlyOne Transactions
    /// </summary>
    public virtual Transaction BookingRelatedTransaction { get; private set; } = null!;

    public virtual void CreateRefToBookingRelatedTransaction(Transaction relatedTransaction)
    {
        BookingRelatedTransaction = relatedTransaction;
    }

    public virtual void DeleteRefToBookingRelatedTransaction(Transaction relatedTransaction)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToBookingRelatedTransaction()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}