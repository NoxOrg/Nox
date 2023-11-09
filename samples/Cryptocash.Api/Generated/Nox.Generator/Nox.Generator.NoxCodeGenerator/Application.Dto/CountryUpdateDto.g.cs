// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Country and related data
/// </summary>
public partial class CountryUpdateDto : IEntityDto<DomainNamespace.Country>
{
    /// <summary>
    /// Country's name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Country's official name 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? OfficialName { get; set; }
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
    /// Country's geo coordinates 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public LatLongDto? GeoCoords { get; set; }
    /// <summary>
    /// Country's flag emoji 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? FlagEmoji { get; set; }
    /// <summary>
    /// Country's flag in svg format 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public ImageDto? FlagSvg { get; set; }
    /// <summary>
    /// Country's flag in png format 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public ImageDto? FlagPng { get; set; }
    /// <summary>
    /// Country's coat of arms in svg format 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public ImageDto? CoatOfArmsSvg { get; set; }
    /// <summary>
    /// Country's coat of arms in png format 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public ImageDto? CoatOfArmsPng { get; set; }
    /// <summary>
    /// Country's map via google maps 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? GoogleMapsUrl { get; set; }
    /// <summary>
    /// Country's map via open street maps 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? OpenStreetMapsUrl { get; set; }
    /// <summary>
    /// Country's start of week day 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "StartOfWeek is required")]
    
    public System.UInt16 StartOfWeek { get; set; } = default!;

    /// <summary>
    /// Country used by ExactlyOne Currencies
    /// </summary>
    [Required(ErrorMessage = "Currency is required")]
    public System.String CurrencyId { get; set; } = default!;

    /// <summary>
    /// Country used by OneOrMany Commissions
    /// </summary>
    public List<System.Int64> CommissionsId { get; set; } = new();

    /// <summary>
    /// Country used by ZeroOrMany VendingMachines
    /// </summary>
    public List<System.Guid> VendingMachinesId { get; set; } = new();

    /// <summary>
    /// Country used by ZeroOrMany Customers
    /// </summary>
    public List<System.Int64> CustomersId { get; set; } = new();
}