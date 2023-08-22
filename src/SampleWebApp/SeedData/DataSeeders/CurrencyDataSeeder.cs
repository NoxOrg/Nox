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

    protected override Currency TransformToEntity(CurrencyModel model)
    {
        var currency = new Currency
        {
            Name = Text.From(model.Name),
        };

        currency.EnsureId();
        return currency;
    }
}