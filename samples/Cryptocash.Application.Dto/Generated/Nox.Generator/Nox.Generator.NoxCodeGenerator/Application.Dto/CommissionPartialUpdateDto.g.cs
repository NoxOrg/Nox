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
public partial class CommissionPartialUpdateDto : CommissionPartialUpdateDtoBase
{

}

/// <summary>
/// Exchange commission rate and amount
/// </summary>
public partial class CommissionPartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Commission rate
    /// </summary>
    public virtual System.Single Rate { get; set; } = default!;
    /// <summary>
    /// Exchange rate conversion amount
    /// </summary>
    public virtual System.DateTimeOffset EffectiveAt { get; set; } = default!;
}