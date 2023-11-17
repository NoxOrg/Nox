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
/// Tenant.
/// </summary>
public partial class TenantUpdateDto : TenantUpdateDtoBase
{

}

/// <summary>
/// Tenant
/// </summary>
public partial class TenantUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Tenant>
{
    /// <summary>
    /// Teanant Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
}