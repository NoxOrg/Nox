// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
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
    /// Commission fees for ZeroOrOne Countries
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? CommissionFeesForCountryId { get; set; } = default!;
    public virtual CountryDto? CommissionFeesForCountry { get; set; } = null!;

    /// <summary>
    /// Commission fees for ZeroOrMany Bookings
    /// </summary>
    public virtual List<BookingDto> CommissionFeesForBooking { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    [JsonProperty("@odata.etag")]
    public System.Guid Etag { get; set; }
}