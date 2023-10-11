﻿// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOneOrManyToExactlyOneExtensions
{
    public static TestEntityOneOrManyToExactlyOneDto ToDto(this TestEntityOneOrManyToExactlyOne entity)
    {
        var dto = new TestEntityOneOrManyToExactlyOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.TestEntityExactlyOneToOneOrMany, (dto) => dto.TestEntityExactlyOneToOneOrMany = entity!.TestEntityExactlyOneToOneOrMany.Select(e => e.ToDto()).ToList());

        return dto;
    }
}