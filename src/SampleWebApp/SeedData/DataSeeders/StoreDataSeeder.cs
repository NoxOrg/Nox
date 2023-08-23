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

    protected override Store TransformToEntity(StoreModel model)
    {
        return new Store
        {
            Id = Text.From(model.Id),
            Name = Text.From(model.Name),
            PhysicalMoney = Money.From(model.PhysicalMoney, CurrencyCode.USD),
        };
    }
}