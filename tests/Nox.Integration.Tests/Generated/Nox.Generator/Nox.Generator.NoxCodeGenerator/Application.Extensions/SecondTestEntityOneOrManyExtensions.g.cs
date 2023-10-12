// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityOneOrManyExtensions
{
    public static SecondTestEntityOneOrManyDto ToDto(this SecondTestEntityOneOrMany entity)
    {
        var dto = new SecondTestEntityOneOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.TestEntityOneOrManyRelationship, (dto) => dto.TestEntityOneOrManyRelationship = entity!.TestEntityOneOrManyRelationship.Select(e => e.ToDto()).ToList());

        return dto;
    }
}