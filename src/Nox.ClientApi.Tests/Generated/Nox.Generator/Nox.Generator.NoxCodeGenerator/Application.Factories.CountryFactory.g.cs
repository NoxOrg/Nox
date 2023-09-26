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

internal abstract class CountryFactoryBase : IEntityFactory<Country, CountryCreateDto, CountryUpdateDto>
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

    public virtual void PartialUpdateEntity(Country entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private ClientApi.Domain.Country ToEntity(CountryCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Country();
        entity.Name = ClientApi.Domain.Country.CreateName(createDto.Name);
        if (createDto.Population is not null)entity.Population = ClientApi.Domain.Country.CreatePopulation(createDto.Population.NonNullValue<System.Int32>());
        if (createDto.CountryDebt is not null)entity.CountryDebt = ClientApi.Domain.Country.CreateCountryDebt(createDto.CountryDebt.NonNullValue<MoneyDto>());
        if (createDto.FirstLanguageCode is not null)entity.FirstLanguageCode = ClientApi.Domain.Country.CreateFirstLanguageCode(createDto.FirstLanguageCode.NonNullValue<System.String>());
        if (createDto.CountryIsoNumeric is not null)entity.CountryIsoNumeric = ClientApi.Domain.Country.CreateCountryIsoNumeric(createDto.CountryIsoNumeric.NonNullValue<System.UInt16>());
        if (createDto.CountryIsoAlpha3 is not null)entity.CountryIsoAlpha3 = ClientApi.Domain.Country.CreateCountryIsoAlpha3(createDto.CountryIsoAlpha3.NonNullValue<System.String>());
        if (createDto.GoogleMapsUrl is not null)entity.GoogleMapsUrl = ClientApi.Domain.Country.CreateGoogleMapsUrl(createDto.GoogleMapsUrl.NonNullValue<System.String>());
        if (createDto.StartOfWeek is not null)entity.StartOfWeek = ClientApi.Domain.Country.CreateStartOfWeek(createDto.StartOfWeek.NonNullValue<System.UInt16>());
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
        if (updateDto.CountryIsoNumeric == null) { entity.CountryIsoNumeric = null; } else {
            entity.CountryIsoNumeric = ClientApi.Domain.Country.CreateCountryIsoNumeric(updateDto.CountryIsoNumeric.ToValueFromNonNull<System.UInt16>());
        }
        if (updateDto.CountryIsoAlpha3 == null) { entity.CountryIsoAlpha3 = null; } else {
            entity.CountryIsoAlpha3 = ClientApi.Domain.Country.CreateCountryIsoAlpha3(updateDto.CountryIsoAlpha3.ToValueFromNonNull<System.String>());
        }
        if (updateDto.GoogleMapsUrl == null) { entity.GoogleMapsUrl = null; } else {
            entity.GoogleMapsUrl = ClientApi.Domain.Country.CreateGoogleMapsUrl(updateDto.GoogleMapsUrl.ToValueFromNonNull<System.String>());
        }
        if (updateDto.StartOfWeek == null) { entity.StartOfWeek = null; } else {
            entity.StartOfWeek = ClientApi.Domain.Country.CreateStartOfWeek(updateDto.StartOfWeek.ToValueFromNonNull<System.UInt16>());
        }
    }

    private void PartialUpdateEntityInternal(Country entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.Country.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            if (PopulationUpdateValue == null) { entity.Population = null; }
            else
            {
                entity.Population = ClientApi.Domain.Country.CreatePopulation(PopulationUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryDebt", out var CountryDebtUpdateValue))
        {
            if (CountryDebtUpdateValue == null) { entity.CountryDebt = null; }
            else
            {
                entity.CountryDebt = ClientApi.Domain.Country.CreateCountryDebt(CountryDebtUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("FirstLanguageCode", out var FirstLanguageCodeUpdateValue))
        {
            if (FirstLanguageCodeUpdateValue == null) { entity.FirstLanguageCode = null; }
            else
            {
                entity.FirstLanguageCode = ClientApi.Domain.Country.CreateFirstLanguageCode(FirstLanguageCodeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoNumeric", out var CountryIsoNumericUpdateValue))
        {
            if (CountryIsoNumericUpdateValue == null) { entity.CountryIsoNumeric = null; }
            else
            {
                entity.CountryIsoNumeric = ClientApi.Domain.Country.CreateCountryIsoNumeric(CountryIsoNumericUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoAlpha3", out var CountryIsoAlpha3UpdateValue))
        {
            if (CountryIsoAlpha3UpdateValue == null) { entity.CountryIsoAlpha3 = null; }
            else
            {
                entity.CountryIsoAlpha3 = ClientApi.Domain.Country.CreateCountryIsoAlpha3(CountryIsoAlpha3UpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("GoogleMapsUrl", out var GoogleMapsUrlUpdateValue))
        {
            if (GoogleMapsUrlUpdateValue == null) { entity.GoogleMapsUrl = null; }
            else
            {
                entity.GoogleMapsUrl = ClientApi.Domain.Country.CreateGoogleMapsUrl(GoogleMapsUrlUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("StartOfWeek", out var StartOfWeekUpdateValue))
        {
            if (StartOfWeekUpdateValue == null) { entity.StartOfWeek = null; }
            else
            {
                entity.StartOfWeek = ClientApi.Domain.Country.CreateStartOfWeek(StartOfWeekUpdateValue);
            }
        }
    }
}

internal partial class CountryFactory : CountryFactoryBase
{
    public CountryFactory
    (
        IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> countrylocalnamefactory,
        IEntityFactory<CountryBarCode, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> countrybarcodefactory
    ): base(countrylocalnamefactory,countrybarcodefactory)
    {}
}