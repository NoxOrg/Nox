// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CommissionKeyDto(System.Int64 keyId);

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public partial class CommissionDto
{

    /// <summary>
    /// Commission unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Commission rate (Required).
    /// </summary>
    public System.Single Rate { get; set; } = default!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public System.DateTimeOffset EffectiveAt { get; set; } = default!;

    /// <summary>
    /// Commission Commission's country ZeroOrOne Countries
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? CountryId { get; set; } = default!;
    public virtual CountryDto? Country { get; set; } = null!;

    /// <summary>
    /// Commission Booking's fee ZeroOrMany Bookings
    /// </summary>
    public virtual List<BookingDto> Bookings { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    public Commission ToEntity()
    {
        var entity = new Commission();
        entity.Id = Commission.CreateId(Id);
        entity.Rate = Commission.CreateRate(Rate);
        entity.EffectiveAt = Commission.CreateEffectiveAt(EffectiveAt);
        entity.Country = Country?.ToEntity();
        entity.Bookings = Bookings.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }

}