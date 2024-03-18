// Generated

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Country Localized Upsert DTO.
/// </summary>
public partial class CountryLocalizedUpsertDto
{
    /// <summary>
    /// TestAttForLocalization
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? TestAttForLocalization { get; set; }
}