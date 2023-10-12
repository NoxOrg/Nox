// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class CountryExtensions
{
    public static CountryDto ToDto(this Country entity)
    {
        var dto = new CountryDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Population, (dto) => dto.Population =entity!.Population!.Value);
        dto.SetIfNotNull(entity?.CountryDebt, (dto) => dto.CountryDebt =entity!.CountryDebt!.ToDto());
        dto.SetIfNotNull(entity?.FirstLanguageCode, (dto) => dto.FirstLanguageCode =entity!.FirstLanguageCode!.Value);
        dto.SetIfNotNull(entity?.ShortDescription, (dto) => dto.ShortDescription =entity!.ShortDescription!.ToString());
        dto.SetIfNotNull(entity?.CountryIsoNumeric, (dto) => dto.CountryIsoNumeric =entity!.CountryIsoNumeric!.Value);
        dto.SetIfNotNull(entity?.CountryIsoAlpha3, (dto) => dto.CountryIsoAlpha3 =entity!.CountryIsoAlpha3!.Value);
        dto.SetIfNotNull(entity?.GoogleMapsUrl, (dto) => dto.GoogleMapsUrl =entity!.GoogleMapsUrl!.Value.ToString());
        dto.SetIfNotNull(entity?.StartOfWeek, (dto) => dto.StartOfWeek =entity!.StartOfWeek!.Value);
        dto.SetIfNotNull(entity?.PhysicalWorkplaces, (dto) => dto.PhysicalWorkplaces = entity!.PhysicalWorkplaces.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.CountryShortNames, (dto) => dto.CountryShortNames = entity!.CountryShortNames.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.CountryBarCode, (dto) => dto.CountryBarCode = entity!.CountryBarCode!.ToDto());

        return dto;
    }
}