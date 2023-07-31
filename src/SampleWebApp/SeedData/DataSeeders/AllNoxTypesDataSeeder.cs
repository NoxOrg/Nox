using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using Nox.Types;
using SampleWebApp.SeedData.Models;

namespace SampleWebApp.SeedData;

internal class AllNoxTypesDataSeeder : SampleDataSeederBase<AllNoxTypeModel, AllNoxType>
{
    public AllNoxTypesDataSeeder(SampleWebAppDbContext dbContext) : base(dbContext)
    {
    }

    protected override string SourceFile => "allnoxtypes.json";

    protected override IEnumerable<AllNoxType> TransformToEntities(IEnumerable<AllNoxTypeModel> models)
    {
        var entities = models.Select(x =>
            new AllNoxType
            {
                Id = Text.From(x.Id),
                TextField = Text.From(x.TextField),
                VatNumberField = VatNumber.From(x.VatNumber, CountryCode2.From(x.CountryCode2)),
                CountryCode2Field = CountryCode2.From(x.CountryCode2),
                CountryCode3Field = CountryCode3.From(x.CountryCode3),
                CreatedAtUtc = System.DateTime.Now
            }).ToList();

        return entities;
    }
}