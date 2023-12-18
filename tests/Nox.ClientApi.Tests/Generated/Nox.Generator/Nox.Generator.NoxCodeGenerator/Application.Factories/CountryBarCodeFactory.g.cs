
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
using CountryBarCodeEntity = ClientApi.Domain.CountryBarCode;

namespace ClientApi.Application.Factories;

internal partial class CountryBarCodeFactory : CountryBarCodeFactoryBase
{
    public CountryBarCodeFactory
    (
    ) : base()
    {}
}

internal abstract class CountryBarCodeFactoryBase : IEntityFactory<CountryBarCodeEntity, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto>
{

    public CountryBarCodeFactoryBase(
        )
    {
    }

    public virtual async Task<CountryBarCodeEntity> CreateEntityAsync(CountryBarCodeUpsertDto createDto, Nox.Types.CultureCode cultureCode)
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

    public virtual async Task UpdateEntityAsync(CountryBarCodeEntity entity, CountryBarCodeUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(CountryBarCodeEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<ClientApi.Domain.CountryBarCode> ToEntityAsync(CountryBarCodeUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.CountryBarCode();
        exceptionCollector.Collect("BarCodeName", () => entity.SetIfNotNull(createDto.BarCodeName, (entity) => entity.BarCodeName = 
            ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeName(createDto.BarCodeName.NonNullValue<System.String>())));
        exceptionCollector.Collect("BarCodeNumber", () => entity.SetIfNotNull(createDto.BarCodeNumber, (entity) => entity.BarCodeNumber = 
            ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeNumber(createDto.BarCodeNumber.NonNullValue<System.Int32>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryBarCodeEntity entity, CountryBarCodeUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("BarCodeName",() => entity.BarCodeName = ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeName(updateDto.BarCodeName.NonNullValue<System.String>()));
        if(updateDto.BarCodeNumber is null)
        {
             entity.BarCodeNumber = null;
        }
        else
        {
            exceptionCollector.Collect("BarCodeNumber",() =>entity.BarCodeNumber = ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeNumber(updateDto.BarCodeNumber.ToValueFromNonNull<System.Int32>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryBarCodeEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("BarCodeName", out var BarCodeNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(BarCodeNameUpdateValue, "Attribute 'BarCodeName' can't be null.");
            {
                exceptionCollector.Collect("BarCodeName",() =>entity.BarCodeName = ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeName(BarCodeNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("BarCodeNumber", out var BarCodeNumberUpdateValue))
        {
            if (BarCodeNumberUpdateValue == null) { entity.BarCodeNumber = null; }
            else
            {
                exceptionCollector.Collect("BarCodeNumber",() =>entity.BarCodeNumber = ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeNumber(BarCodeNumberUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}