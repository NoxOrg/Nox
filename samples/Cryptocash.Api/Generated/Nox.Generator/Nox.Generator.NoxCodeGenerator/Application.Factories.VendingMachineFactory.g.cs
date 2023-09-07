// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using VendingMachine = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Factories;

public abstract class VendingMachineFactoryBase: IEntityFactory<VendingMachineCreateDto,VendingMachine>
{

    public VendingMachineFactoryBase
    (
        )
    {
    }

    public virtual VendingMachine CreateEntity(VendingMachineCreateDto createDto)
    {
        return ToEntity(createDto);
    }
    private Cryptocash.Domain.VendingMachine ToEntity(VendingMachineCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.VendingMachine();
        entity.MacAddress = Cryptocash.Domain.VendingMachine.CreateMacAddress(createDto.MacAddress);
        entity.PublicIp = Cryptocash.Domain.VendingMachine.CreatePublicIp(createDto.PublicIp);
        entity.GeoLocation = Cryptocash.Domain.VendingMachine.CreateGeoLocation(createDto.GeoLocation);
        entity.StreetAddress = Cryptocash.Domain.VendingMachine.CreateStreetAddress(createDto.StreetAddress);
        entity.SerialNumber = Cryptocash.Domain.VendingMachine.CreateSerialNumber(createDto.SerialNumber);
        if (createDto.InstallationFootPrint is not null)entity.InstallationFootPrint = Cryptocash.Domain.VendingMachine.CreateInstallationFootPrint(createDto.InstallationFootPrint.NonNullValue<System.Decimal>());
        if (createDto.RentPerSquareMetre is not null)entity.RentPerSquareMetre = Cryptocash.Domain.VendingMachine.CreateRentPerSquareMetre(createDto.RentPerSquareMetre.NonNullValue<MoneyDto>());
        //entity.Country = Country.ToEntity();
        //entity.LandLord = LandLord.ToEntity();
        //entity.Bookings = Bookings.Select(dto => dto.ToEntity()).ToList();
        //entity.CashStockOrders = CashStockOrders.Select(dto => dto.ToEntity()).ToList();
        //entity.MinimumCashStocks = MinimumCashStocks.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}

public partial class VendingMachineFactory : VendingMachineFactoryBase
{
}