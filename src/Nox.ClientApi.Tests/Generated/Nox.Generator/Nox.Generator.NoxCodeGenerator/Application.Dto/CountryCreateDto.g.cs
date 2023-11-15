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
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Population Number of People living in the country 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Int32? Population { get; set; }
    /// <summary>
    /// The Money 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual MoneyDto? CountryDebt { get; set; }
    /// <summary>
    /// First Official Language 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? FirstLanguageCode { get; set; }
    /// <summary>
    /// Country's iso number id 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.UInt16? CountryIsoNumeric { get; set; }
    /// <summary>
    /// Country's iso alpha3 id 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? CountryIsoAlpha3 { get; set; }
    /// <summary>
    /// Country's map via google maps 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? GoogleMapsUrl { get; set; }
    /// <summary>
    /// Country's start of week day 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.UInt16? StartOfWeek { get; set; }
    /// <summary>
    /// Country Continent 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Int32? Continent { get; set; }

    /// <summary>
    /// Country Country workplaces ZeroOrMany Workplaces
    /// </summary>
    public virtual List<System.UInt32> WorkplacesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<WorkplaceCreateDto> Workplaces { get; set; } = new();

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalNameCreateDto> CountryShortNames { get; set; } = new();

    /// <summary>
    /// Country is also coded as ZeroOrOne CountryBarCodes
    /// </summary>
    public virtual CountryBarCodeCreateDto? CountryBarCode { get; set; } = null!;
}