// Generated

#nullable enable

using System;
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

public abstract class HolidayFactoryBase: IEntityFactory<Holiday,HolidayCreateDto>
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
    private Cryptocash.Domain.Holiday ToEntity(HolidayCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Holiday();
        entity.Name = Cryptocash.Domain.Holiday.CreateName(createDto.Name);
        entity.Type = Cryptocash.Domain.Holiday.CreateType(createDto.Type);
        entity.Date = Cryptocash.Domain.Holiday.CreateDate(createDto.Date);
        return entity;
    }
}

public partial class HolidayFactory : HolidayFactoryBase
{
}