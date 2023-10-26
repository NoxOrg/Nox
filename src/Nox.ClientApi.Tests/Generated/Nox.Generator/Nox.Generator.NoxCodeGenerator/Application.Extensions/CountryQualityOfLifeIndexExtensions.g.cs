// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class CountryQualityOfLifeIndexExtensions
{
    public static CountryQualityOfLifeIndexDto ToDto(this ClientApi.Domain.CountryQualityOfLifeIndex entity)
    {
        var dto = new CountryQualityOfLifeIndexDto();
        dto.SetIfNotNull(entity?.CountryId, (dto) => dto.CountryId = entity!.CountryId.Value);
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.IndexRating, (dto) => dto.IndexRating =entity!.IndexRating!.Value);

        return dto;
    }
}