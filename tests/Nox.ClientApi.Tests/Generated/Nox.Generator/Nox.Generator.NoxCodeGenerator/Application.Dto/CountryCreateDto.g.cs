// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Country Entity Country representation for the Client API tests.
/// </summary>
public partial class CountryCreateDto : CountryCreateDtoBase
{

}

/// <summary>
/// Country Entity Country representation for the Client API tests.
/// </summary>
public abstract class CountryCreateDtoBase : IEntityDto<DomainNamespace.Country>
{
    /// <summary>
    /// The Country Name     Set a unique name for the country Do not use abbreviations     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Population Number of People living in the country     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.Int32? Population { get; set; }
    /// <summary>
    /// The Money     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual MoneyDto? CountryDebt { get; set; }
    /// <summary>
    /// The capital location     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual LatLongDto? CapitalCityLocation { get; set; }
    /// <summary>
    /// First Official Language     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? FirstLanguageCode { get; set; }
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
    /// Country's map via google maps     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? GoogleMapsUrl { get; set; }
    /// <summary>
    /// Country's start of week day     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.UInt16? StartOfWeek { get; set; }
    /// <summary>
    /// Country Continent     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.Int32? Continent { get; set; }

    /// <summary>
    /// Country Country workplaces ZeroOrMany Workplaces
    /// </summary>
    public virtual List<System.Int64> WorkplacesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<WorkplaceCreateDto> Workplaces { get; set; } = new();

    /// <summary>
    /// Country Country stores ZeroOrMany Stores
    /// </summary>
    public virtual List<System.Guid> StoresId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<StoreCreateDto> Stores { get; set; } = new();

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalNameUpsertDto> CountryLocalNames { get; set; } = new();

    /// <summary>
    /// Country is also coded as ZeroOrOne CountryBarCodes
    /// </summary>
    public virtual CountryBarCodeUpsertDto? CountryBarCode { get; set; } = null!;

    /// <summary>
    /// Country uses ZeroOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZoneUpsertDto> CountryTimeZones { get; set; } = new();

    /// <summary>
    /// Country owned ZeroOrMany Holidays
    /// </summary>
    public virtual List<HolidayUpsertDto> Holidays { get; set; } = new();
}