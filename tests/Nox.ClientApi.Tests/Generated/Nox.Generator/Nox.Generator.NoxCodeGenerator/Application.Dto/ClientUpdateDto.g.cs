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
/// Client of a Store.
/// </summary>
public partial class ClientUpdateDto : ClientUpdateDtoBase
{

}

/// <summary>
/// Client of a Store
/// </summary>
public partial class ClientUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Client>
{
    /// <summary>
    /// Store Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
}