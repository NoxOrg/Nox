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

internal partial class Country : CountryBase, IEntityHaveDomainEvents
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
internal record CountryCreated(Country Country) :  IDomainEvent, INotification;
/// <summary>
/// Record for Country updated event.
/// </summary>
internal record CountryUpdated(Country Country) : IDomainEvent, INotification;
/// <summary>
/// Record for Country deleted event.
/// </summary>
internal record CountryDeleted(Country Country) : IDomainEvent, INotification;

/// <summary>
/// Country and related data.
/// </summary>
internal abstract partial class CountryBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Country unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.CountryCode2 Id { get; set; } = null!;

    /// <summary>
    /// Country's name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Country's official name    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? OfficialName { get; set; } = null!;

    /// <summary>
    /// Country's iso number id    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.CountryNumber? CountryIsoNumeric { get; set; } = null!;

    /// <summary>
    /// Country's iso alpha3 id    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.CountryCode3? CountryIsoAlpha3 { get; set; } = null!;

    /// <summary>
    /// Country's geo coordinates    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.LatLong? GeoCoords { get; set; } = null!;

    /// <summary>
    /// Country's flag emoji    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? FlagEmoji { get; set; } = null!;

    /// <summary>
    /// Country's flag in svg format    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Image? FlagSvg { get; set; } = null!;

    /// <summary>
    /// Country's flag in png format    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Image? FlagPng { get; set; } = null!;

    /// <summary>
    /// Country's coat of arms in svg format    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Image? CoatOfArmsSvg { get; set; } = null!;

    /// <summary>
    /// Country's coat of arms in png format    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Image? CoatOfArmsPng { get; set; } = null!;

    /// <summary>
    /// Country's map via google maps    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Url? GoogleMapsUrl { get; set; } = null!;

    /// <summary>
    /// Country's map via open street maps    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Url? OpenStreetMapsUrl { get; set; } = null!;

    /// <summary>
    /// Country's start of week day    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.DayOfWeek StartOfWeek { get; set; } = null!;

    /// <summary>
    /// Country's population    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Number Population { get; set; } = null!;
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
    /// Country used by ExactlyOne Currencies
    /// </summary>
    public virtual Currency Currency { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Currency
    /// </summary>
    public Nox.Types.CurrencyCode3 CurrencyId { get; set; } = null!;

    public virtual void CreateRefToCurrency(Currency relatedCurrency)
    {
        Currency = relatedCurrency;
    }

    public virtual void DeleteRefToCurrency(Currency relatedCurrency)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToCurrency()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Country used by OneOrMany Commissions
    /// </summary>
    public virtual List<Commission> Commissions { get; private set; } = new();

    public virtual void CreateRefToCommissions(Commission relatedCommission)
    {
        Commissions.Add(relatedCommission);
    }

    public virtual void UpdateRefToCommissions(List<Commission> relatedCommission)
    {
        if(relatedCommission is null || relatedCommission.Count < 2)
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        Commissions.Clear();
        Commissions.AddRange(relatedCommission);
    }

    public virtual void DeleteRefToCommissions(Commission relatedCommission)
    {
        if(Commissions.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        Commissions.Remove(relatedCommission);
    }

    public virtual void DeleteAllRefToCommissions()
    {
        if(Commissions.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        Commissions.Clear();
    }

    /// <summary>
    /// Country used by ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachine> VendingMachines { get; private set; } = new();

    public virtual void CreateRefToVendingMachines(VendingMachine relatedVendingMachine)
    {
        VendingMachines.Add(relatedVendingMachine);
    }

    public virtual void UpdateRefToVendingMachines(List<VendingMachine> relatedVendingMachine)
    {
        VendingMachines.Clear();
        VendingMachines.AddRange(relatedVendingMachine);
    }

    public virtual void DeleteRefToVendingMachines(VendingMachine relatedVendingMachine)
    {
        VendingMachines.Remove(relatedVendingMachine);
    }

    public virtual void DeleteAllRefToVendingMachines()
    {
        VendingMachines.Clear();
    }

    /// <summary>
    /// Country used by ZeroOrMany Customers
    /// </summary>
    public virtual List<Customer> Customers { get; private set; } = new();

    public virtual void CreateRefToCustomers(Customer relatedCustomer)
    {
        Customers.Add(relatedCustomer);
    }

    public virtual void UpdateRefToCustomers(List<Customer> relatedCustomer)
    {
        Customers.Clear();
        Customers.AddRange(relatedCustomer);
    }

    public virtual void DeleteRefToCustomers(Customer relatedCustomer)
    {
        Customers.Remove(relatedCustomer);
    }

    public virtual void DeleteAllRefToCustomers()
    {
        Customers.Clear();
    }﻿

    /// <summary>
    /// Country owned OneOrMany CountryTimeZones
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
    /// Deletes owned CountryTimeZone entity.
    /// </summary>
    public virtual void DeleteRefToCountryTimeZones(CountryTimeZone relatedCountryTimeZone)
    {
        if(CountryTimeZones.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        CountryTimeZones.Remove(relatedCountryTimeZone);
    }
    
    /// <summary>
    /// Deletes all owned CountryTimeZone entities.
    /// </summary>
    public virtual void DeleteAllRefToCountryTimeZones()
    {
        if(CountryTimeZones.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
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