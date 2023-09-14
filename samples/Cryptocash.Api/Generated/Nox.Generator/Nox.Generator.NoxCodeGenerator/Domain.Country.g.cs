// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class Country:CountryBase
{

}
/// <summary>
/// Record for Country created event.
/// </summary>
public record CountryCreated(Country Country) : IDomainEvent;
/// <summary>
/// Record for Country updated event.
/// </summary>
public record CountryUpdated(Country Country) : IDomainEvent;
/// <summary>
/// Record for Country deleted event.
/// </summary>
public record CountryDeleted(Country Country) : IDomainEvent;

/// <summary>
/// Country and related data.
/// </summary>
public abstract class CountryBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Country unique identifier (Required).
    /// </summary>
    public CountryCode2 Id { get; set; } = null!;

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

    /// <summary>
    /// Country used by ExactlyOne Currencies
    /// </summary>
    public virtual Currency CountryUsedByCurrency { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Currency
    /// </summary>
    public Nox.Types.CurrencyCode3 CountryUsedByCurrencyId { get; set; } = null!;

    public virtual void CreateRefToCurrency(Currency relatedCurrency)
    {
        CountryUsedByCurrency = relatedCurrency;
    }

    /// <summary>
    /// Country used by OneOrMany Commissions
    /// </summary>
    public virtual List<Commission> CountryUsedByCommissions { get; set; } = new();

    public virtual void CreateRefToCommission(Commission relatedCommission)
    {
        CountryUsedByCommissions.Add(relatedCommission);
    }

    /// <summary>
    /// Country used by ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachine> CountryUsedByVendingMachines { get; set; } = new();

    public virtual void CreateRefToVendingMachine(VendingMachine relatedVendingMachine)
    {
        CountryUsedByVendingMachines.Add(relatedVendingMachine);
    }

    /// <summary>
    /// Country used by ZeroOrMany Customers
    /// </summary>
    public virtual List<Customer> CountryUsedByCustomers { get; set; } = new();

    public virtual void CreateRefToCustomer(Customer relatedCustomer)
    {
        CountryUsedByCustomers.Add(relatedCustomer);
    }

    /// <summary>
    /// Country owned OneOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZone> CountryTimeZones { get; set; } = new();

    public List<CountryTimeZone> CountryOwnedTimeZones => CountryTimeZones;

    /// <summary>
    /// Country owned ZeroOrMany Holidays
    /// </summary>
    public virtual List<Holiday> Holidays { get; set; } = new();

    public List<Holiday> CountryOwnedHolidays => Holidays;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}