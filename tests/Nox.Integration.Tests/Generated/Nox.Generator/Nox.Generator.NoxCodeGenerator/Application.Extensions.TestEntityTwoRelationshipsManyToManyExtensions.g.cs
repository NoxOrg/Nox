// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityTwoRelationshipsManyToManyExtensions
{
    public static TestEntityTwoRelationshipsManyToManyDto ToDto(this TestEntityTwoRelationshipsManyToMany entity)
    {
        var dto = new TestEntityTwoRelationshipsManyToManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.TestRelationshipOne, () => dto.TestRelationshipOne = entity!.TestRelationshipOne.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.TestRelationshipTwo, () => dto.TestRelationshipTwo = entity!.TestRelationshipTwo.Select(e => e.ToDto()).ToList());

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