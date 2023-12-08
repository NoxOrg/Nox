﻿// Generated

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
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class EntityUniqueConstraintsWithForeignKeyFactoryBase : IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public EntityUniqueConstraintsWithForeignKeyFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<EntityUniqueConstraintsWithForeignKeyEntity> CreateEntityAsync(EntityUniqueConstraintsWithForeignKeyCreateDto createDto)
    {
        try
        {
            return await ToEntityAsync(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual async Task UpdateEntityAsync(EntityUniqueConstraintsWithForeignKeyEntity entity, EntityUniqueConstraintsWithForeignKeyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(EntityUniqueConstraintsWithForeignKeyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey> ToEntityAsync(EntityUniqueConstraintsWithForeignKeyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey();
        entity.SetIfNotNull(createDto.TextField, (entity) => entity.TextField =TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateTextField(createDto.TextField.NonNullValue<System.String>()));
        entity.SomeUniqueId = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateSomeUniqueId(createDto.SomeUniqueId);
        entity.EnsureId(createDto.Id);
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(EntityUniqueConstraintsWithForeignKeyEntity entity, EntityUniqueConstraintsWithForeignKeyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        if(updateDto.TextField is null)
        {
             entity.TextField = null;
        }
        else
        {
            entity.TextField = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateTextField(updateDto.TextField.ToValueFromNonNull<System.String>());
        }
        entity.SomeUniqueId = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateSomeUniqueId(updateDto.SomeUniqueId.NonNullValue<System.Int32>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(EntityUniqueConstraintsWithForeignKeyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextField", out var TextFieldUpdateValue))
        {
            if (TextFieldUpdateValue == null) { entity.TextField = null; }
            else
            {
                entity.TextField = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateTextField(TextFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("SomeUniqueId", out var SomeUniqueIdUpdateValue))
        {
            if (SomeUniqueIdUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'SomeUniqueId' can't be null");
            }
            {
                entity.SomeUniqueId = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateSomeUniqueId(SomeUniqueIdUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}