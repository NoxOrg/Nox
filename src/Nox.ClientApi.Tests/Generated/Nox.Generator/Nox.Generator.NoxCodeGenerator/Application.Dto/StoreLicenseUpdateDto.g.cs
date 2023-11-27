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
/// Store license info.
/// </summary>
public partial class StoreLicenseUpdateDto : StoreLicenseUpdateDtoBase
{

}

/// <summary>
/// Patch entity StoreLicense: Store license info.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class StoreLicensePatchDto: { { className} }
{

}

/// <summary>
/// Store license info
/// </summary>
public partial class StoreLicenseUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.StoreLicense>
{
    /// <summary>
    /// License issuer     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Issuer is required")]
    
    public virtual System.String Issuer { get; set; } = default!;
}