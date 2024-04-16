// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class EmailAddressExtensions
{
    public static EmailAddressDto ToDto(this ClientApi.Domain.EmailAddress entity)
    {
        var dto = new EmailAddressDto();
        dto.SetIfNotNull(entity?.Email, (dto) => dto.Email =entity!.Email!.Value);
        dto.SetIfNotNull(entity?.IsVerified, (dto) => dto.IsVerified =entity!.IsVerified!.Value);

        return dto;
    }
}