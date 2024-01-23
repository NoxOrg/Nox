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

namespace ClientApi.Domain;

public partial class Country : CountryBase, IEntityHaveDomainEvents
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
/// Record for Country created event.
/// </summary>
public record CountryCreated(Country Country) :  IDomainEvent, INotification;
/// <summary>
/// Record for Country updated event.
/// </summary>
public record CountryUpdated(Country Country) : IDomainEvent, INotification;
/// <summary>
/// Record for Country deleted event.
/// </summary>
public record CountryDeleted(Country Country) : IDomainEvent, INotification;

/// <summary>
/// Country Entity Country representation for the Client API tests.
/// </summary>
public abstract partial class CountryBase : AuditableEntityBase, IEtag
{
    /// <summary>
    /// The unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; private set; } = null!;

    /// <summary>
    /// The Country Name     Set a unique name for the country Do not use abbreviations    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get;  set; } = null!;

    /// <summary>
    /// Population Number of People living in the country    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Number? Population { get;  set; } = null!;

    /// <summary>
    /// The Money    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Money? CountryDebt { get;  set; } = null!;

    /// <summary>
    /// national debt per person    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public double? DebtPerCapita
        { 
            get { return (CountryDebt is null || Population is null) ? null : CountryDebt.Amount / Population.Value; }
            private set { }
        }

    /// <summary>
    /// The capital location    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.LatLong? CapitalCityLocation { get;  set; } = null!;

    /// <summary>
    /// First Official Language    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.LanguageCode? FirstLanguageCode { get;  set; } = null!;

    /// <summary>
    /// The Formula    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public string? ShortDescription
        { 
            get { return $"{Name} has a population of {Population} people."; }
            private set { }
        }

    /// <summary>
    /// Country's iso number id    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.CountryNumber? CountryIsoNumeric { get;  set; } = null!;

    /// <summary>
    /// Country's iso alpha3 id    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.CountryCode3? CountryIsoAlpha3 { get;  set; } = null!;

    /// <summary>
    /// Country's map via google maps    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Url? GoogleMapsUrl { get;  set; } = null!;

    /// <summary>
    /// Country's start of week day    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.DayOfWeek? StartOfWeek { get;  set; } = null!;

    /// <summary>
    /// Country Continent    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Enumeration? Continent { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Country country)
	{
		InternalDomainEvents.Add(new CountryCreated(country));
    }
	
	protected virtual void InternalRaiseUpdateEvent(Country country)
	{
		InternalDomainEvents.Add(new CountryUpdated(country));
    }
	
