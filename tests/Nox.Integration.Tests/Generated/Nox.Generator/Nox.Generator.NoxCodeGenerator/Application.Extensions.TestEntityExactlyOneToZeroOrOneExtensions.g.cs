// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityExactlyOneToZeroOrOneExtensions
{
    public static TestEntityExactlyOneToZeroOrOneDto ToDto(this TestEntityExactlyOneToZeroOrOne entity)
    {
        var dto = new TestEntityExactlyOneToZeroOrOneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField2, () => dto.TextTestField2 =entity!.TextTestField2!.Value);
        SetIfNotNull(entity?.TestEntityZeroOrOneToExactlyOneId, () => dto.TestEntityZeroOrOneToExactlyOneId = entity!.TestEntityZeroOrOneToExactlyOneId!.Value);
        SetIfNotNull(entity?.TestEntityZeroOrOneToExactlyOne, () => dto.TestEntityZeroOrOneToExactlyOne = entity!.TestEntityZeroOrOneToExactlyOne!.ToDto());

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