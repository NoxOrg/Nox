// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOwnedRelationshipExactlyOneExtensions
{
    public static TestEntityOwnedRelationshipExactlyOneDto ToDto(this TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne entity)
    {
        var dto = new TestEntityOwnedRelationshipExactlyOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.SecondTestEntityOwnedRelationshipExactlyOne, (dto) => dto.SecondTestEntityOwnedRelationshipExactlyOne = entity!.SecondTestEntityOwnedRelationshipExactlyOne!.ToDto());

        return dto;
    }
}