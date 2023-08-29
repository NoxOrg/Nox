// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto;

/// <summary>
/// Customer payment account related data.
/// </summary>
public partial class CustomerPaymentDetailsUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The payment account name (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentAccountName is required")]
    
    public System.String PaymentAccountName { get; set; } = default!;
    /// <summary>
    /// The payment account type (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentAccountType is required")]
    
    public System.String PaymentAccountType { get; set; } = default!;
    /// <summary>
    /// The payment account reference number (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentAccountNumber is required")]
    
    public System.String PaymentAccountNumber { get; set; } = default!;
    /// <summary>
    /// The payment account sort code (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentAccountSortCode is required")]
    
    public System.String PaymentAccountSortCode { get; set; } = default!;

    /// <summary>
    /// CustomerPaymentDetails The payment account related customer ExactlyOne Customers
    /// </summary>
    public string CustomerId { get; set; } = null!;
}