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
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;

    /// <summary>
    /// Tenant Workplaces where the tenant is active ZeroOrMany Workplaces
    /// </summary>
    public virtual List<System.Int64> WorkplacesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<WorkplaceCreateDto> Workplaces { get; set; } = new();
}