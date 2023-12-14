// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class CountryBarCodeExtensions
{
    public static CountryBarCodeDto ToDto(this ClientApi.Domain.CountryBarCode entity)
    {
        var dto = new CountryBarCodeDto();
        dto.SetIfNotNull(entity?.BarCodeName, (dto) => dto.BarCodeName =entity!.BarCodeName!.Value);
        dto.SetIfNotNull(entity?.BarCodeNumber, (dto) => dto.BarCodeNumber =entity!.BarCodeNumber!.Value);

        return dto;
    }
}