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
/// Workplace Address Localized DTO.
/// </summary>
public partial class WorkplaceAddressLocalizedDto
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public System.Guid Id { get; set; } = default!;

    public System.String CultureCode { get; set; } = default!;

    /// <summary>
    /// Address line (Optional).
    /// </summary>
    public System.String? AddressLine { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}