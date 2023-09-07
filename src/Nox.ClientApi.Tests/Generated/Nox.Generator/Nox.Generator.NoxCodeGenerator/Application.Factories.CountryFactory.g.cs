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
using Country = ClientApi.Domain.Country;

namespace ClientApi.Application.Factories;

public abstract class CountryFactoryBase: IEntityFactory<CountryCreateDto,Country>
{
    protected IEntityFactory<CountryLocalNameCreateDto,CountryLocalName> CountryLocalNameFactory {get;}

    public CountryFactoryBase
    (
        IEntityFactory<CountryLocalNameCreateDto,CountryLocalName> countrylocalnamefactory
        )
    {        
        CountryLocalNameFactory = countrylocalnamefactory;
    }

    public virtual Country CreateEntity(CountryCreateDto createDto)
    {
        return ToEntity(createDto);
    }
    private ClientApi.Domain.Country ToEntity(CountryCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Country();
        entity.Name = ClientApi.Domain.Country.CreateName(createDto.Name);
        if (createDto.Population is not null)entity.Population = ClientApi.Domain.Country.CreatePopulation(createDto.Population.NonNullValue<System.Int32>());
        if (createDto.CountryDebt is not null)entity.CountryDebt = ClientApi.Domain.Country.CreateCountryDebt(createDto.CountryDebt.NonNullValue<MoneyDto>());
        if (createDto.FirstLanguageCode is not null)entity.FirstLanguageCode = ClientApi.Domain.Country.CreateFirstLanguageCode(createDto.FirstLanguageCode.NonNullValue<System.String>());
        entity.CountryLocalNames = createDto.CountryLocalNames.Select(dto => CountryLocalNameFactory.CreateEntity(dto)).ToList();
        return entity;
    }
}

public partial class CountryFactory : CountryFactoryBase
{
    public CountryFactory
    (
        IEntityFactory<CountryLocalNameCreateDto,CountryLocalName> countrylocalnamefactory
    ): base(countrylocalnamefactory)                      
    {}
}