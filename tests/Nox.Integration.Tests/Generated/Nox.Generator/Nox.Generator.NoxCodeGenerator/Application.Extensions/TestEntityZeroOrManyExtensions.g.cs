// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrManyExtensions
{
    public static TestEntityZeroOrManyDto ToDto(this TestWebApp.Domain.TestEntityZeroOrMany entity)
    {
        var dto = new TestEntityZeroOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.SecondTestEntityZeroOrManyRelationship, (dto) => dto.SecondTestEntityZeroOrManyRelationship = entity!.SecondTestEntityZeroOrManyRelationship.Select(e => e.ToDto()).ToList());

        return dto;
    }
}