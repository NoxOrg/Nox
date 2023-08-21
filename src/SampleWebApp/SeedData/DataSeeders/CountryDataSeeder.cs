using Nox.Types;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.SeedData.Models;

namespace SampleWebApp.SeedData;

internal class CountryDataSeeder : SampleDataSeederBase<CountryModel, Country>
{
    public CountryDataSeeder(SampleWebAppDbContext dbContext) : base(dbContext)
    {
    }

    protected override string SourceFile => "countries.json";

    protected override Country TransformToEntity(CountryModel model)
    {
        return new Country
        {
            AlphaCode2 = CountryCode2.From(model.AlphaCode2),
            AlphaCode3 = CountryCode3.From(model.AlphaCode3),
            AreaInSquareKilometres = Area.From(model.AreaInSquareKilometres, AreaTypeUnit.SquareMeter),
            Capital = Text.From(model.Capital),
            Demonym = Text.From(model.Demonym),
            DialingCodes = Text.From(model.DialingCodes),
            Name = Text.From(model.Name),
            FormalName = Text.From(model.FormalName),
            NumericCode = Number.From(model.NumericCode),
            Population = Number.From(model.Population),
            TopLevelDomains = Text.From(model.TopLevelDomains),
            GeoRegion = Text.From(model.GeoRegion),
            GeoSubRegion = Text.From(model.GeoSubRegion),
            GeoWorldRegion = Text.From(model.GeoWorldRegion),
            CountryLocalNames = x.CountryLocalNames.Select(model => new CountryLocalNames
            {
                Id = Text.From(model.Id)
            }).ToList()
        };
    }
}