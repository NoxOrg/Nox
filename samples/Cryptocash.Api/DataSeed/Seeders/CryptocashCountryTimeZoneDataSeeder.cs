using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using AutoMapper;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Cryptocash.Infrastructure;

internal class CryptocashCountryTimeZoneDataSeeder : DataSeederBase<CountryTimeZoneDto, CountryTimeZone>
{
    public CryptocashCountryTimeZoneDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashCountryTimeZone.json";

    protected override CountryTimeZone TransformToEntity(CountryTimeZoneDto model)
    {
        return new() {
        };
    }
}