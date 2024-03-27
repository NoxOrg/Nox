// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class TenantContactExtensions
{
    public static TenantContactDto ToDto(this ClientApi.Domain.TenantContact entity)
    {
        var dto = new TenantContactDto();
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Description, (dto) => dto.Description =entity!.Description!.Value);
        dto.SetIfNotNull(entity?.Email, (dto) => dto.Email =entity!.Email!.Value);
        dto.SetIfNotNull(entity?.Status, (dto) => dto.Status =entity!.Status!.Value);

        return dto;
    }
}