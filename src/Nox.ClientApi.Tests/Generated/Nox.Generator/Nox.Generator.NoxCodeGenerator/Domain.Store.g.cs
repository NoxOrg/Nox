// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace ClientApi.Domain;
internal partial class Store:StoreBase
{

}
/// <summary>
/// Record for Store created event.
/// </summary>
internal record StoreCreated(Store Store) : IDomainEvent;
/// <summary>
/// Record for Store updated event.
/// </summary>
internal record StoreUpdated(Store Store) : IDomainEvent;
/// <summary>
/// Record for Store deleted event.
/// </summary>
internal record StoreDeleted(Store Store) : IDomainEvent;

/// <summary>
/// Stores.
/// </summary>
internal abstract class StoreBase : AuditableEntityBase, IEntityConcurrent
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