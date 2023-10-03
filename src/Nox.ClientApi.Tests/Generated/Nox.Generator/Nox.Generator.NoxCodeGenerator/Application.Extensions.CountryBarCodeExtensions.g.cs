// Generated

#nullable enable
using System;
using System.Linq;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class CountryBarCodeExtensions
{
    public static CountryBarCodeDto ToDto(this CountryBarCode entity)
    {
        var dto = new CountryBarCodeDto();
        SetIfNotNull(entity?.BarCodeName, () => dto.BarCodeName = entity!.BarCodeName!.Value);
        SetIfNotNull(entity?.BarCodeNumber, () => dto.BarCodeNumber = entity!.BarCodeNumber!.Value);

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