// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;

internal partial class SecondTestEntityOwnedRelationshipExactlyOne : SecondTestEntityOwnedRelationshipExactlyOneBase, IEntityHaveDomainEvents
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
/// Record for SecondTestEntityOwnedRelationshipExactlyOne created event.
/// </summary>
internal record SecondTestEntityOwnedRelationshipExactlyOneCreated(SecondTestEntityOwnedRelationshipExactlyOne SecondTestEntityOwnedRelationshipExactlyOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipExactlyOne updated event.
/// </summary>
internal record SecondTestEntityOwnedRelationshipExactlyOneUpdated(SecondTestEntityOwnedRelationshipExactlyOne SecondTestEntityOwnedRelationshipExactlyOne) : IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipExactlyOne deleted event.
/// </summary>
internal record SecondTestEntityOwnedRelationshipExactlyOneDeleted(SecondTestEntityOwnedRelationshipExactlyOne SecondTestEntityOwnedRelationshipExactlyOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class SecondTestEntityOwnedRelationshipExactlyOneBase : EntityBase, IOwnedEntity
{

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text TextTestField2 { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityOwnedRelationshipExactlyOne secondTestEntityOwnedRelationshipExactlyOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityOwnedRelationshipExactlyOneCreated(secondTestEntityOwnedRelationshipExactlyOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityOwnedRelationshipExactlyOne secondTestEntityOwnedRelationshipExactlyOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityOwnedRelationshipExactlyOneUpdated(secondTestEntityOwnedRelationshipExactlyOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityOwnedRelationshipExactlyOne secondTestEntityOwnedRelationshipExactlyOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityOwnedRelationshipExactlyOneDeleted(secondTestEntityOwnedRelationshipExactlyOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

}