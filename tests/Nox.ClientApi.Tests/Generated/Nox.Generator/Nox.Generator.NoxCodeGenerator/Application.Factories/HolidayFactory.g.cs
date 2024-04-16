
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
using Dto = ClientApi.Application.Dto;
using ClientApi.Domain;
using HolidayEntity = ClientApi.Domain.Holiday;

namespace ClientApi.Application.Factories;

internal partial class HolidayFactory : HolidayFactoryBase
{
    public HolidayFactory
    (
    ) : base()
    {}
}

internal abstract class HolidayFactoryBase : IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto>
{

    public HolidayFactoryBase(
        )
    {
    }

    public virtual async Task<HolidayEntity> CreateEntityAsync(HolidayUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(HolidayEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(HolidayEntity entity, HolidayUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(HolidayEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(HolidayEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(HolidayEntity));
        }   
    }

    private async Task<ClientApi.Domain.Holiday> ToEntityAsync(HolidayUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.Holiday();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.HolidayMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Type", () => entity.SetIfNotNull(createDto.Type, (entity) => entity.Type = 
            Dto.HolidayMetadata.CreateType(createDto.Type.NonNullValue<System.String>())));
        exceptionCollector.Collect("Date", () => entity.SetIfNotNull(createDto.Date, (entity) => entity.Date = 
            Dto.HolidayMetadata.CreateDate(createDto.Date.NonNullValue<System.DateTime>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        entity.EnsureId(createDto.Id);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(HolidayEntity entity, HolidayUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Dto.HolidayMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        if(updateDto.Type is null)
        {
             entity.Type = null;
        }
        else
        {
            exceptionCollector.Collect("Type",() =>entity.Type = Dto.HolidayMetadata.CreateType(updateDto.Type.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.Date is null)
        {
             entity.Date = null;
        }
        else
        {
            exceptionCollector.Collect("Date",() =>entity.Date = Dto.HolidayMetadata.CreateDate(updateDto.Date.ToValueFromNonNull<System.DateTime>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(HolidayEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = Dto.HolidayMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Type", out var TypeUpdateValue))
        {
            if (TypeUpdateValue == null) { entity.Type = null; }
            else
            {
                exceptionCollector.Collect("Type",() =>entity.Type = Dto.HolidayMetadata.CreateType(TypeUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Date", out var DateUpdateValue))
        {
            if (DateUpdateValue == null) { entity.Date = null; }
            else
            {
                exceptionCollector.Collect("Date",() =>entity.Date = Dto.HolidayMetadata.CreateDate(DateUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}