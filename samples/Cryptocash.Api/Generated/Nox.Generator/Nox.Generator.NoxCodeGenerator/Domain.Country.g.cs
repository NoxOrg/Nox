// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Country and related data.
/// </summary>
public partial class Country : AuditableEntityBase
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
    /// Country Country's primary currency for legal tender ExactlyOne Currencies
    /// </summary>
    public virtual Currency Currency { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Currency
    /// </summary>
    public Nox.Types.CurrencyCode3 CurrencyId { get; set; } = null!;

    /// <summary>
    /// Country Commission rates country OneOrMany Commissions
    /// </summary>
    public virtual List<Commission> Commissions { get; set; } = new();

    public List<Commission> Commission => Commissions;

    /// <summary>
    /// Country Vending machine's country ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachine> VendingMachines { get; set; } = new();

    public List<VendingMachine> VendingMachine => VendingMachines;

    /// <summary>
    /// Country Country's bank and public holidays ZeroOrMany CountryHolidays
    /// </summary>
    public virtual List<CountryHoliday> CountryHolidays { get; set; } = new();

    /// <summary>
    /// Country Customer's country ZeroOrMany Customers
    /// </summary>
    public virtual List<Customer> Customers { get; set; } = new();

    public List<Customer> Customer => Customers;

    /// <summary>
    /// Country Country's time zones OneOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZones> CountryTimeZones { get; set; } = new();

    public List<CountryTimeZones> TimeZones => CountryTimeZones;
}