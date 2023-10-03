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

internal partial class TestEntityZeroOrManyToZeroOrOne : TestEntityZeroOrManyToZeroOrOneBase, IEntityHaveDomainEvents
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
/// Record for TestEntityZeroOrManyToZeroOrOne created event.
/// </summary>
internal record TestEntityZeroOrManyToZeroOrOneCreated(TestEntityZeroOrManyToZeroOrOne TestEntityZeroOrManyToZeroOrOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrManyToZeroOrOne updated event.
/// </summary>
internal record TestEntityZeroOrManyToZeroOrOneUpdated(TestEntityZeroOrManyToZeroOrOne TestEntityZeroOrManyToZeroOrOne) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrManyToZeroOrOne deleted event.
/// </summary>
internal record TestEntityZeroOrManyToZeroOrOneDeleted(TestEntityZeroOrManyToZeroOrOne TestEntityZeroOrManyToZeroOrOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class TestEntityZeroOrManyToZeroOrOneBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(TestEntityZeroOrManyToZeroOrOne testEntityZeroOrManyToZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrManyToZeroOrOneCreated(testEntityZeroOrManyToZeroOrOne));
	}
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityZeroOrManyToZeroOrOne testEntityZeroOrManyToZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrManyToZeroOrOneUpdated(testEntityZeroOrManyToZeroOrOne));
	}
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityZeroOrManyToZeroOrOne testEntityZeroOrManyToZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrManyToZeroOrOneDeleted(testEntityZeroOrManyToZeroOrOne));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

    /// <summary>
    /// TestEntityZeroOrManyToZeroOrOne Test entity relationship to TestEntityZeroOrOneToZeroOrMany ZeroOrMany TestEntityZeroOrOneToZeroOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrOneToZeroOrMany> TestEntityZeroOrOneToZeroOrMany { get; private set; } = new();

    public virtual void CreateRefToTestEntityZeroOrOneToZeroOrMany(TestEntityZeroOrOneToZeroOrMany relatedTestEntityZeroOrOneToZeroOrMany)
    {
        TestEntityZeroOrOneToZeroOrMany.Add(relatedTestEntityZeroOrOneToZeroOrMany);
    }

    public virtual void DeleteRefToTestEntityZeroOrOneToZeroOrMany(TestEntityZeroOrOneToZeroOrMany relatedTestEntityZeroOrOneToZeroOrMany)
    {
        TestEntityZeroOrOneToZeroOrMany.Remove(relatedTestEntityZeroOrOneToZeroOrMany);
    }

    public virtual void DeleteAllRefToTestEntityZeroOrOneToZeroOrMany()
    {
        TestEntityZeroOrOneToZeroOrMany.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}