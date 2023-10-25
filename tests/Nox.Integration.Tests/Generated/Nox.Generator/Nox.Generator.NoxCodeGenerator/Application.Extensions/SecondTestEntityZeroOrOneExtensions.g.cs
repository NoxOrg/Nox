// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityZeroOrOneExtensions
{
    public static SecondTestEntityZeroOrOneDto ToDto(this TestWebApp.Domain.SecondTestEntityZeroOrOne entity)
    {
        var dto = new SecondTestEntityZeroOrOneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);

        return dto;
    }
}