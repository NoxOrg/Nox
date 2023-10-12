// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class ThirdTestEntityZeroOrOneExtensions
{
    public static ThirdTestEntityZeroOrOneDto ToDto(this ThirdTestEntityZeroOrOne entity)
    {
        var dto = new ThirdTestEntityZeroOrOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);

        return dto;
    }
}