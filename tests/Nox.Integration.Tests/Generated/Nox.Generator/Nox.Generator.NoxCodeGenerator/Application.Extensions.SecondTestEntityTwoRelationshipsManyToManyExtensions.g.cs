// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityTwoRelationshipsManyToManyExtensions
{
    public static SecondTestEntityTwoRelationshipsManyToManyDto ToDto(this SecondTestEntityTwoRelationshipsManyToMany entity)
    {
        var dto = new SecondTestEntityTwoRelationshipsManyToManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField2, () => dto.TextTestField2 =entity!.TextTestField2!.Value);
        SetIfNotNull(entity?.TestRelationshipOneOnOtherSide, () => dto.TestRelationshipOneOnOtherSide = entity!.TestRelationshipOneOnOtherSide.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.TestRelationshipTwoOnOtherSide, () => dto.TestRelationshipTwoOnOtherSide = entity!.TestRelationshipTwoOnOtherSide.Select(e => e.ToDto()).ToList());

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