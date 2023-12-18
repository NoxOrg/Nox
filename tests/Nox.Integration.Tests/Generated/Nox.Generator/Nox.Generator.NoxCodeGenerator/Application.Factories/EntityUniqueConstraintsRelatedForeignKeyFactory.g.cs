

// Generated
//TODO: if CultureCode is not needed, remove it from the factory
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
using EntityUniqueConstraintsRelatedForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey;

namespace TestWebApp.Application.Factories;

internal partial class EntityUniqueConstraintsRelatedForeignKeyFactory : EntityUniqueConstraintsRelatedForeignKeyFactoryBase
{
    public EntityUniqueConstraintsRelatedForeignKeyFactory
    (
    ) : base()
    {}
}

internal abstract class EntityUniqueConstraintsRelatedForeignKeyFactoryBase : IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto>
{

    public EntityUniqueConstraintsRelatedForeignKeyFactoryBase(
        )
    {
    }

    public virtual async Task<EntityUniqueConstraintsRelatedForeignKeyEntity> CreateEntityAsync(EntityUniqueConstraintsRelatedForeignKeyCreateDto createDto, Nox.Types.CultureCode cultureCode)
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

    public virtual async Task UpdateEntityAsync(EntityUniqueConstraintsRelatedForeignKeyEntity entity, EntityUniqueConstraintsRelatedForeignKeyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(EntityUniqueConstraintsRelatedForeignKeyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
=======
<<<<<<< main
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
=======
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        await Task.CompletedTask;
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    private async Task<TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey> ToEntityAsync(EntityUniqueConstraintsRelatedForeignKeyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey();
        exceptionCollector.Collect("Id",() => entity.Id = EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(createDto.Id.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("TextField", () => entity.SetIfNotNull(createDto.TextField, (entity) => entity.TextField = 
            TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateTextField(createDto.TextField.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(EntityUniqueConstraintsRelatedForeignKeyEntity entity, EntityUniqueConstraintsRelatedForeignKeyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        if(updateDto.TextField is null)
        {
             entity.TextField = null;
        }
        else
        {
            exceptionCollector.Collect("TextField",() =>entity.TextField = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateTextField(updateDto.TextField.ToValueFromNonNull<System.String>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(EntityUniqueConstraintsRelatedForeignKeyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextField", out var TextFieldUpdateValue))
        {
            if (TextFieldUpdateValue == null) { entity.TextField = null; }
            else
            {
                exceptionCollector.Collect("TextField",() =>entity.TextField = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateTextField(TextFieldUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}