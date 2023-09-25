// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public partial class StoreLicenseCreateDto : StoreLicenseCreateDtoBase
{

}

/// <summary>
/// Store license info.
/// </summary>
public abstract class StoreLicenseCreateDtoBase : IEntityDto<StoreLicense>
{
    /// <summary>
    /// License issuer (Required).
    /// </summary>
    [Required(ErrorMessage = "Issuer is required")]
    
    public virtual System.String Issuer { get; set; } = default!;

    /// <summary>
    /// StoreLicense Store that this license related to ExactlyOne Stores
    /// </summary>
    public virtual StoreCreateDto? StoreWithLicense { get; set; } = default!;
}