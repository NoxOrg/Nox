// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class StoreLicenseExtensions
{
    public static StoreLicenseDto ToDto(this ClientApi.Domain.StoreLicense entity)
    {
        var dto = new StoreLicenseDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Issuer, (dto) => dto.Issuer =entity!.Issuer!.Value);
        dto.SetIfNotNull(entity?.StoreId, (dto) => dto.StoreId = entity!.StoreId!.Value);
        dto.SetIfNotNull(entity?.DefaultCurrencyId, (dto) => dto.DefaultCurrencyId = entity!.DefaultCurrencyId!.Value);
        dto.SetIfNotNull(entity?.SoldInCurrencyId, (dto) => dto.SoldInCurrencyId = entity!.SoldInCurrencyId!.Value);

        return dto;
    }
}