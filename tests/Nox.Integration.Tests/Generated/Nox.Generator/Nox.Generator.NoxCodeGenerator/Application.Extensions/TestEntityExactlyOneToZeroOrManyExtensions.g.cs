// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityExactlyOneToZeroOrManyExtensions
{
    public static TestEntityExactlyOneToZeroOrManyDto ToDto(this TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany entity)
    {
        var dto = new TestEntityExactlyOneToZeroOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);

        return dto;
    }
}