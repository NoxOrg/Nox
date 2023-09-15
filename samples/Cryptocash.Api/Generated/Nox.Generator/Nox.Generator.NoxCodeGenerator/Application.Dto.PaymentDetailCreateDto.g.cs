// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class PaymentDetailCreateDto: PaymentDetailCreateDtoBase
{

}

/// <summary>
/// Customer payment account related data.
/// </summary>
public abstract class PaymentDetailCreateDtoBase : IEntityCreateDto<PaymentDetail>
{    
    /// <summary>
    /// Payment account name (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentAccountName is required")]
    
    public virtual System.String PaymentAccountName { get; set; } = default!;    
    /// <summary>
    /// Payment account reference number (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentAccountNumber is required")]
    
    public virtual System.String PaymentAccountNumber { get; set; } = default!;    
    /// <summary>
    /// Payment account sort code (Optional).
    /// </summary>
    public virtual System.String? PaymentAccountSortCode { get; set; }

    /// <summary>
    /// PaymentDetail used by ExactlyOne Customers
    /// </summary>
    [Required(ErrorMessage = "PaymentDetailsUsedByCustomer is required")]
    public virtual CustomerCreateDto PaymentDetailsUsedByCustomer { get; set; } = null!;

    /// <summary>
    /// PaymentDetail related to ExactlyOne PaymentProviders
    /// </summary>
    [Required(ErrorMessage = "PaymentDetailsRelatedPaymentProvider is required")]
    public virtual PaymentProviderCreateDto PaymentDetailsRelatedPaymentProvider { get; set; } = null!;
}