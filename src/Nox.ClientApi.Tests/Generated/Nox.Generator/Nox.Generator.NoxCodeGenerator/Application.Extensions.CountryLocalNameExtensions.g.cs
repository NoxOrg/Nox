// Generated

#nullable enable
using System;
using System.Linq;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class CountryLocalNameExtensions
{
    public static CountryLocalNameDto ToDto(this CountryLocalName entity)
    {
        var dto = new CountryLocalNameDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Name, () => dto.Name = entity!.Name!.Value);
        SetIfNotNull(entity?.NativeName, () => dto.NativeName = entity!.NativeName!.Value);

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