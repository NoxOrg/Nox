// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityOneOrManyExtensions
{
    public static SecondTestEntityOneOrManyDto ToDto(this SecondTestEntityOneOrMany entity)
    {
        var dto = new SecondTestEntityOneOrManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField2, () => dto.TextTestField2 =entity!.TextTestField2!.Value);
        SetIfNotNull(entity?.TestEntityOneOrManyRelationship, () => dto.TestEntityOneOrManyRelationship = entity!.TestEntityOneOrManyRelationship.Select(e => e.ToDto()).ToList());

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