// Generated

#nullable enable
using System;
using System.Linq;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class StoreLicenseExtensions
{
    public static StoreLicenseDto ToDto(this StoreLicense entity)
    {
        var dto = new StoreLicenseDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Issuer, () => dto.Issuer = entity!.Issuer!.Value);
        SetIfNotNull(entity?.StoreWithLicenseId, () => dto.StoreWithLicenseId = entity!.StoreWithLicenseId!.Value);
        SetIfNotNull(entity?.StoreWithLicense, () => dto.StoreWithLicense = entity!.StoreWithLicense!.ToDto());

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