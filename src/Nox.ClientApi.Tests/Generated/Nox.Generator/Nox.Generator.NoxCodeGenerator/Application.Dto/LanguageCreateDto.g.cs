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
/// Language.
/// </summary>
public partial class LanguageCreateDto : LanguageCreateDtoBase
{

}

/// <summary>
/// Language.
/// </summary>
public abstract class LanguageCreateDtoBase : IEntityDto<DomainNamespace.Language>
{
    /// <summary>
    /// Language unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    /// Country's name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
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
    /// Region of country     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Region is required")]
    
    public virtual System.String Region { get; set; } = default!;
}