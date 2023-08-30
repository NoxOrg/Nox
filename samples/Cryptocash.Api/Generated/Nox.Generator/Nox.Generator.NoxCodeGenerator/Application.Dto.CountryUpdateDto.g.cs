// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto;

/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The country's name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// The country's official name (Required).
    /// </summary>
    [Required(ErrorMessage = "OfficialName is required")]
    
    public System.String OfficialName { get; set; } = default!;
    /// <summary>
    /// The country's iso number id (Required).
    /// </summary>
    [Required(ErrorMessage = "CountryIsoNumeric is required")]
    
    public System.UInt16 CountryIsoNumeric { get; set; } = default!;
    /// <summary>
    /// The country's iso alpha3 id (Required).
    /// </summary>
    [Required(ErrorMessage = "CountryIsoAlpha3 is required")]
    
    public System.String CountryIsoAlpha3 { get; set; } = default!;
    /// <summary>
    /// The country's geo coordinates (Required).
    /// </summary>
    [Required(ErrorMessage = "GeoCoords is required")]
    
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
    [Required(ErrorMessage = "StartOfWeek is required")]
    
    public System.UInt16 StartOfWeek { get; set; } = default!;

    /// <summary>
    /// Country The commission related country ZeroOrOne Commissions
    /// </summary>
    public string? CommissionId { get; set; } = null!;
}