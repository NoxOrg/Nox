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
/// Workplace.
/// </summary>
public partial class WorkplaceUpdateDto : WorkplaceUpdateDtoBase
{

}

/// <summary>
/// Patch entity Workplace: Workplace.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class WorkplacePatchDto: { { className} }
{

}

/// <summary>
/// Workplace
/// </summary>
public partial class WorkplaceUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Workplace>
{
    /// <summary>
    /// Workplace Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Workplace Description     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? Description { get; set; }
}