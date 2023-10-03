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

internal partial class TestEntityOwnedRelationshipZeroOrMany : TestEntityOwnedRelationshipZeroOrManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityOwnedRelationshipZeroOrMany created event.
/// </summary>
internal record TestEntityOwnedRelationshipZeroOrManyCreated(TestEntityOwnedRelationshipZeroOrMany TestEntityOwnedRelationshipZeroOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrMany updated event.
/// </summary>
internal record TestEntityOwnedRelationshipZeroOrManyUpdated(TestEntityOwnedRelationshipZeroOrMany TestEntityOwnedRelationshipZeroOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrMany deleted event.
/// </summary>
internal record TestEntityOwnedRelationshipZeroOrManyDeleted(TestEntityOwnedRelationshipZeroOrMany TestEntityOwnedRelationshipZeroOrMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class TestEntityOwnedRelationshipZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField { get; set; } = null!;
	/// <summary>
	/// Domain events raised by this entity.
	/// </summary>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
	protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(TestEntityOwnedRelationshipZeroOrMany testEntityOwnedRelationshipZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipZeroOrManyCreated(testEntityOwnedRelationshipZeroOrMany));
	}
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityOwnedRelationshipZeroOrMany testEntityOwnedRelationshipZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipZeroOrManyUpdated(testEntityOwnedRelationshipZeroOrMany));
	}
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityOwnedRelationshipZeroOrMany testEntityOwnedRelationshipZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipZeroOrManyDeleted(testEntityOwnedRelationshipZeroOrMany));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

    /// <summary>
    /// TestEntityOwnedRelationshipZeroOrMany Test entity relationship to SecondTestEntityOwnedRelationshipZeroOrMany ZeroOrMany SecondTestEntityOwnedRelationshipZeroOrManies
    /// </summary>
    public virtual List<SecondTestEntityOwnedRelationshipZeroOrMany> SecondTestEntityOwnedRelationshipZeroOrMany { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}