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
/// Language Localized Upsert DTO.
/// </summary>
public partial class LanguageLocalizedUpsertDto
{
    /// <summary>
    /// Country's name
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Name { get; set; } = default!;
}