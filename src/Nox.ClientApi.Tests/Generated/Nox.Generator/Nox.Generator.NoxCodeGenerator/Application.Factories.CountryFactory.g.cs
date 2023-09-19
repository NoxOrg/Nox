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

public abstract class CountryFactoryBase : IEntityFactory<Country, CountryCreateDto, CountryUpdateDto>
{
    protected IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> CountryLocalNameFactory {get;}
    protected IEntityFactory<CountryBarCode, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> CountryBarCodeFactory {get;}

    public CountryFactoryBase
    (
        IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> countrylocalnamefactory,
        IEntityFactory<CountryBarCode, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> countrybarcodefactory
        )
    {
        CountryLocalNameFactory = countrylocalnamefactory;
        CountryBarCodeFactory = countrybarcodefactory;
    }

    public virtual Country CreateEntity(CountryCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public void UpdateEntity(Country entity, CountryUpdateDto updateDto)
    {
        MapEntity(entity, updateDto);
    }

    private ClientApi.Domain.Country ToEntity(CountryCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Country();
        entity.Name = ClientApi.Domain.Country.CreateName(createDto.Name);
        if (createDto.Population is not null)entity.Population = ClientApi.Domain.Country.CreatePopulation(createDto.Population.NonNullValue<System.Int32>());
        if (createDto.CountryDebt is not null)entity.CountryDebt = ClientApi.Domain.Country.CreateCountryDebt(createDto.CountryDebt.NonNullValue<MoneyDto>());
        if (createDto.FirstLanguageCode is not null)entity.FirstLanguageCode = ClientApi.Domain.Country.CreateFirstLanguageCode(createDto.FirstLanguageCode.NonNullValue<System.String>());
        //entity.Workplaces = Workplaces.Select(dto => dto.ToEntity()).ToList();
        entity.CountryShortNames = createDto.CountryShortNames.Select(dto => CountryLocalNameFactory.CreateEntity(dto)).ToList();
        if (createDto.CountryBarCode is not null)
        {
            entity.CountryBarCode = CountryBarCodeFactory.CreateEntity(createDto.CountryBarCode);
        }
        return entity;
    }

    private void MapEntity(Country entity, CountryUpdateDto updateDto)
    {
        // TODO: discuss about keys
        entity.Name = ClientApi.Domain.Country.CreateName(updateDto.Name);
        if (updateDto.Population is not null)entity.Population = ClientApi.Domain.Country.CreatePopulation(updateDto.Population.NonNullValue<System.Int32>());
        if (updateDto.CountryDebt is not null)entity.CountryDebt = ClientApi.Domain.Country.CreateCountryDebt(updateDto.CountryDebt.NonNullValue<MoneyDto>());
        if (updateDto.FirstLanguageCode is not null)entity.FirstLanguageCode = ClientApi.Domain.Country.CreateFirstLanguageCode(updateDto.FirstLanguageCode.NonNullValue<System.String>());

        // TODO: discuss about keys
        //entity.Workplaces = Workplaces.Select(dto => dto.ToEntity()).ToList();
    }
}

public partial class CountryFactory : CountryFactoryBase
{
    public CountryFactory
    (
        IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> countrylocalnamefactory,
        IEntityFactory<CountryBarCode, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> countrybarcodefactory
    ): base(countrylocalnamefactory,countrybarcodefactory)
    {}
}