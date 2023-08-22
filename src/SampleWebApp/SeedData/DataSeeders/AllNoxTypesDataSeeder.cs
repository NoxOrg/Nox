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

    protected override AllNoxType TransformToEntity(AllNoxTypeModel model)
    {
        return new AllNoxType
        {
            TextId = Text.From(model.Id),
            BooleanField = Nox.Types.Boolean.From(model.Boolean),
            CountryCode2Field = CountryCode2.From(model.CountryCode2),
            CountryCode3Field = CountryCode3.From(model.CountryCode3),
            CultureCodeField = CultureCode.From(model.CultureCode),
            DateTimeField = Nox.Types.DateTime.From(System.DateTime.UtcNow, TimeSpan.FromHours(0)),
            LanguageCodeField = LanguageCode.From(model.LanguageCode),
            LengthField = Length.From(model.LengthValue, (LengthTypeUnit)Enum.Parse(typeof(LengthTypeUnit), model.LengthUnit)),
            MacAddressField = MacAddress.From(model.MacAddress),
            MarkdownField = Markdown.From(model.Markdown),
            PhoneNumberField = PhoneNumber.From(model.PhoneNumber),
            TemperatureField = Temperature.From(model.Temperature, (TemperatureTypeUnit)Enum.Parse(typeof(TemperatureTypeUnit), model.TemperatureUnit)),
            TextField = Text.From(model.TextField),
            VatNumberField = VatNumber.From(model.VatNumber, model.CountryCode2),
        };
    }
}