// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record StoreLicenseKeyDto(System.Int64 keyId);

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
    

        return result;
    }
    #endregion

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// License issuer (Required).
    /// </summary>
    public System.String Issuer { get; set; } = default!;

    /// <summary>
    /// StoreLicense Store that this license related to ExactlyOne Stores
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid? StoreId { get; set; } = default!;
    public virtual StoreDto? Store { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}