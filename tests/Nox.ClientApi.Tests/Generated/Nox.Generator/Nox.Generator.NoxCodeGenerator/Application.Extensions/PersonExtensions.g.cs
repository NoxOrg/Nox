// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class PersonExtensions
{
    public static PersonDto ToDto(this ClientApi.Domain.Person entity)
    {
        var dto = new PersonDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.FirstName, (dto) => dto.FirstName =entity!.FirstName!.Value);
        dto.SetIfNotNull(entity?.LastName, (dto) => dto.LastName =entity!.LastName!.Value);
        dto.SetIfNotNull(entity?.TenantId, (dto) => dto.TenantId =entity!.TenantId!.Value);
        dto.SetIfNotNull(entity?.PrimaryEmailAddress, (dto) => dto.PrimaryEmailAddress =entity!.PrimaryEmailAddress!.Value);
        dto.SetIfNotNull(entity?.UserContactSelection, (dto) => dto.UserContactSelection = entity!.UserContactSelection!.ToDto());

        return dto;
    }
}