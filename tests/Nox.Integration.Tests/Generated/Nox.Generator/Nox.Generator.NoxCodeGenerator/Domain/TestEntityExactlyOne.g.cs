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

internal partial class TestEntityExactlyOne : TestEntityExactlyOneBase, IEntityHaveDomainEvents
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
/// Record for TestEntityExactlyOne created event.
/// </summary>
internal record TestEntityExactlyOneCreated(TestEntityExactlyOne TestEntityExactlyOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityExactlyOne updated event.
/// </summary>
internal record TestEntityExactlyOneUpdated(TestEntityExactlyOne TestEntityExactlyOne) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityExactlyOne deleted event.
/// </summary>
internal record TestEntityExactlyOneDeleted(TestEntityExactlyOne TestEntityExactlyOne) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
internal abstract partial class TestEntityExactlyOneBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(TestEntityExactlyOne testEntityExactlyOne)
	{
		InternalDomainEvents.Add(new TestEntityExactlyOneCreated(testEntityExactlyOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityExactlyOne testEntityExactlyOne)
	{
		InternalDomainEvents.Add(new TestEntityExactlyOneUpdated(testEntityExactlyOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityExactlyOne testEntityExactlyOne)
	{
		InternalDomainEvents.Add(new TestEntityExactlyOneDeleted(testEntityExactlyOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityExactlyOne Test entity relationship to SecondTestEntityExactlyOneRelationship ExactlyOne SecondTestEntityExactlyOnes
    /// </summary>
    public virtual SecondTestEntityExactlyOne SecondTestEntityExactlyOne { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity SecondTestEntityExactlyOne
    /// </summary>
    public Nox.Types.Text SecondTestEntityExactlyOneId { get; set; } = null!;

    public virtual void CreateRefToSecondTestEntityExactlyOne(SecondTestEntityExactlyOne relatedSecondTestEntityExactlyOne)
    {
        SecondTestEntityExactlyOne = relatedSecondTestEntityExactlyOne;
    }

    public virtual void DeleteRefToSecondTestEntityExactlyOne(SecondTestEntityExactlyOne relatedSecondTestEntityExactlyOne)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToSecondTestEntityExactlyOne()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}