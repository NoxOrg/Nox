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

namespace TestWebApp.Domain;

public partial class SecEntityOwnedRelExactlyOne : SecEntityOwnedRelExactlyOneBase, IEntityHaveDomainEvents
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
/// Record for SecEntityOwnedRelExactlyOne created event.
/// </summary>
public record SecEntityOwnedRelExactlyOneCreated(SecEntityOwnedRelExactlyOne SecEntityOwnedRelExactlyOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecEntityOwnedRelExactlyOne updated event.
/// </summary>
public record SecEntityOwnedRelExactlyOneUpdated(SecEntityOwnedRelExactlyOne SecEntityOwnedRelExactlyOne) : IDomainEvent, INotification;
/// <summary>
/// Record for SecEntityOwnedRelExactlyOne deleted event.
/// </summary>
public record SecEntityOwnedRelExactlyOneDeleted(SecEntityOwnedRelExactlyOne SecEntityOwnedRelExactlyOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
public abstract partial class SecEntityOwnedRelExactlyOneBase : EntityBase, IOwnedEntity
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text TestEntityOwnedRelationshipExactlyOneId { get;  set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text TextTestField2 { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(SecEntityOwnedRelExactlyOne secEntityOwnedRelExactlyOne)
	{
		InternalDomainEvents.Add(new SecEntityOwnedRelExactlyOneCreated(secEntityOwnedRelExactlyOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecEntityOwnedRelExactlyOne secEntityOwnedRelExactlyOne)
	{
		InternalDomainEvents.Add(new SecEntityOwnedRelExactlyOneUpdated(secEntityOwnedRelExactlyOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecEntityOwnedRelExactlyOne secEntityOwnedRelExactlyOne)
	{
		InternalDomainEvents.Add(new SecEntityOwnedRelExactlyOneDeleted(secEntityOwnedRelExactlyOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    
}