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

internal partial class TestEntityZeroOrOneToZeroOrMany : TestEntityZeroOrOneToZeroOrManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityZeroOrOneToZeroOrMany created event.
/// </summary>
internal record TestEntityZeroOrOneToZeroOrManyCreated(TestEntityZeroOrOneToZeroOrMany TestEntityZeroOrOneToZeroOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrOneToZeroOrMany updated event.
/// </summary>
internal record TestEntityZeroOrOneToZeroOrManyUpdated(TestEntityZeroOrOneToZeroOrMany TestEntityZeroOrOneToZeroOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrOneToZeroOrMany deleted event.
/// </summary>
internal record TestEntityZeroOrOneToZeroOrManyDeleted(TestEntityZeroOrOneToZeroOrMany TestEntityZeroOrOneToZeroOrMany) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
internal abstract partial class TestEntityZeroOrOneToZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// 
    /// <remarks>Required.</remarks>   
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    /// 
    /// <remarks>Required.</remarks>   
    /// </summary>
    public Nox.Types.Text TextTestField { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(TestEntityZeroOrOneToZeroOrMany testEntityZeroOrOneToZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrOneToZeroOrManyCreated(testEntityZeroOrOneToZeroOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityZeroOrOneToZeroOrMany testEntityZeroOrOneToZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrOneToZeroOrManyUpdated(testEntityZeroOrOneToZeroOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityZeroOrOneToZeroOrMany testEntityZeroOrOneToZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrOneToZeroOrManyDeleted(testEntityZeroOrOneToZeroOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityZeroOrOneToZeroOrMany Test entity relationship to TestEntityZeroOrManyToZeroOrOne ZeroOrOne TestEntityZeroOrManyToZeroOrOnes
    /// </summary>
    public virtual TestEntityZeroOrManyToZeroOrOne? TestEntityZeroOrManyToZeroOrOne { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity TestEntityZeroOrManyToZeroOrOne
    /// </summary>
    public Nox.Types.Text? TestEntityZeroOrManyToZeroOrOneId { get; set; } = null!;

    public virtual void CreateRefToTestEntityZeroOrManyToZeroOrOne(TestEntityZeroOrManyToZeroOrOne relatedTestEntityZeroOrManyToZeroOrOne)
    {
        TestEntityZeroOrManyToZeroOrOne = relatedTestEntityZeroOrManyToZeroOrOne;
    }

    public virtual void DeleteRefToTestEntityZeroOrManyToZeroOrOne(TestEntityZeroOrManyToZeroOrOne relatedTestEntityZeroOrManyToZeroOrOne)
    {
        TestEntityZeroOrManyToZeroOrOne = null;
    }

    public virtual void DeleteAllRefToTestEntityZeroOrManyToZeroOrOne()
    {
        TestEntityZeroOrManyToZeroOrOneId = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}