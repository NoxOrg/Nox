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
            CurrencyCode3Field = CurrencyCode3.From(model.CurrencyCode3),
            CurrencyNumberField = CurrencyNumber.From(model.CurrencyNumber),
            LanguageCodeField = LanguageCode.From(model.LanguageCode),
            LengthField = Length.From(model.LengthValue, (LengthTypeUnit)Enum.Parse(typeof(LengthTypeUnit), model.LengthUnit)),
            MacAddressField = MacAddress.From(model.MacAddress),
            MarkdownField = Markdown.From(model.Markdown),
            PhoneNumberField = PhoneNumber.From(model.PhoneNumber),
            TemperatureField = Temperature.From(model.Temperature, (TemperatureTypeUnit)Enum.Parse(typeof(TemperatureTypeUnit), model.TemperatureUnit)),
            HtmlField = Html.From(model.HtmlText),
            InternetDomainField = InternetDomain.From(model.InternetDomain),
            IpAddressField = IpAddress.From(model.IpAddress),
            JsonField = Json.From(model.Json),
            JwtTokenField = JwtToken.From(model.JwtToken),
            MonthField = Month.From(model.Month),
            NuidField = Nuid.From(model.NuidText),
            TextField = Text.From(model.TextField),
            DateField = Date.From(model.DateYear, model.DateMonth, model.DateDay),
            DateTimeDurationField = DateTimeDuration.From(model.DurationTicks),
            DateTimeField = Nox.Types.DateTime.From(new System.DateTime(model.DateYear, model.DateMonth, model.DateDay, model.TimeHour, model.TimeMinute, model.TimeSecond, model.TimeMillisecond, DateTimeKind.Utc)),
            DateTimeScheduleField = DateTimeSchedule.From(model.DateTimeSchedule),
            //VatNumberField = VatNumber.From(model.VatNumber, model.CountryCode2),
        };
    }
}