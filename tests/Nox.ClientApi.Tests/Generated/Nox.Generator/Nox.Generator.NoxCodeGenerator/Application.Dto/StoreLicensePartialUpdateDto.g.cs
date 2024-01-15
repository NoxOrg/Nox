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
public partial class StoreLicensePartialUpdateDto : StoreLicensePartialUpdateDtoBase
{

}

/// <summary>
/// Store license info
/// </summary>
public partial class StoreLicensePartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// License issuer
    /// </summary>
    public virtual System.String Issuer { get; set; } = default!;
}