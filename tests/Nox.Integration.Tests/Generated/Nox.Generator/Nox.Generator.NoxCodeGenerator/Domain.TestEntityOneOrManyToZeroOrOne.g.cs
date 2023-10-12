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

internal partial class TestEntityOneOrManyToZeroOrOne : TestEntityOneOrManyToZeroOrOneBase, IEntityHaveDomainEvents
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
/// Record for TestEntityOneOrManyToZeroOrOne created event.
/// </summary>
internal record TestEntityOneOrManyToZeroOrOneCreated(TestEntityOneOrManyToZeroOrOne TestEntityOneOrManyToZeroOrOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrOne updated event.
/// </summary>
internal record TestEntityOneOrManyToZeroOrOneUpdated(TestEntityOneOrManyToZeroOrOne TestEntityOneOrManyToZeroOrOne) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrOne deleted event.
/// </summary>
internal record TestEntityOneOrManyToZeroOrOneDeleted(TestEntityOneOrManyToZeroOrOne TestEntityOneOrManyToZeroOrOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class TestEntityOneOrManyToZeroOrOneBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(TestEntityOneOrManyToZeroOrOne testEntityOneOrManyToZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyToZeroOrOneCreated(testEntityOneOrManyToZeroOrOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityOneOrManyToZeroOrOne testEntityOneOrManyToZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyToZeroOrOneUpdated(testEntityOneOrManyToZeroOrOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityOneOrManyToZeroOrOne testEntityOneOrManyToZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyToZeroOrOneDeleted(testEntityOneOrManyToZeroOrOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityOneOrManyToZeroOrOne Test entity relationship to TestEntityZeroOrOneToOneOrMany OneOrMany TestEntityZeroOrOneToOneOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrOneToOneOrMany> TestEntityZeroOrOneToOneOrMany { get; private set; } = new();

    public virtual void CreateRefToTestEntityZeroOrOneToOneOrMany(TestEntityZeroOrOneToOneOrMany relatedTestEntityZeroOrOneToOneOrMany)
    {
        TestEntityZeroOrOneToOneOrMany.Add(relatedTestEntityZeroOrOneToOneOrMany);
    }

    public virtual void DeleteRefToTestEntityZeroOrOneToOneOrMany(TestEntityZeroOrOneToOneOrMany relatedTestEntityZeroOrOneToOneOrMany)
    {
        if(TestEntityZeroOrOneToOneOrMany.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestEntityZeroOrOneToOneOrMany.Remove(relatedTestEntityZeroOrOneToOneOrMany);
    }

    public virtual void DeleteAllRefToTestEntityZeroOrOneToOneOrMany()
    {
        if(TestEntityZeroOrOneToOneOrMany.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestEntityZeroOrOneToOneOrMany.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}