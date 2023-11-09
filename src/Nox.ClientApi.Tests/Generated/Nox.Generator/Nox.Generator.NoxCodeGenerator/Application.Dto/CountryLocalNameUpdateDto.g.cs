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
/// Local names for countries
/// </summary>
public partial class CountryLocalNameUpdateDto : IEntityDto<DomainNamespace.CountryLocalName>
{
    /// <summary>
    /// Local name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Local name in native tongue 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? NativeName { get; set; }
}