// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

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
public partial class CommissionPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Commission>
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