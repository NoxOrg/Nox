// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityExactlyOneToOneOrManyExtensions
{
    public static TestEntityExactlyOneToOneOrManyDto ToDto(this TestWebApp.Domain.TestEntityExactlyOneToOneOrMany entity)
    {
        var dto = new TestEntityExactlyOneToOneOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);

        return dto;
    }
}