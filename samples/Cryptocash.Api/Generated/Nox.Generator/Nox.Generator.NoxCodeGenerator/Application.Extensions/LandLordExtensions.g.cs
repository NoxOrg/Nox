// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class LandLordExtensions
{
    public static LandLordDto ToDto(this LandLord entity)
    {
        var dto = new LandLordDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Address, (dto) => dto.Address =entity!.Address!.ToDto());
        dto.SetIfNotNull(entity?.ContractedAreasForVendingMachines, (dto) => dto.ContractedAreasForVendingMachines = entity!.ContractedAreasForVendingMachines.Select(e => e.ToDto()).ToList());

        return dto;
    }
}