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
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField { get; set; } = null!;
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
    public virtual SecondTestEntityZeroOrOne? SecondTestEntityZeroOrOneRelationship { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity SecondTestEntityZeroOrOne
    /// </summary>
    public Nox.Types.Text? SecondTestEntityZeroOrOneRelationshipId { get; set; } = null!;

    public virtual void CreateRefToSecondTestEntityZeroOrOneRelationship(SecondTestEntityZeroOrOne relatedSecondTestEntityZeroOrOne)
    {
        SecondTestEntityZeroOrOneRelationship = relatedSecondTestEntityZeroOrOne;
    }

    public virtual void DeleteRefToSecondTestEntityZeroOrOneRelationship(SecondTestEntityZeroOrOne relatedSecondTestEntityZeroOrOne)
    {
        SecondTestEntityZeroOrOneRelationship = null;
    }

    public virtual void DeleteAllRefToSecondTestEntityZeroOrOneRelationship()
    {
        SecondTestEntityZeroOrOneRelationshipId = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}