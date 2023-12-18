
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
using TestEntityWithNuidEntity = TestWebApp.Domain.TestEntityWithNuid;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityWithNuidFactory : TestEntityWithNuidFactoryBase
{
    public TestEntityWithNuidFactory
    (
    ) : base()
    {}
}

internal abstract class TestEntityWithNuidFactoryBase : IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto>
{

    public TestEntityWithNuidFactoryBase(
        )
    {
    }

    public virtual async Task<TestEntityWithNuidEntity> CreateEntityAsync(TestEntityWithNuidCreateDto createDto, Nox.Types.CultureCode cultureCode)
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

    public virtual async Task UpdateEntityAsync(TestEntityWithNuidEntity entity, TestEntityWithNuidUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(TestEntityWithNuidEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<TestWebApp.Domain.TestEntityWithNuid> ToEntityAsync(TestEntityWithNuidCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityWithNuid();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            TestWebApp.Domain.TestEntityWithNuidMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
		entity.EnsureId();        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityWithNuidEntity entity, TestEntityWithNuidUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = TestWebApp.Domain.TestEntityWithNuidMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
		entity.EnsureId();
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityWithNuidEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = TestWebApp.Domain.TestEntityWithNuidMetadata.CreateName(NameUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
		entity.EnsureId();
    }
}