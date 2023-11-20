// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityTwoRelationshipsManyToManyExtensions
{
    public static TestEntityTwoRelationshipsManyToManyDto ToDto(this TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany entity)
    {
        var dto = new TestEntityTwoRelationshipsManyToManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.TestRelationshipOne, (dto) => dto.TestRelationshipOne = entity!.TestRelationshipOne.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.TestRelationshipTwo, (dto) => dto.TestRelationshipTwo = entity!.TestRelationshipTwo.Select(e => e.ToDto()).ToList());

        return dto;
    }
}