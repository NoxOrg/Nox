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
/// Tenant.
/// </summary>
public partial class TenantCreateDto : TenantCreateDtoBase
{

}

/// <summary>
/// Tenant.
/// </summary>
public abstract class TenantCreateDtoBase : IEntityDto<DomainNamespace.Tenant>
{
    /// <summary>
    /// Teanant Name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;

    /// <summary>
    /// Tenant Workplaces where the tenant is active ZeroOrMany Workplaces
    /// </summary>
    public virtual List<System.Int64> WorkplacesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<WorkplaceCreateDto> Workplaces { get; set; } = new();

    /// <summary>
    /// Tenant Brands owned by the tenant ZeroOrMany TenantBrands
    /// </summary>
    public virtual List<TenantBrandUpsertDto> TenantBrands { get; set; } = new();

    /// <summary>
    /// Tenant Contact information for the tenant ZeroOrOne TenantContacts
    /// </summary>
    public virtual TenantContactUpsertDto? TenantContact { get; set; } = null!;
}