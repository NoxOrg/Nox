using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using Nox.Types;
using SampleWebApp.SeedData.Models;

namespace SampleWebApp.SeedData;

internal class CurrencyDataSeeder : SampleDataSeederBase<CurrencyModel, Currency>
{
    public CurrencyDataSeeder(SampleWebAppDbContext dbContext) : base(dbContext)
    {
    }

    protected override string SourceFile => "currencies.json";

    protected override IEnumerable<Currency> TransformToEntities(IEnumerable<CurrencyModel> models)
    {
        var entities = models.Select(x =>
        {
            return CreateCurrency(x);

            static Currency CreateCurrency(CurrencyModel x)
            {
                var currency = new Currency
                {
                    Name = Text.From(x.Name),
                    CreatedAtUtc = System.DateTime.Now,
                };
                currency.EnsureId();
                return currency;
            }
        }).ToList();

        return entities;
    }
}