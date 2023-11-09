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

public partial class ExchangeRateCreateDto : ExchangeRateCreateDtoBase
{

}

/// <summary>
/// Exchange rate and related data.
/// </summary>
public abstract class ExchangeRateCreateDtoBase : IEntityDto<DomainNamespace.ExchangeRate>
{
    /// <summary>
    /// Exchange rate conversion amount 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "EffectiveRate is required")]
    
    public virtual System.Int32 EffectiveRate { get; set; } = default!;
    /// <summary>
    /// Exchange rate conversion amount 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "EffectiveAt is required")]
    
    public virtual System.DateTimeOffset EffectiveAt { get; set; } = default!;
}