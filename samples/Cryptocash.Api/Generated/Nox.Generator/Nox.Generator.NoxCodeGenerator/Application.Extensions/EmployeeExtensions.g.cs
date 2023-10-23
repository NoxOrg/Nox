﻿// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class EmployeeExtensions
{
    public static EmployeeDto ToDto(this Employee entity)
    {
        var dto = new EmployeeDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.FirstName, (dto) => dto.FirstName =entity!.FirstName!.Value);
        dto.SetIfNotNull(entity?.LastName, (dto) => dto.LastName =entity!.LastName!.Value);
        dto.SetIfNotNull(entity?.EmailAddress, (dto) => dto.EmailAddress =entity!.EmailAddress!.Value);
        dto.SetIfNotNull(entity?.Address, (dto) => dto.Address =entity!.Address!.ToDto());
        dto.SetIfNotNull(entity?.FirstWorkingDay, (dto) => dto.FirstWorkingDay =entity!.FirstWorkingDay!.Value.ToDateTime(new System.TimeOnly(0, 0, 0)));
        dto.SetIfNotNull(entity?.LastWorkingDay, (dto) => dto.LastWorkingDay =entity!.LastWorkingDay!.Value.ToDateTime(new System.TimeOnly(0, 0, 0)));
        dto.SetIfNotNull(entity?.EmployeeReviewingCashStockOrderId, (dto) => dto.EmployeeReviewingCashStockOrderId = entity!.EmployeeReviewingCashStockOrderId!.Value);
        dto.SetIfNotNull(entity?.EmployeeContactPhoneNumbers, (dto) => dto.EmployeeContactPhoneNumbers = entity!.EmployeeContactPhoneNumbers.Select(e => e.ToDto()).ToList());

        return dto;
    }
}