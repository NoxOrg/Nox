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

internal partial class Client : ClientBase, IEntityHaveDomainEvents
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
/// Record for Client created event.
/// </summary>
internal record ClientCreated(Client Client) :  IDomainEvent, INotification;
/// <summary>
/// Record for Client updated event.
/// </summary>
internal record ClientUpdated(Client Client) : IDomainEvent, INotification;
/// <summary>
/// Record for Client deleted event.
/// </summary>
internal record ClientDeleted(Client Client) : IDomainEvent, INotification;

/// <summary>
/// Client of a Store.
/// </summary>
internal abstract partial class ClientBase : AuditableEntityBase, IEntityConcurrent
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
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Client client)
	{
		InternalDomainEvents.Add(new ClientCreated(client));
    }
	
	protected virtual void InternalRaiseUpdateEvent(Client client)
	{
		InternalDomainEvents.Add(new ClientUpdated(client));
    }
	
	protected virtual void InternalRaiseDeleteEvent(Client client)
	{
		InternalDomainEvents.Add(new ClientDeleted(client));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// Client Buys in this Store ZeroOrMany Stores
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
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}