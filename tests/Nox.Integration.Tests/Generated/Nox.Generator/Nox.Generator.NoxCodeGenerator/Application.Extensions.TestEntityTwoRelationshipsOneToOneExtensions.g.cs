// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityTwoRelationshipsOneToOneExtensions
{
    public static TestEntityTwoRelationshipsOneToOneDto ToDto(this TestEntityTwoRelationshipsOneToOne entity)
    {
        var dto = new TestEntityTwoRelationshipsOneToOneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.TestRelationshipOneId, () => dto.TestRelationshipOneId = entity!.TestRelationshipOneId!.Value);
        SetIfNotNull(entity?.TestRelationshipOne, () => dto.TestRelationshipOne = entity!.TestRelationshipOne!.ToDto());
        SetIfNotNull(entity?.TestRelationshipTwoId, () => dto.TestRelationshipTwoId = entity!.TestRelationshipTwoId!.Value);
        SetIfNotNull(entity?.TestRelationshipTwo, () => dto.TestRelationshipTwo = entity!.TestRelationshipTwo!.ToDto());

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