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

internal partial class TestEntityZeroOrOneToOneOrMany : TestEntityZeroOrOneToOneOrManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityZeroOrOneToOneOrMany created event.
/// </summary>
internal record TestEntityZeroOrOneToOneOrManyCreated(TestEntityZeroOrOneToOneOrMany TestEntityZeroOrOneToOneOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrOneToOneOrMany updated event.
/// </summary>
internal record TestEntityZeroOrOneToOneOrManyUpdated(TestEntityZeroOrOneToOneOrMany TestEntityZeroOrOneToOneOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrOneToOneOrMany deleted event.
/// </summary>
internal record TestEntityZeroOrOneToOneOrManyDeleted(TestEntityZeroOrOneToOneOrMany TestEntityZeroOrOneToOneOrMany) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
internal abstract partial class TestEntityZeroOrOneToOneOrManyBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(TestEntityZeroOrOneToOneOrMany testEntityZeroOrOneToOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrOneToOneOrManyCreated(testEntityZeroOrOneToOneOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityZeroOrOneToOneOrMany testEntityZeroOrOneToOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrOneToOneOrManyUpdated(testEntityZeroOrOneToOneOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityZeroOrOneToOneOrMany testEntityZeroOrOneToOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrOneToOneOrManyDeleted(testEntityZeroOrOneToOneOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityZeroOrOneToOneOrMany Test entity relationship to TestEntityOneOrManyToZeroOrOne ZeroOrOne TestEntityOneOrManyToZeroOrOnes
    /// </summary>
    public virtual TestEntityOneOrManyToZeroOrOne? TestEntityOneOrManyToZeroOrOne { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity TestEntityOneOrManyToZeroOrOne
    /// </summary>
    public Nox.Types.Text? TestEntityOneOrManyToZeroOrOneId { get; set; } = null!;

    public virtual void CreateRefToTestEntityOneOrManyToZeroOrOne(TestEntityOneOrManyToZeroOrOne relatedTestEntityOneOrManyToZeroOrOne)
    {
        TestEntityOneOrManyToZeroOrOne = relatedTestEntityOneOrManyToZeroOrOne;
    }

    public virtual void DeleteRefToTestEntityOneOrManyToZeroOrOne(TestEntityOneOrManyToZeroOrOne relatedTestEntityOneOrManyToZeroOrOne)
    {
        TestEntityOneOrManyToZeroOrOne = null;
    }

    public virtual void DeleteAllRefToTestEntityOneOrManyToZeroOrOne()
    {
        TestEntityOneOrManyToZeroOrOneId = null;
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}