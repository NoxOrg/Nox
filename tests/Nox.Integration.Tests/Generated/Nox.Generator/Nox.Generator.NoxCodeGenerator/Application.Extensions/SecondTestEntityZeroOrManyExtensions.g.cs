// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityZeroOrManyExtensions
{
    public static SecondTestEntityZeroOrManyDto ToDto(this TestWebApp.Domain.SecondTestEntityZeroOrMany entity)
    {
        var dto = new SecondTestEntityZeroOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.TestEntityZeroOrManies, (dto) => dto.TestEntityZeroOrManies = entity!.TestEntityZeroOrManies.Select(e => e.ToDto()).ToList());

        return dto;
    }
}