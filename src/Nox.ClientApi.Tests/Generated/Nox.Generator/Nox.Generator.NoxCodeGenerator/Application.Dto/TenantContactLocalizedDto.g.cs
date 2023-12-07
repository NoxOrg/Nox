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
/// Tenant Contact Localized DTO.
/// </summary>
public partial class TenantContactLocalizedDto
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public System.UInt32 TenantId { get; set; } = default!;

    public System.String CultureCode { get; set; } = default!;

    /// <summary>
    /// Teanant Brand Description (Optional).
    /// </summary>
    public System.String? Description { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}