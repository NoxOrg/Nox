// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityTwoRelationshipsOneToManyExtensions
{
    public static TestEntityTwoRelationshipsOneToManyDto ToDto(this TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany entity)
    {
        var dto = new TestEntityTwoRelationshipsOneToManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);

        return dto;
    }
}