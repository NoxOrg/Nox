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

internal partial class TestEntityOwnedRelationshipZeroOrMany : TestEntityOwnedRelationshipZeroOrManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityOwnedRelationshipZeroOrMany created event.
/// </summary>
internal record TestEntityOwnedRelationshipZeroOrManyCreated(TestEntityOwnedRelationshipZeroOrMany TestEntityOwnedRelationshipZeroOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrMany updated event.
/// </summary>
internal record TestEntityOwnedRelationshipZeroOrManyUpdated(TestEntityOwnedRelationshipZeroOrMany TestEntityOwnedRelationshipZeroOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrMany deleted event.
/// </summary>
internal record TestEntityOwnedRelationshipZeroOrManyDeleted(TestEntityOwnedRelationshipZeroOrMany TestEntityOwnedRelationshipZeroOrMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class TestEntityOwnedRelationshipZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(TestEntityOwnedRelationshipZeroOrMany testEntityOwnedRelationshipZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipZeroOrManyCreated(testEntityOwnedRelationshipZeroOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityOwnedRelationshipZeroOrMany testEntityOwnedRelationshipZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipZeroOrManyUpdated(testEntityOwnedRelationshipZeroOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityOwnedRelationshipZeroOrMany testEntityOwnedRelationshipZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipZeroOrManyDeleted(testEntityOwnedRelationshipZeroOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }﻿

    /// <summary>
    /// TestEntityOwnedRelationshipZeroOrMany Test entity relationship to SecondTestEntityOwnedRelationshipZeroOrMany ZeroOrMany SecEntityOwnedRelZeroOrManies
    /// </summary>
    public virtual List<SecEntityOwnedRelZeroOrMany> SecEntityOwnedRelZeroOrManies { get; private set; } = new();
    
    /// <summary>
    /// Creates a new SecEntityOwnedRelZeroOrMany entity.
    /// </summary>
    public virtual void CreateRefToSecEntityOwnedRelZeroOrManies(SecEntityOwnedRelZeroOrMany relatedSecEntityOwnedRelZeroOrMany)
    {
        SecEntityOwnedRelZeroOrManies.Add(relatedSecEntityOwnedRelZeroOrMany);
    }
    
    /// <summary>
    /// Updates all owned SecEntityOwnedRelZeroOrMany entities.
    /// </summary>
    public virtual void UpdateRefToSecEntityOwnedRelZeroOrManies(List<SecEntityOwnedRelZeroOrMany> relatedSecEntityOwnedRelZeroOrMany)
    {
        SecEntityOwnedRelZeroOrManies.Clear();
        SecEntityOwnedRelZeroOrManies.AddRange(relatedSecEntityOwnedRelZeroOrMany);
    }
    
    /// <summary>
    /// Deletes owned SecEntityOwnedRelZeroOrMany entity.
    /// </summary>
    public virtual void DeleteRefToSecEntityOwnedRelZeroOrManies(SecEntityOwnedRelZeroOrMany relatedSecEntityOwnedRelZeroOrMany)
    {
        SecEntityOwnedRelZeroOrManies.Remove(relatedSecEntityOwnedRelZeroOrMany);
    }
    
    /// <summary>
    /// Deletes all owned SecEntityOwnedRelZeroOrMany entities.
    /// </summary>
    public virtual void DeleteAllRefToSecEntityOwnedRelZeroOrManies()
    {
        SecEntityOwnedRelZeroOrManies.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}