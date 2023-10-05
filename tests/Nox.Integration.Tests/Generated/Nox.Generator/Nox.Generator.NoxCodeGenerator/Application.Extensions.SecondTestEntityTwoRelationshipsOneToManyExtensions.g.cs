// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityTwoRelationshipsOneToManyExtensions
{
    public static SecondTestEntityTwoRelationshipsOneToManyDto ToDto(this SecondTestEntityTwoRelationshipsOneToMany entity)
    {
        var dto = new SecondTestEntityTwoRelationshipsOneToManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField2, () => dto.TextTestField2 =entity!.TextTestField2!.Value);
        SetIfNotNull(entity?.TestRelationshipOneOnOtherSideId, () => dto.TestRelationshipOneOnOtherSideId = entity!.TestRelationshipOneOnOtherSideId!.Value);
        SetIfNotNull(entity?.TestRelationshipTwoOnOtherSideId, () => dto.TestRelationshipTwoOnOtherSideId = entity!.TestRelationshipTwoOnOtherSideId!.Value);

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