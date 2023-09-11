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
using Country = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Factories;

public abstract class CountryFactoryBase: IEntityFactory<Country,CountryCreateDto>
{
    protected IEntityFactory<CountryTimeZone,CountryTimeZoneCreateDto> CountryTimeZoneFactory {get;}
    protected IEntityFactory<Holiday,HolidayCreateDto> HolidayFactory {get;}

    public CountryFactoryBase
    (
        IEntityFactory<CountryTimeZone,CountryTimeZoneCreateDto> countrytimezonefactory,
        IEntityFactory<Holiday,HolidayCreateDto> holidayfactory
        )
    {        
        CountryTimeZoneFactory = countrytimezonefactory;        
        HolidayFactory = holidayfactory;
    }

    public virtual Country CreateEntity(CountryCreateDto createDto)
    {
        return ToEntity(createDto);
    }
    private Cryptocash.Domain.Country ToEntity(CountryCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Country();
        entity.Id = Country.CreateId(createDto.Id);
        entity.Name = Cryptocash.Domain.Country.CreateName(createDto.Name);
        if (createDto.OfficialName is not null)entity.OfficialName = Cryptocash.Domain.Country.CreateOfficialName(createDto.OfficialName.NonNullValue<System.String>());
        if (createDto.CountryIsoNumeric is not null)entity.CountryIsoNumeric = Cryptocash.Domain.Country.CreateCountryIsoNumeric(createDto.CountryIsoNumeric.NonNullValue<System.UInt16>());
        if (createDto.CountryIsoAlpha3 is not null)entity.CountryIsoAlpha3 = Cryptocash.Domain.Country.CreateCountryIsoAlpha3(createDto.CountryIsoAlpha3.NonNullValue<System.String>());
        if (createDto.GeoCoords is not null)entity.GeoCoords = Cryptocash.Domain.Country.CreateGeoCoords(createDto.GeoCoords.NonNullValue<LatLongDto>());
        if (createDto.FlagEmoji is not null)entity.FlagEmoji = Cryptocash.Domain.Country.CreateFlagEmoji(createDto.FlagEmoji.NonNullValue<System.String>());
        if (createDto.FlagSvg is not null)entity.FlagSvg = Cryptocash.Domain.Country.CreateFlagSvg(createDto.FlagSvg.NonNullValue<ImageDto>());
        if (createDto.FlagPng is not null)entity.FlagPng = Cryptocash.Domain.Country.CreateFlagPng(createDto.FlagPng.NonNullValue<ImageDto>());
        if (createDto.CoatOfArmsSvg is not null)entity.CoatOfArmsSvg = Cryptocash.Domain.Country.CreateCoatOfArmsSvg(createDto.CoatOfArmsSvg.NonNullValue<ImageDto>());
        if (createDto.CoatOfArmsPng is not null)entity.CoatOfArmsPng = Cryptocash.Domain.Country.CreateCoatOfArmsPng(createDto.CoatOfArmsPng.NonNullValue<ImageDto>());
        if (createDto.GoogleMapsUrl is not null)entity.GoogleMapsUrl = Cryptocash.Domain.Country.CreateGoogleMapsUrl(createDto.GoogleMapsUrl.NonNullValue<System.String>());
        if (createDto.OpenStreetMapsUrl is not null)entity.OpenStreetMapsUrl = Cryptocash.Domain.Country.CreateOpenStreetMapsUrl(createDto.OpenStreetMapsUrl.NonNullValue<System.String>());
        entity.StartOfWeek = Cryptocash.Domain.Country.CreateStartOfWeek(createDto.StartOfWeek);
        //entity.Currency = Currency.ToEntity();
        //entity.Commissions = Commissions.Select(dto => dto.ToEntity()).ToList();
        //entity.VendingMachines = VendingMachines.Select(dto => dto.ToEntity()).ToList();
        //entity.Customers = Customers.Select(dto => dto.ToEntity()).ToList();
        entity.CountryTimeZones = createDto.CountryTimeZones.Select(dto => CountryTimeZoneFactory.CreateEntity(dto)).ToList();
        entity.Holidays = createDto.Holidays.Select(dto => HolidayFactory.CreateEntity(dto)).ToList();
        return entity;
    }
}

public partial class CountryFactory : CountryFactoryBase
{
    public CountryFactory
    (
        IEntityFactory<CountryTimeZone,CountryTimeZoneCreateDto> countrytimezonefactory,
        IEntityFactory<Holiday,HolidayCreateDto> holidayfactory
    ): base(countrytimezonefactory,holidayfactory)                      
    {}
}