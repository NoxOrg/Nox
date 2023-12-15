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

namespace Cryptocash.Domain;

internal partial class AProduct : AProductBase, IEntityHaveDomainEvents
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
/// Record for AProduct created event.
/// </summary>
internal record AProductCreated(AProduct AProduct) :  IDomainEvent, INotification;
/// <summary>
/// Record for AProduct updated event.
/// </summary>
internal record AProductUpdated(AProduct AProduct) : IDomainEvent, INotification;
/// <summary>
/// Record for AProduct deleted event.
/// </summary>
internal record AProductDeleted(AProduct AProduct) : IDomainEvent, INotification;

/// <summary>
/// ReferenceNumberEntity.
/// </summary>
internal abstract partial class AProductBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; private set; } = null!;

    /// <summary>
    /// ReferenceNumber    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Guid MyGuid { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(AProduct aProduct)
	{
		InternalDomainEvents.Add(new AProductCreated(aProduct));
    }
	
	protected virtual void InternalRaiseUpdateEvent(AProduct aProduct)
	{
		InternalDomainEvents.Add(new AProductUpdated(aProduct));
    }
	
	protected virtual void InternalRaiseDeleteEvent(AProduct aProduct)
	{
		InternalDomainEvents.Add(new AProductDeleted(aProduct));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}