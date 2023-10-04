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

internal partial class TestEntityForUniqueConstraints : TestEntityForUniqueConstraintsBase, IEntityHaveDomainEvents
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
/// Record for TestEntityForUniqueConstraints created event.
/// </summary>
internal record TestEntityForUniqueConstraintsCreated(TestEntityForUniqueConstraints TestEntityForUniqueConstraints) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityForUniqueConstraints updated event.
/// </summary>
internal record TestEntityForUniqueConstraintsUpdated(TestEntityForUniqueConstraints TestEntityForUniqueConstraints) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityForUniqueConstraints deleted event.
/// </summary>
internal record TestEntityForUniqueConstraintsDeleted(TestEntityForUniqueConstraints TestEntityForUniqueConstraints) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing constraints.
/// </summary>
internal abstract partial class TestEntityForUniqueConstraintsBase : EntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextField { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Number NumberField { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Number UniqueNumberField { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.CountryCode2 UniqueCountryCode { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.CurrencyCode3 UniqueCurrencyCode { get; set; } = null!;
	/// <summary>
	/// Domain events raised by this entity.
	/// </summary>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
	protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(TestEntityForUniqueConstraints testEntityForUniqueConstraints)
	{
		InternalDomainEvents.Add(new TestEntityForUniqueConstraintsCreated(testEntityForUniqueConstraints));
	}
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityForUniqueConstraints testEntityForUniqueConstraints)
	{
		InternalDomainEvents.Add(new TestEntityForUniqueConstraintsUpdated(testEntityForUniqueConstraints));
	}
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityForUniqueConstraints testEntityForUniqueConstraints)
	{
		InternalDomainEvents.Add(new TestEntityForUniqueConstraintsDeleted(testEntityForUniqueConstraints));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}