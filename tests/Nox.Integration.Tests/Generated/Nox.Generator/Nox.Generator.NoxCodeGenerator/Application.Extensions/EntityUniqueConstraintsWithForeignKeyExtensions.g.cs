// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class EntityUniqueConstraintsWithForeignKeyExtensions
{
    public static EntityUniqueConstraintsWithForeignKeyDto ToDto(this TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey entity)
    {
        var dto = new EntityUniqueConstraintsWithForeignKeyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextField, (dto) => dto.TextField =entity!.TextField!.Value);
        dto.SetIfNotNull(entity?.SomeUniqueId, (dto) => dto.SomeUniqueId =entity!.SomeUniqueId!.Value);

        return dto;
    }
}