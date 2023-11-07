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

internal partial class SecondTestEntityZeroOrMany : SecondTestEntityZeroOrManyBase, IEntityHaveDomainEvents
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
/// Record for SecondTestEntityZeroOrMany created event.
/// </summary>
internal record SecondTestEntityZeroOrManyCreated(SecondTestEntityZeroOrMany SecondTestEntityZeroOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityZeroOrMany updated event.
/// </summary>
internal record SecondTestEntityZeroOrManyUpdated(SecondTestEntityZeroOrMany SecondTestEntityZeroOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityZeroOrMany deleted event.
/// </summary>
internal record SecondTestEntityZeroOrManyDeleted(SecondTestEntityZeroOrMany SecondTestEntityZeroOrMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class SecondTestEntityZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityZeroOrMany secondTestEntityZeroOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityZeroOrManyCreated(secondTestEntityZeroOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityZeroOrMany secondTestEntityZeroOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityZeroOrManyUpdated(secondTestEntityZeroOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityZeroOrMany secondTestEntityZeroOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityZeroOrManyDeleted(secondTestEntityZeroOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// SecondTestEntityZeroOrMany Test entity relationship to TestEntityZeroOrMany ZeroOrMany TestEntityZeroOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrMany> TestEntityZeroOrManies { get; private set; } = new();

    public virtual void CreateRefToTestEntityZeroOrManies(TestEntityZeroOrMany relatedTestEntityZeroOrMany)
    {
        TestEntityZeroOrManies.Add(relatedTestEntityZeroOrMany);
    }

    public virtual void UpdateRefToTestEntityZeroOrManies(List<TestEntityZeroOrMany> relatedTestEntityZeroOrMany)
    {
        TestEntityZeroOrManies.Clear();
        TestEntityZeroOrManies.AddRange(relatedTestEntityZeroOrMany);
    }

    public virtual void DeleteRefToTestEntityZeroOrManies(TestEntityZeroOrMany relatedTestEntityZeroOrMany)
    {
        TestEntityZeroOrManies.Remove(relatedTestEntityZeroOrMany);
    }

    public virtual void DeleteAllRefToTestEntityZeroOrManies()
    {
        TestEntityZeroOrManies.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}