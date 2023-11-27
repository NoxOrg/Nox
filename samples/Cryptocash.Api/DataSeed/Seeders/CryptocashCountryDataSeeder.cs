using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using AutoMapper;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Cryptocash.Infrastructure;

internal class CryptocashCountryDataSeeder : DataSeederBase<CountryDto, Country>
{
    public CryptocashCountryDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashCountry.json";

    protected override Country TransformToEntity(CountryDto model)
    {
        return new() {
            Id = CountryCode2.From(model.Id),
            Name = Text.From(model.Name!),
            OfficialName = Text.From(model.OfficialName!),
            CountryIsoNumeric = CountryNumber.From((ushort)model.CountryIsoNumeric!),
            CountryIsoAlpha3 = CountryCode3.From(model.CountryIsoAlpha3!),
            GeoCoords = LatLong.From(model.GeoCoords!.Latitude, model.GeoCoords.Longitude),
            FlagEmoji = Text.From(model?.FlagEmoji!),
            FlagSvg = model?.FlagSvg == null ? null : Image.From(model?.FlagSvg!),
            FlagPng = model?.FlagPng == null ? null : Image.From(model?.FlagPng!),
            CoatOfArmsSvg = model?.CoatOfArmsSvg == null ? null : Image.From(model?.CoatOfArmsSvg!),
            CoatOfArmsPng = model?.CoatOfArmsPng == null ? null : Image.From(model?.CoatOfArmsPng!),
            GoogleMapsUrl = Url.From(model?.GoogleMapsUrl!),
            OpenStreetMapsUrl = Url.From(model?.OpenStreetMapsUrl!),
            StartOfWeek = Nox.Types.DayOfWeek.From((ushort)model?.StartOfWeek!),
            CurrencyId = CurrencyCode3.From(model?.CurrencyId!)
        };
    }
}