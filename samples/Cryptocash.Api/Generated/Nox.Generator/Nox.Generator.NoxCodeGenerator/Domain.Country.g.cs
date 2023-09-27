// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
internal partial class Country:CountryBase
{

}
/// <summary>
/// Record for Country created event.
/// </summary>
internal record CountryCreated(CountryBase Country) : IDomainEvent;
/// <summary>
/// Record for Country updated event.
/// </summary>
internal record CountryUpdated(CountryBase Country) : IDomainEvent;
/// <summary>
/// Record for Country deleted event.
/// </summary>
internal record CountryDeleted(CountryBase Country) : IDomainEvent;

/// <summary>
/// Country and related data.
/// </summary>
internal abstract class CountryBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
{
    /// <summary>
    /// Country unique identifier (Required).
    /// </summary>
    public Nox.Types.CountryCode2 Id { get; set; } = null!;

    /// <summary>
    /// Country's name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Country's official name (Optional).
    /// </summary>
    public Nox.Types.Text? OfficialName { get; set; } = null!;

    /// <summary>
    /// Country's iso number id (Optional).
    /// </summary>
    public Nox.Types.CountryNumber? CountryIsoNumeric { get; set; } = null!;

    /// <summary>
    /// Country's iso alpha3 id (Optional).
    /// </summary>
    public Nox.Types.CountryCode3? CountryIsoAlpha3 { get; set; } = null!;

    /// <summary>
    /// Country's geo coordinates (Optional).
    /// </summary>
    public Nox.Types.LatLong? GeoCoords { get; set; } = null!;

    /// <summary>
    /// Country's flag emoji (Optional).
    /// </summary>
    public Nox.Types.Text? FlagEmoji { get; set; } = null!;

    /// <summary>
    /// Country's flag in svg format (Optional).
    /// </summary>
    public Nox.Types.Image? FlagSvg { get; set; } = null!;

    /// <summary>
    /// Country's flag in png format (Optional).
    /// </summary>
    public Nox.Types.Image? FlagPng { get; set; } = null!;

    /// <summary>
    /// Country's coat of arms in svg format (Optional).
    /// </summary>
    public Nox.Types.Image? CoatOfArmsSvg { get; set; } = null!;

    /// <summary>
    /// Country's coat of arms in png format (Optional).
    /// </summary>
    public Nox.Types.Image? CoatOfArmsPng { get; set; } = null!;

    /// <summary>
    /// Country's map via google maps (Optional).
    /// </summary>
    public Nox.Types.Url? GoogleMapsUrl { get; set; } = null!;

    /// <summary>
    /// Country's map via open street maps (Optional).
    /// </summary>
    public Nox.Types.Url? OpenStreetMapsUrl { get; set; } = null!;

    /// <summary>
    /// Country's start of week day (Required).
    /// </summary>
    public Nox.Types.DayOfWeek StartOfWeek { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	protected readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new CountryCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new CountryUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new CountryDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// Country used by ExactlyOne Currencies
    /// </summary>
    public virtual Currency CountryUsedByCurrency { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Currency
    /// </summary>
    public Nox.Types.CurrencyCode3 CountryUsedByCurrencyId { get; set; } = null!;

    public virtual void CreateRefToCountryUsedByCurrency(Currency relatedCurrency)
    {
        CountryUsedByCurrency = relatedCurrency;
    }

    public virtual void DeleteRefToCountryUsedByCurrency(Currency relatedCurrency)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToCountryUsedByCurrency()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Country used by OneOrMany Commissions
    /// </summary>
    public virtual List<Commission> CountryUsedByCommissions { get; private set; } = new();

    public virtual void CreateRefToCountryUsedByCommissions(Commission relatedCommission)
    {
        CountryUsedByCommissions.Add(relatedCommission);
    }

    public virtual void DeleteRefToCountryUsedByCommissions(Commission relatedCommission)
    {
        if(CountryUsedByCommissions.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        CountryUsedByCommissions.Remove(relatedCommission);
    }

    public virtual void DeleteAllRefToCountryUsedByCommissions()
    {
        if(CountryUsedByCommissions.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        CountryUsedByCommissions.Clear();
    }

    /// <summary>
    /// Country used by ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachine> CountryUsedByVendingMachines { get; private set; } = new();

    public virtual void CreateRefToCountryUsedByVendingMachines(VendingMachine relatedVendingMachine)
    {
        CountryUsedByVendingMachines.Add(relatedVendingMachine);
    }

    public virtual void DeleteRefToCountryUsedByVendingMachines(VendingMachine relatedVendingMachine)
    {
        CountryUsedByVendingMachines.Remove(relatedVendingMachine);
    }

    public virtual void DeleteAllRefToCountryUsedByVendingMachines()
    {
        CountryUsedByVendingMachines.Clear();
    }

    /// <summary>
    /// Country used by ZeroOrMany Customers
    /// </summary>
    public virtual List<Customer> CountryUsedByCustomers { get; private set; } = new();

    public virtual void CreateRefToCountryUsedByCustomers(Customer relatedCustomer)
    {
        CountryUsedByCustomers.Add(relatedCustomer);
    }

    public virtual void DeleteRefToCountryUsedByCustomers(Customer relatedCustomer)
    {
        CountryUsedByCustomers.Remove(relatedCustomer);
    }

    public virtual void DeleteAllRefToCountryUsedByCustomers()
    {
        CountryUsedByCustomers.Clear();
    }

    /// <summary>
    /// Country owned OneOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZone> CountryOwnedTimeZones { get; set; } = new();

    /// <summary>
    /// Country owned ZeroOrMany Holidays
    /// </summary>
    public virtual List<Holiday> CountryOwnedHolidays { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}