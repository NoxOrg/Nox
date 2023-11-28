// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class ForReferenceNumberExtensions
{
    public static ForReferenceNumberDto ToDto(this TestWebApp.Domain.ForReferenceNumber entity)
    {
        var dto = new ForReferenceNumberDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.WorkplaceNumber, (dto) => dto.WorkplaceNumber =entity!.WorkplaceNumber!.Value);

        return dto;
    }
}