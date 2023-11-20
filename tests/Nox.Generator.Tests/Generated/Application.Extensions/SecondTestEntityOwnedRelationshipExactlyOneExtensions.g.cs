// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityOwnedRelationshipExactlyOneExtensions
{
    public static SecondTestEntityOwnedRelationshipExactlyOneDto ToDto(this TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne entity)
    {
        var dto = new SecondTestEntityOwnedRelationshipExactlyOneDto();
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);

        return dto;
    }
}