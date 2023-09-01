using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using Nox.Types;
using SampleWebApp.SeedData.Models;

namespace SampleWebApp.SeedData;

internal class StoreSecurityPasswordsDataSeeder : SampleDataSeederBase<StoreSecurityPasswordsModel, StoreSecurityPasswords>
{
    public StoreSecurityPasswordsDataSeeder(SampleWebAppDbContext dbContext) : base(dbContext)
    {
    }

    protected override string SourceFile => "store-security-passwords.json";

    protected override StoreSecurityPasswords TransformToEntity(StoreSecurityPasswordsModel model)
    {
        return new StoreSecurityPasswords
        {
            Id = Text.From(model.Id),
            Name = Text.From(model.Name),
            SecurityCamerasPassword = Text.From(model.SecurityCamerasPassword),
            StoreId = Text.From(model.StoreId),
        };
    }
}