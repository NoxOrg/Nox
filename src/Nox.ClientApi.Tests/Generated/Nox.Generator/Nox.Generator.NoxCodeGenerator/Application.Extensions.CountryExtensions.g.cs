// Generated

#nullable enable
using System;
using System.Linq;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class CountryExtensions
{
    public static CountryDto ToDto(this Country entity)
    {
        var dto = new CountryDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Name, () => dto.Name = entity!.Name!.Value);
        SetIfNotNull(entity?.Population, () => dto.Population = entity!.Population!.Value);
        SetIfNotNull(entity?.CountryDebt, () => dto.CountryDebt = entity!.CountryDebt!.ToDto());
        SetIfNotNull(entity?.FirstLanguageCode, () => dto.FirstLanguageCode = entity!.FirstLanguageCode!.Value);
        SetIfNotNull(entity?.ShortDescription, () => dto.ShortDescription = entity!.ShortDescription);
        SetIfNotNull(entity?.CountryIsoNumeric, () => dto.CountryIsoNumeric = entity!.CountryIsoNumeric!.Value);
        SetIfNotNull(entity?.CountryIsoAlpha3, () => dto.CountryIsoAlpha3 = entity!.CountryIsoAlpha3!.Value);
        SetIfNotNull(entity?.GoogleMapsUrl, () => dto.GoogleMapsUrl = entity!.GoogleMapsUrl!.Value.ToString());
        SetIfNotNull(entity?.StartOfWeek, () => dto.StartOfWeek = entity!.StartOfWeek!.Value);
        SetIfNotNull(entity?.PhysicalWorkplaces, () => dto.PhysicalWorkplaces = entity!.PhysicalWorkplaces.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.CountryShortNames, () => dto.CountryShortNames = entity!.CountryShortNames.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.CountryBarCode, () => dto.CountryBarCode = entity!.CountryBarCode!.ToDto());

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