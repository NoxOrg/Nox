// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class PaymentDetailExtensions
{
    public static PaymentDetailDto ToDto(this Cryptocash.Domain.PaymentDetail entity)
    {
        var dto = new PaymentDetailDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.PaymentAccountName, (dto) => dto.PaymentAccountName =entity!.PaymentAccountName!.Value);
        dto.SetIfNotNull(entity?.PaymentAccountNumber, (dto) => dto.PaymentAccountNumber =entity!.PaymentAccountNumber!.Value);
        dto.SetIfNotNull(entity?.PaymentAccountSortCode, (dto) => dto.PaymentAccountSortCode =entity!.PaymentAccountSortCode!.Value);

        return dto;
    }
}