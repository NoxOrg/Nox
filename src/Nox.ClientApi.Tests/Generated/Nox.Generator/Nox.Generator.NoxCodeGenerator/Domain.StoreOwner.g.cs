// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;
internal partial class StoreOwner:StoreOwnerBase
{

}
/// <summary>
/// Record for StoreOwner created event.
/// </summary>
public record StoreOwnerCreated(StoreOwnerBase StoreOwner) : IDomainEvent;
/// <summary>
/// Record for StoreOwner updated event.
/// </summary>
public record StoreOwnerUpdated(StoreOwnerBase StoreOwner) : IDomainEvent;
/// <summary>
/// Record for StoreOwner deleted event.
/// </summary>
public record StoreOwnerDeleted(StoreOwnerBase StoreOwner) : IDomainEvent;

/// <summary>
/// Store owners.
/// </summary>
public abstract class StoreOwnerBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    /// Owner Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Temporary Owner Name (Required).
    /// </summary>
    public Nox.Types.Text TemporaryOwnerName { get; set; } = null!;

    /// <summary>
    /// Vat Number (Optional).
    /// </summary>
    public Nox.Types.VatNumber? VatNumber { get; set; } = null!;

    /// <summary>
    /// Street Address (Optional).
    /// </summary>
    public Nox.Types.StreetAddress? StreetAddress { get; set; } = null!;

    /// <summary>
    /// Owner Greeting (Optional).
    /// </summary>
    public Nox.Types.TranslatedText? LocalGreeting { get; set; } = null!;

    /// <summary>
    /// Notes (Optional).
    /// </summary>
    public Nox.Types.Text? Notes { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new StoreOwnerCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new StoreOwnerUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new StoreOwnerDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// StoreOwner Set of stores that this owner owns ZeroOrMany Stores
    /// </summary>
    public virtual List<Store> Stores { get; private set; } = new();

    public virtual void CreateRefToStores(Store relatedStore)
    {
        Stores.Add(relatedStore);
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