// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityOwnedRelationshipZeroOrOneExtensions
{
    public static SecondTestEntityOwnedRelationshipZeroOrOneDto ToDto(this TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne entity)
    {
        var dto = new SecondTestEntityOwnedRelationshipZeroOrOneDto();
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);

        return dto;
    }
}