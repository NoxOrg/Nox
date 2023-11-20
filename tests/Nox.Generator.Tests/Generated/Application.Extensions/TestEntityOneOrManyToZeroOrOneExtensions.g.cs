// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOneOrManyToZeroOrOneExtensions
{
    public static TestEntityOneOrManyToZeroOrOneDto ToDto(this TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne entity)
    {
        var dto = new TestEntityOneOrManyToZeroOrOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.TestEntityZeroOrOneToOneOrManies, (dto) => dto.TestEntityZeroOrOneToOneOrManies = entity!.TestEntityZeroOrOneToOneOrManies.Select(e => e.ToDto()).ToList());

        return dto;
    }
}