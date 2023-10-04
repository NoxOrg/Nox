// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class ThirdTestEntityZeroOrOneExtensions
{
    public static ThirdTestEntityZeroOrOneDto ToDto(this ThirdTestEntityZeroOrOne entity)
    {
        var dto = new ThirdTestEntityZeroOrOneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField2, () => dto.TextTestField2 =entity!.TextTestField2!.Value);
        SetIfNotNull(entity?.ThirdTestEntityExactlyOneRelationship, () => dto.ThirdTestEntityExactlyOneRelationship = entity!.ThirdTestEntityExactlyOneRelationship!.ToDto());

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