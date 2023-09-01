using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using Nox.Types;
using SampleWebApp.SeedData.Models;

namespace SampleWebApp.SeedData;

internal class StoreOwnerDataSeeder : SampleDataSeederBase<StoreOwnerModel, StoreOwner>
{
    public StoreOwnerDataSeeder(SampleWebAppDbContext dbContext) : base(dbContext)
    {
    }

    protected override string SourceFile => "store-owners.json";

    protected override StoreOwner TransformToEntity(StoreOwnerModel model)
    {
        return new StoreOwner
        {
            Id = Text.From(model.Id),
            Name = Text.From(model.Name)
        };
    }
}