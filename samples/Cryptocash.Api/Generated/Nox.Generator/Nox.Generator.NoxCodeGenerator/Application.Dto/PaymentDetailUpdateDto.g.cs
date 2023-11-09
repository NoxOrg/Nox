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
/// Customer payment account related data
/// </summary>
public partial class PaymentDetailUpdateDto : IEntityDto<DomainNamespace.PaymentDetail>
{
    /// <summary>
    /// Payment account name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "PaymentAccountName is required")]
    
    public System.String PaymentAccountName { get; set; } = default!;
    /// <summary>
    /// Payment account reference number 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "PaymentAccountNumber is required")]
    
    public System.String PaymentAccountNumber { get; set; } = default!;
    /// <summary>
    /// Payment account sort code 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? PaymentAccountSortCode { get; set; }

    /// <summary>
    /// PaymentDetail used by ExactlyOne Customers
    /// </summary>
    [Required(ErrorMessage = "Customer is required")]
    public System.Int64 CustomerId { get; set; } = default!;

    /// <summary>
    /// PaymentDetail related to ExactlyOne PaymentProviders
    /// </summary>
    [Required(ErrorMessage = "PaymentProvider is required")]
    public System.Int64 PaymentProviderId { get; set; } = default!;
}