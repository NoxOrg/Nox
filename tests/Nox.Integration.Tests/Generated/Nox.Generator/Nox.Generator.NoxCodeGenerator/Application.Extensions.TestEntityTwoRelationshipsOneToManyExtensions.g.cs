// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityTwoRelationshipsOneToManyExtensions
{
    public static TestEntityTwoRelationshipsOneToManyDto ToDto(this TestEntityTwoRelationshipsOneToMany entity)
    {
        var dto = new TestEntityTwoRelationshipsOneToManyDto();
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