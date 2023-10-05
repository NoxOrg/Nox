// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrOneToOneOrManyExtensions
{
    public static TestEntityZeroOrOneToOneOrManyDto ToDto(this TestEntityZeroOrOneToOneOrMany entity)
    {
        var dto = new TestEntityZeroOrOneToOneOrManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.TestEntityOneOrManyToZeroOrOneId, () => dto.TestEntityOneOrManyToZeroOrOneId = entity!.TestEntityOneOrManyToZeroOrOneId!.Value);

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