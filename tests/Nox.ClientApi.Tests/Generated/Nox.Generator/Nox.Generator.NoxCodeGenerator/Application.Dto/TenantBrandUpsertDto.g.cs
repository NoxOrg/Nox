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
/// Tenant Brand.
/// </summary>
public partial class TenantBrandUpsertDto : TenantBrandUpsertDtoBase
{

}

/// <summary>
/// Tenant Brand
/// </summary>
public abstract class TenantBrandUpsertDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TenantBrand>
{

    /// <summary>
    /// 
    /// </summary>
    public virtual System.Int64? Id { get; set; }

    /// <summary>
    /// Teanant Brand Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    public virtual System.String? Name { get; set; }

    /// <summary>
    /// Teanant Brand Description     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Description is required")]
    public virtual System.String? Description { get; set; }
}