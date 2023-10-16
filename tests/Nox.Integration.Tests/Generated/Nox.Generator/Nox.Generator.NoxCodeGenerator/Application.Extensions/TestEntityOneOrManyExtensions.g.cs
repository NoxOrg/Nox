// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOneOrManyExtensions
{
    public static TestEntityOneOrManyDto ToDto(this TestEntityOneOrMany entity)
    {
        var dto = new TestEntityOneOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.SecondTestEntityOneOrManyRelationship, (dto) => dto.SecondTestEntityOneOrManyRelationship = entity!.SecondTestEntityOneOrManyRelationship.Select(e => e.ToDto()).ToList());

        return dto;
    }
}