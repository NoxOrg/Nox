﻿// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOneOrManyToExactlyOneExtensions
{
    public static TestEntityOneOrManyToExactlyOneDto ToDto(this TestWebApp.Domain.TestEntityOneOrManyToExactlyOne entity)
    {
        var dto = new TestEntityOneOrManyToExactlyOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);

        return dto;
    }
}