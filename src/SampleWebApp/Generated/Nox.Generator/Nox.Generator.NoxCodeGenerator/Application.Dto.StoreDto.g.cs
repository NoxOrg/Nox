// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public record StoreKeyDto(System.String keyId);

/// <summary>
/// Stores.
/// </summary>
public partial class StoreDto
{

    /// <summary>
    /// Store Primary Key (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Physical Money in the Physical Store (Required).
    /// </summary>
    public MoneyDto PhysicalMoney { get; set; } = default!;

    /// <summary>
    /// Store Set of passwords for this store ExactlyOne StoreSecurityPasswords
    /// </summary>
    public virtual StoreSecurityPasswordsDto PasswordsRel { get; set; } = null!;

    /// <summary>
    /// Store Store owner relationship ZeroOrOne StoreOwners
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? OwnerRelId { get; set; } = default!;
    public virtual StoreOwnerDto? OwnerRel { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    [JsonProperty("@odata.etag")]
    public System.Guid Etag { get; set; }
}