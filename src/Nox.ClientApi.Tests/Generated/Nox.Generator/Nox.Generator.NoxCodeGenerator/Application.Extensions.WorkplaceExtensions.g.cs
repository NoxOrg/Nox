// Generated

#nullable enable
using System;
using System.Linq;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class WorkplaceExtensions
{
    public static WorkplaceDto ToDto(this Workplace entity)
    {
        var dto = new WorkplaceDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Name, () => dto.Name =entity!.Name!.Value);
        SetIfNotNull(entity?.Description, () => dto.Description =entity!.Description!.Value);
        SetIfNotNull(entity?.Greeting, () => dto.Greeting =entity!.Greeting!.ToString());
        SetIfNotNull(entity?.BelongsToCountryId, () => dto.BelongsToCountryId = entity!.BelongsToCountryId!.Value);
        SetIfNotNull(entity?.BelongsToCountry, () => dto.BelongsToCountry = entity!.BelongsToCountry!.ToDto());

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