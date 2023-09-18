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
using Commission = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Factories;

public abstract class CommissionFactoryBase: IEntityFactory<Commission,CommissionCreateDto>
{

    public CommissionFactoryBase
    (
        )
    {
    }

    public virtual Commission CreateEntity(CommissionCreateDto createDto)
    {
        return ToEntity(createDto);
    }
    private Cryptocash.Domain.Commission ToEntity(CommissionCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Commission();
        entity.Rate = Cryptocash.Domain.Commission.CreateRate(createDto.Rate);
        entity.EffectiveAt = Cryptocash.Domain.Commission.CreateEffectiveAt(createDto.EffectiveAt);
        //entity.Country = Country?.ToEntity();
        //entity.Bookings = Bookings.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}

public partial class CommissionFactory : CommissionFactoryBase
{
}