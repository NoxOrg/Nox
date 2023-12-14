// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class ReferenceNumberEntityExtensions
{
    public static ReferenceNumberEntityDto ToDto(this ClientApi.Domain.ReferenceNumberEntity entity)
    {
        var dto = new ReferenceNumberEntityDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.ReferenceNumber, (dto) => dto.ReferenceNumber =entity!.ReferenceNumber!.Value);

        return dto;
    }
}