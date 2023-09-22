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

public record StoreDescriptionKeyDto(System.Guid keyStoreId, System.Int64 keyId);

/// <summary>
/// Description for store.
/// </summary>
public partial class StoreDescriptionDto
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.Guid StoreId { get; set; } = default!;

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Store Decsription (Optional).
    /// </summary>
    public System.String? Description { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}