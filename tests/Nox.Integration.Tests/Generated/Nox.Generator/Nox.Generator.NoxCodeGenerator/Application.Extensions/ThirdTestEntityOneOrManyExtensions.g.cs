// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class ThirdTestEntityOneOrManyExtensions
{
    public static ThirdTestEntityOneOrManyDto ToDto(this TestWebApp.Domain.ThirdTestEntityOneOrMany entity)
    {
        var dto = new ThirdTestEntityOneOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.ThirdTestEntityZeroOrManyRelationship, (dto) => dto.ThirdTestEntityZeroOrManyRelationship = entity!.ThirdTestEntityZeroOrManyRelationship.Select(e => e.ToDto()).ToList());

        return dto;
    }
}