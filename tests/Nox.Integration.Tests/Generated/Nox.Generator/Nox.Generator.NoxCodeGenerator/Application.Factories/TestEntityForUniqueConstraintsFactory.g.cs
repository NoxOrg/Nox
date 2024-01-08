
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

using TestWebApp.Application.Dto;
using TestWebApp.Domain;
using TestEntityForUniqueConstraintsEntity = TestWebApp.Domain.TestEntityForUniqueConstraints;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityForUniqueConstraintsFactory : TestEntityForUniqueConstraintsFactoryBase
{
    public TestEntityForUniqueConstraintsFactory
    (
    ) : base()
    {}
}

internal abstract class TestEntityForUniqueConstraintsFactoryBase : IEntityFactory<TestEntityForUniqueConstraintsEntity, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto>
{

    public TestEntityForUniqueConstraintsFactoryBase(
        )
    {
    }

    public virtual async Task<TestEntityForUniqueConstraintsEntity> CreateEntityAsync(TestEntityForUniqueConstraintsCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityForUniqueConstraintsEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(TestEntityForUniqueConstraintsEntity entity, TestEntityForUniqueConstraintsUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityForUniqueConstraintsEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(TestEntityForUniqueConstraintsEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityForUniqueConstraintsEntity));
        }   
    }

    private async Task<TestWebApp.Domain.TestEntityForUniqueConstraints> ToEntityAsync(TestEntityForUniqueConstraintsCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityForUniqueConstraints();
        exceptionCollector.Collect("Id",() => entity.Id = TestEntityForUniqueConstraintsMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextField", () => entity.SetIfNotNull(createDto.TextField, (entity) => entity.TextField = 
            TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateTextField(createDto.TextField.NonNullValue<System.String>())));
        exceptionCollector.Collect("NumberField", () => entity.SetIfNotNull(createDto.NumberField, (entity) => entity.NumberField = 
            TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateNumberField(createDto.NumberField.NonNullValue<System.Int16>())));
        exceptionCollector.Collect("UniqueNumberField", () => entity.SetIfNotNull(createDto.UniqueNumberField, (entity) => entity.UniqueNumberField = 
            TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueNumberField(createDto.UniqueNumberField.NonNullValue<System.Int16>())));
        exceptionCollector.Collect("UniqueCountryCode", () => entity.SetIfNotNull(createDto.UniqueCountryCode, (entity) => entity.UniqueCountryCode = 
            TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCountryCode(createDto.UniqueCountryCode.NonNullValue<System.String>())));
        exceptionCollector.Collect("UniqueCurrencyCode", () => entity.SetIfNotNull(createDto.UniqueCurrencyCode, (entity) => entity.UniqueCurrencyCode = 
            TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCurrencyCode(createDto.UniqueCurrencyCode.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityForUniqueConstraintsEntity entity, TestEntityForUniqueConstraintsUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextField",() => entity.TextField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateTextField(updateDto.TextField.NonNullValue<System.String>()));
        exceptionCollector.Collect("NumberField",() => entity.NumberField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateNumberField(updateDto.NumberField.NonNullValue<System.Int16>()));
        exceptionCollector.Collect("UniqueNumberField",() => entity.UniqueNumberField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueNumberField(updateDto.UniqueNumberField.NonNullValue<System.Int16>()));
        exceptionCollector.Collect("UniqueCountryCode",() => entity.UniqueCountryCode = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCountryCode(updateDto.UniqueCountryCode.NonNullValue<System.String>()));
        exceptionCollector.Collect("UniqueCurrencyCode",() => entity.UniqueCurrencyCode = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCurrencyCode(updateDto.UniqueCurrencyCode.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityForUniqueConstraintsEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextField", out var TextFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextFieldUpdateValue, "Attribute 'TextField' can't be null.");
            {
                exceptionCollector.Collect("TextField",() =>entity.TextField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateTextField(TextFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("NumberField", out var NumberFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NumberFieldUpdateValue, "Attribute 'NumberField' can't be null.");
            {
                exceptionCollector.Collect("NumberField",() =>entity.NumberField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateNumberField(NumberFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("UniqueNumberField", out var UniqueNumberFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(UniqueNumberFieldUpdateValue, "Attribute 'UniqueNumberField' can't be null.");
            {
                exceptionCollector.Collect("UniqueNumberField",() =>entity.UniqueNumberField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueNumberField(UniqueNumberFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("UniqueCountryCode", out var UniqueCountryCodeUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(UniqueCountryCodeUpdateValue, "Attribute 'UniqueCountryCode' can't be null.");
            {
                exceptionCollector.Collect("UniqueCountryCode",() =>entity.UniqueCountryCode = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCountryCode(UniqueCountryCodeUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("UniqueCurrencyCode", out var UniqueCurrencyCodeUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(UniqueCurrencyCodeUpdateValue, "Attribute 'UniqueCurrencyCode' can't be null.");
            {
                exceptionCollector.Collect("UniqueCurrencyCode",() =>entity.UniqueCurrencyCode = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCurrencyCode(UniqueCurrencyCodeUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}