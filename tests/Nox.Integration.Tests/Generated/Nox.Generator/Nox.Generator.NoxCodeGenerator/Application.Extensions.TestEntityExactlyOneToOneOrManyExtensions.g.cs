// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityExactlyOneToOneOrManyExtensions
{
    public static TestEntityExactlyOneToOneOrManyDto ToDto(this TestEntityExactlyOneToOneOrMany entity)
    {
        var dto = new TestEntityExactlyOneToOneOrManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.TestEntityOneOrManyToExactlyOneId, () => dto.TestEntityOneOrManyToExactlyOneId = entity!.TestEntityOneOrManyToExactlyOneId!.Value);
        SetIfNotNull(entity?.TestEntityOneOrManyToExactlyOne, () => dto.TestEntityOneOrManyToExactlyOne = entity!.TestEntityOneOrManyToExactlyOne!.ToDto());

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