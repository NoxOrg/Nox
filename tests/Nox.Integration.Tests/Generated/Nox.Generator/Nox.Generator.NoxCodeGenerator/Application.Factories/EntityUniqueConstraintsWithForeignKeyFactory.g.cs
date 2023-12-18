
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

    public virtual async Task UpdateEntityAsync(EntityUniqueConstraintsWithForeignKeyEntity entity, EntityUniqueConstraintsWithForeignKeyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(EntityUniqueConstraintsWithForeignKeyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey> ToEntityAsync(EntityUniqueConstraintsWithForeignKeyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey();
        exceptionCollector.Collect("TextField", () => entity.SetIfNotNull(createDto.TextField, (entity) => entity.TextField = 
            TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateTextField(createDto.TextField.NonNullValue<System.String>())));
        exceptionCollector.Collect("SomeUniqueId", () => entity.SetIfNotNull(createDto.SomeUniqueId, (entity) => entity.SomeUniqueId = 
            TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateSomeUniqueId(createDto.SomeUniqueId.NonNullValue<System.Int32>())));

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
            exceptionCollector.Collect("TextField",() =>entity.TextField = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateTextField(updateDto.TextField.ToValueFromNonNull<System.String>()));
        }
        exceptionCollector.Collect("SomeUniqueId",() => entity.SomeUniqueId = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateSomeUniqueId(updateDto.SomeUniqueId.NonNullValue<System.Int32>()));

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
                exceptionCollector.Collect("TextField",() =>entity.TextField = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateTextField(TextFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("SomeUniqueId", out var SomeUniqueIdUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(SomeUniqueIdUpdateValue, "Attribute 'SomeUniqueId' can't be null.");
            {
                exceptionCollector.Collect("SomeUniqueId",() =>entity.SomeUniqueId = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateSomeUniqueId(SomeUniqueIdUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}