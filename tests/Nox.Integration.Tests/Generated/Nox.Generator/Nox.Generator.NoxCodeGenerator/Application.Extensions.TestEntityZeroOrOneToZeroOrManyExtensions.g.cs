// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrOneToZeroOrManyExtensions
{
    public static TestEntityZeroOrOneToZeroOrManyDto ToDto(this TestEntityZeroOrOneToZeroOrMany entity)
    {
        var dto = new TestEntityZeroOrOneToZeroOrManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.TestEntityZeroOrManyToZeroOrOneId, () => dto.TestEntityZeroOrManyToZeroOrOneId = entity!.TestEntityZeroOrManyToZeroOrOneId!.Value);
        SetIfNotNull(entity?.TestEntityZeroOrManyToZeroOrOne, () => dto.TestEntityZeroOrManyToZeroOrOne = entity!.TestEntityZeroOrManyToZeroOrOne!.ToDto());

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