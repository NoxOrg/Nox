// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOneOrManyToZeroOrManyExtensions
{
    public static TestEntityOneOrManyToZeroOrManyDto ToDto(this TestEntityOneOrManyToZeroOrMany entity)
    {
        var dto = new TestEntityOneOrManyToZeroOrManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.TestEntityZeroOrManyToOneOrMany, () => dto.TestEntityZeroOrManyToOneOrMany = entity!.TestEntityZeroOrManyToOneOrMany.Select(e => e.ToDto()).ToList());

        return dto;
    }

    private static void SetIfNotNull(object? value, Action setPropertyAction)
    {
        if (value is not null)
        {
            setPropertyAction();
        }
    }
}