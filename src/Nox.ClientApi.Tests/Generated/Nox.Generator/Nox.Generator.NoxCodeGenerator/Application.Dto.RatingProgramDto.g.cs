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

public record RatingProgramKeyDto(System.Guid keyStoreId, System.Int64 keyId);

/// <summary>
/// Rating program for store.
/// </summary>
public partial class RatingProgramDto
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
    /// Rating Program Name (Optional).
    /// </summary>
    public System.String? Name { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}