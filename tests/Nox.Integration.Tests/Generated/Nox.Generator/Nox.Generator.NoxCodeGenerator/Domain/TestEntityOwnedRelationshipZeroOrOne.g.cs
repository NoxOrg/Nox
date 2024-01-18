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

public partial class TestEntityOwnedRelationshipZeroOrOne : TestEntityOwnedRelationshipZeroOrOneBase, IEntityHaveDomainEvents
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
/// Record for TestEntityOwnedRelationshipZeroOrOne created event.
/// </summary>
public record TestEntityOwnedRelationshipZeroOrOneCreated(TestEntityOwnedRelationshipZeroOrOne TestEntityOwnedRelationshipZeroOrOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrOne updated event.
/// </summary>
public record TestEntityOwnedRelationshipZeroOrOneUpdated(TestEntityOwnedRelationshipZeroOrOne TestEntityOwnedRelationshipZeroOrOne) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrOne deleted event.
/// </summary>
public record TestEntityOwnedRelationshipZeroOrOneDeleted(TestEntityOwnedRelationshipZeroOrOne TestEntityOwnedRelationshipZeroOrOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
public abstract partial class TestEntityOwnedRelationshipZeroOrOneBase : AuditableEntityBase, IEtag
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

	protected virtual void InternalRaiseCreateEvent(TestEntityOwnedRelationshipZeroOrOne testEntityOwnedRelationshipZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipZeroOrOneCreated(testEntityOwnedRelationshipZeroOrOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityOwnedRelationshipZeroOrOne testEntityOwnedRelationshipZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipZeroOrOneUpdated(testEntityOwnedRelationshipZeroOrOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityOwnedRelationshipZeroOrOne testEntityOwnedRelationshipZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityOwnedRelationshipZeroOrOneDeleted(testEntityOwnedRelationshipZeroOrOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }﻿

    /// <summary>
    /// TestEntityOwnedRelationshipZeroOrOne Test entity relationship to SecondTestEntityOwnedRelationshipZeroOrOne ZeroOrOne SecondTestEntityOwnedRelationshipZeroOrOnes
    /// </summary>
    public virtual SecondTestEntityOwnedRelationshipZeroOrOne? SecondTestEntityOwnedRelationshipZeroOrOne { get; private set; }
    
    /// <summary>
    /// Creates a new SecondTestEntityOwnedRelationshipZeroOrOne entity.
    /// </summary>
    public virtual void CreateRefToSecondTestEntityOwnedRelationshipZeroOrOne(SecondTestEntityOwnedRelationshipZeroOrOne relatedSecondTestEntityOwnedRelationshipZeroOrOne)
    {
        SecondTestEntityOwnedRelationshipZeroOrOne = relatedSecondTestEntityOwnedRelationshipZeroOrOne;
    }
    
    /// <summary>
    /// Deletes owned SecondTestEntityOwnedRelationshipZeroOrOne entity.
    /// </summary>
    public virtual void DeleteRefToSecondTestEntityOwnedRelationshipZeroOrOne(SecondTestEntityOwnedRelationshipZeroOrOne relatedSecondTestEntityOwnedRelationshipZeroOrOne)
    {
        SecondTestEntityOwnedRelationshipZeroOrOne = null;
    }
    
    /// <summary>
    /// Deletes all owned SecondTestEntityOwnedRelationshipZeroOrOne entities.
    /// </summary>
    public virtual void DeleteAllRefToSecondTestEntityOwnedRelationshipZeroOrOne()
    {
        SecondTestEntityOwnedRelationshipZeroOrOne = null;
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}