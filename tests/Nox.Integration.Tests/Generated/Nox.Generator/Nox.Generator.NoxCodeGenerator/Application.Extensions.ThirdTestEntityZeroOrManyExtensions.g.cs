// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class ThirdTestEntityZeroOrManyExtensions
{
    public static ThirdTestEntityZeroOrManyDto ToDto(this ThirdTestEntityZeroOrMany entity)
    {
        var dto = new ThirdTestEntityZeroOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.ThirdTestEntityOneOrManyRelationship, (dto) => dto.ThirdTestEntityOneOrManyRelationship = entity!.ThirdTestEntityOneOrManyRelationship.Select(e => e.ToDto()).ToList());

        return dto;
    }
}