// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record StoreLicenseKeyDto(System.Int64 keyId);

/// <summary>
/// Update StoreLicense
/// Store license info.
/// </summary>
public partial class StoreLicenseDto : StoreLicenseDtoBase
{

}

/// <summary>
/// Store license info.
/// </summary>
public abstract class StoreLicenseDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.StoreLicense>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Issuer is not null)
            ExecuteActionAndCollectValidationExceptions("Issuer", () => DomainNamespace.StoreLicenseMetadata.CreateIssuer(this.Issuer.NonNullValue<System.String>()), result);
        else
            result.Add("Issuer", new [] { "Issuer is Required." });
    
        ExecuteActionAndCollectValidationExceptions("ExternalId", () => DomainNamespace.StoreLicenseMetadata.CreateExternalId(this.ExternalId), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// License issuer     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Issuer { get; set; } = default!;

    /// <summary>
    /// License external id     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int64 ExternalId { get; set; } = default!;

    /// <summary>
    /// StoreLicense Store that this license related to ExactlyOne Stores
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid? StoreId { get; set; } = default!;
    public virtual StoreDto? Store { get; set; } = null!;

    /// <summary>
    /// StoreLicense Default currency for this license ZeroOrOne Currencies
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? DefaultCurrencyId { get; set; } = default!;
    public virtual CurrencyDto? DefaultCurrency { get; set; } = null!;

    /// <summary>
    /// StoreLicense Currency this license was sold in ZeroOrOne Currencies
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? SoldInCurrencyId { get; set; } = default!;
    public virtual CurrencyDto? SoldInCurrency { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}