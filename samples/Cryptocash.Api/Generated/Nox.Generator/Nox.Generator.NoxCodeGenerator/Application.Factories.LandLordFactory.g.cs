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
using LandLord = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Factories;

public abstract class LandLordFactoryBase: IEntityFactory<LandLord,LandLordCreateDto>
{

    public LandLordFactoryBase
    (
        )
    {
    }

    public virtual LandLord CreateEntity(LandLordCreateDto createDto)
    {
        return ToEntity(createDto);
    }
    private Cryptocash.Domain.LandLord ToEntity(LandLordCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.LandLord();
        entity.Name = Cryptocash.Domain.LandLord.CreateName(createDto.Name);
        entity.Address = Cryptocash.Domain.LandLord.CreateAddress(createDto.Address);
        //entity.VendingMachines = VendingMachines.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}

public partial class LandLordFactory : LandLordFactoryBase
{
}