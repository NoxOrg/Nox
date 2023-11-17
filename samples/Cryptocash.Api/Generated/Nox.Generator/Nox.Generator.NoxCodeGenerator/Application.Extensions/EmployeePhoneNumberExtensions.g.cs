// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class EmployeePhoneNumberExtensions
{
    public static EmployeePhoneNumberDto ToDto(this Cryptocash.Domain.EmployeePhoneNumber entity)
    {
        var dto = new EmployeePhoneNumberDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.PhoneNumberType, (dto) => dto.PhoneNumberType =entity!.PhoneNumberType!.Value);
        dto.SetIfNotNull(entity?.PhoneNumber, (dto) => dto.PhoneNumber =entity!.PhoneNumber!.Value);

        return dto;
    }
}