// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityTwoRelationshipsOneToOneExtensions
{
    public static TestEntityTwoRelationshipsOneToOneDto ToDto(this TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne entity)
    {
        var dto = new TestEntityTwoRelationshipsOneToOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);

        return dto;
    }
}