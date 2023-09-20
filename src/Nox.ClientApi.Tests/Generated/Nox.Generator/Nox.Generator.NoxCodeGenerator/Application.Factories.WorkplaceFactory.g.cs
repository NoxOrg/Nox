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
using Workplace = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Factories;

public abstract class WorkplaceFactoryBase : IEntityFactory<Workplace, WorkplaceCreateDto, WorkplaceUpdateDto>
{

    public WorkplaceFactoryBase
    (
        )
    {
    }

    public virtual Workplace CreateEntity(WorkplaceCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(Workplace entity, WorkplaceUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    private ClientApi.Domain.Workplace ToEntity(WorkplaceCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Workplace();
        entity.Name = ClientApi.Domain.Workplace.CreateName(createDto.Name);
		entity.EnsureId();
        //entity.Country = Country?.ToEntity();
        return entity;
    }

    private void UpdateEntityInternal(Workplace entity, WorkplaceUpdateDto updateDto)
    {
        entity.Name = ClientApi.Domain.Workplace.CreateName(updateDto.Name.NonNullValue<System.String>());
		entity.EnsureId();
        //entity.Country = Country?.ToEntity();
    }
}

public partial class WorkplaceFactory : WorkplaceFactoryBase
{
}