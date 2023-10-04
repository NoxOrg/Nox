// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOneOrManyToExactlyOneExtensions
{
    public static TestEntityOneOrManyToExactlyOneDto ToDto(this TestEntityOneOrManyToExactlyOne entity)
    {
        var dto = new TestEntityOneOrManyToExactlyOneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField2, () => dto.TextTestField2 =entity!.TextTestField2!.Value);
        SetIfNotNull(entity?.TestEntityExactlyOneToOneOrMany, () => dto.TestEntityExactlyOneToOneOrMany = entity!.TestEntityExactlyOneToOneOrMany.Select(e => e.ToDto()).ToList());

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