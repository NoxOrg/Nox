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
using Cryptocash.Domain;
using LandLordEntity = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Factories;

internal partial class LandLordFactory : LandLordFactoryBase
{
    public LandLordFactory
    (
    ) : base()
    {}
}

internal abstract class LandLordFactoryBase : IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto>
{

    public LandLordFactoryBase(
        )
    {
    }

    public virtual async Task<LandLordEntity> CreateEntityAsync(LandLordCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        return await ToEntityAsync(createDto);
=======
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    public virtual async Task UpdateEntityAsync(LandLordEntity entity, LandLordUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(LandLordEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
<<<<<<< main
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
=======
<<<<<<< main
=======
>>>>>>> Merge conflicts have been resolved
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
<<<<<<< main
=======
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        await Task.CompletedTask;
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
=======
>>>>>>> Merge conflicts have been resolved
    }

    private async Task<Cryptocash.Domain.LandLord> ToEntityAsync(LandLordCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.LandLord();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Cryptocash.Domain.LandLordMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Address", () => entity.SetIfNotNull(createDto.Address, (entity) => entity.Address = 
            Cryptocash.Domain.LandLordMetadata.CreateAddress(createDto.Address.NonNullValue<StreetAddressDto>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        entity.EnsureId(createDto.Id);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(LandLordEntity entity, LandLordUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Cryptocash.Domain.LandLordMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        exceptionCollector.Collect("Address",() => entity.Address = Cryptocash.Domain.LandLordMetadata.CreateAddress(updateDto.Address.NonNullValue<StreetAddressDto>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(LandLordEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = Cryptocash.Domain.LandLordMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Address", out var AddressUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(AddressUpdateValue, "Attribute 'Address' can't be null.");
            {
                var entityToUpdate = entity.Address is null ? new StreetAddressDto() : entity.Address.ToDto();
                StreetAddressDto.UpdateFromDictionary(entityToUpdate, AddressUpdateValue);
                exceptionCollector.Collect("Address",() =>entity.Address = Cryptocash.Domain.LandLordMetadata.CreateAddress(entityToUpdate));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}