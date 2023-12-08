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

namespace TestWebApp.Domain;

internal partial class TestEntityOwnedRelationshipOneOrMany : TestEntityOwnedRelationshipOneOrManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityOwnedRelationshipOneOrMany created event.
/// </summary>
internal record TestEntityOwnedRelationshipOneOrManyCreated(TestEntityOwnedRelationshipOneOrMany TestEntityOwnedRelationshipOneOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOwnedRelationshipOneOrMany updated event.
/// </summary>
internal record TestEntityOwnedRelationshipOneOrManyUpdated(TestEntityOwnedRelationshipOneOrMany TestEntityOwnedRelationshipOneOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOwnedRelationshipOneOrMany deleted event.
/// </summary>
internal record TestEntityOwnedRelationshipOneOrManyDeleted(TestEntityOwnedRelationshipOneOrMany TestEntityOwnedRelationshipOneOrMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class TestEntityOwnedRelationshipOneOrManyBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(TestEntityOwnedRelationshipOneOrMany testEntityOwnedRelationshipOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipOneOrManyCreated(testEntityOwnedRelationshipOneOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityOwnedRelationshipOneOrMany testEntityOwnedRelationshipOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipOneOrManyUpdated(testEntityOwnedRelationshipOneOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityOwnedRelationshipOneOrMany testEntityOwnedRelationshipOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipOneOrManyDeleted(testEntityOwnedRelationshipOneOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }﻿

    /// <summary>
    /// TestEntityOwnedRelationshipOneOrMany Test entity relationship to SecondTestEntityOwnedRelationshipOneOrMany OneOrMany SecondTestEntityOwnedRelationshipOneOrManies
    /// </summary>
    public virtual List<SecondTestEntityOwnedRelationshipOneOrMany> SecondTestEntityOwnedRelationshipOneOrManies { get; private set; } = new();
    
    /// <summary>
    /// Creates a new SecondTestEntityOwnedRelationshipOneOrMany entity.
    /// </summary>
    public virtual void CreateRefToSecondTestEntityOwnedRelationshipOneOrManies(SecondTestEntityOwnedRelationshipOneOrMany relatedSecondTestEntityOwnedRelationshipOneOrMany)
    {
        SecondTestEntityOwnedRelationshipOneOrManies.Add(relatedSecondTestEntityOwnedRelationshipOneOrMany);
    }
    
    /// <summary>
    /// Updates all owned SecondTestEntityOwnedRelationshipOneOrMany entities.
    /// </summary>
    public virtual void UpdateRefToSecondTestEntityOwnedRelationshipOneOrManies(List<SecondTestEntityOwnedRelationshipOneOrMany> relatedSecondTestEntityOwnedRelationshipOneOrMany)
    {
        if(!relatedSecondTestEntityOwnedRelationshipOneOrMany.HasAtLeastOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        SecondTestEntityOwnedRelationshipOneOrManies.Clear();
        SecondTestEntityOwnedRelationshipOneOrManies.AddRange(relatedSecondTestEntityOwnedRelationshipOneOrMany);
    }
    
    /// <summary>
    /// Deletes owned SecondTestEntityOwnedRelationshipOneOrMany entity.
    /// </summary>
    public virtual void DeleteRefToSecondTestEntityOwnedRelationshipOneOrManies(SecondTestEntityOwnedRelationshipOneOrMany relatedSecondTestEntityOwnedRelationshipOneOrMany)
    {
        if(SecondTestEntityOwnedRelationshipOneOrManies.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        SecondTestEntityOwnedRelationshipOneOrManies.Remove(relatedSecondTestEntityOwnedRelationshipOneOrMany);
    }
    
    /// <summary>
    /// Deletes all owned SecondTestEntityOwnedRelationshipOneOrMany entities.
    /// </summary>
    public virtual void DeleteAllRefToSecondTestEntityOwnedRelationshipOneOrManies()
    {
        if(SecondTestEntityOwnedRelationshipOneOrManies.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        SecondTestEntityOwnedRelationshipOneOrManies.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}