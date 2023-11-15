// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;

internal partial class Commission : CommissionBase, IEntityHaveDomainEvents
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
/// Record for Commission created event.
/// </summary>
internal record CommissionCreated(Commission Commission) :  IDomainEvent, INotification;
/// <summary>
/// Record for Commission updated event.
/// </summary>
internal record CommissionUpdated(Commission Commission) : IDomainEvent, INotification;
/// <summary>
/// Record for Commission deleted event.
/// </summary>
internal record CommissionDeleted(Commission Commission) : IDomainEvent, INotification;

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
internal abstract partial class CommissionBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Commission unique identifier
    /// <remarks>Required.</remarks>   
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Commission rate
    /// <remarks>Required.</remarks>   
    /// </summary>
    public Nox.Types.Percentage Rate { get; set; } = null!;

    /// <summary>
    /// Exchange rate conversion amount
    /// <remarks>Required.</remarks>   
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
    public virtual Country? Country { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2? CountryId { get; set; } = null!;

    public virtual void CreateRefToCountry(Country relatedCountry)
    {
        Country = relatedCountry;
    }

    public virtual void DeleteRefToCountry(Country relatedCountry)
    {
        Country = null;
    }

    public virtual void DeleteAllRefToCountry()
    {
        CountryId = null;
    }

    /// <summary>
    /// Commission fees for ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> Bookings { get; private set; } = new();

    public virtual void CreateRefToBookings(Booking relatedBooking)
    {
        Bookings.Add(relatedBooking);
    }

    public virtual void UpdateRefToBookings(List<Booking> relatedBooking)
    {
        Bookings.Clear();
        Bookings.AddRange(relatedBooking);
    }

    public virtual void DeleteRefToBookings(Booking relatedBooking)
    {
        Bookings.Remove(relatedBooking);
    }

    public virtual void DeleteAllRefToBookings()
    {
        Bookings.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}