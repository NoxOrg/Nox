// Generated

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
using StoreDescription = ClientApi.Domain.StoreDescription;

namespace ClientApi.Application.Factories;

public abstract class StoreDescriptionFactoryBase : IEntityFactory<StoreDescription, StoreDescriptionCreateDto, StoreDescriptionUpdateDto>
{

    public StoreDescriptionFactoryBase
    (
        )
    {
    }

    public virtual StoreDescription CreateEntity(StoreDescriptionCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(StoreDescription entity, StoreDescriptionUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    private ClientApi.Domain.StoreDescription ToEntity(StoreDescriptionCreateDto createDto)
    {
        var entity = new ClientApi.Domain.StoreDescription();
        entity.StoreId = StoreDescription.CreateStoreId(createDto.StoreId);
        if (createDto.Description is not null)entity.Description = ClientApi.Domain.StoreDescription.CreateDescription(createDto.Description.NonNullValue<System.String>());
        return entity;
    }

    private void UpdateEntityInternal(StoreDescription entity, StoreDescriptionUpdateDto updateDto)
    {
        if (updateDto.Description == null) { entity.Description = null; } else {
            entity.Description = ClientApi.Domain.StoreDescription.CreateDescription(updateDto.Description.ToValueFromNonNull<System.String>());
        }
    }
}

public partial class StoreDescriptionFactory : StoreDescriptionFactoryBase
{
}