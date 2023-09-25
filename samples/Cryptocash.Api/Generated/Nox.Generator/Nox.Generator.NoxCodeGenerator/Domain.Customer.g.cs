// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class Customer:CustomerBase
{

}
/// <summary>
/// Record for Customer created event.
/// </summary>
public record CustomerCreated(CustomerBase Customer) : IDomainEvent;
/// <summary>
/// Record for Customer updated event.
/// </summary>
public record CustomerUpdated(CustomerBase Customer) : IDomainEvent;
/// <summary>
/// Record for Customer deleted event.
/// </summary>
public record CustomerDeleted(CustomerBase Customer) : IDomainEvent;

/// <summary>
/// Customer definition and related data.
/// </summary>
public abstract class CustomerBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new CustomerCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new CustomerUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new CustomerDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
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