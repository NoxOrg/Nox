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

internal partial class TestEntityZeroOrManyToExactlyOne : TestEntityZeroOrManyToExactlyOneBase, IEntityHaveDomainEvents
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
/// Record for TestEntityZeroOrManyToExactlyOne created event.
/// </summary>
internal record TestEntityZeroOrManyToExactlyOneCreated(TestEntityZeroOrManyToExactlyOne TestEntityZeroOrManyToExactlyOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrManyToExactlyOne updated event.
/// </summary>
internal record TestEntityZeroOrManyToExactlyOneUpdated(TestEntityZeroOrManyToExactlyOne TestEntityZeroOrManyToExactlyOne) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrManyToExactlyOne deleted event.
/// </summary>
internal record TestEntityZeroOrManyToExactlyOneDeleted(TestEntityZeroOrManyToExactlyOne TestEntityZeroOrManyToExactlyOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class TestEntityZeroOrManyToExactlyOneBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

    protected virtual void InternalRaiseCreateEvent(TestEntityZeroOrManyToExactlyOne testEntityZeroOrManyToExactlyOne)
    {
        InternalDomainEvents.Add(new TestEntityZeroOrManyToExactlyOneCreated(testEntityZeroOrManyToExactlyOne));
    }
	
    protected virtual void InternalRaiseUpdateEvent(TestEntityZeroOrManyToExactlyOne testEntityZeroOrManyToExactlyOne)
    {
        InternalDomainEvents.Add(new TestEntityZeroOrManyToExactlyOneUpdated(testEntityZeroOrManyToExactlyOne));
    }
	
    protected virtual void InternalRaiseDeleteEvent(TestEntityZeroOrManyToExactlyOne testEntityZeroOrManyToExactlyOne)
    {
        InternalDomainEvents.Add(new TestEntityZeroOrManyToExactlyOneDeleted(testEntityZeroOrManyToExactlyOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityZeroOrManyToExactlyOne Test entity relationship to TestEntityExactlyOneToZeroOrMany ZeroOrMany TestEntityExactlyOneToZeroOrManies
    /// </summary>
    public virtual List<TestEntityExactlyOneToZeroOrMany> TestEntityExactlyOneToZeroOrMany { get; private set; } = new();

    public virtual void CreateRefToTestEntityExactlyOneToZeroOrMany(TestEntityExactlyOneToZeroOrMany relatedTestEntityExactlyOneToZeroOrMany)
    {
        TestEntityExactlyOneToZeroOrMany.Add(relatedTestEntityExactlyOneToZeroOrMany);
    }

    public virtual void DeleteRefToTestEntityExactlyOneToZeroOrMany(TestEntityExactlyOneToZeroOrMany relatedTestEntityExactlyOneToZeroOrMany)
    {
        TestEntityExactlyOneToZeroOrMany.Remove(relatedTestEntityExactlyOneToZeroOrMany);
    }

    public virtual void DeleteAllRefToTestEntityExactlyOneToZeroOrMany()
    {
        TestEntityExactlyOneToZeroOrMany.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}