// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOwnedRelationshipZeroOrOneExtensions
{
    public static TestEntityOwnedRelationshipZeroOrOneDto ToDto(this TestEntityOwnedRelationshipZeroOrOne entity)
    {
        var dto = new TestEntityOwnedRelationshipZeroOrOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.SecondTestEntityOwnedRelationshipZeroOrOne, (dto) => dto.SecondTestEntityOwnedRelationshipZeroOrOne = entity!.SecondTestEntityOwnedRelationshipZeroOrOne!.ToDto());

        return dto;
    }
}