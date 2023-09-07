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
using ExchangeRate = Cryptocash.Domain.ExchangeRate;

namespace Cryptocash.Application.Factories;

public abstract class ExchangeRateFactoryBase: IEntityFactory<ExchangeRateCreateDto,ExchangeRate>
{

    public ExchangeRateFactoryBase
    (
        )
    {
    }

    public virtual ExchangeRate CreateEntity(ExchangeRateCreateDto createDto)
    {
        return ToEntity(createDto);
    }
    private Cryptocash.Domain.ExchangeRate ToEntity(ExchangeRateCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.ExchangeRate();
        entity.EffectiveRate = Cryptocash.Domain.ExchangeRate.CreateEffectiveRate(createDto.EffectiveRate);
        entity.EffectiveAt = Cryptocash.Domain.ExchangeRate.CreateEffectiveAt(createDto.EffectiveAt);
        return entity;
    }
}

public partial class ExchangeRateFactory : ExchangeRateFactoryBase
{
}