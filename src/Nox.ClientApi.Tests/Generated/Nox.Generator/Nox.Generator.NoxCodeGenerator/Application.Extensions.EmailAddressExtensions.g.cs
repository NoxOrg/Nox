// Generated

#nullable enable
using System;
using System.Linq;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class EmailAddressExtensions
{
    public static EmailAddressDto ToDto(this EmailAddress entity)
    {
        var dto = new EmailAddressDto();
        SetIfNotNull(entity?.Email, () => dto.Email = entity!.Email!.Value);
        SetIfNotNull(entity?.IsVerified, () => dto.IsVerified = entity!.IsVerified!.Value);

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