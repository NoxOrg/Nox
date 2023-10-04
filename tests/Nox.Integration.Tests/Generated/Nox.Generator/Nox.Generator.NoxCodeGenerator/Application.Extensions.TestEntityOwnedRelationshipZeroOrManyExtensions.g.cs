// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOwnedRelationshipZeroOrManyExtensions
{
    public static TestEntityOwnedRelationshipZeroOrManyDto ToDto(this TestEntityOwnedRelationshipZeroOrMany entity)
    {
        var dto = new TestEntityOwnedRelationshipZeroOrManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.SecondTestEntityOwnedRelationshipZeroOrMany, () => dto.SecondTestEntityOwnedRelationshipZeroOrMany = entity!.SecondTestEntityOwnedRelationshipZeroOrMany.Select(e => e.ToDto()).ToList());

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