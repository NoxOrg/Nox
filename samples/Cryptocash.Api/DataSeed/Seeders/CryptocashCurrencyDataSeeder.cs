using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using AutoMapper;
using MassTransit.Transports;

namespace Cryptocash.Infrastructure;

internal class CryptocashCurrencyDataSeeder : DataSeederBase<CurrencyDto, Currency>
{
    public CryptocashCurrencyDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashCurrency.json";

    protected override Currency TransformToEntity(CurrencyDto model)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Currency, CurrencyDto>());
        var mapper = config.CreateMapper();

        var test = mapper.Map<Currency>(model);

        return test;
    }
}