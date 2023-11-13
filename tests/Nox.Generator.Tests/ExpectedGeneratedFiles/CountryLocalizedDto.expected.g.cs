// Generated

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// The list of countries Localized DTO.
/// </summary>
public partial class CountryLocalizedDto
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    public System.String CultureCode { get; set; } = default!;

    /// <summary>
    /// The country's official name (Optional).
    /// </summary>
    public System.String? FormalName { get; set; }

    /// <summary>
    /// The country's official ISO 4217 alpha-3 code (Optional).
    /// </summary>
    public System.String? AlphaCode3 { get; set; }

    /// <summary>
    /// The capital city of the country (Optional).
    /// </summary>
    public System.String? Capital { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}