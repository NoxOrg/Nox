// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOneOrManyToZeroOrManyExtensions
{
    public static TestEntityOneOrManyToZeroOrManyDto ToDto(this TestEntityOneOrManyToZeroOrMany entity)
    {
        var dto = new TestEntityOneOrManyToZeroOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.TestEntityZeroOrManyToOneOrMany, (dto) => dto.TestEntityZeroOrManyToOneOrMany = entity!.TestEntityZeroOrManyToOneOrMany.Select(e => e.ToDto()).ToList());

        return dto;
    }
}