﻿// Generated

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

public partial class TestEntityTwoRelationshipsManyToMany : TestEntityTwoRelationshipsManyToManyBase, IEntityHaveDomainEvents
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
public record TestEntityTwoRelationshipsManyToManyCreated(TestEntityTwoRelationshipsManyToMany TestEntityTwoRelationshipsManyToMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityTwoRelationshipsManyToMany updated event.
/// </summary>
public record TestEntityTwoRelationshipsManyToManyUpdated(TestEntityTwoRelationshipsManyToMany TestEntityTwoRelationshipsManyToMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityTwoRelationshipsManyToMany deleted event.
/// </summary>
public record TestEntityTwoRelationshipsManyToManyDeleted(TestEntityTwoRelationshipsManyToMany TestEntityTwoRelationshipsManyToMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
public abstract partial class TestEntityTwoRelationshipsManyToManyBase : AuditableEntityBase, IEtag
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
    public Nox.Types.Text TextTestField { get;  set; } = null!;
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

    public virtual void UpdateRefToTestRelationshipOne(List<SecondTestEntityTwoRelationshipsManyToMany> relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        if(!relatedSecondTestEntityTwoRelationshipsManyToMany.HasAtLeastOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        TestRelationshipOne.Clear();
        TestRelationshipOne.AddRange(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteRefToTestRelationshipOne(SecondTestEntityTwoRelationshipsManyToMany relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        if(TestRelationshipOne.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestRelationshipOne.Remove(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipOne()
    {
        if(TestRelationshipOne.HasExactlyOneItem())
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

    public virtual void UpdateRefToTestRelationshipTwo(List<SecondTestEntityTwoRelationshipsManyToMany> relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        if(!relatedSecondTestEntityTwoRelationshipsManyToMany.HasAtLeastOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        TestRelationshipTwo.Clear();
        TestRelationshipTwo.AddRange(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteRefToTestRelationshipTwo(SecondTestEntityTwoRelationshipsManyToMany relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        if(TestRelationshipTwo.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestRelationshipTwo.Remove(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipTwo()
    {
        if(TestRelationshipTwo.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestRelationshipTwo.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}