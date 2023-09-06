// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CountryTimeZoneKeyDto(System.Int64 keyId);

/// <summary>
/// Time zone related to country.
/// </summary>
public partial class CountryTimeZoneDto
{

    /// <summary>
    /// Country's time zone unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Country's related time zone code (Required).
    /// </summary>
    public System.String TimeZoneCode { get; set; } = default!;
}