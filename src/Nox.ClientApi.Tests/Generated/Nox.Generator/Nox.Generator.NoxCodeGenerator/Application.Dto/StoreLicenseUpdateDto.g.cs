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
public partial class StoreLicenseUpdateDto : IEntityDto<DomainNamespace.StoreLicense>
{
    /// <summary>
    /// License issuer (Required).
    /// </summary>
    [Required(ErrorMessage = "Issuer is required")]
    
    public System.String Issuer { get; set; } = default!;

    /// <summary>
    /// StoreLicense Store that this license related to ExactlyOne Stores
    /// </summary>
    [Required(ErrorMessage = "Store is required")]
    public System.Guid StoreId { get; set; } = default!;
}