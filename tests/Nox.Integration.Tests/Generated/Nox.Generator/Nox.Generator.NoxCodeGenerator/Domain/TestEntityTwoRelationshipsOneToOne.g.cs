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

public partial class TestEntityTwoRelationshipsOneToOne : TestEntityTwoRelationshipsOneToOneBase, IEntityHaveDomainEvents
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
/// Record for TestEntityTwoRelationshipsOneToOne created event.
/// </summary>
public record TestEntityTwoRelationshipsOneToOneCreated(TestEntityTwoRelationshipsOneToOne TestEntityTwoRelationshipsOneToOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityTwoRelationshipsOneToOne updated event.
/// </summary>
public record TestEntityTwoRelationshipsOneToOneUpdated(TestEntityTwoRelationshipsOneToOne TestEntityTwoRelationshipsOneToOne) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityTwoRelationshipsOneToOne deleted event.
/// </summary>
public record TestEntityTwoRelationshipsOneToOneDeleted(TestEntityTwoRelationshipsOneToOne TestEntityTwoRelationshipsOneToOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
public abstract partial class TestEntityTwoRelationshipsOneToOneBase : AuditableEntityBase, IEtag
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

	protected virtual void InternalRaiseCreateEvent(TestEntityTwoRelationshipsOneToOne testEntityTwoRelationshipsOneToOne)
	{
		InternalDomainEvents.Add(new TestEntityTwoRelationshipsOneToOneCreated(testEntityTwoRelationshipsOneToOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityTwoRelationshipsOneToOne testEntityTwoRelationshipsOneToOne)
	{
		InternalDomainEvents.Add(new TestEntityTwoRelationshipsOneToOneUpdated(testEntityTwoRelationshipsOneToOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityTwoRelationshipsOneToOne testEntityTwoRelationshipsOneToOne)
	{
		InternalDomainEvents.Add(new TestEntityTwoRelationshipsOneToOneDeleted(testEntityTwoRelationshipsOneToOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityTwoRelationshipsOneToOne First relationship to the same entity ExactlyOne SecondTestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public virtual SecondTestEntityTwoRelationshipsOneToOne TestRelationshipOne { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity SecondTestEntityTwoRelationshipsOneToOne
    /// </summary>
    public Nox.Types.Text TestRelationshipOneId { get; set; } = null!;

    public virtual void CreateRefToTestRelationshipOne(SecondTestEntityTwoRelationshipsOneToOne relatedSecondTestEntityTwoRelationshipsOneToOne)
    {
        TestRelationshipOne = relatedSecondTestEntityTwoRelationshipsOneToOne;
    }

    public virtual void DeleteRefToTestRelationshipOne(SecondTestEntityTwoRelationshipsOneToOne relatedSecondTestEntityTwoRelationshipsOneToOne)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTestRelationshipOne()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// TestEntityTwoRelationshipsOneToOne Second relationship to the same entity ExactlyOne SecondTestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public virtual SecondTestEntityTwoRelationshipsOneToOne TestRelationshipTwo { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity SecondTestEntityTwoRelationshipsOneToOne
    /// </summary>
    public Nox.Types.Text TestRelationshipTwoId { get; set; } = null!;

    public virtual void CreateRefToTestRelationshipTwo(SecondTestEntityTwoRelationshipsOneToOne relatedSecondTestEntityTwoRelationshipsOneToOne)
    {
        TestRelationshipTwo = relatedSecondTestEntityTwoRelationshipsOneToOne;
    }

    public virtual void DeleteRefToTestRelationshipTwo(SecondTestEntityTwoRelationshipsOneToOne relatedSecondTestEntityTwoRelationshipsOneToOne)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTestRelationshipTwo()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}