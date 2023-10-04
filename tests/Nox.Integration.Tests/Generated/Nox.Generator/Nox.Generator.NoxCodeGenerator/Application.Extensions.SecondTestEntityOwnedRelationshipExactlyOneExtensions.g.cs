// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityOwnedRelationshipExactlyOneExtensions
{
    public static SecondTestEntityOwnedRelationshipExactlyOneDto ToDto(this SecondTestEntityOwnedRelationshipExactlyOne entity)
    {
        var dto = new SecondTestEntityOwnedRelationshipExactlyOneDto();
        SetIfNotNull(entity?.TextTestField2, () => dto.TextTestField2 =entity!.TextTestField2!.Value);

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