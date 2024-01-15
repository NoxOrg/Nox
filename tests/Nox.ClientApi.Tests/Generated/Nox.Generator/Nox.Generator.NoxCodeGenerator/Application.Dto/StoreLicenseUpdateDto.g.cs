// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Store license info.
/// </summary>
public partial class StoreLicenseUpdateDto : StoreLicenseUpdateDtoBase
{

}

/// <summary>
/// Store license info
/// </summary>
public partial class StoreLicenseUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// License issuer     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Issuer is required")]
    
    public virtual System.String? Issuer { get; set; }
}