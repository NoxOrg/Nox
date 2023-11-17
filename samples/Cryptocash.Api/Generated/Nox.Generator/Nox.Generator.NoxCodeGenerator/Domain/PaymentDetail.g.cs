// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;

internal partial class PaymentDetail : PaymentDetailBase, IEntityHaveDomainEvents
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
/// Record for PaymentDetail created event.
/// </summary>
internal record PaymentDetailCreated(PaymentDetail PaymentDetail) :  IDomainEvent, INotification;
/// <summary>
/// Record for PaymentDetail updated event.
/// </summary>
internal record PaymentDetailUpdated(PaymentDetail PaymentDetail) : IDomainEvent, INotification;
/// <summary>
/// Record for PaymentDetail deleted event.
/// </summary>
internal record PaymentDetailDeleted(PaymentDetail PaymentDetail) : IDomainEvent, INotification;

/// <summary>
/// Customer payment account related data.
/// </summary>
internal abstract partial class PaymentDetailBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Customer payment account unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Payment account name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text PaymentAccountName { get; set; } = null!;

    /// <summary>
    /// Payment account reference number    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text PaymentAccountNumber { get; set; } = null!;

    /// <summary>
    /// Payment account sort code    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? PaymentAccountSortCode { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(PaymentDetail paymentDetail)
	{
		InternalDomainEvents.Add(new PaymentDetailCreated(paymentDetail));
    }
	
	protected virtual void InternalRaiseUpdateEvent(PaymentDetail paymentDetail)
	{
		InternalDomainEvents.Add(new PaymentDetailUpdated(paymentDetail));
    }
	
	protected virtual void InternalRaiseDeleteEvent(PaymentDetail paymentDetail)
	{
		InternalDomainEvents.Add(new PaymentDetailDeleted(paymentDetail));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// PaymentDetail used by ExactlyOne Customers
    /// </summary>
    public virtual Customer Customer { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Customer
    /// </summary>
    public Nox.Types.AutoNumber CustomerId { get; set; } = null!;

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
    /// PaymentDetail related to ExactlyOne PaymentProviders
    /// </summary>
    public virtual PaymentProvider PaymentProvider { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity PaymentProvider
    /// </summary>
    public Nox.Types.AutoNumber PaymentProviderId { get; set; } = null!;

    public virtual void CreateRefToPaymentProvider(PaymentProvider relatedPaymentProvider)
    {
        PaymentProvider = relatedPaymentProvider;
    }

    public virtual void DeleteRefToPaymentProvider(PaymentProvider relatedPaymentProvider)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToPaymentProvider()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}