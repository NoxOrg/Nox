using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using Nox.Types;

namespace SampleWebApp.SeedData;

internal class CountryDataSeeder : SampleDataSeederBase<CountryModel, Country>
{
    public CountryDataSeeder(SampleWebAppDbContext dbContext) : base(dbContext)
    {
    }

    protected override string SourceFile => "countries.json";

    protected override IEnumerable<Country> TransformToEntities(IEnumerable<CountryModel> models)
    {
        var entities = models.Select(x =>
            new Country
            {
                Id = Text.From(x.Id.ToString()),
                AlphaCode2 = Text.From(x.AlphaCode2),
                AlphaCode3 = Text.From(x.AlphaCode3),
                AreaInSquareKilometres = Number.From(x.AreaInSquareKilometres),
                Capital = Text.From(x.Capital),
                Demonym = Text.From(x.Demonym),
                DialingCodes = Text.From(x.DialingCodes),
                Name = Text.From(x.Name),
                FormalName = Text.From(x.FormalName),
                NumericCode = Number.From(x.NumericCode),
                Population = Number.From(x.Population),
                TopLevelDomains = Text.From(x.TopLevelDomains),
                GeoRegion = Text.From(x.GeoRegion),
                GeoSubRegion = Text.From(x.GeoSubRegion),
                GeoWorldRegion = Text.From(x.GeoWorldRegion),
            }).ToList();

        return entities;
    }
}