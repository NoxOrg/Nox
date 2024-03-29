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

public partial class TestEntityTwoRelationshipsOneToMany : TestEntityTwoRelationshipsOneToManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityTwoRelationshipsOneToMany created event.
/// </summary>
public record TestEntityTwoRelationshipsOneToManyCreated(TestEntityTwoRelationshipsOneToMany TestEntityTwoRelationshipsOneToMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityTwoRelationshipsOneToMany updated event.
/// </summary>
public record TestEntityTwoRelationshipsOneToManyUpdated(TestEntityTwoRelationshipsOneToMany TestEntityTwoRelationshipsOneToMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityTwoRelationshipsOneToMany deleted event.
/// </summary>
public record TestEntityTwoRelationshipsOneToManyDeleted(TestEntityTwoRelationshipsOneToMany TestEntityTwoRelationshipsOneToMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
public abstract partial class TestEntityTwoRelationshipsOneToManyBase : AuditableEntityBase, IEtag
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

	protected virtual void InternalRaiseCreateEvent(TestEntityTwoRelationshipsOneToMany testEntityTwoRelationshipsOneToMany)
	{
		InternalDomainEvents.Add(new TestEntityTwoRelationshipsOneToManyCreated(testEntityTwoRelationshipsOneToMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityTwoRelationshipsOneToMany testEntityTwoRelationshipsOneToMany)
	{
		InternalDomainEvents.Add(new TestEntityTwoRelationshipsOneToManyUpdated(testEntityTwoRelationshipsOneToMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityTwoRelationshipsOneToMany testEntityTwoRelationshipsOneToMany)
	{
		InternalDomainEvents.Add(new TestEntityTwoRelationshipsOneToManyDeleted(testEntityTwoRelationshipsOneToMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityTwoRelationshipsOneToMany First relationship to the same entity ZeroOrMany SecondTestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsOneToMany> TestRelationshipOne { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipOne(SecondTestEntityTwoRelationshipsOneToMany relatedSecondTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipOne.Add(relatedSecondTestEntityTwoRelationshipsOneToMany);
    }

    public virtual void UpdateRefToTestRelationshipOne(List<SecondTestEntityTwoRelationshipsOneToMany> relatedSecondTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipOne.Clear();
        TestRelationshipOne.AddRange(relatedSecondTestEntityTwoRelationshipsOneToMany);
    }

    public virtual void DeleteRefToTestRelationshipOne(SecondTestEntityTwoRelationshipsOneToMany relatedSecondTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipOne.Remove(relatedSecondTestEntityTwoRelationshipsOneToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipOne()
    {
        TestRelationshipOne.Clear();
    }

    /// <summary>
    /// TestEntityTwoRelationshipsOneToMany Second relationship to the same entity ZeroOrMany SecondTestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsOneToMany> TestRelationshipTwo { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipTwo(SecondTestEntityTwoRelationshipsOneToMany relatedSecondTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipTwo.Add(relatedSecondTestEntityTwoRelationshipsOneToMany);
    }

    public virtual void UpdateRefToTestRelationshipTwo(List<SecondTestEntityTwoRelationshipsOneToMany> relatedSecondTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipTwo.Clear();
        TestRelationshipTwo.AddRange(relatedSecondTestEntityTwoRelationshipsOneToMany);
    }

    public virtual void DeleteRefToTestRelationshipTwo(SecondTestEntityTwoRelationshipsOneToMany relatedSecondTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipTwo.Remove(relatedSecondTestEntityTwoRelationshipsOneToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipTwo()
    {
        TestRelationshipTwo.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}