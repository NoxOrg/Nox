// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class EmployeeExtensions
{
    public static EmployeeDto ToDto(this Employee entity)
    {
        var dto = new EmployeeDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.FirstName, () => dto.FirstName = entity!.FirstName!.Value);
        SetIfNotNull(entity?.LastName, () => dto.LastName = entity!.LastName!.Value);
        SetIfNotNull(entity?.EmailAddress, () => dto.EmailAddress = entity!.EmailAddress!.Value);
        SetIfNotNull(entity?.Address, () => dto.Address = entity!.Address!.ToDto());
        SetIfNotNull(entity?.FirstWorkingDay, () => dto.FirstWorkingDay = entity!.FirstWorkingDay!.Value.ToDateTime(new System.TimeOnly(0, 0, 0)));
        SetIfNotNull(entity?.LastWorkingDay, () => dto.LastWorkingDay = entity!.LastWorkingDay!.Value.ToDateTime(new System.TimeOnly(0, 0, 0)));
        SetIfNotNull(entity?.EmployeeReviewingCashStockOrderId, () => dto.EmployeeReviewingCashStockOrderId = entity!.EmployeeReviewingCashStockOrderId!.Value);
        SetIfNotNull(entity?.EmployeeReviewingCashStockOrder, () => dto.EmployeeReviewingCashStockOrder = entity!.EmployeeReviewingCashStockOrder!.ToDto());
        SetIfNotNull(entity?.EmployeeContactPhoneNumbers, () => dto.EmployeeContactPhoneNumbers = entity!.EmployeeContactPhoneNumbers.Select(e => e.ToDto()).ToList());

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