// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class WorkplaceExtensions
{
    public static WorkplaceDto ToDto(this ClientApi.Domain.Workplace entity)
    {
        var dto = new WorkplaceDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.ReferenceNumber, (dto) => dto.ReferenceNumber =entity!.ReferenceNumber!.Value);
        dto.SetIfNotNull(entity?.Description, (dto) => dto.Description =entity!.Description!.Value);
        dto.SetIfNotNull(entity?.Greeting, (dto) => dto.Greeting =entity!.Greeting);
        dto.SetIfNotNull(entity?.Ownership, (dto) => dto.Ownership =entity!.Ownership!.Value);
        dto.SetIfNotNull(entity?.Type, (dto) => dto.Type =entity!.Type!.Value);

        return dto;
    }
}