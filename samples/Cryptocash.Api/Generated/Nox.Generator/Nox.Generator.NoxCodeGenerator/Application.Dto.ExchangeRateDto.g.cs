﻿// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using Cryptocash.Application.DataTransferObjects;
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

    /// <summary>
    /// ExchangeRate Exchanged from currency ExactlyOne Currencies
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string CurrencyId { get; set; } = null!;
    public virtual CurrencyDto Currency { get; set; } = null!;

    public System.DateTime? DeletedAtUtc { get; set; }
}