// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryUpdateDto : CountryUpdateDtoBase
{

}

/// <summary>
/// Country and related data
/// </summary>
public partial class CountryUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Country's name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Country's official name     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? OfficialName { get; set; }
    /// <summary>
    /// Country's iso number id     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.UInt16? CountryIsoNumeric { get; set; }
    /// <summary>
    /// Country's iso alpha3 id     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? CountryIsoAlpha3 { get; set; }
    /// <summary>
    /// Country's geo coordinates     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual LatLongDto? GeoCoords { get; set; }
    /// <summary>
    /// Country's flag emoji     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? FlagEmoji { get; set; }
    /// <summary>
    /// Country's flag in svg format     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual ImageDto? FlagSvg { get; set; }
    /// <summary>
    /// Country's flag in png format     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual ImageDto? FlagPng { get; set; }
    /// <summary>
    /// Country's coat of arms in svg format     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual ImageDto? CoatOfArmsSvg { get; set; }
    /// <summary>
    /// Country's coat of arms in png format     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual ImageDto? CoatOfArmsPng { get; set; }
    /// <summary>
    /// Country's map via google maps     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? GoogleMapsUrl { get; set; }
    /// <summary>
    /// Country's map via open street maps     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? OpenStreetMapsUrl { get; set; }
    /// <summary>
    /// Country's start of week day     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "StartOfWeek is required")]
    
    public virtual System.UInt16? StartOfWeek { get; set; }
    /// <summary>
    /// Country's population     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Population is required")]
    
    public virtual System.Int32? Population { get; set; }
    /// <summary>
    /// Country owned OneOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZoneUpsertDto> CountryTimeZones { get; set; } = new();
    /// <summary>
    /// Country owned ZeroOrMany Holidays
    /// </summary>
    public virtual List<HolidayUpsertDto> Holidays { get; set; } = new();
}