// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOwnedRelationshipOneOrManyExtensions
{
    public static TestEntityOwnedRelationshipOneOrManyDto ToDto(this TestEntityOwnedRelationshipOneOrMany entity)
    {
        var dto = new TestEntityOwnedRelationshipOneOrManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.SecondTestEntityOwnedRelationshipOneOrMany, () => dto.SecondTestEntityOwnedRelationshipOneOrMany = entity!.SecondTestEntityOwnedRelationshipOneOrMany.Select(e => e.ToDto()).ToList());

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