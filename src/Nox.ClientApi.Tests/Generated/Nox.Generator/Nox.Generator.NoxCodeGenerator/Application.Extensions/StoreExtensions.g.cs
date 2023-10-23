// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class StoreExtensions
{
    public static StoreDto ToDto(this ClientApi.Domain.Store entity)
    {
        var dto = new StoreDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Address, (dto) => dto.Address =entity!.Address!.ToDto());
        dto.SetIfNotNull(entity?.Location, (dto) => dto.Location =entity!.Location!.ToDto());
        dto.SetIfNotNull(entity?.OpeningDay, (dto) => dto.OpeningDay =entity!.OpeningDay!.Value);
        dto.SetIfNotNull(entity?.Status, (dto) => dto.Status =entity!.Status!.Value);
        dto.SetIfNotNull(entity?.OwnershipId, (dto) => dto.OwnershipId = entity!.OwnershipId!.Value);
        dto.SetIfNotNull(entity?.VerifiedEmails, (dto) => dto.VerifiedEmails = entity!.VerifiedEmails!.ToDto());

        return dto;
    }
}