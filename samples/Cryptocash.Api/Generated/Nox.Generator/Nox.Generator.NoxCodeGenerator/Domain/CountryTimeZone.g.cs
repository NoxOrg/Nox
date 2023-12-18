// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using Nox.Exceptions;

namespace Cryptocash.Domain;

internal partial class CountryTimeZone : CountryTimeZoneBase, IEntityHaveDomainEvents
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
/// Record for CountryTimeZone created event.
/// </summary>
internal record CountryTimeZoneCreated(CountryTimeZone CountryTimeZone) :  IDomainEvent, INotification;
/// <summary>
/// Record for CountryTimeZone updated event.
/// </summary>
internal record CountryTimeZoneUpdated(CountryTimeZone CountryTimeZone) : IDomainEvent, INotification;
/// <summary>
/// Record for CountryTimeZone deleted event.
/// </summary>
internal record CountryTimeZoneDeleted(CountryTimeZone CountryTimeZone) : IDomainEvent, INotification;

/// <summary>
/// Time zone related to country.
/// </summary>
internal abstract partial class CountryTimeZoneBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// Country's time zone unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; private set; } = null!;

    /// <summary>
    /// Country's related time zone code    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.TimeZoneCode TimeZoneCode { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(CountryTimeZone countryTimeZone)
	{
		InternalDomainEvents.Add(new CountryTimeZoneCreated(countryTimeZone));
    }
	
	protected virtual void InternalRaiseUpdateEvent(CountryTimeZone countryTimeZone)
	{
		InternalDomainEvents.Add(new CountryTimeZoneUpdated(countryTimeZone));
    }
	
	protected virtual void InternalRaiseDeleteEvent(CountryTimeZone countryTimeZone)
	{
		InternalDomainEvents.Add(new CountryTimeZoneDeleted(countryTimeZone));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

}