// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityExactlyOneExtensions
{
    public static TestEntityExactlyOneDto ToDto(this TestEntityExactlyOne entity)
    {
        var dto = new TestEntityExactlyOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.SecondTestEntityExactlyOneRelationshipId, (dto) => dto.SecondTestEntityExactlyOneRelationshipId = entity!.SecondTestEntityExactlyOneRelationshipId!.Value);

        return dto;
    }
}