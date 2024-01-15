
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
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(EntityUniqueConstraintsRelatedForeignKeyEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(EntityUniqueConstraintsRelatedForeignKeyEntity entity, EntityUniqueConstraintsRelatedForeignKeyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(EntityUniqueConstraintsRelatedForeignKeyEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(EntityUniqueConstraintsRelatedForeignKeyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(EntityUniqueConstraintsRelatedForeignKeyEntity));
        }   
    }

    private async Task<TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey> ToEntityAsync(EntityUniqueConstraintsRelatedForeignKeyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey();
        exceptionCollector.Collect("Id",() => entity.Id = Dto.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(createDto.Id.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("TextField", () => entity.SetIfNotNull(createDto.TextField, (entity) => entity.TextField = 
            Dto.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateTextField(createDto.TextField.NonNullValue<System.String>())));

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
            exceptionCollector.Collect("TextField",() =>entity.TextField = Dto.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateTextField(updateDto.TextField.ToValueFromNonNull<System.String>()));
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
                exceptionCollector.Collect("TextField",() =>entity.TextField = Dto.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateTextField(TextFieldUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}