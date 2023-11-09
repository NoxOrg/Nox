// Generated

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing localization Localized DTO.
/// </summary>
internal partial class TestEntityLocalizationLocalizedDto
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    public System.String CultureCode { get; set; } = default!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? TextFieldToLocalize { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}