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

internal partial class TestEntityZeroOrManyToOneOrMany : TestEntityZeroOrManyToOneOrManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityZeroOrManyToOneOrMany created event.
/// </summary>
internal record TestEntityZeroOrManyToOneOrManyCreated(TestEntityZeroOrManyToOneOrMany TestEntityZeroOrManyToOneOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrManyToOneOrMany updated event.
/// </summary>
internal record TestEntityZeroOrManyToOneOrManyUpdated(TestEntityZeroOrManyToOneOrMany TestEntityZeroOrManyToOneOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrManyToOneOrMany deleted event.
/// </summary>
internal record TestEntityZeroOrManyToOneOrManyDeleted(TestEntityZeroOrManyToOneOrMany TestEntityZeroOrManyToOneOrMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class TestEntityZeroOrManyToOneOrManyBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(TestEntityZeroOrManyToOneOrMany testEntityZeroOrManyToOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrManyToOneOrManyCreated(testEntityZeroOrManyToOneOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityZeroOrManyToOneOrMany testEntityZeroOrManyToOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrManyToOneOrManyUpdated(testEntityZeroOrManyToOneOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityZeroOrManyToOneOrMany testEntityZeroOrManyToOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrManyToOneOrManyDeleted(testEntityZeroOrManyToOneOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityZeroOrManyToOneOrMany Test entity relationship to TestEntityOneOrManyToZeroOrMany ZeroOrMany TestEntityOneOrManyToZeroOrManies
    /// </summary>
    public virtual List<TestEntityOneOrManyToZeroOrMany> TestEntityOneOrManyToZeroOrManies { get; private set; } = new();

    public virtual void CreateRefToTestEntityOneOrManyToZeroOrManies(TestEntityOneOrManyToZeroOrMany relatedTestEntityOneOrManyToZeroOrMany)
    {
        TestEntityOneOrManyToZeroOrManies.Add(relatedTestEntityOneOrManyToZeroOrMany);
    }

    public virtual void UpdateRefToTestEntityOneOrManyToZeroOrManies(List<TestEntityOneOrManyToZeroOrMany> relatedTestEntityOneOrManyToZeroOrMany)
    {
        TestEntityOneOrManyToZeroOrManies.Clear();
        TestEntityOneOrManyToZeroOrManies.AddRange(relatedTestEntityOneOrManyToZeroOrMany);
    }

    public virtual void DeleteRefToTestEntityOneOrManyToZeroOrManies(TestEntityOneOrManyToZeroOrMany relatedTestEntityOneOrManyToZeroOrMany)
    {
        TestEntityOneOrManyToZeroOrManies.Remove(relatedTestEntityOneOrManyToZeroOrMany);
    }

    public virtual void DeleteAllRefToTestEntityOneOrManyToZeroOrManies()
    {
        TestEntityOneOrManyToZeroOrManies.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}