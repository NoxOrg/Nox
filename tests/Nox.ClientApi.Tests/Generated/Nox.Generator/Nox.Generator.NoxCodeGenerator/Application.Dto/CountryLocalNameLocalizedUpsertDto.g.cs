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
/// CountryLocalName Localized Upsert DTO.
/// </summary>
public partial class CountryLocalNameLocalizedUpsertDto
{
    /// <summary>
    /// The unique identifier
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.Int64? Id { get; set; }
    /// <summary>
    /// Description
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? Description { get; set; }
}