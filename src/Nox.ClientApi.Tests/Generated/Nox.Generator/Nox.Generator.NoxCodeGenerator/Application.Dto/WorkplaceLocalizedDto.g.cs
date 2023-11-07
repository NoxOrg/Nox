// Generated

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Workplace Localized DTO.
/// </summary>
internal partial class WorkplaceLocalizedDto
{
    /// <summary>
    /// Workplace unique identifier (Required).
    /// </summary>
    
    public System.UInt32 Id { get; set; } = default!;

    public System.String CultureCode { get; set; } = default!;

    /// <summary>
    /// Workplace Description (Optional).
    /// </summary>
    public System.String? Description { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}

/// <summary>
/// Record for Workplace Localized Key DTO.
/// </summary>
public record WorkplaceLocalizedKeyDto(System.UInt32 Id, System.String CultureCode);