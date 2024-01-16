
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
using HolidayEntity = Cryptocash.Domain.Holiday;

namespace Cryptocash.Application.Factories;

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

    private async Task<Cryptocash.Domain.Holiday> ToEntityAsync(HolidayUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.Holiday();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.HolidayMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Type", () => entity.SetIfNotNull(createDto.Type, (entity) => entity.Type = 
            Dto.HolidayMetadata.CreateType(createDto.Type.NonNullValue<System.String>())));
        exceptionCollector.Collect("Date", () => entity.SetIfNotNull(createDto.Date, (entity) => entity.Date = 
            Dto.HolidayMetadata.CreateDate(createDto.Date.NonNullValue<System.DateTime>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(HolidayEntity entity, HolidayUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Dto.HolidayMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        exceptionCollector.Collect("Type",() => entity.Type = Dto.HolidayMetadata.CreateType(updateDto.Type.NonNullValue<System.String>()));
        exceptionCollector.Collect("Date",() => entity.Date = Dto.HolidayMetadata.CreateDate(updateDto.Date.NonNullValue<System.DateTime>()));

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
            ArgumentNullException.ThrowIfNull(TypeUpdateValue, "Attribute 'Type' can't be null.");
            {
                exceptionCollector.Collect("Type",() =>entity.Type = Dto.HolidayMetadata.CreateType(TypeUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Date", out var DateUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(DateUpdateValue, "Attribute 'Date' can't be null.");
            {
                exceptionCollector.Collect("Date",() =>entity.Date = Dto.HolidayMetadata.CreateDate(DateUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}