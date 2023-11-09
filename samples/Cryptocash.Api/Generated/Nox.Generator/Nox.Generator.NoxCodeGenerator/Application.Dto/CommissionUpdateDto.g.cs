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
/// Exchange commission rate and amount
/// </summary>
public partial class CommissionUpdateDto : IEntityDto<DomainNamespace.Commission>
{
    /// <summary>
    /// Commission rate 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Rate is required")]
    
    public System.Single Rate { get; set; } = default!;
    /// <summary>
    /// Exchange rate conversion amount 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "EffectiveAt is required")]
    
    public System.DateTimeOffset EffectiveAt { get; set; } = default!;

    /// <summary>
    /// Commission fees for ZeroOrOne Countries
    /// </summary>
    
    public System.String? CountryId { get; set; } = default!;

    /// <summary>
    /// Commission fees for ZeroOrMany Bookings
    /// </summary>
    public List<System.Guid> BookingsId { get; set; } = new();
}