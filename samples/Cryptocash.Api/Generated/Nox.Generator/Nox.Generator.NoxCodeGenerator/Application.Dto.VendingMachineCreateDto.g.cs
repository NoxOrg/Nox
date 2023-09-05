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

    public Cryptocash.Domain.VendingMachine ToEntity()
    {
        var entity = new Cryptocash.Domain.VendingMachine();
        entity.MacAddress = Cryptocash.Domain.VendingMachine.CreateMacAddress(MacAddress);
        entity.PublicIp = Cryptocash.Domain.VendingMachine.CreatePublicIp(PublicIp);
        entity.GeoLocation = Cryptocash.Domain.VendingMachine.CreateGeoLocation(GeoLocation);
        entity.StreetAddress = Cryptocash.Domain.VendingMachine.CreateStreetAddress(StreetAddress);
        entity.SerialNumber = Cryptocash.Domain.VendingMachine.CreateSerialNumber(SerialNumber);
        if (InstallationFootPrint is not null)entity.InstallationFootPrint = Cryptocash.Domain.VendingMachine.CreateInstallationFootPrint(InstallationFootPrint.NonNullValue<System.Decimal>());
        if (RentPerSquareMetre is not null)entity.RentPerSquareMetre = Cryptocash.Domain.VendingMachine.CreateRentPerSquareMetre(RentPerSquareMetre.NonNullValue<MoneyDto>());
        //entity.Country = Country.ToEntity();
        //entity.LandLord = LandLord.ToEntity();
        //entity.Bookings = Bookings.Select(dto => dto.ToEntity()).ToList();
        //entity.CashStockOrders = CashStockOrders.Select(dto => dto.ToEntity()).ToList();
        //entity.MinimumCashStocks = MinimumCashStocks.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}