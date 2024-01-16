
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
using CountryTimeZoneEntity = Cryptocash.Domain.CountryTimeZone;

namespace Cryptocash.Application.Factories;

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
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryTimeZoneEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(CountryTimeZoneEntity entity, CountryTimeZoneUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryTimeZoneEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(CountryTimeZoneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryTimeZoneEntity));
        }   
    }

    private async Task<Cryptocash.Domain.CountryTimeZone> ToEntityAsync(CountryTimeZoneUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.CountryTimeZone();
        exceptionCollector.Collect("TimeZoneCode", () => entity.SetIfNotNull(createDto.TimeZoneCode, (entity) => entity.TimeZoneCode = 
            Dto.CountryTimeZoneMetadata.CreateTimeZoneCode(createDto.TimeZoneCode.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryTimeZoneEntity entity, CountryTimeZoneUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TimeZoneCode",() => entity.TimeZoneCode = Dto.CountryTimeZoneMetadata.CreateTimeZoneCode(updateDto.TimeZoneCode.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryTimeZoneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TimeZoneCode", out var TimeZoneCodeUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TimeZoneCodeUpdateValue, "Attribute 'TimeZoneCode' can't be null.");
            {
                exceptionCollector.Collect("TimeZoneCode",() =>entity.TimeZoneCode = Dto.CountryTimeZoneMetadata.CreateTimeZoneCode(TimeZoneCodeUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}