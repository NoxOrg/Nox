// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cryptocash.Domain;

using CommissionEntity = Cryptocash.Domain.Commission;
namespace Cryptocash.Application.Dto;

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public partial class CommissionUpdateDto : IEntityDto<CommissionEntity>
{
    /// <summary>
    /// Commission rate (Required).
    /// </summary>
    [Required(ErrorMessage = "Rate is required")]
    
    public System.Single Rate { get; set; } = default!;
    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    [Required(ErrorMessage = "EffectiveAt is required")]
    
    public System.DateTimeOffset EffectiveAt { get; set; } = default!;

    /// <summary>
    /// Commission fees for ZeroOrOne Countries
    /// </summary>
    
    public System.String? CommissionFeesForCountryId { get; set; } = default!;
}