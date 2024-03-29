﻿// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrManyToZeroOrOneExtensions
{
    public static TestEntityZeroOrManyToZeroOrOneDto ToDto(this TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne entity)
    {
        var dto = new TestEntityZeroOrManyToZeroOrOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);

        return dto;
    }
}