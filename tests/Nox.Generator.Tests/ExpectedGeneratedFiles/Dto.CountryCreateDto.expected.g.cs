// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// The list of countries.
/// </summary>
public partial class CountryCreateDto : CountryCreateDtoBase
{

}

/// <summary>
/// The list of countries.
/// </summary>
public abstract class CountryCreateDtoBase : IEntityDto<DomainNamespace.Country>
{
    /// <summary>
    /// 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    /// The country's common name 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// The country's official name 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "FormalName is required")]
    
    public virtual System.String FormalName { get; set; } = default!;
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "AlphaCode3 is required")]
    
    public virtual System.String AlphaCode3 { get; set; } = default!;
    /// <summary>
    /// The country's official ISO 4217 alpha-2 code 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "AlphaCode2 is required")]
    
    public virtual System.String AlphaCode2 { get; set; } = default!;
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "NumericCode is required")]
    
    public virtual System.Int16 NumericCode { get; set; } = default!;
    /// <summary>
    /// The country's phone dialing codes (comma-delimited) 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? DialingCodes { get; set; }
    /// <summary>
    /// The capital city of the country 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? Capital { get; set; }
    /// <summary>
    /// Noun denoting the natives of the country 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? Demonym { get; set; }
    /// <summary>
    /// Country area in square kilometers 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "AreaInSquareKilometres is required")]
    
    public virtual System.Int32 AreaInSquareKilometres { get; set; } = default!;
    /// <summary>
    /// The the position of the workplace's point on the surface of the Earth 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual LatLongDto? GeoCoord { get; set; }
    /// <summary>
    /// The region the country is in 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "GeoRegion is required")]
    
    public virtual System.String GeoRegion { get; set; } = default!;
    /// <summary>
    /// The sub-region the country is in 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "GeoSubRegion is required")]
    
    public virtual System.String GeoSubRegion { get; set; } = default!;
    /// <summary>
    /// The world region the country is in 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "GeoWorldRegion is required")]
    
    public virtual System.String GeoWorldRegion { get; set; } = default!;
    /// <summary>
    /// The estimated population of the country 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Int32? Population { get; set; }
    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited) 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? TopLevelDomains { get; set; }
    /// <summary>
    /// EncryptedText Nox Type 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Byte[]? EncryptedTextField { get; set; }
    /// <summary>
    /// HashedText Nox Type 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual HashedTextDto? HashedTextField { get; set; }
    /// <summary>
    /// Password Nox Type 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual PasswordDto? PasswordField { get; set; }
}