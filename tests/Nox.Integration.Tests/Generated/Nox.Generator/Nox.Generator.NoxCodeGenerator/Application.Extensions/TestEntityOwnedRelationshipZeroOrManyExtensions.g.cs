// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOwnedRelationshipZeroOrManyExtensions
{
    public static TestEntityOwnedRelationshipZeroOrManyDto ToDto(this TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany entity)
    {
        var dto = new TestEntityOwnedRelationshipZeroOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.SecondTestEntityOwnedRelationshipZeroOrMany, (dto) => dto.SecondTestEntityOwnedRelationshipZeroOrMany = entity!.SecondTestEntityOwnedRelationshipZeroOrMany.Select(e => e.ToDto()).ToList());

        return dto;
    }
}