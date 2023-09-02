// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using Cryptocash.Application.DataTransferObjects;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CountryKeyDto(System.String keyId);

/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryDto
{

    /// <summary>
    /// Country unique identifier (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Country's name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Country's official name (Optional).
    /// </summary>
    public System.String? OfficialName { get; set; }

    /// <summary>
    /// Country's iso number id (Optional).
    /// </summary>
    public System.UInt16? CountryIsoNumeric { get; set; }

    /// <summary>
    /// Country's iso alpha3 id (Optional).
    /// </summary>
    public System.String? CountryIsoAlpha3 { get; set; }

    /// <summary>
    /// Country's geo coordinates (Optional).
    /// </summary>
    public LatLongDto? GeoCoords { get; set; }

    /// <summary>
    /// Country's flag emoji (Optional).
    /// </summary>
    public System.String? FlagEmoji { get; set; }

    /// <summary>
    /// Country's flag in svg format (Optional).
    /// </summary>
    public ImageDto? FlagSvg { get; set; }

    /// <summary>
    /// Country's flag in png format (Optional).
    /// </summary>
    public ImageDto? FlagPng { get; set; }

    /// <summary>
    /// Country's coat of arms in svg format (Optional).
    /// </summary>
    public ImageDto? CoatOfArmsSvg { get; set; }

    /// <summary>
    /// Country's coat of arms in png format (Optional).
    /// </summary>
    public ImageDto? CoatOfArmsPng { get; set; }

    /// <summary>
    /// Country's map via google maps (Optional).
    /// </summary>
    public System.String? GoogleMapsUrl { get; set; }

    /// <summary>
    /// Country's map via open street maps (Optional).
    /// </summary>
    public System.String? OpenStreetMapsUrl { get; set; }

    /// <summary>
    /// Country's start of week day (Required).
    /// </summary>
    public System.UInt16 StartOfWeek { get; set; } = default!;

    /// <summary>
    /// Country Country's primary currency for legal tender ExactlyOne Currencies
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String CurrencyId { get; set; } = default!;
    public virtual CurrencyDto Currency { get; set; } = null!;

    /// <summary>
    /// Country Commission rates country OneOrMany Commissions
    /// </summary>
    public virtual List<CommissionDto> Commissions { get; set; } = new();

    /// <summary>
    /// Country Vending machine's country ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachineDto> VendingMachines { get; set; } = new();

    /// <summary>
    /// Country Country's bank and public holidays ZeroOrMany CountryHolidays
    /// </summary>
    public virtual List<CountryHolidayDto> CountryHolidays { get; set; } = new();

    /// <summary>
    /// Country Customer's country ZeroOrMany Customers
    /// </summary>
    public virtual List<CustomerDto> Customers { get; set; } = new();

    /// <summary>
    /// Country Country's time zones OneOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZonesDto> CountryTimeZones { get; set; } = new();

    public System.DateTime? DeletedAtUtc { get; set; }
}