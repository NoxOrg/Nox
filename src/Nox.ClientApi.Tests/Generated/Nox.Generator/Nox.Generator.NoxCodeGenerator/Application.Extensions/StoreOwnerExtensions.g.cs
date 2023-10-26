// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class StoreOwnerExtensions
{
    public static StoreOwnerDto ToDto(this ClientApi.Domain.StoreOwner entity)
    {
        var dto = new StoreOwnerDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.TemporaryOwnerName, (dto) => dto.TemporaryOwnerName =entity!.TemporaryOwnerName!.Value);
        dto.SetIfNotNull(entity?.VatNumber, (dto) => dto.VatNumber =entity!.VatNumber!.ToDto());
        dto.SetIfNotNull(entity?.StreetAddress, (dto) => dto.StreetAddress =entity!.StreetAddress!.ToDto());
        dto.SetIfNotNull(entity?.LocalGreeting, (dto) => dto.LocalGreeting =entity!.LocalGreeting!.ToDto());
        dto.SetIfNotNull(entity?.Notes, (dto) => dto.Notes =entity!.Notes!.Value);
        dto.SetIfNotNull(entity?.Stores, (dto) => dto.Stores = entity!.Stores.Select(e => e.ToDto()).ToList());

        return dto;
    }
}