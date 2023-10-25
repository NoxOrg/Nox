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

public partial class CountryCreateDto : CountryCreateDtoBase
{

}

/// <summary>
/// Country Entity.
/// </summary>
public abstract class CountryCreateDtoBase : IEntityDto<DomainNamespace.Country>
{
    /// <summary>
    /// The Country Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Population (Optional).
    /// </summary>
    public virtual System.Int32? Population { get; set; }
    /// <summary>
    /// The Money (Optional).
    /// </summary>
    public virtual MoneyDto? CountryDebt { get; set; }
    /// <summary>
    /// First Official Language (Optional).
    /// </summary>
    public virtual System.String? FirstLanguageCode { get; set; }
    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public virtual System.String? ShortDescription { get; set; }
    /// <summary>
    /// Country's iso number id (Optional).
    /// </summary>
    public virtual System.UInt16? CountryIsoNumeric { get; set; }
    /// <summary>
    /// Country's iso alpha3 id (Optional).
    /// </summary>
    public virtual System.String? CountryIsoAlpha3 { get; set; }
    /// <summary>
    /// Country's map via google maps (Optional).
    /// </summary>
    public virtual System.String? GoogleMapsUrl { get; set; }
    /// <summary>
    /// Country's start of week day (Optional).
    /// </summary>
    public virtual System.UInt16? StartOfWeek { get; set; }
    /// <summary>
    /// Country Continent (Optional).
    /// </summary>
    public virtual System.Int32? Continent { get; set; }

    /// <summary>
    /// Country Country workplaces ZeroOrMany Workplaces
    /// </summary>
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<WorkplaceCreateDto> PhysicalWorkplaces { get; set; } = new();

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalNameCreateDto> CountryShortNames { get; set; } = new();

    /// <summary>
    /// Country is also coded as ZeroOrOne CountryBarCodes
    /// </summary>
    public virtual CountryBarCodeCreateDto? CountryBarCode { get; set; } = null!;
}