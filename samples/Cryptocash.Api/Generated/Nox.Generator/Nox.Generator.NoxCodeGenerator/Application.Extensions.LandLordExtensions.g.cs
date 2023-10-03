// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class LandLordExtensions
{
    public static LandLordDto ToDto(this LandLord entity)
    {
        var dto = new LandLordDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Name, () => dto.Name = entity!.Name!.Value);
        SetIfNotNull(entity?.Address, () => dto.Address = entity!.Address!.ToDto());
        SetIfNotNull(entity?.ContractedAreasForVendingMachines, () => dto.ContractedAreasForVendingMachines = entity!.ContractedAreasForVendingMachines.Select(e => e.ToDto()).ToList());

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