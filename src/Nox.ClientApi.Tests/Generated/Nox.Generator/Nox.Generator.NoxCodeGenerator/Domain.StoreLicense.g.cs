// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;
internal partial class StoreLicense:StoreLicenseBase
{

}
/// <summary>
/// Record for StoreLicense created event.
/// </summary>
internal record StoreLicenseCreated(StoreLicenseBase StoreLicense) : IDomainEvent;
/// <summary>
/// Record for StoreLicense updated event.
/// </summary>
internal record StoreLicenseUpdated(StoreLicenseBase StoreLicense) : IDomainEvent;
/// <summary>
/// Record for StoreLicense deleted event.
/// </summary>
internal record StoreLicenseDeleted(StoreLicenseBase StoreLicense) : IDomainEvent;

/// <summary>
/// Store license info.
/// </summary>
internal abstract class StoreLicenseBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// License issuer (Required).
    /// </summary>
    public Nox.Types.Text Issuer { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	protected readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new StoreLicenseCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new StoreLicenseUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new StoreLicenseDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
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