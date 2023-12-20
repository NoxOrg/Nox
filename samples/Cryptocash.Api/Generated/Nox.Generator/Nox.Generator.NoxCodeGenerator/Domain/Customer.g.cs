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
using Nox.Exceptions;

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
internal record CustomerCreated(Customer Customer) :  IDomainEvent, INotification;
/// <summary>
/// Record for Customer updated event.
/// </summary>
internal record CustomerUpdated(Customer Customer) : IDomainEvent, INotification;
/// <summary>
/// Record for Customer deleted event.
/// </summary>
internal record CustomerDeleted(Customer Customer) : IDomainEvent, INotification;

/// <summary>
/// Customer definition and related data.
/// </summary>
internal abstract partial class CustomerBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Customer's unique identifier    
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
    /// Customer's first name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text FirstName { get;  set; } = null!;

    /// <summary>
    /// Customer's last name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text LastName { get;  set; } = null!;

    /// <summary>
    /// Customer's email address    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Email EmailAddress { get;  set; } = null!;

    /// <summary>
    /// Customer's street address    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.StreetAddress Address { get;  set; } = null!;

    /// <summary>
    /// Customer's mobile number    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.PhoneNumber? MobileNumber { get;  set; } = null!;
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
    public virtual List<PaymentDetail> PaymentDetails { get; private set; } = new();

    public virtual void CreateRefToPaymentDetails(PaymentDetail relatedPaymentDetail)
    {
        PaymentDetails.Add(relatedPaymentDetail);
    }

    public virtual void UpdateRefToPaymentDetails(List<PaymentDetail> relatedPaymentDetail)
    {
        PaymentDetails.Clear();
        PaymentDetails.AddRange(relatedPaymentDetail);
    }

    public virtual void DeleteRefToPaymentDetails(PaymentDetail relatedPaymentDetail)
    {
        PaymentDetails.Remove(relatedPaymentDetail);
    }

    public virtual void DeleteAllRefToPaymentDetails()
    {
        PaymentDetails.Clear();
    }

    /// <summary>
    /// Customer related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> Bookings { get; private set; } = new();

    public virtual void CreateRefToBookings(Booking relatedBooking)
    {
        Bookings.Add(relatedBooking);
    }

    public virtual void UpdateRefToBookings(List<Booking> relatedBooking)
    {
        Bookings.Clear();
        Bookings.AddRange(relatedBooking);
    }

    public virtual void DeleteRefToBookings(Booking relatedBooking)
    {
        Bookings.Remove(relatedBooking);
    }

    public virtual void DeleteAllRefToBookings()
    {
        Bookings.Clear();
    }

    /// <summary>
    /// Customer related to ZeroOrMany Transactions
    /// </summary>
    public virtual List<Transaction> Transactions { get; private set; } = new();

    public virtual void CreateRefToTransactions(Transaction relatedTransaction)
    {
        Transactions.Add(relatedTransaction);
    }

    public virtual void UpdateRefToTransactions(List<Transaction> relatedTransaction)
    {
        Transactions.Clear();
        Transactions.AddRange(relatedTransaction);
    }

    public virtual void DeleteRefToTransactions(Transaction relatedTransaction)
    {
        Transactions.Remove(relatedTransaction);
    }

    public virtual void DeleteAllRefToTransactions()
    {
        Transactions.Clear();
    }

    /// <summary>
    /// Customer based in ExactlyOne Countries
    /// </summary>
    public virtual Country Country { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 CountryId { get; set; } = null!;

    public virtual void CreateRefToCountry(Country relatedCountry)
    {
        Country = relatedCountry;
    }

    public virtual void DeleteRefToCountry(Country relatedCountry)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToCountry()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}