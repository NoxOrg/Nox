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

internal partial class TestEntityExactlyOneToZeroOrOne : TestEntityExactlyOneToZeroOrOneBase, IEntityHaveDomainEvents
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
/// Record for TestEntityExactlyOneToZeroOrOne created event.
/// </summary>
internal record TestEntityExactlyOneToZeroOrOneCreated(TestEntityExactlyOneToZeroOrOne TestEntityExactlyOneToZeroOrOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrOne updated event.
/// </summary>
internal record TestEntityExactlyOneToZeroOrOneUpdated(TestEntityExactlyOneToZeroOrOne TestEntityExactlyOneToZeroOrOne) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrOne deleted event.
/// </summary>
internal record TestEntityExactlyOneToZeroOrOneDeleted(TestEntityExactlyOneToZeroOrOne TestEntityExactlyOneToZeroOrOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class TestEntityExactlyOneToZeroOrOneBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(TestEntityExactlyOneToZeroOrOne testEntityExactlyOneToZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityExactlyOneToZeroOrOneCreated(testEntityExactlyOneToZeroOrOne));
	}
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityExactlyOneToZeroOrOne testEntityExactlyOneToZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityExactlyOneToZeroOrOneUpdated(testEntityExactlyOneToZeroOrOne));
	}
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityExactlyOneToZeroOrOne testEntityExactlyOneToZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityExactlyOneToZeroOrOneDeleted(testEntityExactlyOneToZeroOrOne));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

    /// <summary>
    /// TestEntityExactlyOneToZeroOrOne Test entity relationship to TestEntityZeroOrOneToExactlyOne ExactlyOne TestEntityZeroOrOneToExactlyOnes
    /// </summary>
    public virtual TestEntityZeroOrOneToExactlyOne TestEntityZeroOrOneToExactlyOne { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity TestEntityZeroOrOneToExactlyOne
    /// </summary>
    public Nox.Types.Text TestEntityZeroOrOneToExactlyOneId { get; set; } = null!;

    public virtual void CreateRefToTestEntityZeroOrOneToExactlyOne(TestEntityZeroOrOneToExactlyOne relatedTestEntityZeroOrOneToExactlyOne)
    {
        TestEntityZeroOrOneToExactlyOne = relatedTestEntityZeroOrOneToExactlyOne;
    }

    public virtual void DeleteRefToTestEntityZeroOrOneToExactlyOne(TestEntityZeroOrOneToExactlyOne relatedTestEntityZeroOrOneToExactlyOne)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTestEntityZeroOrOneToExactlyOne()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}