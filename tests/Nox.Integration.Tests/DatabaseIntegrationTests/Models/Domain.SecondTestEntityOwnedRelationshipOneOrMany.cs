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

internal partial class SecondTestEntityOwnedRelationshipOneOrMany : SecondTestEntityOwnedRelationshipOneOrManyBase, IEntityHaveDomainEvents
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
/// Record for SecondTestEntityOwnedRelationshipOneOrMany created event.
/// </summary>
internal record SecondTestEntityOwnedRelationshipOneOrManyCreated(SecondTestEntityOwnedRelationshipOneOrMany SecondTestEntityOwnedRelationshipOneOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipOneOrMany updated event.
/// </summary>
internal record SecondTestEntityOwnedRelationshipOneOrManyUpdated(SecondTestEntityOwnedRelationshipOneOrMany SecondTestEntityOwnedRelationshipOneOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipOneOrMany deleted event.
/// </summary>
internal record SecondTestEntityOwnedRelationshipOneOrManyDeleted(SecondTestEntityOwnedRelationshipOneOrMany SecondTestEntityOwnedRelationshipOneOrMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class SecondTestEntityOwnedRelationshipOneOrManyBase : EntityBase, IOwnedEntity
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;
	/// <summary>
	/// Domain events raised by this entity.
	/// </summary>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
	protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityOwnedRelationshipOneOrMany secondTestEntityOwnedRelationshipOneOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityOwnedRelationshipOneOrManyCreated(secondTestEntityOwnedRelationshipOneOrMany));
	}
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityOwnedRelationshipOneOrMany secondTestEntityOwnedRelationshipOneOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityOwnedRelationshipOneOrManyUpdated(secondTestEntityOwnedRelationshipOneOrMany));
	}
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityOwnedRelationshipOneOrMany secondTestEntityOwnedRelationshipOneOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityOwnedRelationshipOneOrManyDeleted(secondTestEntityOwnedRelationshipOneOrMany));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

}