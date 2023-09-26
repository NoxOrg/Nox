﻿// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using RatingProgram = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Factories;

internal abstract class RatingProgramFactoryBase : IEntityFactory<RatingProgram, RatingProgramCreateDto, RatingProgramUpdateDto>
{

    public RatingProgramFactoryBase
    (
        )
    {
    }

    public virtual RatingProgram CreateEntity(RatingProgramCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(RatingProgram entity, RatingProgramUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(RatingProgram entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private ClientApi.Domain.RatingProgram ToEntity(RatingProgramCreateDto createDto)
    {
        var entity = new ClientApi.Domain.RatingProgram();
        entity.StoreId = RatingProgram.CreateStoreId(createDto.StoreId);
        if (createDto.Name is not null)entity.Name = ClientApi.Domain.RatingProgram.CreateName(createDto.Name.NonNullValue<System.String>());
        return entity;
    }

    private void UpdateEntityInternal(RatingProgram entity, RatingProgramUpdateDto updateDto)
    {
        if (updateDto.Name == null) { entity.Name = null; } else {
            entity.Name = ClientApi.Domain.RatingProgram.CreateName(updateDto.Name.ToValueFromNonNull<System.String>());
        }
    }

    private void PartialUpdateEntityInternal(RatingProgram entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null) { entity.Name = null; }
            else
            {
                entity.Name = ClientApi.Domain.RatingProgram.CreateName(NameUpdateValue);
            }
        }
    }
}

internal partial class RatingProgramFactory : RatingProgramFactoryBase
{
}