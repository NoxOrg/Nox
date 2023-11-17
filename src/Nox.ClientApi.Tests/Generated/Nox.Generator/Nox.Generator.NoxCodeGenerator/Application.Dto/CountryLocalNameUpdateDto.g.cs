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
/// Local names for countries.
/// </summary>
public partial class CountryLocalNameUpdateDto : CountryLocalNameUpdateDtoBase
{

}

/// <summary>
/// Local names for countries
/// </summary>
public partial class CountryLocalNameUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.CountryLocalName>
{
    /// <summary>
    /// Local name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Local name in native tongue     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? NativeName { get; set; }
}