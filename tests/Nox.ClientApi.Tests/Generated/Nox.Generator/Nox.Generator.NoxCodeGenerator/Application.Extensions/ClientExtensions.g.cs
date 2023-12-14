// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class ClientExtensions
{
    public static ClientDto ToDto(this ClientApi.Domain.Client entity)
    {
        var dto = new ClientDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);

        return dto;
    }
}