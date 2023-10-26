// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class RatingProgramExtensions
{
    public static RatingProgramDto ToDto(this ClientApi.Domain.RatingProgram entity)
    {
        var dto = new RatingProgramDto();
        dto.SetIfNotNull(entity?.StoreId, (dto) => dto.StoreId = entity!.StoreId.Value);
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);

        return dto;
    }
}