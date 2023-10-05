// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrOneToExactlyOneExtensions
{
    public static TestEntityZeroOrOneToExactlyOneDto ToDto(this TestEntityZeroOrOneToExactlyOne entity)
    {
        var dto = new TestEntityZeroOrOneToExactlyOneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);

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