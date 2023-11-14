﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Workplace.
/// </summary>
public partial class WorkplaceUpdateDto : WorkplaceUpdateDtoBase
{

}

/// <summary>
/// Workplace
/// </summary>
public partial class WorkplaceUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Workplace>
{
    /// <summary>
    /// Workplace Name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Workplace Description 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual System.String? Description { get; set; }

    /// <summary>
    /// Workplace Workplace country ZeroOrOne Countries
    /// </summary>
    
    public virtual System.Int64? CountryId { get; set; } = default!;

    /// <summary>
    /// Workplace Actve Tenants in the workplace ZeroOrMany Tenants
    /// </summary>
    public virtual List<System.Guid> TenantsId { get; set; } = new();
}