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

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using Holiday = Cryptocash.Domain.Holiday;

namespace Cryptocash.Application.Factories;

public abstract class HolidayFactoryBase : IEntityFactory<Holiday, HolidayCreateDto, HolidayUpdateDto>
{

    public HolidayFactoryBase
    (
        )
    {
    }

    public virtual Holiday CreateEntity(HolidayCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public void UpdateEntity(Holiday entity, HolidayUpdateDto updateDto)
    {
        MapEntity(entity, updateDto);
    }

    private Cryptocash.Domain.Holiday ToEntity(HolidayCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Holiday();
        entity.Name = Cryptocash.Domain.Holiday.CreateName(createDto.Name);
        entity.Type = Cryptocash.Domain.Holiday.CreateType(createDto.Type);
        entity.Date = Cryptocash.Domain.Holiday.CreateDate(createDto.Date);
        return entity;
    }

    private void MapEntity(Holiday entity, HolidayUpdateDto updateDto)
    {
        // TODO: discuss about keys
        entity.Name = Cryptocash.Domain.Holiday.CreateName(updateDto.Name);
        entity.Type = Cryptocash.Domain.Holiday.CreateType(updateDto.Type);
        entity.Date = Cryptocash.Domain.Holiday.CreateDate(updateDto.Date);

        // TODO: discuss about keys
    }
}

public partial class HolidayFactory : HolidayFactoryBase
{
}