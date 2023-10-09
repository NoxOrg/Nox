// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrOneToOneOrManyExtensions
{
    public static TestEntityZeroOrOneToOneOrManyDto ToDto(this TestEntityZeroOrOneToOneOrMany entity)
    {
        var dto = new TestEntityZeroOrOneToOneOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.TestEntityOneOrManyToZeroOrOneId, (dto) => dto.TestEntityOneOrManyToZeroOrOneId = entity!.TestEntityOneOrManyToZeroOrOneId!.Value);

        return dto;
    }
}