// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;

internal partial class Holiday : HolidayBase, IEntityHaveDomainEvents
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
/// Record for Holiday created event.
/// </summary>
internal record HolidayCreated(Holiday Holiday) : IDomainEvent;
/// <summary>
/// Record for Holiday updated event.
/// </summary>
internal record HolidayUpdated(Holiday Holiday) : IDomainEvent;
/// <summary>
/// Record for Holiday deleted event.
/// </summary>
internal record HolidayDeleted(Holiday Holiday) : IDomainEvent;

/// <summary>
/// Holiday related to country.
/// </summary>
internal abstract class HolidayBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// Country's holiday unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Country holiday name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Country holiday type (Required).
    /// </summary>
    public Nox.Types.Text Type { get; set; } = null!;

    /// <summary>
    /// Country holiday date (Required).
    /// </summary>
    public Nox.Types.Date Date { get; set; } = null!;
	/// <summary>
	/// Domain events raised by this entity.
	/// </summary>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
	protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Holiday holiday)
	{
		InternalDomainEvents.Add(new HolidayCreated(holiday));
	}
	
	protected virtual void InternalRaiseUpdateEvent(Holiday holiday)
	{
		InternalDomainEvents.Add(new HolidayUpdated(holiday));
	}
	
	protected virtual void InternalRaiseDeleteEvent(Holiday holiday)
	{
		InternalDomainEvents.Add(new HolidayDeleted(holiday));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

}