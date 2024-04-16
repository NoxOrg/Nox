// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class UserContactSelectionExtensions
{
    public static UserContactSelectionDto ToDto(this ClientApi.Domain.UserContactSelection entity)
    {
        var dto = new UserContactSelectionDto();
        dto.SetIfNotNull(entity?.ContactId, (dto) => dto.ContactId =entity!.ContactId!.Value);
        dto.SetIfNotNull(entity?.AccountId, (dto) => dto.AccountId =entity!.AccountId!.Value);
        dto.SetIfNotNull(entity?.SelectedDate, (dto) => dto.SelectedDate =entity!.SelectedDate!.Value);

        return dto;
    }
}