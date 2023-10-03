// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class CommissionCreateDto : CommissionCreateDtoBase
{

}

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public abstract class CommissionCreateDtoBase : IEntityDto<Commission>
{
    /// <summary>
    /// Commission rate (Required).
    /// </summary>
    [Required(ErrorMessage = "Rate is required")]
    
    public virtual System.Single Rate { get; set; } = default!;
    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    [Required(ErrorMessage = "EffectiveAt is required")]
    
    public virtual System.DateTimeOffset EffectiveAt { get; set; } = default!;

    /// <summary>
    /// Commission fees for ZeroOrOne Countries
    /// </summary>
    public System.String? CommissionFeesForCountryId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual CountryCreateDto? CommissionFeesForCountry { get; set; } = default!;

    /// <summary>
    /// Commission fees for ZeroOrMany Bookings
    /// </summary>
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual List<BookingCreateDto> CommissionFeesForBooking { get; set; } = new();
}