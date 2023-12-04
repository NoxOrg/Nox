// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class CountryExtensions
{
    public static CountryDto ToDto(this ClientApi.Domain.Country entity)
    {
        var dto = new CountryDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Population, (dto) => dto.Population =entity!.Population!.Value);
        dto.SetIfNotNull(entity?.CountryDebt, (dto) => dto.CountryDebt =entity!.CountryDebt!.ToDto());
        dto.SetIfNotNull(entity?.CapitalCityLocation, (dto) => dto.CapitalCityLocation =entity!.CapitalCityLocation!.ToDto());
        dto.SetIfNotNull(entity?.FirstLanguageCode, (dto) => dto.FirstLanguageCode =entity!.FirstLanguageCode!.Value);
        dto.SetIfNotNull(entity?.ShortDescription, (dto) => dto.ShortDescription =entity!.ShortDescription!.ToString());
        dto.SetIfNotNull(entity?.CountryIsoNumeric, (dto) => dto.CountryIsoNumeric =entity!.CountryIsoNumeric!.Value);
        dto.SetIfNotNull(entity?.CountryIsoAlpha3, (dto) => dto.CountryIsoAlpha3 =entity!.CountryIsoAlpha3!.Value);
        dto.SetIfNotNull(entity?.GoogleMapsUrl, (dto) => dto.GoogleMapsUrl =entity!.GoogleMapsUrl!.Value.ToString());
        dto.SetIfNotNull(entity?.StartOfWeek, (dto) => dto.StartOfWeek =entity!.StartOfWeek!.Value);
        dto.SetIfNotNull(entity?.Continent, (dto) => dto.Continent =entity!.Continent!.Value);
        dto.SetIfNotNull(entity?.CountryLocalNames, (dto) => dto.CountryLocalNames = entity!.CountryLocalNames.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.CountryBarCode, (dto) => dto.CountryBarCode = entity!.CountryBarCode!.ToDto());
        dto.SetIfNotNull(entity?.CountryTimeZones, (dto) => dto.CountryTimeZones = entity!.CountryTimeZones.Select(e => e.ToDto()).ToList());

        return dto;
    }
}