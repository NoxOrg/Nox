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
/// WorkplaceAddress Localized Upsert DTO.
/// </summary>
public partial class WorkplaceAddressLocalizedUpsertDto
{
    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.Guid? Id { get; set; }
    /// <summary>
    /// Address line
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String AddressLine { get; set; } = default!;
}