// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class EntityUniqueConstraintsRelatedForeignKeyExtensions
{
    public static EntityUniqueConstraintsRelatedForeignKeyDto ToDto(this TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey entity)
    {
        var dto = new EntityUniqueConstraintsRelatedForeignKeyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextField, (dto) => dto.TextField =entity!.TextField!.Value);

        return dto;
    }
}