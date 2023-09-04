// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using Cryptocash.Application.DataTransferObjects;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CountryTimeZonesKeyDto(System.Int64 keyId);

/// <summary>
/// Time zones related to country.
/// </summary>
public partial class CountryTimeZonesDto
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