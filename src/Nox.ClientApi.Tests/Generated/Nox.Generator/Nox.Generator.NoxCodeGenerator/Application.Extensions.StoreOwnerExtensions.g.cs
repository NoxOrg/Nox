// Generated

#nullable enable
using System;
using System.Linq;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class StoreOwnerExtensions
{
    public static StoreOwnerDto ToDto(this StoreOwner entity)
    {
        var dto = new StoreOwnerDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Name, () => dto.Name =entity!.Name!.Value);
        SetIfNotNull(entity?.TemporaryOwnerName, () => dto.TemporaryOwnerName =entity!.TemporaryOwnerName!.Value);
        SetIfNotNull(entity?.VatNumber, () => dto.VatNumber =entity!.VatNumber!.ToDto());
        SetIfNotNull(entity?.StreetAddress, () => dto.StreetAddress =entity!.StreetAddress!.ToDto());
        SetIfNotNull(entity?.LocalGreeting, () => dto.LocalGreeting =entity!.LocalGreeting!.ToDto());
        SetIfNotNull(entity?.Notes, () => dto.Notes =entity!.Notes!.Value);
        SetIfNotNull(entity?.Stores, () => dto.Stores = entity!.Stores.Select(e => e.ToDto()).ToList());

        return dto;
    }

    private static void SetIfNotNull(object? value, Action setPropertyAction)
    {
        if (value is not null)
        {
            setPropertyAction();
        }
    }
}