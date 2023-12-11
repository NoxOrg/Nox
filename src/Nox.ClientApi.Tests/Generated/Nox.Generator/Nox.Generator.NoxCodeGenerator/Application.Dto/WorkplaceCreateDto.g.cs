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
/// Workplace.
/// </summary>
public partial class WorkplaceCreateDto : WorkplaceCreateDtoBase
{

}

/// <summary>
/// Workplace.
/// </summary>
public abstract class WorkplaceCreateDtoBase : IEntityDto<DomainNamespace.Workplace>
{
    /// <summary>
    /// Workplace Name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Workplace Description     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? Description { get; set; }
    /// <summary>
    /// Workplace Ownership     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.Int32? Ownership { get; set; }
    /// <summary>
    /// Workplace Type     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.Int32? Type { get; set; }

    /// <summary>
    /// Workplace Workplace country ZeroOrOne Countries
    /// </summary>
    public System.Int64? CountryId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual CountryCreateDto? Country { get; set; } = default!;

    /// <summary>
    /// Workplace Actve Tenants in the workplace ZeroOrMany Tenants
    /// </summary>
    public virtual List<System.UInt32> TenantsId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<TenantCreateDto> Tenants { get; set; } = new();
}