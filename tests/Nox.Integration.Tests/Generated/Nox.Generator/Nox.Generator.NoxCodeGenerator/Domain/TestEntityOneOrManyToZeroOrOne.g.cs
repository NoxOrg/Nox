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
    public virtual List<TestEntityZeroOrOneToOneOrMany> TestEntityZeroOrOneToOneOrManies { get; private set; } = new();

    public virtual void CreateRefToTestEntityZeroOrOneToOneOrManies(TestEntityZeroOrOneToOneOrMany relatedTestEntityZeroOrOneToOneOrMany)
    {
        TestEntityZeroOrOneToOneOrManies.Add(relatedTestEntityZeroOrOneToOneOrMany);
    }

    public virtual void UpdateRefToTestEntityZeroOrOneToOneOrManies(List<TestEntityZeroOrOneToOneOrMany> relatedTestEntityZeroOrOneToOneOrMany)
    {
        if(!relatedTestEntityZeroOrOneToOneOrMany.HasAtLeastOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        TestEntityZeroOrOneToOneOrManies.Clear();
        TestEntityZeroOrOneToOneOrManies.AddRange(relatedTestEntityZeroOrOneToOneOrMany);
    }

    public virtual void DeleteRefToTestEntityZeroOrOneToOneOrManies(TestEntityZeroOrOneToOneOrMany relatedTestEntityZeroOrOneToOneOrMany)
    {
        if(TestEntityZeroOrOneToOneOrManies.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestEntityZeroOrOneToOneOrManies.Remove(relatedTestEntityZeroOrOneToOneOrMany);
    }

    public virtual void DeleteAllRefToTestEntityZeroOrOneToOneOrManies()
    {
        if(TestEntityZeroOrOneToOneOrManies.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestEntityZeroOrOneToOneOrManies.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}