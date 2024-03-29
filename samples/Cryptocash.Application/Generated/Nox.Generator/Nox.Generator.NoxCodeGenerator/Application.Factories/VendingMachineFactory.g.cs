﻿
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
using Dto = Cryptocash.Application.Dto;
using Cryptocash.Domain;
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Factories;

internal partial class VendingMachineFactory : VendingMachineFactoryBase
{
    public VendingMachineFactory
    (
    ) : base()
    {}
}

internal abstract class VendingMachineFactoryBase : IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto>
{

    public VendingMachineFactoryBase(
        )
    {
    }

    public virtual async Task<VendingMachineEntity> CreateEntityAsync(VendingMachineCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(VendingMachineEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(VendingMachineEntity entity, VendingMachineUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(VendingMachineEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(VendingMachineEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(VendingMachineEntity));
        }   
    }

    private async Task<Cryptocash.Domain.VendingMachine> ToEntityAsync(VendingMachineCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.VendingMachine();
        exceptionCollector.Collect("MacAddress", () => entity.SetIfNotNull(createDto.MacAddress, (entity) => entity.MacAddress = 
            Dto.VendingMachineMetadata.CreateMacAddress(createDto.MacAddress.NonNullValue<System.String>())));
        exceptionCollector.Collect("PublicIp", () => entity.SetIfNotNull(createDto.PublicIp, (entity) => entity.PublicIp = 
            Dto.VendingMachineMetadata.CreatePublicIp(createDto.PublicIp.NonNullValue<System.String>())));
        exceptionCollector.Collect("GeoLocation", () => entity.SetIfNotNull(createDto.GeoLocation, (entity) => entity.GeoLocation = 
            Dto.VendingMachineMetadata.CreateGeoLocation(createDto.GeoLocation.NonNullValue<LatLongDto>())));
        exceptionCollector.Collect("StreetAddress", () => entity.SetIfNotNull(createDto.StreetAddress, (entity) => entity.StreetAddress = 
            Dto.VendingMachineMetadata.CreateStreetAddress(createDto.StreetAddress.NonNullValue<StreetAddressDto>())));
        exceptionCollector.Collect("SerialNumber", () => entity.SetIfNotNull(createDto.SerialNumber, (entity) => entity.SerialNumber = 
            Dto.VendingMachineMetadata.CreateSerialNumber(createDto.SerialNumber.NonNullValue<System.String>())));
        exceptionCollector.Collect("InstallationFootPrint", () => entity.SetIfNotNull(createDto.InstallationFootPrint, (entity) => entity.InstallationFootPrint = 
            Dto.VendingMachineMetadata.CreateInstallationFootPrint(createDto.InstallationFootPrint.NonNullValue<System.Decimal>())));
        exceptionCollector.Collect("RentPerSquareMetre", () => entity.SetIfNotNull(createDto.RentPerSquareMetre, (entity) => entity.RentPerSquareMetre = 
            Dto.VendingMachineMetadata.CreateRentPerSquareMetre(createDto.RentPerSquareMetre.NonNullValue<MoneyDto>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        entity.EnsureId(createDto.Id);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(VendingMachineEntity entity, VendingMachineUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("MacAddress",() => entity.MacAddress = Dto.VendingMachineMetadata.CreateMacAddress(updateDto.MacAddress.NonNullValue<System.String>()));
        exceptionCollector.Collect("PublicIp",() => entity.PublicIp = Dto.VendingMachineMetadata.CreatePublicIp(updateDto.PublicIp.NonNullValue<System.String>()));
        exceptionCollector.Collect("GeoLocation",() => entity.GeoLocation = Dto.VendingMachineMetadata.CreateGeoLocation(updateDto.GeoLocation.NonNullValue<LatLongDto>()));
        exceptionCollector.Collect("StreetAddress",() => entity.StreetAddress = Dto.VendingMachineMetadata.CreateStreetAddress(updateDto.StreetAddress.NonNullValue<StreetAddressDto>()));
        exceptionCollector.Collect("SerialNumber",() => entity.SerialNumber = Dto.VendingMachineMetadata.CreateSerialNumber(updateDto.SerialNumber.NonNullValue<System.String>()));
        if(updateDto.InstallationFootPrint is null)
        {
             entity.InstallationFootPrint = null;
        }
        else
        {
            exceptionCollector.Collect("InstallationFootPrint",() =>entity.InstallationFootPrint = Dto.VendingMachineMetadata.CreateInstallationFootPrint(updateDto.InstallationFootPrint.ToValueFromNonNull<System.Decimal>()));
        }
        if(updateDto.RentPerSquareMetre is null)
        {
             entity.RentPerSquareMetre = null;
        }
        else
        {
            exceptionCollector.Collect("RentPerSquareMetre",() =>entity.RentPerSquareMetre = Dto.VendingMachineMetadata.CreateRentPerSquareMetre(updateDto.RentPerSquareMetre.ToValueFromNonNull<MoneyDto>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(VendingMachineEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("MacAddress", out var MacAddressUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(MacAddressUpdateValue, "Attribute 'MacAddress' can't be null.");
            {
                exceptionCollector.Collect("MacAddress",() =>entity.MacAddress = Dto.VendingMachineMetadata.CreateMacAddress(MacAddressUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PublicIp", out var PublicIpUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PublicIpUpdateValue, "Attribute 'PublicIp' can't be null.");
            {
                exceptionCollector.Collect("PublicIp",() =>entity.PublicIp = Dto.VendingMachineMetadata.CreatePublicIp(PublicIpUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("GeoLocation", out var GeoLocationUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(GeoLocationUpdateValue, "Attribute 'GeoLocation' can't be null.");
            {
                var entityToUpdate = entity.GeoLocation is null ? new LatLongDto() : entity.GeoLocation.ToDto();
                LatLongDto.UpdateFromDictionary(entityToUpdate, GeoLocationUpdateValue);
                exceptionCollector.Collect("GeoLocation",() =>entity.GeoLocation = Dto.VendingMachineMetadata.CreateGeoLocation(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("StreetAddress", out var StreetAddressUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(StreetAddressUpdateValue, "Attribute 'StreetAddress' can't be null.");
            {
                var entityToUpdate = entity.StreetAddress is null ? new StreetAddressDto() : entity.StreetAddress.ToDto();
                StreetAddressDto.UpdateFromDictionary(entityToUpdate, StreetAddressUpdateValue);
                exceptionCollector.Collect("StreetAddress",() =>entity.StreetAddress = Dto.VendingMachineMetadata.CreateStreetAddress(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("SerialNumber", out var SerialNumberUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(SerialNumberUpdateValue, "Attribute 'SerialNumber' can't be null.");
            {
                exceptionCollector.Collect("SerialNumber",() =>entity.SerialNumber = Dto.VendingMachineMetadata.CreateSerialNumber(SerialNumberUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("InstallationFootPrint", out var InstallationFootPrintUpdateValue))
        {
            if (InstallationFootPrintUpdateValue == null) { entity.InstallationFootPrint = null; }
            else
            {
                exceptionCollector.Collect("InstallationFootPrint",() =>entity.InstallationFootPrint = Dto.VendingMachineMetadata.CreateInstallationFootPrint(InstallationFootPrintUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("RentPerSquareMetre", out var RentPerSquareMetreUpdateValue))
        {
            if (RentPerSquareMetreUpdateValue == null) { entity.RentPerSquareMetre = null; }
            else
            {
                var entityToUpdate = entity.RentPerSquareMetre is null ? new MoneyDto() : entity.RentPerSquareMetre.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, RentPerSquareMetreUpdateValue);
                exceptionCollector.Collect("RentPerSquareMetre",() =>entity.RentPerSquareMetre = Dto.VendingMachineMetadata.CreateRentPerSquareMetre(entityToUpdate));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}