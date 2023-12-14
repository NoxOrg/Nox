// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryCreateDto : CountryCreateDtoBase
{

}

/// <summary>
/// Country and related data.
/// </summary>
public abstract class CountryCreateDtoBase : IEntityDto<DomainNamespace.Country>
{
    /// <summary>
    /// Country unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public virtual System.String? Id { get; set; }
    /// <summary>
    /// Country's name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Country's official name     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? OfficialName { get; set; }
    /// <summary>
    /// Country's iso number id     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.UInt16? CountryIsoNumeric { get; set; }
    /// <summary>
    /// Country's iso alpha3 id     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? CountryIsoAlpha3 { get; set; }
    /// <summary>
    /// Country's geo coordinates     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual LatLongDto? GeoCoords { get; set; }
    /// <summary>
    /// Country's flag emoji     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? FlagEmoji { get; set; }
    /// <summary>
    /// Country's flag in svg format     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual ImageDto? FlagSvg { get; set; }
    /// <summary>
    /// Country's flag in png format     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual ImageDto? FlagPng { get; set; }
    /// <summary>
    /// Country's coat of arms in svg format     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual ImageDto? CoatOfArmsSvg { get; set; }
    /// <summary>
    /// Country's coat of arms in png format     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual ImageDto? CoatOfArmsPng { get; set; }
    /// <summary>
    /// Country's map via google maps     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? GoogleMapsUrl { get; set; }
    /// <summary>
    /// Country's map via open street maps     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? OpenStreetMapsUrl { get; set; }
    /// <summary>
    /// Country's start of week day     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "StartOfWeek is required")]
    
    public virtual System.UInt16? StartOfWeek { get; set; }
    /// <summary>
    /// Country's population     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Population is required")]
    
    public virtual System.Int32? Population { get; set; }

    /// <summary>
    /// Country used by ExactlyOne Currencies
    /// </summary>
    public System.String? CurrencyId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual CurrencyCreateDto? Currency { get; set; } = default!;

    /// <summary>
    /// Country used by OneOrMany Commissions
    /// </summary>
    public virtual List<System.Int64> CommissionsId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<CommissionCreateDto> Commissions { get; set; } = new();

    /// <summary>
    /// Country used by ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<System.Guid> VendingMachinesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<VendingMachineCreateDto> VendingMachines { get; set; } = new();

    /// <summary>
    /// Country used by ZeroOrMany Customers
    /// </summary>
    public virtual List<System.Int64> CustomersId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<CustomerCreateDto> Customers { get; set; } = new();

    /// <summary>
    /// Country owned OneOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZoneUpsertDto> CountryTimeZones { get; set; } = new();

    /// <summary>
    /// Country owned ZeroOrMany Holidays
    /// </summary>
    public virtual List<HolidayUpsertDto> Holidays { get; set; } = new();
}