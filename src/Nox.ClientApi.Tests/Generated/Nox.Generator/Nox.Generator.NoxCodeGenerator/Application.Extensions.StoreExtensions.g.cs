// Generated

#nullable enable
using System;
using System.Linq;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class StoreExtensions
{
    public static StoreDto ToDto(this Store entity)
    {
        var dto = new StoreDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Name, () => dto.Name =entity!.Name!.Value);
        SetIfNotNull(entity?.Address, () => dto.Address =entity!.Address!.ToDto());
        SetIfNotNull(entity?.Location, () => dto.Location =entity!.Location!.ToDto());
        SetIfNotNull(entity?.OpeningDay, () => dto.OpeningDay =entity!.OpeningDay!.Value);
        SetIfNotNull(entity?.OwnershipId, () => dto.OwnershipId = entity!.OwnershipId!.Value);
        SetIfNotNull(entity?.Ownership, () => dto.Ownership = entity!.Ownership!.ToDto());
        SetIfNotNull(entity?.License, () => dto.License = entity!.License!.ToDto());
        SetIfNotNull(entity?.VerifiedEmails, () => dto.VerifiedEmails = entity!.VerifiedEmails!.ToDto());

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