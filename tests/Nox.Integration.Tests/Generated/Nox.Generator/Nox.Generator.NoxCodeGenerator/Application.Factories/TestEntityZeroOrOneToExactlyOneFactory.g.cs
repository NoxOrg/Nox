
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
using TestEntityZeroOrOneToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityZeroOrOneToExactlyOneFactory : TestEntityZeroOrOneToExactlyOneFactoryBase
{
    public TestEntityZeroOrOneToExactlyOneFactory
    (
    ) : base()
    {}
}

internal abstract class TestEntityZeroOrOneToExactlyOneFactoryBase : IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto>
{

    public TestEntityZeroOrOneToExactlyOneFactoryBase(
        )
    {
    }

    public virtual async Task<TestEntityZeroOrOneToExactlyOneEntity> CreateEntityAsync(TestEntityZeroOrOneToExactlyOneCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityZeroOrOneToExactlyOneEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(TestEntityZeroOrOneToExactlyOneEntity entity, TestEntityZeroOrOneToExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityZeroOrOneToExactlyOneEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(TestEntityZeroOrOneToExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityZeroOrOneToExactlyOneEntity));
        }   
    }

    private async Task<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne> ToEntityAsync(TestEntityZeroOrOneToExactlyOneCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne();
        exceptionCollector.Collect("Id",() => entity.Id = Dto.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextTestField", () => entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            Dto.TestEntityZeroOrOneToExactlyOneMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityZeroOrOneToExactlyOneEntity entity, TestEntityZeroOrOneToExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextTestField",() => entity.TextTestField = Dto.TestEntityZeroOrOneToExactlyOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityZeroOrOneToExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextTestFieldUpdateValue, "Attribute 'TextTestField' can't be null.");
            {
                exceptionCollector.Collect("TextTestField",() =>entity.TextTestField = Dto.TestEntityZeroOrOneToExactlyOneMetadata.CreateTextTestField(TextTestFieldUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}