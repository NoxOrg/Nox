// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
internal partial class PaymentProvider:PaymentProviderBase
{

}
/// <summary>
/// Record for PaymentProvider created event.
/// </summary>
public record PaymentProviderCreated(PaymentProviderBase PaymentProvider) : IDomainEvent;
/// <summary>
/// Record for PaymentProvider updated event.
/// </summary>
public record PaymentProviderUpdated(PaymentProviderBase PaymentProvider) : IDomainEvent;
/// <summary>
/// Record for PaymentProvider deleted event.
/// </summary>
public record PaymentProviderDeleted(PaymentProviderBase PaymentProvider) : IDomainEvent;

/// <summary>
/// Payment provider related data.
/// </summary>
public abstract class PaymentProviderBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new PaymentProviderCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new PaymentProviderUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new PaymentProviderDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// PaymentProvider related to ZeroOrMany PaymentDetails
    /// </summary>
    public virtual List<PaymentDetail> PaymentProviderRelatedPaymentDetails { get; private set; } = new();

    public virtual void CreateRefToPaymentProviderRelatedPaymentDetails(PaymentDetail relatedPaymentDetail)
    {
        PaymentProviderRelatedPaymentDetails.Add(relatedPaymentDetail);
    }

    public virtual void DeleteRefToPaymentProviderRelatedPaymentDetails(PaymentDetail relatedPaymentDetail)
    {
        PaymentProviderRelatedPaymentDetails.Remove(relatedPaymentDetail);
    }

    public virtual void DeleteAllRefToPaymentProviderRelatedPaymentDetails()
    {
        PaymentProviderRelatedPaymentDetails.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}