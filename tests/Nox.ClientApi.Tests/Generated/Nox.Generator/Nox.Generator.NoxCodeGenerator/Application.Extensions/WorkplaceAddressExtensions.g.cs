// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class WorkplaceAddressExtensions
{
    public static WorkplaceAddressDto ToDto(this ClientApi.Domain.WorkplaceAddress entity)
    {
        var dto = new WorkplaceAddressDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.AddressLine, (dto) => dto.AddressLine =entity!.AddressLine!.Value);

        return dto;
    }
}