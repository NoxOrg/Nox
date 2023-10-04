// Generated

#nullable enable
using System;
using System.Linq;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class CountryQualityOfLifeIndexExtensions
{
    public static CountryQualityOfLifeIndexDto ToDto(this CountryQualityOfLifeIndex entity)
    {
        var dto = new CountryQualityOfLifeIndexDto();
        SetIfNotNull(entity?.CountryId, () => dto.CountryId = entity!.CountryId.Value);
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.IndexRating, () => dto.IndexRating =entity!.IndexRating!.Value);

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