// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrOneToExactlyOneExtensions
{
    public static TestEntityZeroOrOneToExactlyOneDto ToDto(this TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne entity)
    {
        var dto = new TestEntityZeroOrOneToExactlyOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);

        return dto;
    }
}