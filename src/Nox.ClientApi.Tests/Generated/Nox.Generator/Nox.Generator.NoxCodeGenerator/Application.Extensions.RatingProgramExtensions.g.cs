// Generated

#nullable enable
using System;
using System.Linq;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class RatingProgramExtensions
{
    public static RatingProgramDto ToDto(this RatingProgram entity)
    {
        var dto = new RatingProgramDto();
        SetIfNotNull(entity?.StoreId, () => dto.StoreId = entity!.StoreId.Value);
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Name, () => dto.Name =entity!.Name!.Value);

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