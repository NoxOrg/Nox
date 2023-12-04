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

        return dto;
    }
}