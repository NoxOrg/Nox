
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

using ClientApi.Application.Dto;
using ClientApi.Domain;
using CountryTimeZoneEntity = ClientApi.Domain.CountryTimeZone;

namespace ClientApi.Application.Factories;

internal partial class CountryTimeZoneFactory : CountryTimeZoneFactoryBase
{
    public CountryTimeZoneFactory
    (
    ) : base()
    {}
}

internal abstract class CountryTimeZoneFactoryBase : IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto>
{

    public CountryTimeZoneFactoryBase(
        )
    {
    }

    public virtual async Task<CountryTimeZoneEntity> CreateEntityAsync(CountryTimeZoneUpsertDto createDto, Nox.Types.CultureCode cultureCode)
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

    public virtual async Task UpdateEntityAsync(CountryTimeZoneEntity entity, CountryTimeZoneUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(CountryTimeZoneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<ClientApi.Domain.CountryTimeZone> ToEntityAsync(CountryTimeZoneUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.CountryTimeZone();
        exceptionCollector.Collect("Id",() => entity.Id = CountryTimeZoneMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            ClientApi.Domain.CountryTimeZoneMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryTimeZoneEntity entity, CountryTimeZoneUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        if(updateDto.Name is null)
        {
             entity.Name = null;
        }
        else
        {
            exceptionCollector.Collect("Name",() =>entity.Name = ClientApi.Domain.CountryTimeZoneMetadata.CreateName(updateDto.Name.ToValueFromNonNull<System.String>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryTimeZoneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null) { entity.Name = null; }
            else
            {
                exceptionCollector.Collect("Name",() =>entity.Name = ClientApi.Domain.CountryTimeZoneMetadata.CreateName(NameUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}