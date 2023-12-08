// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class SecEntityOwnedRelExactlyOneExtensions
{
    public static SecEntityOwnedRelExactlyOneDto ToDto(this TestWebApp.Domain.SecEntityOwnedRelExactlyOne entity)
    {
        var dto = new SecEntityOwnedRelExactlyOneDto();
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);

        return dto;
    }
}