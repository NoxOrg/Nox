// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachineCreateDto : VendingMachineUpdateDto
{

    public VendingMachine ToEntity()
    {
        var entity = new VendingMachine();
        entity.MacAddress = VendingMachine.CreateMacAddress(MacAddress);
        entity.PublicIp = VendingMachine.CreatePublicIp(PublicIp);
        entity.GeoLocation = VendingMachine.CreateGeoLocation(GeoLocation);
        entity.StreetAddress = VendingMachine.CreateStreetAddress(StreetAddress);
        entity.SerialNumber = VendingMachine.CreateSerialNumber(SerialNumber);
        if (InstallationFootPrint is not null)entity.InstallationFootPrint = VendingMachine.CreateInstallationFootPrint(InstallationFootPrint.NonNullValue<System.Decimal>());
        if (RentPerSquareMetre is not null)entity.RentPerSquareMetre = VendingMachine.CreateRentPerSquareMetre(RentPerSquareMetre.NonNullValue<MoneyDto>());
        //entity.Country = Country.ToEntity();
        //entity.LandLord = LandLord.ToEntity();
        //entity.Bookings = Bookings.Select(dto => dto.ToEntity()).ToList();
        //entity.VendingMachineOrders = VendingMachineOrders.Select(dto => dto.ToEntity()).ToList();
        //entity.MinimumCashStocks = MinimumCashStocks.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}