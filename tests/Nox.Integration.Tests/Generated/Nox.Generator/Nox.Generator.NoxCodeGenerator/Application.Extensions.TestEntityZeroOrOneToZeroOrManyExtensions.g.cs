// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrOneToZeroOrManyExtensions
{
    public static TestEntityZeroOrOneToZeroOrManyDto ToDto(this TestEntityZeroOrOneToZeroOrMany entity)
    {
        var dto = new TestEntityZeroOrOneToZeroOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.TestEntityZeroOrManyToZeroOrOneId, (dto) => dto.TestEntityZeroOrManyToZeroOrOneId = entity!.TestEntityZeroOrManyToZeroOrOneId!.Value);

        return dto;
    }
}