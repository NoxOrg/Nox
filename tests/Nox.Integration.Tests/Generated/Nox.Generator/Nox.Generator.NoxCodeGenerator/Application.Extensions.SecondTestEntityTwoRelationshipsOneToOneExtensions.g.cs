// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityTwoRelationshipsOneToOneExtensions
{
    public static SecondTestEntityTwoRelationshipsOneToOneDto ToDto(this SecondTestEntityTwoRelationshipsOneToOne entity)
    {
        var dto = new SecondTestEntityTwoRelationshipsOneToOneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField2, () => dto.TextTestField2 =entity!.TextTestField2!.Value);
        SetIfNotNull(entity?.TestRelationshipOneOnOtherSide, () => dto.TestRelationshipOneOnOtherSide = entity!.TestRelationshipOneOnOtherSide!.ToDto());
        SetIfNotNull(entity?.TestRelationshipTwoOnOtherSide, () => dto.TestRelationshipTwoOnOtherSide = entity!.TestRelationshipTwoOnOtherSide!.ToDto());

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