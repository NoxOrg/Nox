// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

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
internal abstract partial class StoreLicenseBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// License issuer (Required).
    /// </summary>
    public Nox.Types.Text Issuer { get; set; } = null!;
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
    public virtual Store StoreWithLicense { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Store
    /// </summary>
    public Nox.Types.Guid StoreWithLicenseId { get; set; } = null!;

    public virtual void CreateRefToStoreWithLicense(Store relatedStore)
    {
        StoreWithLicense = relatedStore;
    }

    public virtual void DeleteRefToStoreWithLicense(Store relatedStore)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToStoreWithLicense()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}