using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using Nox.Types;
using SampleWebApp.SeedData.Models;

namespace SampleWebApp.SeedData;

internal class StoreDataSeeder : SampleDataSeederBase<StoreModel, Store>
{
    public StoreDataSeeder(SampleWebAppDbContext dbContext) : base(dbContext)
    {
    }

    protected override string SourceFile => "stores.json";

    protected override IEnumerable<Store> TransformToEntities(IEnumerable<StoreModel> models)
    {
        var entities = models.Select(x =>
            new Store
            {
                Id = Text.From(x.Id),
                Name = Text.From(x.Name),
                PhysicalMoney = Money.From(x.PhysicalMoney, CurrencyCode.USD),
                CreatedAtUtc = System.DateTime.UtcNow
            }).ToList();

        return entities;
    }
}