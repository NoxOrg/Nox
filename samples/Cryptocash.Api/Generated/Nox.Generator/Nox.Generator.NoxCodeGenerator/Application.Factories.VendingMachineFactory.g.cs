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

public abstract class VendingMachineFactoryBase : IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto>
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

    public virtual void UpdateEntity(VendingMachine entity, VendingMachineUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
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
        entity.EnsureId(createDto.Id);
        return entity;
    }

    private void UpdateEntityInternal(VendingMachine entity, VendingMachineUpdateDto updateDto)
    {
        entity.MacAddress = Cryptocash.Domain.VendingMachine.CreateMacAddress(updateDto.MacAddress.NonNullValue<System.String>());
        entity.PublicIp = Cryptocash.Domain.VendingMachine.CreatePublicIp(updateDto.PublicIp.NonNullValue<System.String>());
        entity.GeoLocation = Cryptocash.Domain.VendingMachine.CreateGeoLocation(updateDto.GeoLocation.NonNullValue<LatLongDto>());
        entity.StreetAddress = Cryptocash.Domain.VendingMachine.CreateStreetAddress(updateDto.StreetAddress.NonNullValue<StreetAddressDto>());
        entity.SerialNumber = Cryptocash.Domain.VendingMachine.CreateSerialNumber(updateDto.SerialNumber.NonNullValue<System.String>());
        if (updateDto.InstallationFootPrint == null) { entity.InstallationFootPrint = null; } else {
            entity.InstallationFootPrint = Cryptocash.Domain.VendingMachine.CreateInstallationFootPrint(updateDto.InstallationFootPrint.ToValueFromNonNull<System.Decimal>());
        }
        if (updateDto.RentPerSquareMetre == null) { entity.RentPerSquareMetre = null; } else {
            entity.RentPerSquareMetre = Cryptocash.Domain.VendingMachine.CreateRentPerSquareMetre(updateDto.RentPerSquareMetre.ToValueFromNonNull<MoneyDto>());
        }
    }
}

public partial class VendingMachineFactory : VendingMachineFactoryBase
{
}