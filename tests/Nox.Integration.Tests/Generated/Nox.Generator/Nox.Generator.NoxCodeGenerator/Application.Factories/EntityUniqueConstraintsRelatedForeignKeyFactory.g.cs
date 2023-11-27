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
using EntityUniqueConstraintsRelatedForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey;

namespace TestWebApp.Application.Factories;

internal abstract class EntityUniqueConstraintsRelatedForeignKeyFactoryBase : IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public EntityUniqueConstraintsRelatedForeignKeyFactoryBase
    (
        )
    {
    }

    public virtual EntityUniqueConstraintsRelatedForeignKeyEntity CreateEntity(EntityUniqueConstraintsRelatedForeignKeyCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(EntityUniqueConstraintsRelatedForeignKeyEntity entity, EntityUniqueConstraintsRelatedForeignKeyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(EntityUniqueConstraintsRelatedForeignKeyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey ToEntity(EntityUniqueConstraintsRelatedForeignKeyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey();
        entity.Id = EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(createDto.Id);
        entity.SetIfNotNull(createDto.TextField, (entity) => entity.TextField =TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateTextField(createDto.TextField.NonNullValue<System.String>()));
        return entity;
    }

    private void UpdateEntityInternal(EntityUniqueConstraintsRelatedForeignKeyEntity entity, EntityUniqueConstraintsRelatedForeignKeyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        if(updateDto.TextField is null)
        {
             entity.TextField = null;
        }
        else
        {
            entity.TextField = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateTextField(updateDto.TextField.ToValueFromNonNull<System.String>());
        }
    }

    private void PartialUpdateEntityInternal(EntityUniqueConstraintsRelatedForeignKeyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextField", out var TextFieldUpdateValue))
        {
            if (TextFieldUpdateValue == null) { entity.TextField = null; }
            else
            {
                entity.TextField = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateTextField(TextFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class EntityUniqueConstraintsRelatedForeignKeyFactory : EntityUniqueConstraintsRelatedForeignKeyFactoryBase
{
}