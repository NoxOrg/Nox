// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

public partial class StoreLicenseCreateDto : StoreLicenseCreateDtoBase
{

}

/// <summary>
/// Store license info.
/// </summary>
public abstract class StoreLicenseCreateDtoBase : IEntityDto<DomainNamespace.StoreLicense>
{
    /// <summary>
    /// License issuer 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Issuer is required")]
    
    public virtual System.String Issuer { get; set; } = default!;
    /// <summary>
    /// License external id 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "ExternalId is required")]
    
    public virtual System.Int64 ExternalId { get; set; } = default!;

    /// <summary>
    /// StoreLicense Store that this license related to ExactlyOne Stores
    /// </summary>
    public System.Guid? StoreId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual StoreCreateDto? Store { get; set; } = default!;

    /// <summary>
    /// StoreLicense Default currency for this license ZeroOrOne Currencies
    /// </summary>
    public System.String? DefaultCurrencyId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual CurrencyCreateDto? DefaultCurrency { get; set; } = default!;

    /// <summary>
    /// StoreLicense Currency this license was sold in ZeroOrOne Currencies
    /// </summary>
    public System.String? SoldInCurrencyId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual CurrencyCreateDto? SoldInCurrency { get; set; } = default!;
}