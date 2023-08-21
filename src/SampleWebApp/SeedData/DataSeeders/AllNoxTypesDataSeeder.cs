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
                CultureCodeField = CultureCode.From(x.CultureCode),
                DateTimeField = Nox.Types.DateTime.From(System.DateTime.UtcNow, TimeSpan.FromHours(0)),
                LanguageCodeField = LanguageCode.From(x.LanguageCode),
                LengthField = Length.From(x.LengthValue, (LengthTypeUnit)Enum.Parse(typeof(LengthTypeUnit), x.LengthUnit)),
                MacAddressField = MacAddress.From(x.MacAddress),
                MarkdownField = Markdown.From(x.Markdown),
                PhoneNumberField = PhoneNumber.From(x.PhoneNumber),
                TemperatureField = Temperature.From(x.Temperature, (TemperatureTypeUnit)Enum.Parse(typeof(TemperatureTypeUnit), x.TemperatureUnit)),
                TextField = Text.From(x.TextField),
                VatNumberField = VatNumber.From(x.VatNumber, x.CountryCode2),
                CreatedAtUtc = System.DateTime.Now
            };
        }
    }
}