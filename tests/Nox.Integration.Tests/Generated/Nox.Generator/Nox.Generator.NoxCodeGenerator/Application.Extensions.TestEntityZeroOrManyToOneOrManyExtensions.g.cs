// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrManyToOneOrManyExtensions
{
    public static TestEntityZeroOrManyToOneOrManyDto ToDto(this TestEntityZeroOrManyToOneOrMany entity)
    {
        var dto = new TestEntityZeroOrManyToOneOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.TestEntityOneOrManyToZeroOrMany, (dto) => dto.TestEntityOneOrManyToZeroOrMany = entity!.TestEntityOneOrManyToZeroOrMany.Select(e => e.ToDto()).ToList());

        return dto;
    }
}