// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Factories;

internal abstract class VendingMachineFactoryBase : IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public VendingMachineFactoryBase
    (
        )
    {
    }

    public virtual VendingMachineEntity CreateEntity(VendingMachineCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(VendingMachineEntity entity, VendingMachineUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(VendingMachineEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private Cryptocash.Domain.VendingMachine ToEntity(VendingMachineCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.VendingMachine();
        entity.MacAddress = Cryptocash.Domain.VendingMachineMetadata.CreateMacAddress(createDto.MacAddress);
        entity.PublicIp = Cryptocash.Domain.VendingMachineMetadata.CreatePublicIp(createDto.PublicIp);
        entity.GeoLocation = Cryptocash.Domain.VendingMachineMetadata.CreateGeoLocation(createDto.GeoLocation);
        entity.StreetAddress = Cryptocash.Domain.VendingMachineMetadata.CreateStreetAddress(createDto.StreetAddress);
        entity.SerialNumber = Cryptocash.Domain.VendingMachineMetadata.CreateSerialNumber(createDto.SerialNumber);
        entity.SetIfNotNull(createDto.InstallationFootPrint, (entity) => entity.InstallationFootPrint =Cryptocash.Domain.VendingMachineMetadata.CreateInstallationFootPrint(createDto.InstallationFootPrint.NonNullValue<System.Decimal>()));
        entity.SetIfNotNull(createDto.RentPerSquareMetre, (entity) => entity.RentPerSquareMetre =Cryptocash.Domain.VendingMachineMetadata.CreateRentPerSquareMetre(createDto.RentPerSquareMetre.NonNullValue<MoneyDto>()));
        entity.EnsureId(createDto.Id);
        return entity;
    }

    private void UpdateEntityInternal(VendingMachineEntity entity, VendingMachineUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.MacAddress = Cryptocash.Domain.VendingMachineMetadata.CreateMacAddress(updateDto.MacAddress.NonNullValue<System.String>());
        entity.PublicIp = Cryptocash.Domain.VendingMachineMetadata.CreatePublicIp(updateDto.PublicIp.NonNullValue<System.String>());
        entity.GeoLocation = Cryptocash.Domain.VendingMachineMetadata.CreateGeoLocation(updateDto.GeoLocation.NonNullValue<LatLongDto>());
        entity.StreetAddress = Cryptocash.Domain.VendingMachineMetadata.CreateStreetAddress(updateDto.StreetAddress.NonNullValue<StreetAddressDto>());
        entity.SerialNumber = Cryptocash.Domain.VendingMachineMetadata.CreateSerialNumber(updateDto.SerialNumber.NonNullValue<System.String>());
        if(updateDto.InstallationFootPrint is null)
        {
             entity.InstallationFootPrint = null;
        }
        else
        {
            entity.InstallationFootPrint = Cryptocash.Domain.VendingMachineMetadata.CreateInstallationFootPrint(updateDto.InstallationFootPrint.ToValueFromNonNull<System.Decimal>());
        }
        if(updateDto.RentPerSquareMetre is null)
        {
             entity.RentPerSquareMetre = null;
        }
        else
        {
            entity.RentPerSquareMetre = Cryptocash.Domain.VendingMachineMetadata.CreateRentPerSquareMetre(updateDto.RentPerSquareMetre.ToValueFromNonNull<MoneyDto>());
        }
    }

    private void PartialUpdateEntityInternal(VendingMachineEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("MacAddress", out var MacAddressUpdateValue))
        {
            if (MacAddressUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'MacAddress' can't be null");
            }
            {
                entity.MacAddress = Cryptocash.Domain.VendingMachineMetadata.CreateMacAddress(MacAddressUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("PublicIp", out var PublicIpUpdateValue))
        {
            if (PublicIpUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'PublicIp' can't be null");
            }
            {
                entity.PublicIp = Cryptocash.Domain.VendingMachineMetadata.CreatePublicIp(PublicIpUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("GeoLocation", out var GeoLocationUpdateValue))
        {
            if (GeoLocationUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'GeoLocation' can't be null");
            }
            {
                entity.GeoLocation = Cryptocash.Domain.VendingMachineMetadata.CreateGeoLocation(GeoLocationUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("StreetAddress", out var StreetAddressUpdateValue))
        {
            if (StreetAddressUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'StreetAddress' can't be null");
            }
            {
                entity.StreetAddress = Cryptocash.Domain.VendingMachineMetadata.CreateStreetAddress(StreetAddressUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("SerialNumber", out var SerialNumberUpdateValue))
        {
            if (SerialNumberUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'SerialNumber' can't be null");
            }
            {
                entity.SerialNumber = Cryptocash.Domain.VendingMachineMetadata.CreateSerialNumber(SerialNumberUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("InstallationFootPrint", out var InstallationFootPrintUpdateValue))
        {
            if (InstallationFootPrintUpdateValue == null) { entity.InstallationFootPrint = null; }
            else
            {
                entity.InstallationFootPrint = Cryptocash.Domain.VendingMachineMetadata.CreateInstallationFootPrint(InstallationFootPrintUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("RentPerSquareMetre", out var RentPerSquareMetreUpdateValue))
        {
            if (RentPerSquareMetreUpdateValue == null) { entity.RentPerSquareMetre = null; }
            else
            {
                entity.RentPerSquareMetre = Cryptocash.Domain.VendingMachineMetadata.CreateRentPerSquareMetre(RentPerSquareMetreUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class VendingMachineFactory : VendingMachineFactoryBase
{
}