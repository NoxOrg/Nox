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

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public partial class CommissionCreateDto : IEntityCreateDto<Commission>
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