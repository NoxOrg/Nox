// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class LandLordExtensions
{
    public static LandLordDto ToDto(this Cryptocash.Domain.LandLord entity)
    {
        var dto = new LandLordDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Address, (dto) => dto.Address =entity!.Address!.ToDto());
        dto.SetIfNotNull(entity?.VendingMachines, (dto) => dto.VendingMachines = entity!.VendingMachines.Select(e => e.ToDto()).ToList());

        return dto;
    }
}