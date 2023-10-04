// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityExactlyOneExtensions
{
    public static SecondTestEntityExactlyOneDto ToDto(this SecondTestEntityExactlyOne entity)
    {
        var dto = new SecondTestEntityExactlyOneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField2, () => dto.TextTestField2 =entity!.TextTestField2!.Value);
        SetIfNotNull(entity?.TestEntityExactlyOneRelationship, () => dto.TestEntityExactlyOneRelationship = entity!.TestEntityExactlyOneRelationship!.ToDto());

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