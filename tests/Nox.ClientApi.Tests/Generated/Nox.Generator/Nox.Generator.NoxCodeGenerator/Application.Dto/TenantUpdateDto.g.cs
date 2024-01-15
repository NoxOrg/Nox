// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

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
public partial class TenantUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Teanant Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Tenant Status     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Int32? Status { get; set; }
    /// <summary>
    /// Tenant Brands owned by the tenant ZeroOrMany TenantBrands
    /// </summary>
    public virtual List<TenantBrandUpsertDto> TenantBrands { get; set; } = new();
    /// <summary>
    /// Tenant Contact information for the tenant ZeroOrOne TenantContacts
    /// </summary>
    public virtual TenantContactUpsertDto? TenantContact { get; set; } = null!;
}