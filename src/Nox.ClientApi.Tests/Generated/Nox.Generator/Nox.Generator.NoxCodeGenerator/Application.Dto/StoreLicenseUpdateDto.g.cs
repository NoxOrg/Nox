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
    /// License external id (Required).
    /// </summary>
    [Required(ErrorMessage = "ExternalId is required")]
    
    public System.Int64 ExternalId { get; set; } = default!;

    /// <summary>
    /// StoreLicense Store that this license related to ExactlyOne Stores
    /// </summary>
    [Required(ErrorMessage = "StoreWithLicense is required")]
    public System.Guid StoreWithLicenseId { get; set; } = default!;
}