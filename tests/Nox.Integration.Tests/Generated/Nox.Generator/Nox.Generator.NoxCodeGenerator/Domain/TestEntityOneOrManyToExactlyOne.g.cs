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

internal partial class TestEntityOneOrManyToExactlyOne : TestEntityOneOrManyToExactlyOneBase, IEntityHaveDomainEvents
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
/// Record for TestEntityOneOrManyToExactlyOne created event.
/// </summary>
internal record TestEntityOneOrManyToExactlyOneCreated(TestEntityOneOrManyToExactlyOne TestEntityOneOrManyToExactlyOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOneOrManyToExactlyOne updated event.
/// </summary>
internal record TestEntityOneOrManyToExactlyOneUpdated(TestEntityOneOrManyToExactlyOne TestEntityOneOrManyToExactlyOne) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOneOrManyToExactlyOne deleted event.
/// </summary>
internal record TestEntityOneOrManyToExactlyOneDeleted(TestEntityOneOrManyToExactlyOne TestEntityOneOrManyToExactlyOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class TestEntityOneOrManyToExactlyOneBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// 
    /// <remarks>Required.</remarks>   
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    /// 
    /// <remarks>Required.</remarks>   
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(TestEntityOneOrManyToExactlyOne testEntityOneOrManyToExactlyOne)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyToExactlyOneCreated(testEntityOneOrManyToExactlyOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityOneOrManyToExactlyOne testEntityOneOrManyToExactlyOne)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyToExactlyOneUpdated(testEntityOneOrManyToExactlyOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityOneOrManyToExactlyOne testEntityOneOrManyToExactlyOne)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyToExactlyOneDeleted(testEntityOneOrManyToExactlyOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityOneOrManyToExactlyOne Test entity relationship to TestEntityExactlyOneToOneOrMany OneOrMany TestEntityExactlyOneToOneOrManies
    /// </summary>
    public virtual List<TestEntityExactlyOneToOneOrMany> TestEntityExactlyOneToOneOrManies { get; private set; } = new();

    public virtual void CreateRefToTestEntityExactlyOneToOneOrManies(TestEntityExactlyOneToOneOrMany relatedTestEntityExactlyOneToOneOrMany)
    {
        TestEntityExactlyOneToOneOrManies.Add(relatedTestEntityExactlyOneToOneOrMany);
    }

    public virtual void UpdateRefToTestEntityExactlyOneToOneOrManies(List<TestEntityExactlyOneToOneOrMany> relatedTestEntityExactlyOneToOneOrMany)
    {
        if(relatedTestEntityExactlyOneToOneOrMany is null || relatedTestEntityExactlyOneToOneOrMany.Count < 2)
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        TestEntityExactlyOneToOneOrManies.Clear();
        TestEntityExactlyOneToOneOrManies.AddRange(relatedTestEntityExactlyOneToOneOrMany);
    }

    public virtual void DeleteRefToTestEntityExactlyOneToOneOrManies(TestEntityExactlyOneToOneOrMany relatedTestEntityExactlyOneToOneOrMany)
    {
        if(TestEntityExactlyOneToOneOrManies.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestEntityExactlyOneToOneOrManies.Remove(relatedTestEntityExactlyOneToOneOrMany);
    }

    public virtual void DeleteAllRefToTestEntityExactlyOneToOneOrManies()
    {
        if(TestEntityExactlyOneToOneOrManies.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestEntityExactlyOneToOneOrManies.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}