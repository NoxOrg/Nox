// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class TenantExtensions
{
    public static TenantDto ToDto(this ClientApi.Domain.Tenant entity)
    {
        var dto = new TenantDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Workplaces, (dto) => dto.Workplaces = entity!.Workplaces.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.TenantBrands, (dto) => dto.TenantBrands = entity!.TenantBrands.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.TenantContact, (dto) => dto.TenantContact = entity!.TenantContact!.ToDto());

        return dto;
    }
}