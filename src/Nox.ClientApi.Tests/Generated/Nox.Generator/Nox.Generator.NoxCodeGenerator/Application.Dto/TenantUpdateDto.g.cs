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
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;

    /// <summary>
    /// Tenant Workplaces where the tenant is active ZeroOrMany Workplaces
    /// </summary>
    public virtual List<System.UInt32> WorkplacesId { get; set; } = new();
}