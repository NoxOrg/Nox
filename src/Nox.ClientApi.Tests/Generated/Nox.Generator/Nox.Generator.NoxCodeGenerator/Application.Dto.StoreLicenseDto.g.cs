// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record StoreLicenseKeyDto(System.Int64 keyId);

/// <summary>
/// Store license info.
/// </summary>
public partial class StoreLicenseDto
{

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
    public System.Guid? StoreWithLicenseId { get; set; } = default!;
    public virtual StoreDto? StoreWithLicense { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}