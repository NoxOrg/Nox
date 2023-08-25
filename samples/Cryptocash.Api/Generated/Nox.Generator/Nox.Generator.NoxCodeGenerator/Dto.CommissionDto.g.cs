// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using CryptocashApi.Application.DataTransferObjects;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record CommissionKeyDto(System.Int64 keyId);

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public partial class CommissionDto
{

    /// <summary>
    /// The commission unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The commission rate (Required).
    /// </summary>
    public System.Single Rate { get; set; } = default!;

    /// <summary>
    /// The exchange rate conversion amount (Required).
    /// </summary>
    public System.DateTimeOffset EffectiveAt { get; set; } = default!;

    /// <summary>
    /// Commission The commission related country ZeroOrOne Countries
    /// </summary>
    public virtual CountryDto ?Country { get; set; } = null!;

    /// <summary>
    /// Commission The booking's related fee ZeroOrMany Bookings
    /// </summary>
    public virtual List<BookingDto> Bookings { get; set; } = new();

    public System.DateTime? DeletedAtUtc { get; set; }
}