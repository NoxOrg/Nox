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

public partial class TestEntityZeroOrManyToZeroOrOne : TestEntityZeroOrManyToZeroOrOneBase, IEntityHaveDomainEvents
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
/// Record for TestEntityZeroOrManyToZeroOrOne created event.
/// </summary>
public record TestEntityZeroOrManyToZeroOrOneCreated(TestEntityZeroOrManyToZeroOrOne TestEntityZeroOrManyToZeroOrOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrManyToZeroOrOne updated event.
/// </summary>
public record TestEntityZeroOrManyToZeroOrOneUpdated(TestEntityZeroOrManyToZeroOrOne TestEntityZeroOrManyToZeroOrOne) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrManyToZeroOrOne deleted event.
/// </summary>
public record TestEntityZeroOrManyToZeroOrOneDeleted(TestEntityZeroOrManyToZeroOrOne TestEntityZeroOrManyToZeroOrOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
public abstract partial class TestEntityZeroOrManyToZeroOrOneBase : AuditableEntityBase, IEtag
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
    public Nox.Types.Text TextTestField2 { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(TestEntityZeroOrManyToZeroOrOne testEntityZeroOrManyToZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrManyToZeroOrOneCreated(testEntityZeroOrManyToZeroOrOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityZeroOrManyToZeroOrOne testEntityZeroOrManyToZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrManyToZeroOrOneUpdated(testEntityZeroOrManyToZeroOrOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityZeroOrManyToZeroOrOne testEntityZeroOrManyToZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrManyToZeroOrOneDeleted(testEntityZeroOrManyToZeroOrOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityZeroOrManyToZeroOrOne Test entity relationship to TestEntityZeroOrOneToZeroOrMany ZeroOrMany TestEntityZeroOrOneToZeroOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrOneToZeroOrMany> TestEntityZeroOrOneToZeroOrManies { get; private set; } = new();

    public virtual void CreateRefToTestEntityZeroOrOneToZeroOrManies(TestEntityZeroOrOneToZeroOrMany relatedTestEntityZeroOrOneToZeroOrMany)
    {
        TestEntityZeroOrOneToZeroOrManies.Add(relatedTestEntityZeroOrOneToZeroOrMany);
    }

    public virtual void UpdateRefToTestEntityZeroOrOneToZeroOrManies(List<TestEntityZeroOrOneToZeroOrMany> relatedTestEntityZeroOrOneToZeroOrMany)
    {
        TestEntityZeroOrOneToZeroOrManies.Clear();
        TestEntityZeroOrOneToZeroOrManies.AddRange(relatedTestEntityZeroOrOneToZeroOrMany);
    }

    public virtual void DeleteRefToTestEntityZeroOrOneToZeroOrManies(TestEntityZeroOrOneToZeroOrMany relatedTestEntityZeroOrOneToZeroOrMany)
    {
        TestEntityZeroOrOneToZeroOrManies.Remove(relatedTestEntityZeroOrOneToZeroOrMany);
    }

    public virtual void DeleteAllRefToTestEntityZeroOrOneToZeroOrManies()
    {
        TestEntityZeroOrOneToZeroOrManies.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}