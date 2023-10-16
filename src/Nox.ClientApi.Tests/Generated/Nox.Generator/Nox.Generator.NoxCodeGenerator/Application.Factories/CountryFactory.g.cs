// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Factories;

internal abstract class CountryFactoryBase : IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto>
{
    protected IEntityFactory<ClientApi.Domain.CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> CountryLocalNameFactory {get;}
    protected IEntityFactory<ClientApi.Domain.CountryBarCode, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> CountryBarCodeFactory {get;}

    public CountryFactoryBase
    (
        IEntityFactory<ClientApi.Domain.CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> countrylocalnamefactory,
        IEntityFactory<ClientApi.Domain.CountryBarCode, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> countrybarcodefactory
        )
    {
        CountryLocalNameFactory = countrylocalnamefactory;
        CountryBarCodeFactory = countrybarcodefactory;
    }

    public virtual CountryEntity CreateEntity(CountryCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CountryEntity entity, CountryUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(CountryEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private ClientApi.Domain.Country ToEntity(CountryCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Country();
        entity.Name = ClientApi.Domain.CountryMetadata.CreateName(createDto.Name);
        if (createDto.Population is not null)entity.Population = ClientApi.Domain.CountryMetadata.CreatePopulation(createDto.Population.NonNullValue<System.Int32>());
        if (createDto.CountryDebt is not null)entity.CountryDebt = ClientApi.Domain.CountryMetadata.CreateCountryDebt(createDto.CountryDebt.NonNullValue<MoneyDto>());
        if (createDto.FirstLanguageCode is not null)entity.FirstLanguageCode = ClientApi.Domain.CountryMetadata.CreateFirstLanguageCode(createDto.FirstLanguageCode.NonNullValue<System.String>());
        if (createDto.CountryIsoNumeric is not null)entity.CountryIsoNumeric = ClientApi.Domain.CountryMetadata.CreateCountryIsoNumeric(createDto.CountryIsoNumeric.NonNullValue<System.UInt16>());
        if (createDto.CountryIsoAlpha3 is not null)entity.CountryIsoAlpha3 = ClientApi.Domain.CountryMetadata.CreateCountryIsoAlpha3(createDto.CountryIsoAlpha3.NonNullValue<System.String>());
        if (createDto.GoogleMapsUrl is not null)entity.GoogleMapsUrl = ClientApi.Domain.CountryMetadata.CreateGoogleMapsUrl(createDto.GoogleMapsUrl.NonNullValue<System.String>());
        if (createDto.StartOfWeek is not null)entity.StartOfWeek = ClientApi.Domain.CountryMetadata.CreateStartOfWeek(createDto.StartOfWeek.NonNullValue<System.UInt16>());
        createDto.CountryShortNames.ForEach(dto => entity.CreateRefToCountryShortNames(CountryLocalNameFactory.CreateEntity(dto)));
        if (createDto.CountryBarCode is not null)
        {
            entity.CreateRefToCountryBarCode(CountryBarCodeFactory.CreateEntity(createDto.CountryBarCode));
        }
        return entity;
    }

    private void UpdateEntityInternal(CountryEntity entity, CountryUpdateDto updateDto)
    {
        entity.Name = ClientApi.Domain.CountryMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        if (updateDto.Population == null) { entity.Population = null; } else {
            entity.Population = ClientApi.Domain.CountryMetadata.CreatePopulation(updateDto.Population.ToValueFromNonNull<System.Int32>());
        }
        if (updateDto.CountryDebt == null) { entity.CountryDebt = null; } else {
            entity.CountryDebt = ClientApi.Domain.CountryMetadata.CreateCountryDebt(updateDto.CountryDebt.ToValueFromNonNull<MoneyDto>());
        }
        if (updateDto.FirstLanguageCode == null) { entity.FirstLanguageCode = null; } else {
            entity.FirstLanguageCode = ClientApi.Domain.CountryMetadata.CreateFirstLanguageCode(updateDto.FirstLanguageCode.ToValueFromNonNull<System.String>());
        }
        if (updateDto.CountryIsoNumeric == null) { entity.CountryIsoNumeric = null; } else {
            entity.CountryIsoNumeric = ClientApi.Domain.CountryMetadata.CreateCountryIsoNumeric(updateDto.CountryIsoNumeric.ToValueFromNonNull<System.UInt16>());
        }
        if (updateDto.CountryIsoAlpha3 == null) { entity.CountryIsoAlpha3 = null; } else {
            entity.CountryIsoAlpha3 = ClientApi.Domain.CountryMetadata.CreateCountryIsoAlpha3(updateDto.CountryIsoAlpha3.ToValueFromNonNull<System.String>());
        }
        if (updateDto.GoogleMapsUrl == null) { entity.GoogleMapsUrl = null; } else {
            entity.GoogleMapsUrl = ClientApi.Domain.CountryMetadata.CreateGoogleMapsUrl(updateDto.GoogleMapsUrl.ToValueFromNonNull<System.String>());
        }
        if (updateDto.StartOfWeek == null) { entity.StartOfWeek = null; } else {
            entity.StartOfWeek = ClientApi.Domain.CountryMetadata.CreateStartOfWeek(updateDto.StartOfWeek.ToValueFromNonNull<System.UInt16>());
        }
    }

    private void PartialUpdateEntityInternal(CountryEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.CountryMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            if (PopulationUpdateValue == null) { entity.Population = null; }
            else
            {
                entity.Population = ClientApi.Domain.CountryMetadata.CreatePopulation(PopulationUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryDebt", out var CountryDebtUpdateValue))
        {
            if (CountryDebtUpdateValue == null) { entity.CountryDebt = null; }
            else
            {
                entity.CountryDebt = ClientApi.Domain.CountryMetadata.CreateCountryDebt(CountryDebtUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("FirstLanguageCode", out var FirstLanguageCodeUpdateValue))
        {
            if (FirstLanguageCodeUpdateValue == null) { entity.FirstLanguageCode = null; }
            else
            {
                entity.FirstLanguageCode = ClientApi.Domain.CountryMetadata.CreateFirstLanguageCode(FirstLanguageCodeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoNumeric", out var CountryIsoNumericUpdateValue))
        {
            if (CountryIsoNumericUpdateValue == null) { entity.CountryIsoNumeric = null; }
            else
            {
                entity.CountryIsoNumeric = ClientApi.Domain.CountryMetadata.CreateCountryIsoNumeric(CountryIsoNumericUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoAlpha3", out var CountryIsoAlpha3UpdateValue))
        {
            if (CountryIsoAlpha3UpdateValue == null) { entity.CountryIsoAlpha3 = null; }
            else
            {
                entity.CountryIsoAlpha3 = ClientApi.Domain.CountryMetadata.CreateCountryIsoAlpha3(CountryIsoAlpha3UpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("GoogleMapsUrl", out var GoogleMapsUrlUpdateValue))
        {
            if (GoogleMapsUrlUpdateValue == null) { entity.GoogleMapsUrl = null; }
            else
            {
                entity.GoogleMapsUrl = ClientApi.Domain.CountryMetadata.CreateGoogleMapsUrl(GoogleMapsUrlUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("StartOfWeek", out var StartOfWeekUpdateValue))
        {
            if (StartOfWeekUpdateValue == null) { entity.StartOfWeek = null; }
            else
            {
                entity.StartOfWeek = ClientApi.Domain.CountryMetadata.CreateStartOfWeek(StartOfWeekUpdateValue);
            }
        }
    }
}

internal partial class CountryFactory : CountryFactoryBase
{
    public CountryFactory
    (
        IEntityFactory<ClientApi.Domain.CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> countrylocalnamefactory,
        IEntityFactory<ClientApi.Domain.CountryBarCode, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> countrybarcodefactory
    ) : base(countrylocalnamefactory,countrybarcodefactory)
    {}
}