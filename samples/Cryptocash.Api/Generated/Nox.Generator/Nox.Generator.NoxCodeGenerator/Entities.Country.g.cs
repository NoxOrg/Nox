// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace CryptocashApi.Domain;

/// <summary>
/// Country and related data.
/// </summary>
public partial class Country : AuditableEntityBase
{
    /// <summary>
    /// The country unique identifier (Required).
    /// </summary>
    public CountryCode2 Id { get; set; } = null!;

    /// <summary>
    /// The country's name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// The country's official name (Required).
    /// </summary>
    public Nox.Types.Text OfficialName { get; set; } = null!;

    /// <summary>
    /// The country's iso number id (Required).
    /// </summary>
    public Nox.Types.CountryNumber CountryIsoNumeric { get; set; } = null!;

    /// <summary>
    /// The country's iso alpha3 id (Required).
    /// </summary>
    public Nox.Types.CountryCode3 CountryIsoAlpha3 { get; set; } = null!;

    /// <summary>
    /// The country's geo coordinates (Required).
    /// </summary>
    public Nox.Types.LatLong GeoCoords { get; set; } = null!;

    /// <summary>
    /// The country's flag emoji (Optional).
    /// </summary>
    public Nox.Types.Text? FlagEmoji { get; set; } = null!;

    /// <summary>
    /// The country's flag in svg format (Optional).
    /// </summary>
    public Nox.Types.Image? FlagSvg { get; set; } = null!;

    /// <summary>
    /// The country's flag in png format (Optional).
    /// </summary>
    public Nox.Types.Image? FlagPng { get; set; } = null!;

    /// <summary>
    /// The country's coat of arms in svg format (Optional).
    /// </summary>
    public Nox.Types.Image? CoatOfArmsSvg { get; set; } = null!;

    /// <summary>
    /// The country's coat of arms in png format (Optional).
    /// </summary>
    public Nox.Types.Image? CoatOfArmsPng { get; set; } = null!;

    /// <summary>
    /// The country's map via google maps (Optional).
    /// </summary>
    public Nox.Types.Url? GoogleMapsUrl { get; set; } = null!;

    /// <summary>
    /// The country's map via open street maps (Optional).
    /// </summary>
    public Nox.Types.Url? OpenStreeMapsUrl { get; set; } = null!;

    /// <summary>
    /// The country's map via open street maps (Required).
    /// </summary>
    public Nox.Types.DayOfWeek StartOfWeek { get; set; } = null!;

    /// <summary>
    /// Country The country's related currencies ZeroOrMany Currencies
    /// </summary>
    public virtual List<Currency> Currencies { get; set; } = new();

    /// <summary>
    /// Country The country's related timezones ZeroOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZones> CountryTimeZones { get; set; } = new();

    public List<CountryTimeZones> TimeZones => CountryTimeZones;

    /// <summary>
    /// Country The commission related country ZeroOrOne Commissions
    /// </summary>
    public virtual Commission? Commission { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity Commission
    /// </summary>
    public Nox.Types.DatabaseNumber? CommissionId { get; set; } = null!;

    /// <summary>
    /// Country The country of the vending machine ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachine> VendingMachines { get; set; } = new();

    public List<VendingMachine> VendingMachine => VendingMachines;

    /// <summary>
    /// Country The related country ZeroOrOne Holidays
    /// </summary>
    public virtual Holidays? Holidays { get; set; } = null!;
}