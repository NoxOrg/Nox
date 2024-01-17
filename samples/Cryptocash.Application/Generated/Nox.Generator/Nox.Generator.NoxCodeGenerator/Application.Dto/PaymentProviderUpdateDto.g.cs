// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderUpdateDto : PaymentProviderUpdateDtoBase
{

}

/// <summary>
/// Payment provider related data
/// </summary>
public partial class PaymentProviderUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Payment provider name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "PaymentProviderName is required")]
    
    public virtual System.String? PaymentProviderName { get; set; }
    /// <summary>
    /// Payment provider account type     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "PaymentProviderType is required")]
    
    public virtual System.String? PaymentProviderType { get; set; }
}