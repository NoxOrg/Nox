// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class PaymentProviderExtensions
{
    public static PaymentProviderDto ToDto(this Cryptocash.Domain.PaymentProvider entity)
    {
        var dto = new PaymentProviderDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.PaymentProviderName, (dto) => dto.PaymentProviderName =entity!.PaymentProviderName!.Value);
        dto.SetIfNotNull(entity?.PaymentProviderType, (dto) => dto.PaymentProviderType =entity!.PaymentProviderType!.Value);
        dto.SetIfNotNull(entity?.PaymentProviderRelatedPaymentDetails, (dto) => dto.PaymentProviderRelatedPaymentDetails = entity!.PaymentProviderRelatedPaymentDetails.Select(e => e.ToDto()).ToList());

        return dto;
    }
}