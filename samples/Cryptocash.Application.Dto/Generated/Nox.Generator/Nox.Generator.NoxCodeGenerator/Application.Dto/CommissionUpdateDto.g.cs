// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public partial class CommissionUpdateDto : CommissionUpdateDtoBase
{

}

/// <summary>
/// Exchange commission rate and amount
/// </summary>
public partial class CommissionUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Commission rate     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Rate is required")]
    
    public virtual System.Single? Rate { get; set; }
    /// <summary>
    /// Exchange rate conversion amount     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "EffectiveAt is required")]
    
    public virtual System.DateTimeOffset? EffectiveAt { get; set; }
}