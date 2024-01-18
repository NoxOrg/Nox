
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
using Dto = TestWebApp.Application.Dto;
using TestWebApp.Domain;
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityZeroOrOneToOneOrManyFactory : TestEntityZeroOrOneToOneOrManyFactoryBase
{
    public TestEntityZeroOrOneToOneOrManyFactory
    (
    ) : base()
    {}
}

internal abstract class TestEntityZeroOrOneToOneOrManyFactoryBase : IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto>
{

    public TestEntityZeroOrOneToOneOrManyFactoryBase(
        )
    {
    }

    public virtual async Task<TestEntityZeroOrOneToOneOrManyEntity> CreateEntityAsync(TestEntityZeroOrOneToOneOrManyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityZeroOrOneToOneOrManyEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(TestEntityZeroOrOneToOneOrManyEntity entity, TestEntityZeroOrOneToOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityZeroOrOneToOneOrManyEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(TestEntityZeroOrOneToOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityZeroOrOneToOneOrManyEntity));
        }   
    }

    private async Task<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany> ToEntityAsync(TestEntityZeroOrOneToOneOrManyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany();
        exceptionCollector.Collect("Id",() => entity.Id = Dto.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextTestField", () => entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            Dto.TestEntityZeroOrOneToOneOrManyMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityZeroOrOneToOneOrManyEntity entity, TestEntityZeroOrOneToOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextTestField",() => entity.TextTestField = Dto.TestEntityZeroOrOneToOneOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityZeroOrOneToOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextTestFieldUpdateValue, "Attribute 'TextTestField' can't be null.");
            {
                exceptionCollector.Collect("TextTestField",() =>entity.TextTestField = Dto.TestEntityZeroOrOneToOneOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}