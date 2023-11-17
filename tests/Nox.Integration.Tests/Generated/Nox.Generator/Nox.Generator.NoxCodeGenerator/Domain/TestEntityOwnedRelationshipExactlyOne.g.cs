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

internal partial class TestEntityOwnedRelationshipExactlyOne : TestEntityOwnedRelationshipExactlyOneBase, IEntityHaveDomainEvents
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
/// Record for TestEntityOwnedRelationshipExactlyOne created event.
/// </summary>
internal record TestEntityOwnedRelationshipExactlyOneCreated(TestEntityOwnedRelationshipExactlyOne TestEntityOwnedRelationshipExactlyOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOwnedRelationshipExactlyOne updated event.
/// </summary>
internal record TestEntityOwnedRelationshipExactlyOneUpdated(TestEntityOwnedRelationshipExactlyOne TestEntityOwnedRelationshipExactlyOne) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOwnedRelationshipExactlyOne deleted event.
/// </summary>
internal record TestEntityOwnedRelationshipExactlyOneDeleted(TestEntityOwnedRelationshipExactlyOne TestEntityOwnedRelationshipExactlyOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class TestEntityOwnedRelationshipExactlyOneBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(TestEntityOwnedRelationshipExactlyOne testEntityOwnedRelationshipExactlyOne)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipExactlyOneCreated(testEntityOwnedRelationshipExactlyOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityOwnedRelationshipExactlyOne testEntityOwnedRelationshipExactlyOne)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipExactlyOneUpdated(testEntityOwnedRelationshipExactlyOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityOwnedRelationshipExactlyOne testEntityOwnedRelationshipExactlyOne)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipExactlyOneDeleted(testEntityOwnedRelationshipExactlyOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }﻿

    /// <summary>
    /// TestEntityOwnedRelationshipExactlyOne Test entity relationship to SecondTestEntityOwnedRelationshipExactlyOne ExactlyOne SecondTestEntityOwnedRelationshipExactlyOnes
    /// </summary>
    public virtual SecondTestEntityOwnedRelationshipExactlyOne SecondTestEntityOwnedRelationshipExactlyOne { get; private set; } = null!;
    
    /// <summary>
    /// Creates a new SecondTestEntityOwnedRelationshipExactlyOne entity.
    /// </summary>
    public virtual void CreateRefToSecondTestEntityOwnedRelationshipExactlyOne(SecondTestEntityOwnedRelationshipExactlyOne relatedSecondTestEntityOwnedRelationshipExactlyOne)
    {
        SecondTestEntityOwnedRelationshipExactlyOne = relatedSecondTestEntityOwnedRelationshipExactlyOne;
    }
    
    /// <summary>
    /// Deletes owned SecondTestEntityOwnedRelationshipExactlyOne entity.
    /// </summary>
    public virtual void DeleteRefToSecondTestEntityOwnedRelationshipExactlyOne(SecondTestEntityOwnedRelationshipExactlyOne relatedSecondTestEntityOwnedRelationshipExactlyOne)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }
    
    /// <summary>
    /// Deletes all owned SecondTestEntityOwnedRelationshipExactlyOne entities.
    /// </summary>
    public virtual void DeleteAllRefToSecondTestEntityOwnedRelationshipExactlyOne()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}