// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class ThirdTestEntityExactlyOneExtensions
{
    public static ThirdTestEntityExactlyOneDto ToDto(this TestWebApp.Domain.ThirdTestEntityExactlyOne entity)
    {
        var dto = new ThirdTestEntityExactlyOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.ThirdTestEntityZeroOrOneId, (dto) => dto.ThirdTestEntityZeroOrOneId = entity!.ThirdTestEntityZeroOrOneId!.Value);

        return dto;
    }
}