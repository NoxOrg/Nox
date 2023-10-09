// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOneOrManyToZeroOrOneExtensions
{
    public static TestEntityOneOrManyToZeroOrOneDto ToDto(this TestEntityOneOrManyToZeroOrOne entity)
    {
        var dto = new TestEntityOneOrManyToZeroOrOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.TestEntityZeroOrOneToOneOrMany, (dto) => dto.TestEntityZeroOrOneToOneOrMany = entity!.TestEntityZeroOrOneToOneOrMany.Select(e => e.ToDto()).ToList());

        return dto;
    }
}