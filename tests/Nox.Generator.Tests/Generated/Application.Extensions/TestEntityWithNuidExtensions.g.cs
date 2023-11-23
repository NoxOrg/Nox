// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityWithNuidExtensions
{
    public static TestEntityWithNuidDto ToDto(this TestWebApp.Domain.TestEntityWithNuid entity)
    {
        var dto = new TestEntityWithNuidDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);

        return dto;
    }
}