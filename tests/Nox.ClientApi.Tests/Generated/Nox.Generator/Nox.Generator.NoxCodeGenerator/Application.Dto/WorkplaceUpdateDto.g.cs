// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

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
public partial class WorkplaceUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Workplace Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Workplace Description     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? Description { get; set; }
    /// <summary>
    /// Workplace Ownership     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Int32? Ownership { get; set; }
    /// <summary>
    /// Workplace Type     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Int32? Type { get; set; }
}