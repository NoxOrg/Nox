// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class ThirdTestEntityOneOrManyExtensions
{
    public static ThirdTestEntityOneOrManyDto ToDto(this ThirdTestEntityOneOrMany entity)
    {
        var dto = new ThirdTestEntityOneOrManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.ThirdTestEntityZeroOrManyRelationship, () => dto.ThirdTestEntityZeroOrManyRelationship = entity!.ThirdTestEntityZeroOrManyRelationship.Select(e => e.ToDto()).ToList());

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