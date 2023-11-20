// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityExactlyOneExtensions
{
    public static TestEntityExactlyOneDto ToDto(this TestWebApp.Domain.TestEntityExactlyOne entity)
    {
        var dto = new TestEntityExactlyOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.SecondTestEntityExactlyOneId, (dto) => dto.SecondTestEntityExactlyOneId = entity!.SecondTestEntityExactlyOneId!.Value);

        return dto;
    }
}