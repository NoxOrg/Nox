// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOneOrManyExtensions
{
    public static TestEntityOneOrManyDto ToDto(this TestWebApp.Domain.TestEntityOneOrMany entity)
    {
        var dto = new TestEntityOneOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.SecondTestEntityOneOrManies, (dto) => dto.SecondTestEntityOneOrManies = entity!.SecondTestEntityOneOrManies.Select(e => e.ToDto()).ToList());

        return dto;
    }
}