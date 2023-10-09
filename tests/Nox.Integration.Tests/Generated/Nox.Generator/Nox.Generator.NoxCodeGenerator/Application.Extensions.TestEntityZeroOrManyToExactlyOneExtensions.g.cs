// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrManyToExactlyOneExtensions
{
    public static TestEntityZeroOrManyToExactlyOneDto ToDto(this TestEntityZeroOrManyToExactlyOne entity)
    {
        var dto = new TestEntityZeroOrManyToExactlyOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.TestEntityExactlyOneToZeroOrMany, (dto) => dto.TestEntityExactlyOneToZeroOrMany = entity!.TestEntityExactlyOneToZeroOrMany.Select(e => e.ToDto()).ToList());

        return dto;
    }
}