// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
internal partial class Commission:CommissionBase, IEntityHaveDomainEvents
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

}
/// <summary>
/// Record for Commission created event.
/// </summary>
internal record CommissionCreated(Commission Commission) : IDomainEvent;
/// <summary>
/// Record for Commission updated event.
/// </summary>
internal record CommissionUpdated(Commission Commission) : IDomainEvent;
/// <summary>
/// Record for Commission deleted event.
/// </summary>
internal record CommissionDeleted(Commission Commission) : IDomainEvent;

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
internal abstract class CommissionBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Commission unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Commission rate (Required).
    /// </summary>
    public Nox.Types.Percentage Rate { get; set; } = null!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public Nox.Types.DateTime EffectiveAt { get; set; } = null!;
	/// <summary>
	/// Domain events raised by this entity.
	/// </summary>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
	protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Commission commission)
	{
		InternalDomainEvents.Add(new CommissionCreated(commission));
	}
	
	protected virtual void InternalRaiseUpdateEvent(Commission commission)
	{
		InternalDomainEvents.Add(new CommissionUpdated(commission));
	}
	
	protected virtual void InternalRaiseDeleteEvent(Commission commission)
	{
		InternalDomainEvents.Add(new CommissionDeleted(commission));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

    /// <summary>
    /// Commission fees for ZeroOrOne Countries
    /// </summary>
    public virtual Country? CommissionFeesForCountry { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2? CommissionFeesForCountryId { get; set; } = null!;

    public virtual void CreateRefToCommissionFeesForCountry(Country relatedCountry)
    {
        CommissionFeesForCountry = relatedCountry;
    }

    public virtual void DeleteRefToCommissionFeesForCountry(Country relatedCountry)
    {
        CommissionFeesForCountry = null;
    }

    public virtual void DeleteAllRefToCommissionFeesForCountry()
    {
        CommissionFeesForCountryId = null;
    }

    /// <summary>
    /// Commission fees for ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> CommissionFeesForBooking { get; private set; } = new();

    public virtual void CreateRefToCommissionFeesForBooking(Booking relatedBooking)
    {
        CommissionFeesForBooking.Add(relatedBooking);
    }

    public virtual void DeleteRefToCommissionFeesForBooking(Booking relatedBooking)
    {
        CommissionFeesForBooking.Remove(relatedBooking);
    }

    public virtual void DeleteAllRefToCommissionFeesForBooking()
    {
        CommissionFeesForBooking.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}