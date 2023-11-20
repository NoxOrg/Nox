// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityOwnedRelationshipOneOrManyExtensions
{
    public static SecondTestEntityOwnedRelationshipOneOrManyDto ToDto(this TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany entity)
    {
        var dto = new SecondTestEntityOwnedRelationshipOneOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);

        return dto;
    }
}