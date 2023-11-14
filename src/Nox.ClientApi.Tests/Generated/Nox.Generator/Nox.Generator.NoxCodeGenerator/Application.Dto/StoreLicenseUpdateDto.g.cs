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
/// Store license info
/// </summary>
public partial class StoreLicenseUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.StoreLicense>
{
    /// <summary>
    /// License issuer 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Issuer is required")]
    
    public virtual System.String Issuer { get; set; } = default!;

    /// <summary>
    /// StoreLicense Store that this license related to ExactlyOne Stores
    /// </summary>
    [Required(ErrorMessage = "Store is required")]
    public virtual System.Guid StoreId { get; set; } = default!;

    /// <summary>
    /// StoreLicense Default currency for this license ZeroOrOne Currencies
    /// </summary>
    
    public virtual System.String? DefaultCurrencyId { get; set; } = default!;

    /// <summary>
    /// StoreLicense Currency this license was sold in ZeroOrOne Currencies
    /// </summary>
    
    public virtual System.String? SoldInCurrencyId { get; set; } = default!;
}