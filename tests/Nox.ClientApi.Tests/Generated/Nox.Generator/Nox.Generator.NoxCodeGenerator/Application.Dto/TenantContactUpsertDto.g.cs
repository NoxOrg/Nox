// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Tenant Contact.
/// </summary>
public partial class TenantContactUpsertDto : TenantContactUpsertDtoBase
{

}

/// <summary>
/// Tenant Contact
/// </summary>
public abstract class TenantContactUpsertDtoBase: EntityDtoBase
{

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

    /// <summary>
    /// Teanant Brand Email     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Email is required")]
    public virtual System.String? Email { get; set; }

    /// <summary>
    /// Tenant Contact Status     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Int32? Status { get; set; }
}