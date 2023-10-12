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

internal partial class TestEntityOneOrManyToZeroOrMany : TestEntityOneOrManyToZeroOrManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityOneOrManyToZeroOrMany created event.
/// </summary>
internal record TestEntityOneOrManyToZeroOrManyCreated(TestEntityOneOrManyToZeroOrMany TestEntityOneOrManyToZeroOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrMany updated event.
/// </summary>
internal record TestEntityOneOrManyToZeroOrManyUpdated(TestEntityOneOrManyToZeroOrMany TestEntityOneOrManyToZeroOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrMany deleted event.
/// </summary>
internal record TestEntityOneOrManyToZeroOrManyDeleted(TestEntityOneOrManyToZeroOrMany TestEntityOneOrManyToZeroOrMany) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
internal abstract partial class TestEntityOneOrManyToZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(TestEntityOneOrManyToZeroOrMany testEntityOneOrManyToZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyToZeroOrManyCreated(testEntityOneOrManyToZeroOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityOneOrManyToZeroOrMany testEntityOneOrManyToZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyToZeroOrManyUpdated(testEntityOneOrManyToZeroOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityOneOrManyToZeroOrMany testEntityOneOrManyToZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyToZeroOrManyDeleted(testEntityOneOrManyToZeroOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityOneOrManyToZeroOrMany Test entity relationship to TestEntityZeroOrManyToOneOrMany OneOrMany TestEntityZeroOrManyToOneOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrManyToOneOrMany> TestEntityZeroOrManyToOneOrMany { get; private set; } = new();

    public virtual void CreateRefToTestEntityZeroOrManyToOneOrMany(TestEntityZeroOrManyToOneOrMany relatedTestEntityZeroOrManyToOneOrMany)
    {
        TestEntityZeroOrManyToOneOrMany.Add(relatedTestEntityZeroOrManyToOneOrMany);
    }

    public virtual void DeleteRefToTestEntityZeroOrManyToOneOrMany(TestEntityZeroOrManyToOneOrMany relatedTestEntityZeroOrManyToOneOrMany)
    {
        if(TestEntityZeroOrManyToOneOrMany.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestEntityZeroOrManyToOneOrMany.Remove(relatedTestEntityZeroOrManyToOneOrMany);
    }

    public virtual void DeleteAllRefToTestEntityZeroOrManyToOneOrMany()
    {
        if(TestEntityZeroOrManyToOneOrMany.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestEntityZeroOrManyToOneOrMany.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}