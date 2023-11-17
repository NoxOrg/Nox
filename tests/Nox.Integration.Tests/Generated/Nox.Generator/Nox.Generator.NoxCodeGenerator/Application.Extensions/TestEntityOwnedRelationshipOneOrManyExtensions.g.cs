// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOwnedRelationshipOneOrManyExtensions
{
    public static TestEntityOwnedRelationshipOneOrManyDto ToDto(this TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany entity)
    {
        var dto = new TestEntityOwnedRelationshipOneOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.SecondTestEntityOwnedRelationshipOneOrMany, (dto) => dto.SecondTestEntityOwnedRelationshipOneOrMany = entity!.SecondTestEntityOwnedRelationshipOneOrMany.Select(e => e.ToDto()).ToList());

        return dto;
    }
}