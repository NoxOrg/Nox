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

namespace TestWebApp.Domain;

internal partial class SecondTestEntityOwnedRelationshipZeroOrMany : SecondTestEntityOwnedRelationshipZeroOrManyBase, IEntityHaveDomainEvents
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
/// Record for SecondTestEntityOwnedRelationshipZeroOrMany created event.
/// </summary>
internal record SecondTestEntityOwnedRelationshipZeroOrManyCreated(SecondTestEntityOwnedRelationshipZeroOrMany SecondTestEntityOwnedRelationshipZeroOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrMany updated event.
/// </summary>
internal record SecondTestEntityOwnedRelationshipZeroOrManyUpdated(SecondTestEntityOwnedRelationshipZeroOrMany SecondTestEntityOwnedRelationshipZeroOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrMany deleted event.
/// </summary>
internal record SecondTestEntityOwnedRelationshipZeroOrManyDeleted(SecondTestEntityOwnedRelationshipZeroOrMany SecondTestEntityOwnedRelationshipZeroOrMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class SecondTestEntityOwnedRelationshipZeroOrManyBase : EntityBase, IOwnedEntity
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Id { get;  set; } = null!;

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

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityOwnedRelationshipZeroOrMany secondTestEntityOwnedRelationshipZeroOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityOwnedRelationshipZeroOrManyCreated(secondTestEntityOwnedRelationshipZeroOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityOwnedRelationshipZeroOrMany secondTestEntityOwnedRelationshipZeroOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityOwnedRelationshipZeroOrManyUpdated(secondTestEntityOwnedRelationshipZeroOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityOwnedRelationshipZeroOrMany secondTestEntityOwnedRelationshipZeroOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityOwnedRelationshipZeroOrManyDeleted(secondTestEntityOwnedRelationshipZeroOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

}