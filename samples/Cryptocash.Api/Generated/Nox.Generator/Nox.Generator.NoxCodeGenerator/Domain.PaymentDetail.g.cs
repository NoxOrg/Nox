// Generated

#nullable enable

using System;
using System.Collections.Generic;

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
internal record PaymentDetailCreated(PaymentDetail PaymentDetail) : IDomainEvent, MediatR.INotification;
/// <summary>
/// Record for PaymentDetail updated event.
/// </summary>
internal record PaymentDetailUpdated(PaymentDetail PaymentDetail) : IDomainEvent, MediatR.INotification;
/// <summary>
/// Record for PaymentDetail deleted event.
/// </summary>
internal record PaymentDetailDeleted(PaymentDetail PaymentDetail) : IDomainEvent, MediatR.INotification;

/// <summary>
/// Customer payment account related data.
/// </summary>
internal abstract partial class PaymentDetailBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Customer payment account unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Payment account name (Required).
    /// </summary>
    public Nox.Types.Text PaymentAccountName { get; set; } = null!;

    /// <summary>
    /// Payment account reference number (Required).
    /// </summary>
    public Nox.Types.Text PaymentAccountNumber { get; set; } = null!;

    /// <summary>
    /// Payment account sort code (Optional).
    /// </summary>
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
    public virtual Customer PaymentDetailsUsedByCustomer { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Customer
    /// </summary>
    public Nox.Types.AutoNumber PaymentDetailsUsedByCustomerId { get; set; } = null!;

    public virtual void CreateRefToPaymentDetailsUsedByCustomer(Customer relatedCustomer)
    {
        PaymentDetailsUsedByCustomer = relatedCustomer;
    }

    public virtual void DeleteRefToPaymentDetailsUsedByCustomer(Customer relatedCustomer)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToPaymentDetailsUsedByCustomer()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// PaymentDetail related to ExactlyOne PaymentProviders
    /// </summary>
    public virtual PaymentProvider PaymentDetailsRelatedPaymentProvider { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity PaymentProvider
    /// </summary>
    public Nox.Types.AutoNumber PaymentDetailsRelatedPaymentProviderId { get; set; } = null!;

    public virtual void CreateRefToPaymentDetailsRelatedPaymentProvider(PaymentProvider relatedPaymentProvider)
    {
        PaymentDetailsRelatedPaymentProvider = relatedPaymentProvider;
    }

    public virtual void DeleteRefToPaymentDetailsRelatedPaymentProvider(PaymentProvider relatedPaymentProvider)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToPaymentDetailsRelatedPaymentProvider()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}