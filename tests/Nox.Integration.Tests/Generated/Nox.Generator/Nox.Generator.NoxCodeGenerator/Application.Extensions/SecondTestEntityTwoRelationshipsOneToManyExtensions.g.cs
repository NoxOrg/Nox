// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityTwoRelationshipsOneToManyExtensions
{
    public static SecondTestEntityTwoRelationshipsOneToManyDto ToDto(this SecondTestEntityTwoRelationshipsOneToMany entity)
    {
        var dto = new SecondTestEntityTwoRelationshipsOneToManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.TestRelationshipOneOnOtherSideId, (dto) => dto.TestRelationshipOneOnOtherSideId = entity!.TestRelationshipOneOnOtherSideId!.Value);
        dto.SetIfNotNull(entity?.TestRelationshipTwoOnOtherSideId, (dto) => dto.TestRelationshipTwoOnOtherSideId = entity!.TestRelationshipTwoOnOtherSideId!.Value);

        return dto;
    }
}