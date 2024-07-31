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

public partial class TestEntityZeroOrOneToExactlyOne : TestEntityZeroOrOneToExactlyOneBase, IEntityHaveDomainEvents
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
/// Record for TestEntityZeroOrOneToExactlyOne created event.
/// </summary>
public record TestEntityZeroOrOneToExactlyOneCreated(TestEntityZeroOrOneToExactlyOne TestEntityZeroOrOneToExactlyOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrOneToExactlyOne updated event.
/// </summary>
public record TestEntityZeroOrOneToExactlyOneUpdated(TestEntityZeroOrOneToExactlyOne TestEntityZeroOrOneToExactlyOne) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrOneToExactlyOne deleted event.
/// </summary>
public record TestEntityZeroOrOneToExactlyOneDeleted(TestEntityZeroOrOneToExactlyOne TestEntityZeroOrOneToExactlyOne) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract partial class TestEntityZeroOrOneToExactlyOneBase : AuditableEntityBase, IEtag
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

	protected virtual void InternalRaiseCreateEvent(TestEntityZeroOrOneToExactlyOne testEntityZeroOrOneToExactlyOne)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrOneToExactlyOneCreated(testEntityZeroOrOneToExactlyOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityZeroOrOneToExactlyOne testEntityZeroOrOneToExactlyOne)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrOneToExactlyOneUpdated(testEntityZeroOrOneToExactlyOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityZeroOrOneToExactlyOne testEntityZeroOrOneToExactlyOne)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrOneToExactlyOneDeleted(testEntityZeroOrOneToExactlyOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityZeroOrOneToExactlyOne Test entity relationship to TestEntityExactlyOneToZeroOrOne ZeroOrOne TestEntityExactlyOneToZeroOrOnes
    /// </summary>
    public virtual TestEntityExactlyOneToZeroOrOne? TestEntityExactlyOneToZeroOrOne { get; private set; } = null!;

    public virtual void CreateRefToTestEntityExactlyOneToZeroOrOne(TestEntityExactlyOneToZeroOrOne relatedTestEntityExactlyOneToZeroOrOne)
    {
        TestEntityExactlyOneToZeroOrOne = relatedTestEntityExactlyOneToZeroOrOne;
    }

    public virtual void DeleteRefToTestEntityExactlyOneToZeroOrOne(TestEntityExactlyOneToZeroOrOne relatedTestEntityExactlyOneToZeroOrOne)
    {
        TestEntityExactlyOneToZeroOrOne = null;
    }

    public virtual void DeleteAllRefToTestEntityExactlyOneToZeroOrOne()
    {
        TestEntityExactlyOneToZeroOrOne = null;
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}