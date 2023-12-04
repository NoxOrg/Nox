// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityExactlyOneToZeroOrOneExtensions
{
    public static TestEntityExactlyOneToZeroOrOneDto ToDto(this TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne entity)
    {
        var dto = new TestEntityExactlyOneToZeroOrOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);

        return dto;
    }
}