﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Customer payment account related data.
/// </summary>
public partial class PaymentDetailCreateDto 
{    
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
    /// PaymentDetail used by ExactlyOne Customers
    /// </summary>
    [Required(ErrorMessage = "PaymentDetailsUsedByCustomer is required")]
    public System.Int64 PaymentDetailsUsedByCustomerId { get; set; } = default!;

    /// <summary>
    /// PaymentDetail related to ExactlyOne PaymentProviders
    /// </summary>
    [Required(ErrorMessage = "PaymentDetailsRelatedPaymentProvider is required")]
    public System.Int64 PaymentDetailsRelatedPaymentProviderId { get; set; } = default!;

    public Cryptocash.Domain.PaymentDetail ToEntity()
    {
        var entity = new Cryptocash.Domain.PaymentDetail();
        entity.PaymentAccountName = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountName(PaymentAccountName);
        entity.PaymentAccountNumber = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountNumber(PaymentAccountNumber);
        if (PaymentAccountSortCode is not null)entity.PaymentAccountSortCode = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountSortCode(PaymentAccountSortCode.NonNullValue<System.String>());
        //entity.Customer = Customer.ToEntity();
        //entity.PaymentProvider = PaymentProvider.ToEntity();
        return entity;
    }
}