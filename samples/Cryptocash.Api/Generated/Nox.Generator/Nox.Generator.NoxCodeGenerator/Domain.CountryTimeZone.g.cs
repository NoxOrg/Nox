// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class CountryTimeZone:CountryTimeZoneBase
{

}
/// <summary>
/// Record for CountryTimeZone created event.
/// </summary>
public record CountryTimeZoneCreated(CountryTimeZoneBase CountryTimeZone) : IDomainEvent;
/// <summary>
/// Record for CountryTimeZone updated event.
/// </summary>
public record CountryTimeZoneUpdated(CountryTimeZoneBase CountryTimeZone) : IDomainEvent;
/// <summary>
/// Record for CountryTimeZone deleted event.
/// </summary>
public record CountryTimeZoneDeleted(CountryTimeZoneBase CountryTimeZone) : IDomainEvent;

/// <summary>
/// Time zone related to country.
/// </summary>
public abstract class CountryTimeZoneBase : EntityBase, IOwnedEntity, IEntityHaveDomainEvents
{
    /// <summary>
    /// Country's time zone unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Country's related time zone code (Required).
    /// </summary>
    public Nox.Types.TimeZoneCode TimeZoneCode { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new CountryTimeZoneCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new CountryTimeZoneUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new CountryTimeZoneDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

}