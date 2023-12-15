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

internal partial class VendingMachineFactory : VendingMachineFactoryBase
{
    public VendingMachineFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class VendingMachineFactoryBase : IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public VendingMachineFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<VendingMachineEntity> CreateEntityAsync(VendingMachineCreateDto createDto)
    {
        try
        {
            return await ToEntityAsync(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
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
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    public virtual void PartialUpdateEntity(VendingMachineEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    private async Task<Cryptocash.Domain.VendingMachine> ToEntityAsync(VendingMachineCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.VendingMachine();
        entity.SetIfNotNull(createDto.MacAddress, (entity) => entity.MacAddress = 
            Cryptocash.Domain.VendingMachineMetadata.CreateMacAddress(createDto.MacAddress.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.PublicIp, (entity) => entity.PublicIp = 
            Cryptocash.Domain.VendingMachineMetadata.CreatePublicIp(createDto.PublicIp.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.GeoLocation, (entity) => entity.GeoLocation = 
            Cryptocash.Domain.VendingMachineMetadata.CreateGeoLocation(createDto.GeoLocation.NonNullValue<LatLongDto>()));
        entity.SetIfNotNull(createDto.StreetAddress, (entity) => entity.StreetAddress = 
            Cryptocash.Domain.VendingMachineMetadata.CreateStreetAddress(createDto.StreetAddress.NonNullValue<StreetAddressDto>()));
        entity.SetIfNotNull(createDto.SerialNumber, (entity) => entity.SerialNumber = 
            Cryptocash.Domain.VendingMachineMetadata.CreateSerialNumber(createDto.SerialNumber.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.InstallationFootPrint, (entity) => entity.InstallationFootPrint = 
            Cryptocash.Domain.VendingMachineMetadata.CreateInstallationFootPrint(createDto.InstallationFootPrint.NonNullValue<System.Decimal>()));
        entity.SetIfNotNull(createDto.RentPerSquareMetre, (entity) => entity.RentPerSquareMetre = 
            Cryptocash.Domain.VendingMachineMetadata.CreateRentPerSquareMetre(createDto.RentPerSquareMetre.NonNullValue<MoneyDto>()));
        entity.EnsureId(createDto.Id);
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(VendingMachineEntity entity, VendingMachineUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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
        await Task.CompletedTask;
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
                var entityToUpdate = entity.GeoLocation is null ? new LatLongDto() : entity.GeoLocation.ToDto();
                LatLongDto.UpdateFromDictionary(entityToUpdate, GeoLocationUpdateValue);
                entity.GeoLocation = Cryptocash.Domain.VendingMachineMetadata.CreateGeoLocation(entityToUpdate);
            }
        }

        if (updatedProperties.TryGetValue("StreetAddress", out var StreetAddressUpdateValue))
        {
            if (StreetAddressUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'StreetAddress' can't be null");
            }
            {
                var entityToUpdate = entity.StreetAddress is null ? new StreetAddressDto() : entity.StreetAddress.ToDto();
                StreetAddressDto.UpdateFromDictionary(entityToUpdate, StreetAddressUpdateValue);
                entity.StreetAddress = Cryptocash.Domain.VendingMachineMetadata.CreateStreetAddress(entityToUpdate);
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
                var entityToUpdate = entity.RentPerSquareMetre is null ? new MoneyDto() : entity.RentPerSquareMetre.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, RentPerSquareMetreUpdateValue);
                entity.RentPerSquareMetre = Cryptocash.Domain.VendingMachineMetadata.CreateRentPerSquareMetre(entityToUpdate);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}