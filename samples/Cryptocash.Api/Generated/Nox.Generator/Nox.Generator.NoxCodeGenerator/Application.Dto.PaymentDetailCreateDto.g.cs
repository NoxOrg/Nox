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
public partial class PaymentDetailCreateDto : PaymentDetailUpdateDto
{

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