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

internal partial class SecondTestEntityZeroOrOne : SecondTestEntityZeroOrOneBase, IEntityHaveDomainEvents
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
/// Record for SecondTestEntityZeroOrOne created event.
/// </summary>
internal record SecondTestEntityZeroOrOneCreated(SecondTestEntityZeroOrOne SecondTestEntityZeroOrOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityZeroOrOne updated event.
/// </summary>
internal record SecondTestEntityZeroOrOneUpdated(SecondTestEntityZeroOrOne SecondTestEntityZeroOrOne) : IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityZeroOrOne deleted event.
/// </summary>
internal record SecondTestEntityZeroOrOneDeleted(SecondTestEntityZeroOrOne SecondTestEntityZeroOrOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class SecondTestEntityZeroOrOneBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityZeroOrOne secondTestEntityZeroOrOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityZeroOrOneCreated(secondTestEntityZeroOrOne));
	}
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityZeroOrOne secondTestEntityZeroOrOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityZeroOrOneUpdated(secondTestEntityZeroOrOne));
	}
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityZeroOrOne secondTestEntityZeroOrOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityZeroOrOneDeleted(secondTestEntityZeroOrOne));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

    /// <summary>
    /// SecondTestEntityZeroOrOne Test entity relationship to TestEntity ZeroOrOne TestEntityZeroOrOnes
    /// </summary>
    public virtual TestEntityZeroOrOne? TestEntityZeroOrOneRelationship { get; private set; } = null!;

    public virtual void CreateRefToTestEntityZeroOrOneRelationship(TestEntityZeroOrOne relatedTestEntityZeroOrOne)
    {
        TestEntityZeroOrOneRelationship = relatedTestEntityZeroOrOne;
    }

    public virtual void DeleteRefToTestEntityZeroOrOneRelationship(TestEntityZeroOrOne relatedTestEntityZeroOrOne)
    {
        TestEntityZeroOrOneRelationship = null;
    }

    public virtual void DeleteAllRefToTestEntityZeroOrOneRelationship()
    {
        TestEntityZeroOrOneRelationship = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}