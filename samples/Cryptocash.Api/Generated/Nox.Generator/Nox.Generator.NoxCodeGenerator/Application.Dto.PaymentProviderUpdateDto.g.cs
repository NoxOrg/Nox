// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto; 

/// <summary>
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The payment provider name (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentProviderName is required")]
    
    public System.String PaymentProviderName { get; set; } = default!;
    /// <summary>
    /// The payment account type (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentProviderType is required")]
    
    public System.String PaymentProviderType { get; set; } = default!;
}