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

namespace ClientApi.Domain;

internal partial class StoreLicense : StoreLicenseBase, IEntityHaveDomainEvents
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
/// Record for StoreLicense created event.
/// </summary>
internal record StoreLicenseCreated(StoreLicense StoreLicense) :  IDomainEvent, INotification;
/// <summary>
/// Record for StoreLicense updated event.
/// </summary>
internal record StoreLicenseUpdated(StoreLicense StoreLicense) : IDomainEvent, INotification;
/// <summary>
/// Record for StoreLicense deleted event.
/// </summary>
internal record StoreLicenseDeleted(StoreLicense StoreLicense) : IDomainEvent, INotification;

/// <summary>
/// Store license info.
/// </summary>
internal abstract partial class StoreLicenseBase : AuditableEntityBase, IEtag
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; private set; } = null!;

    /// <summary>
    /// License issuer    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Issuer { get;  set; } = null!;

    /// <summary>
    /// License external id    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber ExternalId { get; private set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(StoreLicense storeLicense)
	{
		InternalDomainEvents.Add(new StoreLicenseCreated(storeLicense));
    }
	
	protected virtual void InternalRaiseUpdateEvent(StoreLicense storeLicense)
	{
		InternalDomainEvents.Add(new StoreLicenseUpdated(storeLicense));
    }
	
	protected virtual void InternalRaiseDeleteEvent(StoreLicense storeLicense)
	{
		InternalDomainEvents.Add(new StoreLicenseDeleted(storeLicense));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// StoreLicense Store that this license related to ExactlyOne Stores
    /// </summary>
    public virtual Store Store { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Store
    /// </summary>
    public Nox.Types.Guid StoreId { get; set; } = null!;

    public virtual void CreateRefToStore(Store relatedStore)
    {
        Store = relatedStore;
    }

    public virtual void DeleteRefToStore(Store relatedStore)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToStore()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// StoreLicense Default currency for this license ZeroOrOne Currencies
    /// </summary>
    public virtual Currency? DefaultCurrency { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity Currency
    /// </summary>
    public Nox.Types.CurrencyCode3? DefaultCurrencyId { get; set; } = null!;

    public virtual void CreateRefToDefaultCurrency(Currency relatedCurrency)
    {
        DefaultCurrency = relatedCurrency;
    }

    public virtual void DeleteRefToDefaultCurrency(Currency relatedCurrency)
    {
        DefaultCurrency = null;
    }

    public virtual void DeleteAllRefToDefaultCurrency()
    {
        DefaultCurrencyId = null;
    }

    /// <summary>
    /// StoreLicense Currency this license was sold in ZeroOrOne Currencies
    /// </summary>
    public virtual Currency? SoldInCurrency { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity Currency
    /// </summary>
    public Nox.Types.CurrencyCode3? SoldInCurrencyId { get; set; } = null!;

    public virtual void CreateRefToSoldInCurrency(Currency relatedCurrency)
    {
        SoldInCurrency = relatedCurrency;
    }

    public virtual void DeleteRefToSoldInCurrency(Currency relatedCurrency)
    {
        SoldInCurrency = null;
    }

    public virtual void DeleteAllRefToSoldInCurrency()
    {
        SoldInCurrencyId = null;
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}