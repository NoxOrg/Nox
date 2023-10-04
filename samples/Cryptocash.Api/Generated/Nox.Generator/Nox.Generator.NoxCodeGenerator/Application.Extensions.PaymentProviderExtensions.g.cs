// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class PaymentProviderExtensions
{
    public static PaymentProviderDto ToDto(this PaymentProvider entity)
    {
        var dto = new PaymentProviderDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.PaymentProviderName, () => dto.PaymentProviderName =entity!.PaymentProviderName!.Value);
        SetIfNotNull(entity?.PaymentProviderType, () => dto.PaymentProviderType =entity!.PaymentProviderType!.Value);
        SetIfNotNull(entity?.PaymentProviderRelatedPaymentDetails, () => dto.PaymentProviderRelatedPaymentDetails = entity!.PaymentProviderRelatedPaymentDetails.Select(e => e.ToDto()).ToList());

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