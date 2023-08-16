﻿// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleWebApp.Application.Dto; 

/// <summary>
/// The list of countries.
/// </summary>
public partial class CountryUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The country's common name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// The country's official name (Required).
    /// </summary>
    [Required(ErrorMessage = "FormalName is required")]
    
    public System.String FormalName { get; set; } = default!;
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code (Required).
    /// </summary>
    [Required(ErrorMessage = "AlphaCode3 is required")]
    
    public System.String AlphaCode3 { get; set; } = default!;
    /// <summary>
    /// The country's official ISO 4217 alpha-2 code (Required).
    /// </summary>
    [Required(ErrorMessage = "AlphaCode2 is required")]
    
    public System.String AlphaCode2 { get; set; } = default!;
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code (Required).
    /// </summary>
    [Required(ErrorMessage = "NumericCode is required")]
    
    public System.Int16 NumericCode { get; set; } = default!;
    /// <summary>
    /// The country's phone dialing codes (comma-delimited) (Optional).
    /// </summary>
    public System.String? DialingCodes { get; set; } 
    /// <summary>
    /// The capital city of the country (Optional).
    /// </summary>
    public System.String? Capital { get; set; } 
    /// <summary>
    /// Noun denoting the natives of the country (Optional).
    /// </summary>
    public System.String? Demonym { get; set; } 
    /// <summary>
    /// Country area in square kilometers (Required).
    /// </summary>
    [Required(ErrorMessage = "AreaInSquareKilometres is required")]
    
    public System.Decimal AreaInSquareKilometres { get; set; } = default!;
    /// <summary>
    /// The the position of the workplace's point on the surface of the Earth (Optional).
    /// </summary>
    public LatLongDto? GeoCoord { get; set; } 
    /// <summary>
    /// The region the country is in (Required).
    /// </summary>
    [Required(ErrorMessage = "GeoRegion is required")]
    
    public System.String GeoRegion { get; set; } = default!;
    /// <summary>
    /// The sub-region the country is in (Required).
    /// </summary>
    [Required(ErrorMessage = "GeoSubRegion is required")]
    
    public System.String GeoSubRegion { get; set; } = default!;
    /// <summary>
    /// The world region the country is in (Required).
    /// </summary>
    [Required(ErrorMessage = "GeoWorldRegion is required")]
    
    public System.String GeoWorldRegion { get; set; } = default!;
    /// <summary>
    /// The estimated population of the country (Optional).
    /// </summary>
    public System.Int32? Population { get; set; } 
    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited) (Optional).
    /// </summary>
    public System.String? TopLevelDomains { get; set; } 
}