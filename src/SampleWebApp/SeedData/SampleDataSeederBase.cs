using Nox;
using System.Text.Json;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using Nox.Types;

namespace SampleWebApp.SeedData;

internal abstract class SampleDataSeederBase<TEntity> : INoxDataSeeder
{
    private readonly SampleWebAppDbContext _dbContext;

    protected SampleDataSeederBase(SampleWebAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        var list = new List<Country>();
        for (var i = 0; i < 5; i++)
        {
            var country = new Country()
            {
                AlphaCode2 = Text.From("AlphaCode2_" + i),
                AlphaCode3 = Text.From("AlphaCode3_" + i),
                AreaInSquareKilometres = Number.From(12345 + i),
                Capital = Text.From("Capital" + i),
                Demonym = Text.From("Demonym" + i),
                DialingCodes = Text.From("DialingCodes1" + i),
                Name = Text.From("Name" + i),
                FormalName = Text.From("FormalName" + i),
                NumericCode = Number.From(12345 + i),
                Population = Number.From(12345 + i),
                TopLevelDomains = Text.From("TopLevelDomains" + i),
                GeoRegion = Text.From("GeoRegion" + i),
                GeoSubRegion = Text.From("GeoSubRegion" + i),
                GeoWorldRegion = Text.From("GeoWorldRegion" + i)
            };
            list.Add(country);
        }

        var str = JsonSerializer.Serialize(list);

        using var sr = new StreamReader(SourceFile);
        var jsonText = sr.ReadToEnd();

        var entityData = JsonSerializer.Deserialize<IEnumerable<TEntity>>(jsonText)!;

        _dbContext.AddRange(entityData);
    }

    protected abstract string SourceFile { get; }
}