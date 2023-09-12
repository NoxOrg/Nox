// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record ExchangeRateKeyDto(System.Int64 keyId);

/// <summary>
/// Exchange rate and related data.
/// </summary>
public partial class ExchangeRateDto
{

    /// <summary>
    /// Exchange rate unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public System.Int32 EffectiveRate { get; set; } = default!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public System.DateTimeOffset EffectiveAt { get; set; } = default!;    
}