// Generated

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
public partial class CustomerPaymentDetailsCreateDto : CustomerPaymentDetailsUpdateDto
{

    public CustomerPaymentDetails ToEntity()
    {
        var entity = new CustomerPaymentDetails();
        entity.PaymentAccountName = CustomerPaymentDetails.CreatePaymentAccountName(PaymentAccountName);
        entity.PaymentAccountNumber = CustomerPaymentDetails.CreatePaymentAccountNumber(PaymentAccountNumber);
        if (PaymentAccountSortCode is not null)entity.PaymentAccountSortCode = CustomerPaymentDetails.CreatePaymentAccountSortCode(PaymentAccountSortCode.NonNullValue<System.String>());
        //entity.Customer = Customer.ToEntity();
        //entity.PaymentProvider = PaymentProvider.ToEntity();
        return entity;
    }
}