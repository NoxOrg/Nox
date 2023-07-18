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
            new Currency
            {
                Id = Text.From(x.Id),
                Name = Text.From(x.Name),
                CreatedAtUtc = DateTime.Now
            }).ToList();

        return entities;
    }
}