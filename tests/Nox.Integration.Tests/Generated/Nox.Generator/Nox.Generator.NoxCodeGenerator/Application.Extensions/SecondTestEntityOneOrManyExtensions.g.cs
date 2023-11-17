// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityOneOrManyExtensions
{
    public static SecondTestEntityOneOrManyDto ToDto(this TestWebApp.Domain.SecondTestEntityOneOrMany entity)
    {
        var dto = new SecondTestEntityOneOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.TestEntityOneOrManies, (dto) => dto.TestEntityOneOrManies = entity!.TestEntityOneOrManies.Select(e => e.ToDto()).ToList());

        return dto;
    }
}