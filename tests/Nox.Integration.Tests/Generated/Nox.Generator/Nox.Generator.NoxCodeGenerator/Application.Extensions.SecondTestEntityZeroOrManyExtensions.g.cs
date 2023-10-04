// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityZeroOrManyExtensions
{
    public static SecondTestEntityZeroOrManyDto ToDto(this SecondTestEntityZeroOrMany entity)
    {
        var dto = new SecondTestEntityZeroOrManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField2, () => dto.TextTestField2 =entity!.TextTestField2!.Value);
        SetIfNotNull(entity?.TestEntityZeroOrManyRelationship, () => dto.TestEntityZeroOrManyRelationship = entity!.TestEntityZeroOrManyRelationship.Select(e => e.ToDto()).ToList());

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