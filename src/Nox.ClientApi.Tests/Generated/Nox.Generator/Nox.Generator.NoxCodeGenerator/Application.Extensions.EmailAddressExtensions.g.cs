// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class EmailAddressExtensions
{
    public static EmailAddressDto ToDto(this EmailAddress entity)
    {
        var dto = new EmailAddressDto();
        dto.SetIfNotNull(entity?.Email, (dto) => dto.Email =entity!.Email!.Value);
        dto.SetIfNotNull(entity?.IsVerified, (dto) => dto.IsVerified =entity!.IsVerified!.Value);

        return dto;
    }
}