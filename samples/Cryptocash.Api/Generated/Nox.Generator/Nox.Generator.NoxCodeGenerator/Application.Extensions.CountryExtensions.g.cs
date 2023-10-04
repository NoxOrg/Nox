// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class CountryExtensions
{
    public static CountryDto ToDto(this Country entity)
    {
        var dto = new CountryDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Name, () => dto.Name =entity!.Name!.Value);
        SetIfNotNull(entity?.OfficialName, () => dto.OfficialName =entity!.OfficialName!.Value);
        SetIfNotNull(entity?.CountryIsoNumeric, () => dto.CountryIsoNumeric =entity!.CountryIsoNumeric!.Value);
        SetIfNotNull(entity?.CountryIsoAlpha3, () => dto.CountryIsoAlpha3 =entity!.CountryIsoAlpha3!.Value);
        SetIfNotNull(entity?.GeoCoords, () => dto.GeoCoords =entity!.GeoCoords!.ToDto());
        SetIfNotNull(entity?.FlagEmoji, () => dto.FlagEmoji =entity!.FlagEmoji!.Value);
        SetIfNotNull(entity?.FlagSvg, () => dto.FlagSvg =entity!.FlagSvg!.ToDto());
        SetIfNotNull(entity?.FlagPng, () => dto.FlagPng =entity!.FlagPng!.ToDto());
        SetIfNotNull(entity?.CoatOfArmsSvg, () => dto.CoatOfArmsSvg =entity!.CoatOfArmsSvg!.ToDto());
        SetIfNotNull(entity?.CoatOfArmsPng, () => dto.CoatOfArmsPng =entity!.CoatOfArmsPng!.ToDto());
        SetIfNotNull(entity?.GoogleMapsUrl, () => dto.GoogleMapsUrl =entity!.GoogleMapsUrl!.Value.ToString());
        SetIfNotNull(entity?.OpenStreetMapsUrl, () => dto.OpenStreetMapsUrl =entity!.OpenStreetMapsUrl!.Value.ToString());
        SetIfNotNull(entity?.StartOfWeek, () => dto.StartOfWeek =entity!.StartOfWeek!.Value);
        SetIfNotNull(entity?.CountryUsedByCurrencyId, () => dto.CountryUsedByCurrencyId = entity!.CountryUsedByCurrencyId!.Value);
        SetIfNotNull(entity?.CountryUsedByCurrency, () => dto.CountryUsedByCurrency = entity!.CountryUsedByCurrency!.ToDto());
        SetIfNotNull(entity?.CountryUsedByCommissions, () => dto.CountryUsedByCommissions = entity!.CountryUsedByCommissions.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.CountryUsedByVendingMachines, () => dto.CountryUsedByVendingMachines = entity!.CountryUsedByVendingMachines.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.CountryUsedByCustomers, () => dto.CountryUsedByCustomers = entity!.CountryUsedByCustomers.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.CountryOwnedTimeZones, () => dto.CountryOwnedTimeZones = entity!.CountryOwnedTimeZones.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.CountryOwnedHolidays, () => dto.CountryOwnedHolidays = entity!.CountryOwnedHolidays.Select(e => e.ToDto()).ToList());

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