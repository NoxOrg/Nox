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

internal partial class TestEntityOneOrMany : TestEntityOneOrManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityOneOrMany created event.
/// </summary>
internal record TestEntityOneOrManyCreated(TestEntityOneOrMany TestEntityOneOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOneOrMany updated event.
/// </summary>
internal record TestEntityOneOrManyUpdated(TestEntityOneOrMany TestEntityOneOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOneOrMany deleted event.
/// </summary>
internal record TestEntityOneOrManyDeleted(TestEntityOneOrMany TestEntityOneOrMany) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
internal abstract partial class TestEntityOneOrManyBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text TextTestField { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(TestEntityOneOrMany testEntityOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyCreated(testEntityOneOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityOneOrMany testEntityOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyUpdated(testEntityOneOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityOneOrMany testEntityOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyDeleted(testEntityOneOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityOneOrMany Test entity relationship to SecondTestEntityOneOrMany OneOrMany SecondTestEntityOneOrManies
    /// </summary>
    public virtual List<SecondTestEntityOneOrMany> SecondTestEntityOneOrManies { get; private set; } = new();

    public virtual void CreateRefToSecondTestEntityOneOrManies(SecondTestEntityOneOrMany relatedSecondTestEntityOneOrMany)
    {
        SecondTestEntityOneOrManies.Add(relatedSecondTestEntityOneOrMany);
    }

    public virtual void UpdateRefToSecondTestEntityOneOrManies(List<SecondTestEntityOneOrMany> relatedSecondTestEntityOneOrMany)
    {
        if(relatedSecondTestEntityOneOrMany is null || relatedSecondTestEntityOneOrMany.Count < 2)
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        SecondTestEntityOneOrManies.Clear();
        SecondTestEntityOneOrManies.AddRange(relatedSecondTestEntityOneOrMany);
    }

    public virtual void DeleteRefToSecondTestEntityOneOrManies(SecondTestEntityOneOrMany relatedSecondTestEntityOneOrMany)
    {
        if(SecondTestEntityOneOrManies.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        SecondTestEntityOneOrManies.Remove(relatedSecondTestEntityOneOrMany);
    }

    public virtual void DeleteAllRefToSecondTestEntityOneOrManies()
    {
        if(SecondTestEntityOneOrManies.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        SecondTestEntityOneOrManies.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}