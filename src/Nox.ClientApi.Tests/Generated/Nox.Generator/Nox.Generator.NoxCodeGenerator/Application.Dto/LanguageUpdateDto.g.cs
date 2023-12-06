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
/// Language.
/// </summary>
public partial class LanguageUpdateDto : LanguageUpdateDtoBase
{

}

/// <summary>
/// Language
/// </summary>
public partial class LanguageUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Language>
{
    /// <summary>
    /// Country's name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
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
    /// Region of country     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Region is required")]
    
    public virtual System.String Region { get; set; } = default!;
}