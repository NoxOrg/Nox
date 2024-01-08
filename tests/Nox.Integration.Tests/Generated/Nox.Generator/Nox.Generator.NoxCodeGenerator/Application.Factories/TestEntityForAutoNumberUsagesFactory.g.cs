
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
using TestEntityForAutoNumberUsagesEntity = TestWebApp.Domain.TestEntityForAutoNumberUsages;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityForAutoNumberUsagesFactory : TestEntityForAutoNumberUsagesFactoryBase
{
    public TestEntityForAutoNumberUsagesFactory
    (
    ) : base()
    {}
}

internal abstract class TestEntityForAutoNumberUsagesFactoryBase : IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto>
{

    public TestEntityForAutoNumberUsagesFactoryBase(
        )
    {
    }

    public virtual async Task<TestEntityForAutoNumberUsagesEntity> CreateEntityAsync(TestEntityForAutoNumberUsagesCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityForAutoNumberUsagesEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(TestEntityForAutoNumberUsagesEntity entity, TestEntityForAutoNumberUsagesUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityForAutoNumberUsagesEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(TestEntityForAutoNumberUsagesEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityForAutoNumberUsagesEntity));
        }   
    }

    private async Task<TestWebApp.Domain.TestEntityForAutoNumberUsages> ToEntityAsync(TestEntityForAutoNumberUsagesCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityForAutoNumberUsages();
        exceptionCollector.Collect("TextField", () => entity.SetIfNotNull(createDto.TextField, (entity) => entity.TextField = 
            TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateTextField(createDto.TextField.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityForAutoNumberUsagesEntity entity, TestEntityForAutoNumberUsagesUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextField",() => entity.TextField = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateTextField(updateDto.TextField.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityForAutoNumberUsagesEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextField", out var TextFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextFieldUpdateValue, "Attribute 'TextField' can't be null.");
            {
                exceptionCollector.Collect("TextField",() =>entity.TextField = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateTextField(TextFieldUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}