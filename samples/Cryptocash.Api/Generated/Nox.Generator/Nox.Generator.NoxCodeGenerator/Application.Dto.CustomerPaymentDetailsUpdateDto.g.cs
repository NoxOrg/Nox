﻿// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Customer payment account related data.
/// </summary>
public partial class CustomerPaymentDetailsUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// Payment account name (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentAccountName is required")]
    
    public System.String PaymentAccountName { get; set; } = default!;
    /// <summary>
    /// Payment account reference number (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentAccountNumber is required")]
    
    public System.String PaymentAccountNumber { get; set; } = default!;
    /// <summary>
    /// Payment account sort code (Optional).
    /// </summary>
    public System.String? PaymentAccountSortCode { get; set; }

    /// <summary>
    /// CustomerPaymentDetails Customer's payment account ExactlyOne Customers
    /// </summary>
    [Required(ErrorMessage = "Customer is required")]
    public System.Int64 CustomerId { get; set; } = default!;
}