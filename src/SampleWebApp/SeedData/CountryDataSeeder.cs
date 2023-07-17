using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;

namespace SampleWebApp.SeedData;

internal class CountryDataSeeder : SampleDataSeederBase<Country>
{
    public CountryDataSeeder(SampleWebAppDbContext dbContext) : base(dbContext)
    {
    }

    protected override string SourceFile => "data/countries.json";
}