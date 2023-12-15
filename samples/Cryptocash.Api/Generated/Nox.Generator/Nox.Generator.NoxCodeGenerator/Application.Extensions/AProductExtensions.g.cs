// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class AProductExtensions
{
    public static AProductDto ToDto(this Cryptocash.Domain.AProduct entity)
    {
        var dto = new AProductDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.MyGuid, (dto) => dto.MyGuid =entity!.MyGuid!.Value);

        return dto;
    }
}