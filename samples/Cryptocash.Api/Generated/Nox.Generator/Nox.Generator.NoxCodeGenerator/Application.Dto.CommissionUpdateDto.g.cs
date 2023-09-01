// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto;

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public partial class CommissionUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The commission rate (Required).
    /// </summary>
    [Required(ErrorMessage = "Rate is required")]
    
    public System.Single Rate { get; set; } = default!;
    /// <summary>
    /// The exchange rate conversion amount (Required).
    /// </summary>
    [Required(ErrorMessage = "EffectiveAt is required")]
    
    public System.DateTimeOffset EffectiveAt { get; set; } = default!;
}