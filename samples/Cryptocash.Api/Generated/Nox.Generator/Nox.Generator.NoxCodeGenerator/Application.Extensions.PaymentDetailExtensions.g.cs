// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class PaymentDetailExtensions
{
    public static PaymentDetailDto ToDto(this PaymentDetail entity)
    {
        var dto = new PaymentDetailDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.PaymentAccountName, () => dto.PaymentAccountName =entity!.PaymentAccountName!.Value);
        SetIfNotNull(entity?.PaymentAccountNumber, () => dto.PaymentAccountNumber =entity!.PaymentAccountNumber!.Value);
        SetIfNotNull(entity?.PaymentAccountSortCode, () => dto.PaymentAccountSortCode =entity!.PaymentAccountSortCode!.Value);
        SetIfNotNull(entity?.PaymentDetailsUsedByCustomerId, () => dto.PaymentDetailsUsedByCustomerId = entity!.PaymentDetailsUsedByCustomerId!.Value);
        SetIfNotNull(entity?.PaymentDetailsUsedByCustomer, () => dto.PaymentDetailsUsedByCustomer = entity!.PaymentDetailsUsedByCustomer!.ToDto());
        SetIfNotNull(entity?.PaymentDetailsRelatedPaymentProviderId, () => dto.PaymentDetailsRelatedPaymentProviderId = entity!.PaymentDetailsRelatedPaymentProviderId!.Value);
        SetIfNotNull(entity?.PaymentDetailsRelatedPaymentProvider, () => dto.PaymentDetailsRelatedPaymentProvider = entity!.PaymentDetailsRelatedPaymentProvider!.ToDto());

        return dto;
    }

    private static void SetIfNotNull(object? value, Action setPropertyAction)
    {
        if (value is not null)
        {
            setPropertyAction();
        }
    }
}