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
/// Entity created for testing localization Localized Upsert DTO.
/// </summary>
public partial class TestEntityLocalizationLocalizedUpsertDto
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String TextFieldToLocalize { get; set; } = default!;
}