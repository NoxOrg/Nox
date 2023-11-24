// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrManyToOneOrManyExtensions
{
    public static TestEntityZeroOrManyToOneOrManyDto ToDto(this TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany entity)
    {
        var dto = new TestEntityZeroOrManyToOneOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.TestEntityOneOrManyToZeroOrManies, (dto) => dto.TestEntityOneOrManyToZeroOrManies = entity!.TestEntityOneOrManyToZeroOrManies.Select(e => e.ToDto()).ToList());

        return dto;
    }
}