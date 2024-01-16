// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public partial class CommissionCreateDto : CommissionCreateDtoBase
{

}

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public abstract class CommissionCreateDtoBase : IEntityDto<DomainNamespace.Commission>
{
    /// <summary>
    /// Commission unique identifier     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Guid? Id { get; set; }
    /// <summary>
    /// Commission rate     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Rate is required")]
    
    public virtual System.Single? Rate { get; set; }
    /// <summary>
    /// Exchange rate conversion amount     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "EffectiveAt is required")]
    
    public virtual System.DateTimeOffset? EffectiveAt { get; set; }

    /// <summary>
    /// Commission fees for ZeroOrOne Countries
    /// </summary>
    public System.String? CountryId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual CountryCreateDto? Country { get; set; } = default!;

    /// <summary>
    /// Commission fees for ZeroOrMany Bookings
    /// </summary>
    public virtual List<System.Guid> BookingsId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<BookingCreateDto> Bookings { get; set; } = new();
}