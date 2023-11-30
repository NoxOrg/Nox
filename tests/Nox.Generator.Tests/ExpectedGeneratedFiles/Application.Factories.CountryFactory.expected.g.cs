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

using SampleWebApp.Application.Dto;
using SampleWebApp.Domain;
using CountryEntity = SampleWebApp.Domain.Country;

namespace SampleWebApp.Application.Factories;

internal abstract class CountryFactoryBase : IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public CountryFactoryBase
    (
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual CountryEntity CreateEntity(CountryCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(CountryEntity entity, CountryUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CountryEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private SampleWebApp.Domain.Country ToEntity(CountryCreateDto createDto)
    {
        var entity = new SampleWebApp.Domain.Country();
        entity.Id = CountryMetadata.CreateId(createDto.Id);
        entity.Name = SampleWebApp.Domain.CountryMetadata.CreateName(createDto.Name);
        entity.FormalName = SampleWebApp.Domain.CountryMetadata.CreateFormalName(createDto.FormalName);
        entity.AlphaCode3 = SampleWebApp.Domain.CountryMetadata.CreateAlphaCode3(createDto.AlphaCode3);
        entity.AlphaCode2 = SampleWebApp.Domain.CountryMetadata.CreateAlphaCode2(createDto.AlphaCode2);
        entity.NumericCode = SampleWebApp.Domain.CountryMetadata.CreateNumericCode(createDto.NumericCode);
        entity.SetIfNotNull(createDto.DialingCodes, (entity) => entity.DialingCodes =SampleWebApp.Domain.CountryMetadata.CreateDialingCodes(createDto.DialingCodes.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.Capital, (entity) => entity.Capital =SampleWebApp.Domain.CountryMetadata.CreateCapital(createDto.Capital.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.Demonym, (entity) => entity.Demonym =SampleWebApp.Domain.CountryMetadata.CreateDemonym(createDto.Demonym.NonNullValue<System.String>()));
        entity.AreaInSquareKilometres = SampleWebApp.Domain.CountryMetadata.CreateAreaInSquareKilometres(createDto.AreaInSquareKilometres);
        entity.SetIfNotNull(createDto.GeoCoord, (entity) => entity.GeoCoord =SampleWebApp.Domain.CountryMetadata.CreateGeoCoord(createDto.GeoCoord.NonNullValue<LatLongDto>()));
        entity.GeoRegion = SampleWebApp.Domain.CountryMetadata.CreateGeoRegion(createDto.GeoRegion);
        entity.GeoSubRegion = SampleWebApp.Domain.CountryMetadata.CreateGeoSubRegion(createDto.GeoSubRegion);
        entity.GeoWorldRegion = SampleWebApp.Domain.CountryMetadata.CreateGeoWorldRegion(createDto.GeoWorldRegion);
        entity.SetIfNotNull(createDto.Population, (entity) => entity.Population =SampleWebApp.Domain.CountryMetadata.CreatePopulation(createDto.Population.NonNullValue<System.Int32>()));
        entity.SetIfNotNull(createDto.TopLevelDomains, (entity) => entity.TopLevelDomains =SampleWebApp.Domain.CountryMetadata.CreateTopLevelDomains(createDto.TopLevelDomains.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.EncryptedTextField, (entity) => entity.EncryptedTextField =SampleWebApp.Domain.CountryMetadata.CreateEncryptedTextField(createDto.EncryptedTextField.NonNullValue<System.Byte[]>()));
        entity.SetIfNotNull(createDto.HashedTextField, (entity) => entity.HashedTextField =SampleWebApp.Domain.CountryMetadata.CreateHashedTextField(createDto.HashedTextField.NonNullValue<HashedTextDto>()));
        entity.SetIfNotNull(createDto.PasswordField, (entity) => entity.PasswordField =SampleWebApp.Domain.CountryMetadata.CreatePasswordField(createDto.PasswordField.NonNullValue<PasswordDto>()));
        return entity;
    }

    private void UpdateEntityInternal(CountryEntity entity, CountryUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = SampleWebApp.Domain.CountryMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.FormalName = SampleWebApp.Domain.CountryMetadata.CreateFormalName(updateDto.FormalName.NonNullValue<System.String>());
        entity.AlphaCode3 = SampleWebApp.Domain.CountryMetadata.CreateAlphaCode3(updateDto.AlphaCode3.NonNullValue<System.String>());
        entity.AlphaCode2 = SampleWebApp.Domain.CountryMetadata.CreateAlphaCode2(updateDto.AlphaCode2.NonNullValue<System.String>());
        entity.NumericCode = SampleWebApp.Domain.CountryMetadata.CreateNumericCode(updateDto.NumericCode.NonNullValue<System.Int16>());
        if(updateDto.DialingCodes is null)
        {
             entity.DialingCodes = null;
        }
        else
        {
            entity.DialingCodes = SampleWebApp.Domain.CountryMetadata.CreateDialingCodes(updateDto.DialingCodes.ToValueFromNonNull<System.String>());
        }
        if(updateDto.Capital is null)
        {
             entity.Capital = null;
        }
        else
        {
            entity.Capital = SampleWebApp.Domain.CountryMetadata.CreateCapital(updateDto.Capital.ToValueFromNonNull<System.String>());
        }
        if(updateDto.Demonym is null)
        {
             entity.Demonym = null;
        }
        else
        {
            entity.Demonym = SampleWebApp.Domain.CountryMetadata.CreateDemonym(updateDto.Demonym.ToValueFromNonNull<System.String>());
        }
        entity.AreaInSquareKilometres = SampleWebApp.Domain.CountryMetadata.CreateAreaInSquareKilometres(updateDto.AreaInSquareKilometres.NonNullValue<System.Int32>());
        if(updateDto.GeoCoord is null)
        {
             entity.GeoCoord = null;
        }
        else
        {
            entity.GeoCoord = SampleWebApp.Domain.CountryMetadata.CreateGeoCoord(updateDto.GeoCoord.ToValueFromNonNull<LatLongDto>());
        }
        entity.GeoRegion = SampleWebApp.Domain.CountryMetadata.CreateGeoRegion(updateDto.GeoRegion.NonNullValue<System.String>());
        entity.GeoSubRegion = SampleWebApp.Domain.CountryMetadata.CreateGeoSubRegion(updateDto.GeoSubRegion.NonNullValue<System.String>());
        entity.GeoWorldRegion = SampleWebApp.Domain.CountryMetadata.CreateGeoWorldRegion(updateDto.GeoWorldRegion.NonNullValue<System.String>());
        if(updateDto.Population is null)
        {
             entity.Population = null;
        }
        else
        {
            entity.Population = SampleWebApp.Domain.CountryMetadata.CreatePopulation(updateDto.Population.ToValueFromNonNull<System.Int32>());
        }
        if(updateDto.TopLevelDomains is null)
        {
             entity.TopLevelDomains = null;
        }
        else
        {
            entity.TopLevelDomains = SampleWebApp.Domain.CountryMetadata.CreateTopLevelDomains(updateDto.TopLevelDomains.ToValueFromNonNull<System.String>());
        }
    }

    private void PartialUpdateEntityInternal(CountryEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = SampleWebApp.Domain.CountryMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("FormalName", out var FormalNameUpdateValue))
        {
            if (FormalNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'FormalName' can't be null");
            }
            {
                entity.FormalName = SampleWebApp.Domain.CountryMetadata.CreateFormalName(FormalNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("AlphaCode3", out var AlphaCode3UpdateValue))
        {
            if (AlphaCode3UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'AlphaCode3' can't be null");
            }
            {
                entity.AlphaCode3 = SampleWebApp.Domain.CountryMetadata.CreateAlphaCode3(AlphaCode3UpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("AlphaCode2", out var AlphaCode2UpdateValue))
        {
            if (AlphaCode2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'AlphaCode2' can't be null");
            }
            {
                entity.AlphaCode2 = SampleWebApp.Domain.CountryMetadata.CreateAlphaCode2(AlphaCode2UpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("NumericCode", out var NumericCodeUpdateValue))
        {
            if (NumericCodeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'NumericCode' can't be null");
            }
            {
                entity.NumericCode = SampleWebApp.Domain.CountryMetadata.CreateNumericCode(NumericCodeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DialingCodes", out var DialingCodesUpdateValue))
        {
            if (DialingCodesUpdateValue == null) { entity.DialingCodes = null; }
            else
            {
                entity.DialingCodes = SampleWebApp.Domain.CountryMetadata.CreateDialingCodes(DialingCodesUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Capital", out var CapitalUpdateValue))
        {
            if (CapitalUpdateValue == null) { entity.Capital = null; }
            else
            {
                entity.Capital = SampleWebApp.Domain.CountryMetadata.CreateCapital(CapitalUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Demonym", out var DemonymUpdateValue))
        {
            if (DemonymUpdateValue == null) { entity.Demonym = null; }
            else
            {
                entity.Demonym = SampleWebApp.Domain.CountryMetadata.CreateDemonym(DemonymUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("AreaInSquareKilometres", out var AreaInSquareKilometresUpdateValue))
        {
            if (AreaInSquareKilometresUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'AreaInSquareKilometres' can't be null");
            }
            {
                entity.AreaInSquareKilometres = SampleWebApp.Domain.CountryMetadata.CreateAreaInSquareKilometres(AreaInSquareKilometresUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("GeoCoord", out var GeoCoordUpdateValue))
        {
            if (GeoCoordUpdateValue == null) { entity.GeoCoord = null; }
            else
            {
                entity.GeoCoord = SampleWebApp.Domain.CountryMetadata.CreateGeoCoord(GeoCoordUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("GeoRegion", out var GeoRegionUpdateValue))
        {
            if (GeoRegionUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'GeoRegion' can't be null");
            }
            {
                entity.GeoRegion = SampleWebApp.Domain.CountryMetadata.CreateGeoRegion(GeoRegionUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("GeoSubRegion", out var GeoSubRegionUpdateValue))
        {
            if (GeoSubRegionUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'GeoSubRegion' can't be null");
            }
            {
                entity.GeoSubRegion = SampleWebApp.Domain.CountryMetadata.CreateGeoSubRegion(GeoSubRegionUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("GeoWorldRegion", out var GeoWorldRegionUpdateValue))
        {
            if (GeoWorldRegionUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'GeoWorldRegion' can't be null");
            }
            {
                entity.GeoWorldRegion = SampleWebApp.Domain.CountryMetadata.CreateGeoWorldRegion(GeoWorldRegionUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            if (PopulationUpdateValue == null) { entity.Population = null; }
            else
            {
                entity.Population = SampleWebApp.Domain.CountryMetadata.CreatePopulation(PopulationUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("TopLevelDomains", out var TopLevelDomainsUpdateValue))
        {
            if (TopLevelDomainsUpdateValue == null) { entity.TopLevelDomains = null; }
            else
            {
                entity.TopLevelDomains = SampleWebApp.Domain.CountryMetadata.CreateTopLevelDomains(TopLevelDomainsUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class CountryFactory : CountryFactoryBase
{
    public CountryFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}