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
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderUpdateDto : IEntityDto<DomainNamespace.PaymentProvider>
{
    /// <summary>
    /// Payment provider name (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentProviderName is required")]
    
    public System.String PaymentProviderName { get; set; } = default!;
    /// <summary>
    /// Payment provider account type (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentProviderType is required")]
    
    public System.String PaymentProviderType { get; set; } = default!;

    /// <summary>
    /// PaymentProvider related to ZeroOrMany PaymentDetails
    /// </summary>
    public List<System.Int64> PaymentDetailsId { get; set; } = new();
}