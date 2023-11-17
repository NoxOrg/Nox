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
        dto.SetIfNotNull(entity?.TestRelationshipOneId, (dto) => dto.TestRelationshipOneId = entity!.TestRelationshipOneId!.Value);
        dto.SetIfNotNull(entity?.TestRelationshipTwoId, (dto) => dto.TestRelationshipTwoId = entity!.TestRelationshipTwoId!.Value);

        return dto;
    }
}