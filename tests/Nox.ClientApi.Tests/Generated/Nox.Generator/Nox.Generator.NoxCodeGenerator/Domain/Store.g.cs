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

public partial class Store : StoreBase, IEntityHaveDomainEvents
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
public record StoreCreated(Store Store) :  IDomainEvent, INotification;
/// <summary>
/// Record for Store updated event.
/// </summary>
public record StoreUpdated(Store Store) : IDomainEvent, INotification;
/// <summary>
/// Record for Store deleted event.
/// </summary>
public record StoreDeleted(Store Store) : IDomainEvent, INotification;

/// <summary>
/// Stores.
/// </summary>
public abstract partial class StoreBase : AuditableEntityBase, IEtag
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Guid Id {get; private set;} = null!;
        /// <summary>
        /// Ensures that a Guid Id is set or will be generate a new one
        /// </summary>
    	public virtual void EnsureId(System.Guid? guid)
    	{
    		if(guid is null || System.Guid.Empty.Equals(guid))
    		{
    			Id = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			Id = Nox.Types.Guid.From(guid!.Value);
    		}
    	}

    /// <summary>
    /// Store Name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get;  set; } = null!;

    /// <summary>
    /// Street Address    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.StreetAddress Address { get;  set; } = null!;

    /// <summary>
    /// Location    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.LatLong Location { get;  set; } = null!;

    /// <summary>
    /// Opening day    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.DateTime? OpeningDay { get;  set; } = null!;

    /// <summary>
    /// Store Status    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Enumeration? Status { get;  set; } = null!;
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
    /// Store country where the store is located ZeroOrOne Countries
    /// </summary>
    public virtual Country? Country { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity Country
    /// </summary>
    public Nox.Types.AutoNumber? CountryId { get; set; } = null!;

    public virtual void CreateRefToCountry(Country relatedCountry)
    {
        Country = relatedCountry;
    }

    public virtual void DeleteRefToCountry(Country relatedCountry)
    {
        Country = null;
    }

    public virtual void DeleteAllRefToCountry()
    {
        CountryId = null;
    }

    /// <summary>
    /// Store Owner of the Store ZeroOrOne StoreOwners
    /// </summary>
    public virtual StoreOwner? StoreOwner { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity StoreOwner
    /// </summary>
    public Nox.Types.Text? StoreOwnerId { get; set; } = null!;

    public virtual void CreateRefToStoreOwner(StoreOwner relatedStoreOwner)
    {
        StoreOwner = relatedStoreOwner;
    }

    public virtual void DeleteRefToStoreOwner(StoreOwner relatedStoreOwner)
    {
        StoreOwner = null;
    }

    public virtual void DeleteAllRefToStoreOwner()
    {
        StoreOwnerId = null;
    }

    /// <summary>
    /// Store License that this store uses ZeroOrOne StoreLicenses
    /// </summary>
    public virtual StoreLicense? StoreLicense { get; private set; } = null!;

    public virtual void CreateRefToStoreLicense(StoreLicense relatedStoreLicense)
    {
        StoreLicense = relatedStoreLicense;
    }

    public virtual void DeleteRefToStoreLicense(StoreLicense relatedStoreLicense)
    {
        StoreLicense = null;
    }

    public virtual void DeleteAllRefToStoreLicense()
    {
        StoreLicense = null;
    }

    /// <summary>
    /// Store clients of the store ZeroOrMany Clients
    /// </summary>
    public virtual List<Client> Clients { get; private set; } = new();

    public virtual void CreateRefToClients(Client relatedClient)
    {
        Clients.Add(relatedClient);
    }

    public virtual void UpdateRefToClients(List<Client> relatedClient)
    {
        Clients.Clear();
        Clients.AddRange(relatedClient);
    }

    public virtual void DeleteRefToClients(Client relatedClient)
    {
        Clients.Remove(relatedClient);
    }

    public virtual void DeleteAllRefToClients()
    {
        Clients.Clear();
    }

    /// <summary>
    /// Store franchise stores ZeroOrMany Stores
    /// </summary>
    public virtual List<Store> Stores { get; private set; } = new();

    public virtual void CreateRefToStores(Store relatedStore)
    {
        Stores.Add(relatedStore);
    }

    public virtual void UpdateRefToStores(List<Store> relatedStore)
    {
        Stores.Clear();
        Stores.AddRange(relatedStore);
    }

    public virtual void DeleteRefToStores(Store relatedStore)
    {
        Stores.Remove(relatedStore);
    }

    public virtual void DeleteAllRefToStores()
    {
        Stores.Clear();
    }﻿

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public virtual EmailAddress? EmailAddress { get; private set; }
    
    /// <summary>
    /// Creates a new EmailAddress entity.
    /// </summary>
    public virtual void CreateRefToEmailAddress(EmailAddress relatedEmailAddress)
    {
        EmailAddress = relatedEmailAddress;
    }
    
    /// <summary>
    /// Deletes owned EmailAddress entity.
    /// </summary>
    public virtual void DeleteRefToEmailAddress(EmailAddress relatedEmailAddress)
    {
        EmailAddress = null;
    }
    
    /// <summary>
    /// Deletes all owned EmailAddress entities.
    /// </summary>
    public virtual void DeleteAllRefToEmailAddress()
    {
        EmailAddress = null;
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}