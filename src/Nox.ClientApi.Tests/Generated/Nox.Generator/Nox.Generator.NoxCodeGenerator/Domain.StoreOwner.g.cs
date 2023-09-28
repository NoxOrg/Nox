// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;

internal partial class StoreOwner : StoreOwnerBase, IEntityHaveDomainEvents
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
/// Record for StoreOwner created event.
/// </summary>
internal record StoreOwnerCreated(StoreOwner StoreOwner) : IDomainEvent;
/// <summary>
/// Record for StoreOwner updated event.
/// </summary>
internal record StoreOwnerUpdated(StoreOwner StoreOwner) : IDomainEvent;
/// <summary>
/// Record for StoreOwner deleted event.
/// </summary>
internal record StoreOwnerDeleted(StoreOwner StoreOwner) : IDomainEvent;

/// <summary>
/// Store owners.
/// </summary>
internal abstract class StoreOwnerBase : AuditableEntityBase, IEntityConcurrent
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
	/// <summary>
	/// Domain events raised by this entity.
	/// </summary>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
	protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(StoreOwner storeOwner)
	{
		InternalDomainEvents.Add(new StoreOwnerCreated(storeOwner));
	}
	
	protected virtual void InternalRaiseUpdateEvent(StoreOwner storeOwner)
	{
		InternalDomainEvents.Add(new StoreOwnerUpdated(storeOwner));
	}
	
	protected virtual void InternalRaiseDeleteEvent(StoreOwner storeOwner)
	{
		InternalDomainEvents.Add(new StoreOwnerDeleted(storeOwner));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
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