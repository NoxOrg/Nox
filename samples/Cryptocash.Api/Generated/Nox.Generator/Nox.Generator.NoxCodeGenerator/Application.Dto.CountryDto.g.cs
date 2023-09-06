// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
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
    /// Country used by ExactlyOne Currencies
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String CountryUsedByCurrencyId { get; set; } = default!;
    public virtual CurrencyDto CountryUsedByCurrency { get; set; } = null!;

    /// <summary>
    /// Country used by OneOrMany Commissions
    /// </summary>
    public virtual List<CommissionDto> CountryUsedByCommissions { get; set; } = new();

    /// <summary>
    /// Country used by ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachineDto> CountryUsedByVendingMachines { get; set; } = new();

    /// <summary>
    /// Country used by ZeroOrMany Customers
    /// </summary>
    public virtual List<CustomerDto> CountryUsedByCustomers { get; set; } = new();

    /// <summary>
    /// Country owned OneOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZoneDto> CountryTimeZones { get; set; } = new();

    /// <summary>
    /// Country owned ZeroOrMany Holidays
    /// </summary>
    public virtual List<HolidayDto> Holidays { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; set; }
}