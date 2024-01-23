// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class CountryExtensions
{
    public static CountryDto ToDto(this Cryptocash.Domain.Country entity)
    {
        var dto = new CountryDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.OfficialName, (dto) => dto.OfficialName =entity!.OfficialName!.Value);
        dto.SetIfNotNull(entity?.CountryIsoNumeric, (dto) => dto.CountryIsoNumeric =entity!.CountryIsoNumeric!.Value);
        dto.SetIfNotNull(entity?.CountryIsoAlpha3, (dto) => dto.CountryIsoAlpha3 =entity!.CountryIsoAlpha3!.Value);
        dto.SetIfNotNull(entity?.GeoCoords, (dto) => dto.GeoCoords =entity!.GeoCoords!.ToDto());
        dto.SetIfNotNull(entity?.FlagEmoji, (dto) => dto.FlagEmoji =entity!.FlagEmoji!.Value);
        dto.SetIfNotNull(entity?.FlagSvg, (dto) => dto.FlagSvg =entity!.FlagSvg!.ToDto());
        dto.SetIfNotNull(entity?.FlagPng, (dto) => dto.FlagPng =entity!.FlagPng!.ToDto());
        dto.SetIfNotNull(entity?.CoatOfArmsSvg, (dto) => dto.CoatOfArmsSvg =entity!.CoatOfArmsSvg!.ToDto());
        dto.SetIfNotNull(entity?.CoatOfArmsPng, (dto) => dto.CoatOfArmsPng =entity!.CoatOfArmsPng!.ToDto());
        dto.SetIfNotNull(entity?.GoogleMapsUrl, (dto) => dto.GoogleMapsUrl =entity!.GoogleMapsUrl!.Value.ToString());
        dto.SetIfNotNull(entity?.OpenStreetMapsUrl, (dto) => dto.OpenStreetMapsUrl =entity!.OpenStreetMapsUrl!.Value.ToString());
        dto.SetIfNotNull(entity?.StartOfWeek, (dto) => dto.StartOfWeek =entity!.StartOfWeek!.Value);
        dto.SetIfNotNull(entity?.Population, (dto) => dto.Population =entity!.Population!.Value);
        dto.SetIfNotNull(entity?.CountryTimeZones, (dto) => dto.CountryTimeZones = entity!.CountryTimeZones.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.Holidays, (dto) => dto.Holidays = entity!.Holidays.Select(e => e.ToDto()).ToList());

        return dto;
    }
}