// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityTwoRelationshipsManyToManyExtensions
{
    public static SecondTestEntityTwoRelationshipsManyToManyDto ToDto(this TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany entity)
    {
        var dto = new SecondTestEntityTwoRelationshipsManyToManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.TestRelationshipOneOnOtherSide, (dto) => dto.TestRelationshipOneOnOtherSide = entity!.TestRelationshipOneOnOtherSide.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.TestRelationshipTwoOnOtherSide, (dto) => dto.TestRelationshipTwoOnOtherSide = entity!.TestRelationshipTwoOnOtherSide.Select(e => e.ToDto()).ToList());

        return dto;
    }
}