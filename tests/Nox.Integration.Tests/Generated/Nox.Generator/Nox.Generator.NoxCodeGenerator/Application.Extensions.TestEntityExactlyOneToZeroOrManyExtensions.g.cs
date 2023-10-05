// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityExactlyOneToZeroOrManyExtensions
{
    public static TestEntityExactlyOneToZeroOrManyDto ToDto(this TestEntityExactlyOneToZeroOrMany entity)
    {
        var dto = new TestEntityExactlyOneToZeroOrManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.TestEntityZeroOrManyToExactlyOneId, () => dto.TestEntityZeroOrManyToExactlyOneId = entity!.TestEntityZeroOrManyToExactlyOneId!.Value);

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