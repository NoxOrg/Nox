// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using CryptocashApi.Application.DataTransferObjects;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record CountryKeyDto(System.String keyId);

/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryDto
{

    /// <summary>
    /// The country unique identifier (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// The country's name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// The country's official name (Required).
    /// </summary>
    public System.String OfficialName { get; set; } = default!;

    /// <summary>
    /// The country's iso number id (Required).
    /// </summary>
    public System.UInt16 CountryIsoNumeric { get; set; } = default!;

    /// <summary>
    /// The country's iso alpha3 id (Required).
    /// </summary>
    public System.String CountryIsoAlpha3 { get; set; } = default!;

    /// <summary>
    /// The country's geo coordinates (Required).
    /// </summary>
    public LatLongDto GeoCoords { get; set; } = default!;

    /// <summary>
    /// The country's flag emoji (Optional).
    /// </summary>
    public System.String? FlagEmoji { get; set; }

    /// <summary>
    /// The country's flag in svg format (Optional).
    /// </summary>
    public ImageDto? FlagSvg { get; set; }

    /// <summary>
    /// The country's flag in png format (Optional).
    /// </summary>
    public ImageDto? FlagPng { get; set; }

    /// <summary>
    /// The country's coat of arms in svg format (Optional).
    /// </summary>
    public ImageDto? CoatOfArmsSvg { get; set; }

    /// <summary>
    /// The country's coat of arms in png format (Optional).
    /// </summary>
    public ImageDto? CoatOfArmsPng { get; set; }

    /// <summary>
    /// The country's map via google maps (Optional).
    /// </summary>
    public System.String? GoogleMapsUrl { get; set; }

    /// <summary>
    /// The country's map via open street maps (Optional).
    /// </summary>
    public System.String? OpenStreeMapsUrl { get; set; }

    /// <summary>
    /// The country's map via open street maps (Required).
    /// </summary>
    public System.UInt16 StartOfWeek { get; set; } = default!;

    /// <summary>
    /// Country The country's related currencies ZeroOrMany Currencies
    /// </summary>
    public virtual List<CurrencyDto> Currencies { get; set; } = new();

    /// <summary>
    /// Country The country's related timezones ZeroOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZonesDto> CountryTimeZones { get; set; } = new();

    /// <summary>
    /// Country The commission related country ZeroOrOne Commissions
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string ?CommissionId { get; set; } = null!;
    public virtual CommissionDto ?Commission { get; set; } = null!;

    /// <summary>
    /// Country The country of the vending machine ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachineDto> VendingMachines { get; set; } = new();

    /// <summary>
    /// Country The related country ZeroOrOne Holidays
    /// </summary>
    public virtual HolidaysDto ?Holidays { get; set; } = null!;

    public System.DateTime? DeletedAtUtc { get; set; }
}