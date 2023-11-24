using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using AutoMapper;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Cryptocash.Infrastructure;

internal class CryptocashExchangeRateDataSeeder : DataSeederBase<ExchangeRateDto, ExchangeRate>
{
    public CryptocashExchangeRateDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashExchangeRate.json";

    protected override ExchangeRate TransformToEntity(ExchangeRateDto model)
    {
        return new() {
        };
    }
}