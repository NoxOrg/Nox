// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class ThirdTestEntityExactlyOneExtensions
{
    public static ThirdTestEntityExactlyOneDto ToDto(this ThirdTestEntityExactlyOne entity)
    {
        var dto = new ThirdTestEntityExactlyOneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.ThirdTestEntityZeroOrOneRelationshipId, () => dto.ThirdTestEntityZeroOrOneRelationshipId = entity!.ThirdTestEntityZeroOrOneRelationshipId!.Value);
        SetIfNotNull(entity?.ThirdTestEntityZeroOrOneRelationship, () => dto.ThirdTestEntityZeroOrOneRelationship = entity!.ThirdTestEntityZeroOrOneRelationship!.ToDto());

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