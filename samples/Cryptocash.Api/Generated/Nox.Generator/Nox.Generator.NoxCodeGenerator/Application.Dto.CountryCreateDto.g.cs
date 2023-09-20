// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class CountryCreateDto : CountryCreateDtoBase
{

}

/// <summary>
/// Country and related data.
/// </summary>
public abstract class CountryCreateDtoBase : IEntityDto<Country>
{
    /// <summary>
    /// Country unique identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    /// Country's name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Country's official name (Optional).
    /// </summary>
    public virtual System.String? OfficialName { get; set; }
    /// <summary>
    /// Country's iso number id (Optional).
    /// </summary>
    public virtual System.UInt16? CountryIsoNumeric { get; set; }
    /// <summary>
    /// Country's iso alpha3 id (Optional).
    /// </summary>
    public virtual System.String? CountryIsoAlpha3 { get; set; }
    /// <summary>
    /// Country's geo coordinates (Optional).
    /// </summary>
    public virtual LatLongDto? GeoCoords { get; set; }
    /// <summary>
    /// Country's flag emoji (Optional).
    /// </summary>
    public virtual System.String? FlagEmoji { get; set; }
    /// <summary>
    /// Country's flag in svg format (Optional).
    /// </summary>
    public virtual ImageDto? FlagSvg { get; set; }
    /// <summary>
    /// Country's flag in png format (Optional).
    /// </summary>
    public virtual ImageDto? FlagPng { get; set; }
    /// <summary>
    /// Country's coat of arms in svg format (Optional).
    /// </summary>
    public virtual ImageDto? CoatOfArmsSvg { get; set; }
    /// <summary>
    /// Country's coat of arms in png format (Optional).
    /// </summary>
    public virtual ImageDto? CoatOfArmsPng { get; set; }
    /// <summary>
    /// Country's map via google maps (Optional).
    /// </summary>
    public virtual System.String? GoogleMapsUrl { get; set; }
    /// <summary>
    /// Country's map via open street maps (Optional).
    /// </summary>
    public virtual System.String? OpenStreetMapsUrl { get; set; }
    /// <summary>
    /// Country's start of week day (Required).
    /// </summary>
    [Required(ErrorMessage = "StartOfWeek is required")]
    
    public virtual System.UInt16 StartOfWeek { get; set; } = default!;

    /// <summary>
    /// Country used by ExactlyOne Currencies
    /// </summary>
    public virtual CurrencyCreateDto CountryUsedByCurrency { get; set; } = null!;

    /// <summary>
    /// Country used by OneOrMany Commissions
    /// </summary>
    public virtual List<CommissionCreateDto> CountryUsedByCommissions { get; set; } = new();

    /// <summary>
    /// Country used by ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachineCreateDto> CountryUsedByVendingMachines { get; set; } = new();

    /// <summary>
    /// Country used by ZeroOrMany Customers
    /// </summary>
    public virtual List<CustomerCreateDto> CountryUsedByCustomers { get; set; } = new();

    /// <summary>
    /// Country owned OneOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZoneCreateDto> CountryOwnedTimeZones { get; set; } = new();

    /// <summary>
    /// Country owned ZeroOrMany Holidays
    /// </summary>
    public virtual List<HolidayCreateDto> CountryOwnedHolidays { get; set; } = new();
}