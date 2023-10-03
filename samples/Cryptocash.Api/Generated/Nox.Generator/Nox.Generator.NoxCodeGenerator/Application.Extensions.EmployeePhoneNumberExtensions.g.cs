// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class EmployeePhoneNumberExtensions
{
    public static EmployeePhoneNumberDto ToDto(this EmployeePhoneNumber entity)
    {
        var dto = new EmployeePhoneNumberDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.PhoneNumberType, () => dto.PhoneNumberType = entity!.PhoneNumberType!.Value);
        SetIfNotNull(entity?.PhoneNumber, () => dto.PhoneNumber = entity!.PhoneNumber!.Value);

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