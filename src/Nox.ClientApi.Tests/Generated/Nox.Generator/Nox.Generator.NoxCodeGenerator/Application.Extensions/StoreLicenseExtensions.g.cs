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
        dto.SetIfNotNull(entity?.ExternalId, (dto) => dto.ExternalId =entity!.ExternalId!.Value);
        dto.SetIfNotNull(entity?.StoreWithLicenseId, (dto) => dto.StoreWithLicenseId = entity!.StoreWithLicenseId!.Value);

        return dto;
    }
}