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
        var entities = models.Select(x => Create(x)).ToList();

        return entities;

        static AllNoxType Create(AllNoxTypeModel x)
        {
            return new AllNoxType
            {
                TextId = Text.From(x.Id),
                BooleanField = Nox.Types.Boolean.From(x.Boolean),         
                CountryCode2Field = CountryCode2.From(x.CountryCode2),
                CountryCode3Field = CountryCode3.From(x.CountryCode3),
                DateTimeField = Nox.Types.DateTime.From(System.DateTime.Now, TimeSpan.FromHours(1)),
                TextField = Text.From(x.TextField),
                VatNumberField = VatNumber.From(x.VatNumber, CountryCode2.From(x.CountryCode2)),
                CreatedAtUtc = System.DateTime.Now
            };
        }
    }
}