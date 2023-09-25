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

    public virtual void UpdateEntity(Country entity, CountryUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    private ClientApi.Domain.Country ToEntity(CountryCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Country();
        entity.Name = ClientApi.Domain.Country.CreateName(createDto.Name);
        if (createDto.Population is not null)entity.Population = ClientApi.Domain.Country.CreatePopulation(createDto.Population.NonNullValue<System.Int32>());
        if (createDto.CountryDebt is not null)entity.CountryDebt = ClientApi.Domain.Country.CreateCountryDebt(createDto.CountryDebt.NonNullValue<MoneyDto>());
        if (createDto.FirstLanguageCode is not null)entity.FirstLanguageCode = ClientApi.Domain.Country.CreateFirstLanguageCode(createDto.FirstLanguageCode.NonNullValue<System.String>());
        entity.CountryShortNames = createDto.CountryShortNames.Select(dto => CountryLocalNameFactory.CreateEntity(dto)).ToList();
        if (createDto.CountryBarCode is not null)
        {
            entity.CountryBarCode = CountryBarCodeFactory.CreateEntity(createDto.CountryBarCode);
        }
        return entity;
    }

    private void UpdateEntityInternal(Country entity, CountryUpdateDto updateDto)
    {
        entity.Name = ClientApi.Domain.Country.CreateName(updateDto.Name.NonNullValue<System.String>());
        if (updateDto.Population == null) { entity.Population = null; } else {
            entity.Population = ClientApi.Domain.Country.CreatePopulation(updateDto.Population.ToValueFromNonNull<System.Int32>());
        }
        if (updateDto.CountryDebt == null) { entity.CountryDebt = null; } else {
            entity.CountryDebt = ClientApi.Domain.Country.CreateCountryDebt(updateDto.CountryDebt.ToValueFromNonNull<MoneyDto>());
        }
        if (updateDto.FirstLanguageCode == null) { entity.FirstLanguageCode = null; } else {
            entity.FirstLanguageCode = ClientApi.Domain.Country.CreateFirstLanguageCode(updateDto.FirstLanguageCode.ToValueFromNonNull<System.String>());
        }
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