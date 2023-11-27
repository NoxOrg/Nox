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
/// Patch entity Tenant: Tenant.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class TenantPatchDto: { { className} }
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