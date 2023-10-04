// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOwnedRelationshipExactlyOneExtensions
{
    public static TestEntityOwnedRelationshipExactlyOneDto ToDto(this TestEntityOwnedRelationshipExactlyOne entity)
    {
        var dto = new TestEntityOwnedRelationshipExactlyOneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.SecondTestEntityOwnedRelationshipExactlyOne, () => dto.SecondTestEntityOwnedRelationshipExactlyOne = entity!.SecondTestEntityOwnedRelationshipExactlyOne!.ToDto());

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