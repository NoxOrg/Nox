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
internal record StoreOwnerCreated(StoreOwner StoreOwner) :  IDomainEvent, INotification;
/// <summary>
/// Record for StoreOwner updated event.
/// </summary>
internal record StoreOwnerUpdated(StoreOwner StoreOwner) : IDomainEvent, INotification;
/// <summary>
/// Record for StoreOwner deleted event.
/// </summary>
internal record StoreOwnerDeleted(StoreOwner StoreOwner) : IDomainEvent, INotification;

/// <summary>
/// Store owners.
/// </summary>
internal abstract partial class StoreOwnerBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    /// Owner Name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Temporary Owner Name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text TemporaryOwnerName { get; set; } = null!;

    /// <summary>
    /// Vat Number    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.VatNumber? VatNumber { get; set; } = null!;

    /// <summary>
    /// Street Address    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.StreetAddress? StreetAddress { get; set; } = null!;

    /// <summary>
    /// Owner Greeting    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.TranslatedText? LocalGreeting { get; set; } = null!;

    /// <summary>
    /// Notes    
    /// </summary>
    /// <remarks>Optional.</remarks>   
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
    /// StoreOwner Set of stores that this owner owns OneOrMany Stores
    /// </summary>
    public virtual List<Store> Stores { get; private set; } = new();

    public virtual void CreateRefToStores(Store relatedStore)
    {
        Stores.Add(relatedStore);
    }

    public virtual void UpdateRefToStores(List<Store> relatedStore)
    {
        if(relatedStore is null || relatedStore.Count < 2)
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        Stores.Clear();
        Stores.AddRange(relatedStore);
    }

    public virtual void DeleteRefToStores(Store relatedStore)
    {
        if(Stores.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        Stores.Remove(relatedStore);
    }

    public virtual void DeleteAllRefToStores()
    {
        if(Stores.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        Stores.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}