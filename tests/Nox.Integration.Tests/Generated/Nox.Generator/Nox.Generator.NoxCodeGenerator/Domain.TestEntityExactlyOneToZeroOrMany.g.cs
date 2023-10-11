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

internal partial class TestEntityExactlyOneToZeroOrMany : TestEntityExactlyOneToZeroOrManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityExactlyOneToZeroOrMany created event.
/// </summary>
internal record TestEntityExactlyOneToZeroOrManyCreated(TestEntityExactlyOneToZeroOrMany TestEntityExactlyOneToZeroOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrMany updated event.
/// </summary>
internal record TestEntityExactlyOneToZeroOrManyUpdated(TestEntityExactlyOneToZeroOrMany TestEntityExactlyOneToZeroOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrMany deleted event.
/// </summary>
internal record TestEntityExactlyOneToZeroOrManyDeleted(TestEntityExactlyOneToZeroOrMany TestEntityExactlyOneToZeroOrMany) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
internal abstract partial class TestEntityExactlyOneToZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
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

    protected virtual void InternalRaiseCreateEvent(TestEntityExactlyOneToZeroOrMany testEntityExactlyOneToZeroOrMany)
    {
        InternalDomainEvents.Add(new TestEntityExactlyOneToZeroOrManyCreated(testEntityExactlyOneToZeroOrMany));
    }
	
    protected virtual void InternalRaiseUpdateEvent(TestEntityExactlyOneToZeroOrMany testEntityExactlyOneToZeroOrMany)
    {
        InternalDomainEvents.Add(new TestEntityExactlyOneToZeroOrManyUpdated(testEntityExactlyOneToZeroOrMany));
    }
	
    protected virtual void InternalRaiseDeleteEvent(TestEntityExactlyOneToZeroOrMany testEntityExactlyOneToZeroOrMany)
    {
        InternalDomainEvents.Add(new TestEntityExactlyOneToZeroOrManyDeleted(testEntityExactlyOneToZeroOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityExactlyOneToZeroOrMany Test entity relationship to TestEntityZeroOrManyToExactlyOne ExactlyOne TestEntityZeroOrManyToExactlyOnes
    /// </summary>
    public virtual TestEntityZeroOrManyToExactlyOne TestEntityZeroOrManyToExactlyOne { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity TestEntityZeroOrManyToExactlyOne
    /// </summary>
    public Nox.Types.Text TestEntityZeroOrManyToExactlyOneId { get; set; } = null!;

    public virtual void CreateRefToTestEntityZeroOrManyToExactlyOne(TestEntityZeroOrManyToExactlyOne relatedTestEntityZeroOrManyToExactlyOne)
    {
        TestEntityZeroOrManyToExactlyOne = relatedTestEntityZeroOrManyToExactlyOne;
    }

    public virtual void DeleteRefToTestEntityZeroOrManyToExactlyOne(TestEntityZeroOrManyToExactlyOne relatedTestEntityZeroOrManyToExactlyOne)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTestEntityZeroOrManyToExactlyOne()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}