// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class VendingMachineExtensions
{
    public static VendingMachineDto ToDto(this VendingMachine entity)
    {
        var dto = new VendingMachineDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.MacAddress, () => dto.MacAddress =entity!.MacAddress!.Value);
        SetIfNotNull(entity?.PublicIp, () => dto.PublicIp =entity!.PublicIp!.Value);
        SetIfNotNull(entity?.GeoLocation, () => dto.GeoLocation =entity!.GeoLocation!.ToDto());
        SetIfNotNull(entity?.StreetAddress, () => dto.StreetAddress =entity!.StreetAddress!.ToDto());
        SetIfNotNull(entity?.SerialNumber, () => dto.SerialNumber =entity!.SerialNumber!.Value);
        SetIfNotNull(entity?.InstallationFootPrint, () => dto.InstallationFootPrint =entity!.InstallationFootPrint!.Value);
        SetIfNotNull(entity?.RentPerSquareMetre, () => dto.RentPerSquareMetre =entity!.RentPerSquareMetre!.ToDto());
        SetIfNotNull(entity?.VendingMachineInstallationCountryId, () => dto.VendingMachineInstallationCountryId = entity!.VendingMachineInstallationCountryId!.Value);
        SetIfNotNull(entity?.VendingMachineInstallationCountry, () => dto.VendingMachineInstallationCountry = entity!.VendingMachineInstallationCountry!.ToDto());
        SetIfNotNull(entity?.VendingMachineContractedAreaLandLordId, () => dto.VendingMachineContractedAreaLandLordId = entity!.VendingMachineContractedAreaLandLordId!.Value);
        SetIfNotNull(entity?.VendingMachineContractedAreaLandLord, () => dto.VendingMachineContractedAreaLandLord = entity!.VendingMachineContractedAreaLandLord!.ToDto());
        SetIfNotNull(entity?.VendingMachineRelatedBookings, () => dto.VendingMachineRelatedBookings = entity!.VendingMachineRelatedBookings.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.VendingMachineRelatedCashStockOrders, () => dto.VendingMachineRelatedCashStockOrders = entity!.VendingMachineRelatedCashStockOrders.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.VendingMachineRequiredMinimumCashStocks, () => dto.VendingMachineRequiredMinimumCashStocks = entity!.VendingMachineRequiredMinimumCashStocks.Select(e => e.ToDto()).ToList());

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