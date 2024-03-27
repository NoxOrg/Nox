// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class TenantBrandExtensions
{
    public static TenantBrandDto ToDto(this ClientApi.Domain.TenantBrand entity)
    {
        var dto = new TenantBrandDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Description, (dto) => dto.Description =entity!.Description!.Value);
        dto.SetIfNotNull(entity?.Status, (dto) => dto.Status =entity!.Status!.Value);

        return dto;
    }
}