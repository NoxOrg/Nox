// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;

internal partial class Customer : CustomerBase, IEntityHaveDomainEvents
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
/// Record for Customer created event.
/// </summary>
internal record CustomerCreated(Customer Customer) : IDomainEvent;
/// <summary>
/// Record for Customer updated event.
/// </summary>
internal record CustomerUpdated(Customer Customer) : IDomainEvent;
/// <summary>
/// Record for Customer deleted event.
/// </summary>
internal record CustomerDeleted(Customer Customer) : IDomainEvent;

/// <summary>
/// Customer definition and related data.
/// </summary>
internal abstract class CustomerBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Customer's unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Customer's first name (Required).
    /// </summary>
    public Nox.Types.Text FirstName { get; set; } = null!;

    /// <summary>
    /// Customer's last name (Required).
    /// </summary>
    public Nox.Types.Text LastName { get; set; } = null!;

    /// <summary>
    /// Customer's email address (Required).
    /// </summary>
    public Nox.Types.Email EmailAddress { get; set; } = null!;

    /// <summary>
    /// Customer's street address (Required).
    /// </summary>
    public Nox.Types.StreetAddress Address { get; set; } = null!;

    /// <summary>
    /// Customer's mobile number (Optional).
    /// </summary>
    public Nox.Types.PhoneNumber? MobileNumber { get; set; } = null!;
	/// <summary>
	/// Domain events raised by this entity.
	/// </summary>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
	protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Customer customer)
	{
		InternalDomainEvents.Add(new CustomerCreated(customer));
	}
	
	protected virtual void InternalRaiseUpdateEvent(Customer customer)
	{
		InternalDomainEvents.Add(new CustomerUpdated(customer));
	}
	
	protected virtual void InternalRaiseDeleteEvent(Customer customer)
	{
		InternalDomainEvents.Add(new CustomerDeleted(customer));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

    /// <summary>
    /// Customer related to ZeroOrMany PaymentDetails
    /// </summary>
    public virtual List<PaymentDetail> CustomerRelatedPaymentDetails { get; private set; } = new();

    public virtual void CreateRefToCustomerRelatedPaymentDetails(PaymentDetail relatedPaymentDetail)
    {
        CustomerRelatedPaymentDetails.Add(relatedPaymentDetail);
    }

    public virtual void DeleteRefToCustomerRelatedPaymentDetails(PaymentDetail relatedPaymentDetail)
    {
        CustomerRelatedPaymentDetails.Remove(relatedPaymentDetail);
    }

    public virtual void DeleteAllRefToCustomerRelatedPaymentDetails()
    {
        CustomerRelatedPaymentDetails.Clear();
    }

    /// <summary>
    /// Customer related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> CustomerRelatedBookings { get; private set; } = new();

    public virtual void CreateRefToCustomerRelatedBookings(Booking relatedBooking)
    {
        CustomerRelatedBookings.Add(relatedBooking);
    }

    public virtual void DeleteRefToCustomerRelatedBookings(Booking relatedBooking)
    {
        CustomerRelatedBookings.Remove(relatedBooking);
    }

    public virtual void DeleteAllRefToCustomerRelatedBookings()
    {
        CustomerRelatedBookings.Clear();
    }

    /// <summary>
    /// Customer related to ZeroOrMany Transactions
    /// </summary>
    public virtual List<Transaction> CustomerRelatedTransactions { get; private set; } = new();

    public virtual void CreateRefToCustomerRelatedTransactions(Transaction relatedTransaction)
    {
        CustomerRelatedTransactions.Add(relatedTransaction);
    }

    public virtual void DeleteRefToCustomerRelatedTransactions(Transaction relatedTransaction)
    {
        CustomerRelatedTransactions.Remove(relatedTransaction);
    }

    public virtual void DeleteAllRefToCustomerRelatedTransactions()
    {
        CustomerRelatedTransactions.Clear();
    }

    /// <summary>
    /// Customer based in ExactlyOne Countries
    /// </summary>
    public virtual Country CustomerBaseCountry { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 CustomerBaseCountryId { get; set; } = null!;

    public virtual void CreateRefToCustomerBaseCountry(Country relatedCountry)
    {
        CustomerBaseCountry = relatedCountry;
    }

    public virtual void DeleteRefToCustomerBaseCountry(Country relatedCountry)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToCustomerBaseCountry()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}