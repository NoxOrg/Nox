// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrOneExtensions
{
    public static TestEntityZeroOrOneDto ToDto(this TestEntityZeroOrOne entity)
    {
        var dto = new TestEntityZeroOrOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.SecondTestEntityZeroOrOneRelationshipId, (dto) => dto.SecondTestEntityZeroOrOneRelationshipId = entity!.SecondTestEntityZeroOrOneRelationshipId!.Value);

        return dto;
    }
}