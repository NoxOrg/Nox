// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOneOrManyExtensions
{
    public static TestEntityOneOrManyDto ToDto(this TestEntityOneOrMany entity)
    {
        var dto = new TestEntityOneOrManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.SecondTestEntityOneOrManyRelationship, () => dto.SecondTestEntityOneOrManyRelationship = entity!.SecondTestEntityOneOrManyRelationship.Select(e => e.ToDto()).ToList());

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