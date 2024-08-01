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

public partial class SecondTestEntityOwnedRelationshipZeroOrOne : SecondTestEntityOwnedRelationshipZeroOrOneBase, IEntityHaveDomainEvents
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
/// Record for SecondTestEntityOwnedRelationshipZeroOrOne created event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrOneCreated(SecondTestEntityOwnedRelationshipZeroOrOne SecondTestEntityOwnedRelationshipZeroOrOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrOne updated event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrOneUpdated(SecondTestEntityOwnedRelationshipZeroOrOne SecondTestEntityOwnedRelationshipZeroOrOne) : IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrOne deleted event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrOneDeleted(SecondTestEntityOwnedRelationshipZeroOrOne SecondTestEntityOwnedRelationshipZeroOrOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
public abstract partial class SecondTestEntityOwnedRelationshipZeroOrOneBase : EntityBase, IOwnedEntity
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text TestEntityOwnedRelationshipZeroOrOneId { get;  set; } = null!;

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

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityOwnedRelationshipZeroOrOne secondTestEntityOwnedRelationshipZeroOrOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityOwnedRelationshipZeroOrOneCreated(secondTestEntityOwnedRelationshipZeroOrOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityOwnedRelationshipZeroOrOne secondTestEntityOwnedRelationshipZeroOrOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityOwnedRelationshipZeroOrOneUpdated(secondTestEntityOwnedRelationshipZeroOrOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityOwnedRelationshipZeroOrOne secondTestEntityOwnedRelationshipZeroOrOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityOwnedRelationshipZeroOrOneDeleted(secondTestEntityOwnedRelationshipZeroOrOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    
}