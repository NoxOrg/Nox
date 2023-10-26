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

internal partial class TestEntityTwoRelationshipsManyToMany : TestEntityTwoRelationshipsManyToManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityTwoRelationshipsManyToMany created event.
/// </summary>
internal record TestEntityTwoRelationshipsManyToManyCreated(TestEntityTwoRelationshipsManyToMany TestEntityTwoRelationshipsManyToMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityTwoRelationshipsManyToMany updated event.
/// </summary>
internal record TestEntityTwoRelationshipsManyToManyUpdated(TestEntityTwoRelationshipsManyToMany TestEntityTwoRelationshipsManyToMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityTwoRelationshipsManyToMany deleted event.
/// </summary>
internal record TestEntityTwoRelationshipsManyToManyDeleted(TestEntityTwoRelationshipsManyToMany TestEntityTwoRelationshipsManyToMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class TestEntityTwoRelationshipsManyToManyBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(TestEntityTwoRelationshipsManyToMany testEntityTwoRelationshipsManyToMany)
	{
		InternalDomainEvents.Add(new TestEntityTwoRelationshipsManyToManyCreated(testEntityTwoRelationshipsManyToMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityTwoRelationshipsManyToMany testEntityTwoRelationshipsManyToMany)
	{
		InternalDomainEvents.Add(new TestEntityTwoRelationshipsManyToManyUpdated(testEntityTwoRelationshipsManyToMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityTwoRelationshipsManyToMany testEntityTwoRelationshipsManyToMany)
	{
		InternalDomainEvents.Add(new TestEntityTwoRelationshipsManyToManyDeleted(testEntityTwoRelationshipsManyToMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityTwoRelationshipsManyToMany First relationship to the same entity OneOrMany SecondTestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsManyToMany> TestRelationshipOne { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipOne(SecondTestEntityTwoRelationshipsManyToMany relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipOne.Add(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void UpdateAllRefToTestRelationshipOne(List<SecondTestEntityTwoRelationshipsManyToMany> relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        if(relatedSecondTestEntityTwoRelationshipsManyToMany is null || relatedSecondTestEntityTwoRelationshipsManyToMany.Count < 2)
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        TestRelationshipOne.Clear();
        TestRelationshipOne.AddRange(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteRefToTestRelationshipOne(SecondTestEntityTwoRelationshipsManyToMany relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        if(TestRelationshipOne.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestRelationshipOne.Remove(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipOne()
    {
        if(TestRelationshipOne.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestRelationshipOne.Clear();
    }

    /// <summary>
    /// TestEntityTwoRelationshipsManyToMany Second relationship to the same entity OneOrMany SecondTestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsManyToMany> TestRelationshipTwo { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipTwo(SecondTestEntityTwoRelationshipsManyToMany relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipTwo.Add(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void UpdateAllRefToTestRelationshipTwo(List<SecondTestEntityTwoRelationshipsManyToMany> relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        if(relatedSecondTestEntityTwoRelationshipsManyToMany is null || relatedSecondTestEntityTwoRelationshipsManyToMany.Count < 2)
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        TestRelationshipTwo.Clear();
        TestRelationshipTwo.AddRange(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteRefToTestRelationshipTwo(SecondTestEntityTwoRelationshipsManyToMany relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        if(TestRelationshipTwo.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestRelationshipTwo.Remove(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipTwo()
    {
        if(TestRelationshipTwo.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestRelationshipTwo.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}