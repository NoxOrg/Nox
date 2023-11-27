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
public partial class CommissionUpdateDto : CommissionUpdateDtoBase
{

}

/// <summary>
/// Patch entity Commission: Exchange commission rate and amount.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class CommissionPatchDto: { { className} }
{

}

/// <summary>
/// Exchange commission rate and amount
/// </summary>
public partial class CommissionUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Commission>
{
    /// <summary>
    /// Commission rate     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Rate is required")]
    
    public virtual System.Single Rate { get; set; } = default!;
    /// <summary>
    /// Exchange rate conversion amount     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "EffectiveAt is required")]
    
    public virtual System.DateTimeOffset EffectiveAt { get; set; } = default!;
}