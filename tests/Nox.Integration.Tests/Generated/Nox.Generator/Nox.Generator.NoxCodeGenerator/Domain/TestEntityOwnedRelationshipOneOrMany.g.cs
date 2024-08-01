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

public partial class TestEntityOwnedRelationshipOneOrMany : TestEntityOwnedRelationshipOneOrManyBase, IEntityHaveDomainEvents
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
public record TestEntityOwnedRelationshipOneOrManyCreated(TestEntityOwnedRelationshipOneOrMany TestEntityOwnedRelationshipOneOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOwnedRelationshipOneOrMany updated event.
/// </summary>
public record TestEntityOwnedRelationshipOneOrManyUpdated(TestEntityOwnedRelationshipOneOrMany TestEntityOwnedRelationshipOneOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOwnedRelationshipOneOrMany deleted event.
/// </summary>
public record TestEntityOwnedRelationshipOneOrManyDeleted(TestEntityOwnedRelationshipOneOrMany TestEntityOwnedRelationshipOneOrMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
public abstract partial class TestEntityOwnedRelationshipOneOrManyBase : AuditableEntityBase, IEtag
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
    /// TestEntityOwnedRelationshipOneOrMany Test entity relationship to SecondTestEntityOwnedRelationshipOneOrMany OneOrMany SecEntityOwnedRelOneOrManies
    /// </summary>
    public virtual List<SecEntityOwnedRelOneOrMany> SecEntityOwnedRelOneOrManies { get; private set; } = new();
    
    /// <summary>
    /// Creates a new SecEntityOwnedRelOneOrMany entity.
    /// </summary>
    public virtual void CreateSecEntityOwnedRelOneOrManies(SecEntityOwnedRelOneOrMany relatedSecEntityOwnedRelOneOrMany)
    {
        SecEntityOwnedRelOneOrManies.Add(relatedSecEntityOwnedRelOneOrMany);
    }
    
    /// <summary>
    /// Updates all owned SecEntityOwnedRelOneOrMany entities.
    /// </summary>
    public virtual void UpdateSecEntityOwnedRelOneOrManies(List<SecEntityOwnedRelOneOrMany> relatedSecEntityOwnedRelOneOrMany)
    {
        if(!relatedSecEntityOwnedRelOneOrMany.HasAtLeastOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        SecEntityOwnedRelOneOrManies.Clear();
        SecEntityOwnedRelOneOrManies.AddRange(relatedSecEntityOwnedRelOneOrMany);
    }
    
    /// <summary>
    /// Deletes owned SecEntityOwnedRelOneOrMany entity.
    /// </summary>
    public virtual void DeleteSecEntityOwnedRelOneOrManies(SecEntityOwnedRelOneOrMany relatedSecEntityOwnedRelOneOrMany)
    {
        if(SecEntityOwnedRelOneOrManies.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        SecEntityOwnedRelOneOrManies.Remove(relatedSecEntityOwnedRelOneOrMany);
    }
    
    /// <summary>
    /// Deletes all owned SecEntityOwnedRelOneOrMany entities.
    /// </summary>
    public virtual void DeleteAllSecEntityOwnedRelOneOrManies()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}