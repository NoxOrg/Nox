// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityExactlyOneExtensions
{
    public static TestEntityExactlyOneDto ToDto(this TestEntityExactlyOne entity)
    {
        var dto = new TestEntityExactlyOneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.SecondTestEntityExactlyOneRelationshipId, () => dto.SecondTestEntityExactlyOneRelationshipId = entity!.SecondTestEntityExactlyOneRelationshipId!.Value);

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