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

internal partial class Store : StoreBase, IEntityHaveDomainEvents
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
/// Record for Store created event.
/// </summary>
internal record StoreCreated(Store Store) :  IDomainEvent, INotification;
/// <summary>
/// Record for Store updated event.
/// </summary>
internal record StoreUpdated(Store Store) : IDomainEvent, INotification;
/// <summary>
/// Record for Store deleted event.
/// </summary>
internal record StoreDeleted(Store Store) : IDomainEvent, INotification;

/// <summary>
/// Stores.
/// </summary>
internal abstract partial class StoreBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Guid Id {get; set;} = null!;
         /// <summary>
        /// Ensures that a Guid Id is set or will be generate a new one
        /// </summary>
    	public virtual void EnsureId(System.Guid guid)
    	{
    		if(System.Guid.Empty.Equals(guid))
    		{
    			Id = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			Id = Nox.Types.Guid.From(guid);
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
    /// Store Status (Optional).
    /// </summary>
    public Nox.Types.Enumeration? Status { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Store store)
	{
		InternalDomainEvents.Add(new StoreCreated(store));
    }
	
	protected virtual void InternalRaiseUpdateEvent(Store store)
	{
		InternalDomainEvents.Add(new StoreUpdated(store));
    }
	
	protected virtual void InternalRaiseDeleteEvent(Store store)
	{
		InternalDomainEvents.Add(new StoreDeleted(store));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
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
    public virtual EmailAddress? VerifiedEmails { get; private set; }
    
    /// <summary>
    /// Creates a new EmailAddress entity.
    /// </summary>
    public virtual void CreateRefToVerifiedEmails(EmailAddress relatedEmailAddress)
    {
        VerifiedEmails = relatedEmailAddress;
    }
    
    /// <summary>
    /// Deletes owned EmailAddress entity.
    /// </summary>
    public virtual void DeleteRefToVerifiedEmails(EmailAddress relatedEmailAddress)
    {
        VerifiedEmails = null;
    }
    
    /// <summary>
    /// Deletes all owned EmailAddress entities.
    /// </summary>
    public virtual void DeleteAllRefToVerifiedEmails()
    {
        VerifiedEmails = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}