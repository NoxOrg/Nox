
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
using EntityUniqueConstraintsWithForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey;

namespace TestWebApp.Application.Factories;

internal partial class EntityUniqueConstraintsWithForeignKeyFactory : EntityUniqueConstraintsWithForeignKeyFactoryBase
{
    public EntityUniqueConstraintsWithForeignKeyFactory
    (
    ) : base()
    {}
}

internal abstract class EntityUniqueConstraintsWithForeignKeyFactoryBase : IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto>
{

    public EntityUniqueConstraintsWithForeignKeyFactoryBase(
        )
    {
    }

    public virtual async Task<EntityUniqueConstraintsWithForeignKeyEntity> CreateEntityAsync(EntityUniqueConstraintsWithForeignKeyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(EntityUniqueConstraintsWithForeignKeyEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(EntityUniqueConstraintsWithForeignKeyEntity entity, EntityUniqueConstraintsWithForeignKeyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(EntityUniqueConstraintsWithForeignKeyEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(EntityUniqueConstraintsWithForeignKeyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(EntityUniqueConstraintsWithForeignKeyEntity));
        }   
    }

    private async Task<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey> ToEntityAsync(EntityUniqueConstraintsWithForeignKeyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey();
        exceptionCollector.Collect("TextField", () => entity.SetIfNotNull(createDto.TextField, (entity) => entity.TextField = 
            Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateTextField(createDto.TextField.NonNullValue<System.String>())));
        exceptionCollector.Collect("SomeUniqueId", () => entity.SetIfNotNull(createDto.SomeUniqueId, (entity) => entity.SomeUniqueId = 
            Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateSomeUniqueId(createDto.SomeUniqueId.NonNullValue<System.Int32>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        entity.EnsureId(createDto.Id);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(EntityUniqueConstraintsWithForeignKeyEntity entity, EntityUniqueConstraintsWithForeignKeyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        if(updateDto.TextField is null)
        {
             entity.TextField = null;
        }
        else
        {
            exceptionCollector.Collect("TextField",() =>entity.TextField = Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateTextField(updateDto.TextField.ToValueFromNonNull<System.String>()));
        }
        exceptionCollector.Collect("SomeUniqueId",() => entity.SomeUniqueId = Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateSomeUniqueId(updateDto.SomeUniqueId.NonNullValue<System.Int32>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(EntityUniqueConstraintsWithForeignKeyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextField", out var TextFieldUpdateValue))
        {
            if (TextFieldUpdateValue == null) { entity.TextField = null; }
            else
            {
                exceptionCollector.Collect("TextField",() =>entity.TextField = Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateTextField(TextFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("SomeUniqueId", out var SomeUniqueIdUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(SomeUniqueIdUpdateValue, "Attribute 'SomeUniqueId' can't be null.");
            {
                exceptionCollector.Collect("SomeUniqueId",() =>entity.SomeUniqueId = Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateSomeUniqueId(SomeUniqueIdUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}