// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class VendingMachineExtensions
{
    public static VendingMachineDto ToDto(this Cryptocash.Domain.VendingMachine entity)
    {
        var dto = new VendingMachineDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.MacAddress, (dto) => dto.MacAddress =entity!.MacAddress!.Value);
        dto.SetIfNotNull(entity?.PublicIp, (dto) => dto.PublicIp =entity!.PublicIp!.Value);
        dto.SetIfNotNull(entity?.GeoLocation, (dto) => dto.GeoLocation =entity!.GeoLocation!.ToDto());
        dto.SetIfNotNull(entity?.StreetAddress, (dto) => dto.StreetAddress =entity!.StreetAddress!.ToDto());
        dto.SetIfNotNull(entity?.SerialNumber, (dto) => dto.SerialNumber =entity!.SerialNumber!.Value);
        dto.SetIfNotNull(entity?.InstallationFootPrint, (dto) => dto.InstallationFootPrint =entity!.InstallationFootPrint!.Value);
        dto.SetIfNotNull(entity?.RentPerSquareMetre, (dto) => dto.RentPerSquareMetre =entity!.RentPerSquareMetre!.ToDto());
        dto.SetIfNotNull(entity?.CountryId, (dto) => dto.CountryId = entity!.CountryId!.Value);
        dto.SetIfNotNull(entity?.LandLordId, (dto) => dto.LandLordId = entity!.LandLordId!.Value);
        dto.SetIfNotNull(entity?.Bookings, (dto) => dto.Bookings = entity!.Bookings.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.CashStockOrders, (dto) => dto.CashStockOrders = entity!.CashStockOrders.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.MinimumCashStocks, (dto) => dto.MinimumCashStocks = entity!.MinimumCashStocks.Select(e => e.ToDto()).ToList());

        return dto;
    }
}