	protected virtual void InternalRaiseDeleteEvent(Country country)
	{
		InternalDomainEvents.Add(new CountryDeleted(country));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// Country Country workplaces ZeroOrMany Workplaces
    /// </summary>
    public virtual List<Workplace> Workplaces { get; private set; } = new();

    public virtual void CreateRefToWorkplaces(Workplace relatedWorkplace)
    {
        Workplaces.Add(relatedWorkplace);
    }

    public virtual void UpdateRefToWorkplaces(List<Workplace> relatedWorkplace)
    {
        Workplaces.Clear();
        Workplaces.AddRange(relatedWorkplace);
    }

    public virtual void DeleteRefToWorkplaces(Workplace relatedWorkplace)
    {
        Workplaces.Remove(relatedWorkplace);
    }

    public virtual void DeleteAllRefToWorkplaces()
    {
        Workplaces.Clear();
    }

    /// <summary>
    /// Country Country stores ZeroOrMany Stores
    /// </summary>
    public virtual List<Store> Stores { get; private set; } = new();

    public virtual void CreateRefToStores(Store relatedStore)
    {
        Stores.Add(relatedStore);
    }

    public virtual void UpdateRefToStores(List<Store> relatedStore)
    {
        Stores.Clear();
        Stores.AddRange(relatedStore);
    }

    public virtual void DeleteRefToStores(Store relatedStore)
    {
        Stores.Remove(relatedStore);
    }

    public virtual void DeleteAllRefToStores()
    {
        Stores.Clear();
    }﻿

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalName> CountryLocalNames { get; private set; } = new();
    
    /// <summary>
    /// Creates a new CountryLocalName entity.
    /// </summary>
    public virtual void CreateRefToCountryLocalNames(CountryLocalName relatedCountryLocalName)
    {
        CountryLocalNames.Add(relatedCountryLocalName);
    }
    
    /// <summary>
    /// Updates all owned CountryLocalName entities.
    /// </summary>
    public virtual void UpdateRefToCountryLocalNames(List<CountryLocalName> relatedCountryLocalName)
    {
        CountryLocalNames.Clear();
        CountryLocalNames.AddRange(relatedCountryLocalName);
    }
    
    /// <summary>
    /// Deletes owned CountryLocalName entity.
    /// </summary>
    public virtual void DeleteRefToCountryLocalNames(CountryLocalName relatedCountryLocalName)
    {
        CountryLocalNames.Remove(relatedCountryLocalName);
    }
    
    /// <summary>
    /// Deletes all owned CountryLocalName entities.
    /// </summary>
    public virtual void DeleteAllRefToCountryLocalNames()
    {
        CountryLocalNames.Clear();
    }﻿

    /// <summary>
    /// Country is also coded as ZeroOrOne CountryBarCodes
    /// </summary>
    public virtual CountryBarCode? CountryBarCode { get; private set; }
    
    /// <summary>
    /// Creates a new CountryBarCode entity.
    /// </summary>
    public virtual void CreateRefToCountryBarCode(CountryBarCode relatedCountryBarCode)
    {
        CountryBarCode = relatedCountryBarCode;
    }
    
    /// <summary>
    /// Deletes owned CountryBarCode entity.
    /// </summary>
    public virtual void DeleteRefToCountryBarCode(CountryBarCode relatedCountryBarCode)
    {
        CountryBarCode = null;
    }
    
    /// <summary>
    /// Deletes all owned CountryBarCode entities.
    /// </summary>
    public virtual void DeleteAllRefToCountryBarCode()
    {
        CountryBarCode = null;
    }﻿

    /// <summary>
    /// Country uses ZeroOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZone> CountryTimeZones { get; private set; } = new();
    
    /// <summary>
    /// Creates a new CountryTimeZone entity.
    /// </summary>
    public virtual void CreateRefToCountryTimeZones(CountryTimeZone relatedCountryTimeZone)
    {
        CountryTimeZones.Add(relatedCountryTimeZone);
    }
    
    /// <summary>
    /// Updates all owned CountryTimeZone entities.
    /// </summary>
    public virtual void UpdateRefToCountryTimeZones(List<CountryTimeZone> relatedCountryTimeZone)
    {
        CountryTimeZones.Clear();
        CountryTimeZones.AddRange(relatedCountryTimeZone);
    }
    
    /// <summary>
    /// Deletes owned CountryTimeZone entity.
    /// </summary>
    public virtual void DeleteRefToCountryTimeZones(CountryTimeZone relatedCountryTimeZone)
    {
        CountryTimeZones.Remove(relatedCountryTimeZone);
    }
    
    /// <summary>
    /// Deletes all owned CountryTimeZone entities.
    /// </summary>
    public virtual void DeleteAllRefToCountryTimeZones()
    {
        CountryTimeZones.Clear();
    }﻿

    /// <summary>
    /// Country owned ZeroOrMany Holidays
    /// </summary>
    public virtual List<Holiday> Holidays { get; private set; } = new();
    
    /// <summary>
    /// Creates a new Holiday entity.
    /// </summary>
    public virtual void CreateRefToHolidays(Holiday relatedHoliday)
    {
        Holidays.Add(relatedHoliday);
    }
    
    /// <summary>
    /// Updates all owned Holiday entities.
    /// </summary>
    public virtual void UpdateRefToHolidays(List<Holiday> relatedHoliday)
    {
        Holidays.Clear();
        Holidays.AddRange(relatedHoliday);
    }
    
    /// <summary>
    /// Deletes owned Holiday entity.
    /// </summary>
    public virtual void DeleteRefToHolidays(Holiday relatedHoliday)
    {
        Holidays.Remove(relatedHoliday);
    }
    
    /// <summary>
    /// Deletes all owned Holiday entities.
    /// </summary>
    public virtual void DeleteAllRefToHolidays()
    {
        Holidays.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}