// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Country Entity Country representation for the Client API tests
/// </summary>
public partial class CountryUpdateDto : IEntityDto<DomainNamespace.Country>
{
    /// <summary>
    /// The Country Name     Set a unique name for the country Do not use abbreviations 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Population Number of People living in the country 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.Int32? Population { get; set; }
    /// <summary>
    /// The Money 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public MoneyDto? CountryDebt { get; set; }
    /// <summary>
    /// First Official Language 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? FirstLanguageCode { get; set; }
    /// <summary>
    /// Country's iso number id 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.UInt16? CountryIsoNumeric { get; set; }
    /// <summary>
    /// Country's iso alpha3 id 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? CountryIsoAlpha3 { get; set; }
    /// <summary>
    /// Country's map via google maps 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? GoogleMapsUrl { get; set; }
    /// <summary>
    /// Country's start of week day 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.UInt16? StartOfWeek { get; set; }
    /// <summary>
    /// Country Continent 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.Int32? Continent { get; set; }

    /// <summary>
    /// Country Country workplaces ZeroOrMany Workplaces
    /// </summary>
    public List<System.Int64> WorkplacesId { get; set; } = new();
    /// <summary>
    /// Country is also coded as ZeroOrOne CountryBarCodes
    /// </summary>
    public CountryBarCodeUpdateDto? CountryBarCode { get; set; } = null!;
}