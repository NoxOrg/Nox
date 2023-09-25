// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;
public partial class Store:StoreBase
{

}
/// <summary>
/// Record for Store created event.
/// </summary>
public record StoreCreated(StoreBase Store) : IDomainEvent;
/// <summary>
/// Record for Store updated event.
/// </summary>
public record StoreUpdated(StoreBase Store) : IDomainEvent;
/// <summary>
/// Record for Store deleted event.
/// </summary>
public record StoreDeleted(StoreBase Store) : IDomainEvent;

/// <summary>
/// Stores.
/// </summary>
public abstract class StoreBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Guid Id {get; set;} = null!;
    
    	public virtual void EnsureId(System.Guid guid)
    	{
    		if(System.Guid.Empty.Equals(guid))
    		{
    			Id = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			var currentGuid = Nox.Types.Guid.From(guid);
    			if(Id != currentGuid)
    			{
    				throw new NoxGuidTypeException("Immutable guid property Id value is different since it has been initialized");
    			}
    		}
    	}

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Street Address (Required).
    /// </summary>
    public Nox.Types.StreetAddress Address { get; set; } = null!;

    /// <summary>
    /// Location (Required).
    /// </summary>
    public Nox.Types.LatLong Location { get; set; } = null!;

    /// <summary>
    /// Opening day (Optional).
    /// </summary>
    public Nox.Types.DateTime? OpeningDay { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new StoreCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new StoreUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new StoreDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// Store Owner of the Store ZeroOrOne StoreOwners
    /// </summary>
    public virtual StoreOwner? Ownership { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity StoreOwner
    /// </summary>
    public Nox.Types.Text? OwnershipId { get; set; } = null!;

    public virtual void CreateRefToOwnership(StoreOwner relatedStoreOwner)
    {
        Ownership = relatedStoreOwner;
    }

    public virtual void DeleteRefToOwnership(StoreOwner relatedStoreOwner)
    {
        Ownership = null;
    }

    public virtual void DeleteAllRefToOwnership()
    {
        OwnershipId = null;
    }

    /// <summary>
    /// Store License that this store uses ZeroOrOne StoreLicenses
    /// </summary>
    public virtual StoreLicense? License { get; private set; } = null!;

    public virtual void CreateRefToLicense(StoreLicense relatedStoreLicense)
    {
        License = relatedStoreLicense;
    }

    public virtual void DeleteRefToLicense(StoreLicense relatedStoreLicense)
    {
        License = null;
    }

    public virtual void DeleteAllRefToLicense()
    {
        License = null;
    }

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
     public virtual EmailAddress? VerifiedEmails { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}