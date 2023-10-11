﻿// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class WorkplaceExtensions
{
    public static WorkplaceDto ToDto(this Workplace entity)
    {
        var dto = new WorkplaceDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Description, (dto) => dto.Description =entity!.Description!.Value);
        dto.SetIfNotNull(entity?.Greeting, (dto) => dto.Greeting =entity!.Greeting!.ToString());
        dto.SetIfNotNull(entity?.BelongsToCountryId, (dto) => dto.BelongsToCountryId = entity!.BelongsToCountryId!.Value);

        return dto;
    }
}