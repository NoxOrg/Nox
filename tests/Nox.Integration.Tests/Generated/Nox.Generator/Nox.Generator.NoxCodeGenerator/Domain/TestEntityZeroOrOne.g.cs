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

internal partial class TestEntityZeroOrOne : TestEntityZeroOrOneBase, IEntityHaveDomainEvents
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
/// Record for TestEntityZeroOrOne created event.
/// </summary>
internal record TestEntityZeroOrOneCreated(TestEntityZeroOrOne TestEntityZeroOrOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrOne updated event.
/// </summary>
internal record TestEntityZeroOrOneUpdated(TestEntityZeroOrOne TestEntityZeroOrOne) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrOne deleted event.
/// </summary>
internal record TestEntityZeroOrOneDeleted(TestEntityZeroOrOne TestEntityZeroOrOne) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
internal abstract partial class TestEntityZeroOrOneBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(TestEntityZeroOrOne testEntityZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrOneCreated(testEntityZeroOrOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityZeroOrOne testEntityZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrOneUpdated(testEntityZeroOrOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityZeroOrOne testEntityZeroOrOne)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrOneDeleted(testEntityZeroOrOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityZeroOrOne Test entity relationship to SecondTestEntity ZeroOrOne SecondTestEntityZeroOrOnes
    /// </summary>
    public virtual SecondTestEntityZeroOrOne? SecondTestEntityZeroOrOne { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity SecondTestEntityZeroOrOne
    /// </summary>
    public Nox.Types.Text? SecondTestEntityZeroOrOneId { get; set; } = null!;

    public virtual void CreateRefToSecondTestEntityZeroOrOne(SecondTestEntityZeroOrOne relatedSecondTestEntityZeroOrOne)
    {
        SecondTestEntityZeroOrOne = relatedSecondTestEntityZeroOrOne;
    }

    public virtual void DeleteRefToSecondTestEntityZeroOrOne(SecondTestEntityZeroOrOne relatedSecondTestEntityZeroOrOne)
    {
        SecondTestEntityZeroOrOne = null;
    }

    public virtual void DeleteAllRefToSecondTestEntityZeroOrOne()
    {
        SecondTestEntityZeroOrOneId = null;
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}