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
        Enum.TryParse(model.CountryCode2, out CountryCode countryCode);
        return new AllNoxType
        {
            AreaField = Area.From(model.AreaValue, (AreaTypeUnit)Enum.Parse(typeof(AreaTypeUnit), model.AreaUnit)),
            BooleanField = Nox.Types.Boolean.From(model.Boolean),
            // ColorField
            CountryCode2Field = CountryCode2.From(model.CountryCode2),
            CountryCode3Field = CountryCode3.From(model.CountryCode3),
            CountryNumberField = CountryNumber.From(model.CountryNumber),
            CultureCodeField = CultureCode.From(model.CultureCode),
            CurrencyCode3Field = CurrencyCode3.From(model.CurrencyCode3),
            CurrencyNumberField = CurrencyNumber.From(model.CurrencyNumber),
            DateField = Date.From(model.DateYear, model.DateMonth, model.DateDay),
            DateTimeDurationField = DateTimeDuration.From(model.DurationTicks),
            DateTimeField = Nox.Types.DateTime.From(new System.DateTime(model.DateYear, model.DateMonth, model.DateDay, model.TimeHour, model.TimeMinute, model.TimeSecond, model.TimeMillisecond, DateTimeKind.Utc)),
            DateTimeScheduleField = DateTimeSchedule.From(model.DateTimeSchedule),
            DayOfWeekField = Nox.Types.DayOfWeek.From((System.DayOfWeek)Enum.Parse(typeof(System.DayOfWeek), model.DayOfTheWeek)),
            DistanceField = Distance.From(model.DistanceValue, (DistanceTypeUnit)Enum.Parse(typeof(DistanceTypeUnit), model.DistanceUnit)),
            EmailField = Email.From(model.Email),
            EncryptedTextField = EncryptedText.FromPlainText(model.TextField, model.EncryptedTextTypeOptions),
            FileField = Nox.Types.File.From((model.FileUrl, model.FileName, model.FileSize)),
            GuidField = Nox.Types.Guid.From(model.Guid),
            HashedTexField = HashedText.From(model.TextField),
            HtmlField = Html.From(model.HtmlText),
            ImageField = Image.From((model.ImageUrl, model.ImageName, model.ImageSize)),
            InternetDomainField = InternetDomain.From(model.InternetDomain),
            IpAddressField = IpAddress.From(model.IpAddress),
            JsonField = Json.From(model.Json),
            JwtTokenField = JwtToken.From(model.JwtToken),
            LanguageCodeField = LanguageCode.From(model.LanguageCode),
            //LatLongField = LatLong.From(x.Latitude, x.Longitude),
            LengthField = Length.From(model.LengthValue, (LengthTypeUnit)Enum.Parse(typeof(LengthTypeUnit), model.LengthUnit)),
            MacAddressField = MacAddress.From(model.MacAddress),
            MarkdownField = Markdown.From(model.Markdown),
            MoneyField = Money.From((model.MoneyAmount, (CurrencyCode)Enum.Parse(typeof(CurrencyCode), model.CurrencyCode))),
            MonthField = Month.From(model.Month),
            NuidField = Nuid.From(model.NuidText),
            NumberField = Number.From(model.Number, model.NumberTypeOptions ?? new NumberTypeOptions()),
            PasswordField = Password.From(model.Password),
            PercentageField = Percentage.From(model.Percentage),
            PhoneNumberField = PhoneNumber.From(model.PhoneNumber),
            StreetAddressField = StreetAddress.From(new StreetAddressItem
            {
                StreetNumber = model.StreetAddress.StreetNumber,
                AddressLine1 = model.StreetAddress.AddressLine1,
                AddressLine2 = model.StreetAddress.AddressLine2,
                Route = model.StreetAddress.Route,
                Locality = model.StreetAddress.Locality,
                Neighborhood = model.StreetAddress.Neighborhood,
                AdministrativeArea1 = model.StreetAddress.AdministrativeArea1,
                PostalCode = model.StreetAddress.PostalCode,
                CountryId = countryCode
            }),
            TemperatureField = Temperature.From(model.Temperature, (TemperatureTypeUnit)Enum.Parse(typeof(TemperatureTypeUnit), model.TemperatureUnit)),
            TextField = Text.From(model.TextField),
            TextId = Text.From(model.Id),
            TimeField = Time.From(model.TimeHour, model.TimeMinute, model.TimeSecond, model.TimeMillisecond),
            TimeZoneCodeField = TimeZoneCode.From(model.TimeZoneCode),
            TranslatedTextField = TranslatedText.From((CultureCode.From(model.CultureCode), model.TranslatedText)),
            UserField = User.From(model.User),
            UriField = Nox.Types.Uri.From(model.Uri),
            UrlField = Url.From(model.Url),
            VatNumberField = VatNumber.From(model.VatNumber, countryCode),
            VolumeField = Volume.From(model.Volume, (VolumeTypeUnit)Enum.Parse(typeof(VolumeTypeUnit), model.VolumeUnit)),
            WeightField = Weight.From(model.Weight, (WeightTypeUnit)Enum.Parse(typeof(WeightTypeUnit), model.WeightUnit)),
            YamlField = Yaml.From(System.IO.File.ReadAllText("SeedData\\data\\" + model.Yaml)),
            YearField = Year.From(model.Year)
        };
    }
}