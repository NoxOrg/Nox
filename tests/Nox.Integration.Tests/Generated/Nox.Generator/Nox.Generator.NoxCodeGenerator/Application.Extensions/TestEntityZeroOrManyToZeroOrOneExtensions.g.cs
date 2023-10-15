// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrManyToZeroOrOneExtensions
{
    public static TestEntityZeroOrManyToZeroOrOneDto ToDto(this TestEntityZeroOrManyToZeroOrOne entity)
    {
        var dto = new TestEntityZeroOrManyToZeroOrOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.TestEntityZeroOrOneToZeroOrMany, (dto) => dto.TestEntityZeroOrOneToZeroOrMany = entity!.TestEntityZeroOrOneToZeroOrMany.Select(e => e.ToDto()).ToList());

        return dto;
    }
}