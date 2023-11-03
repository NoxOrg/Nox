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

internal partial class PaymentProvider : PaymentProviderBase, IEntityHaveDomainEvents
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
/// Record for PaymentProvider created event.
/// </summary>
internal record PaymentProviderCreated(PaymentProvider PaymentProvider) :  IDomainEvent, INotification;
/// <summary>
/// Record for PaymentProvider updated event.
/// </summary>
internal record PaymentProviderUpdated(PaymentProvider PaymentProvider) : IDomainEvent, INotification;
/// <summary>
/// Record for PaymentProvider deleted event.
/// </summary>
internal record PaymentProviderDeleted(PaymentProvider PaymentProvider) : IDomainEvent, INotification;

/// <summary>
/// Payment provider related data.
/// </summary>
internal abstract partial class PaymentProviderBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Payment provider unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Payment provider name (Required).
    /// </summary>
    public Nox.Types.Text PaymentProviderName { get; set; } = null!;

    /// <summary>
    /// Payment provider account type (Required).
    /// </summary>
    public Nox.Types.Text PaymentProviderType { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(PaymentProvider paymentProvider)
	{
		InternalDomainEvents.Add(new PaymentProviderCreated(paymentProvider));
    }
	
	protected virtual void InternalRaiseUpdateEvent(PaymentProvider paymentProvider)
	{
		InternalDomainEvents.Add(new PaymentProviderUpdated(paymentProvider));
    }
	
	protected virtual void InternalRaiseDeleteEvent(PaymentProvider paymentProvider)
	{
		InternalDomainEvents.Add(new PaymentProviderDeleted(paymentProvider));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// PaymentProvider related to ZeroOrMany PaymentDetails
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
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}