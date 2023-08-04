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
                TextField = Text.From(x.TextField),
                VatNumberField = VatNumber.From(x.VatNumber, CountryCode2.From(x.CountryCode2)),
                CountryCode2Field = CountryCode2.From(x.CountryCode2),
                CountryCode3Field = CountryCode3.From(x.CountryCode3),
                CountryNumberField = CountryNumber.From(x.CountryNumber),
                CurrencyNumberField = CurrencyNumber.From(x.CurrencyNumber),
                CurrencyCode3Field = CurrencyCode3.From(x.CurrencyCode3),
                CultureCodeField = CultureCode.From(x.CultureCode),
                AreaField = Area.From(x.AreaValue, (AreaTypeUnit)Enum.Parse(typeof(AreaTypeUnit), x.AreaUnit)),
                DistanceField = Distance.From(x.DistanceValue, (DistanceTypeUnit)Enum.Parse(typeof(DistanceTypeUnit), x.DistanceUnit)),
                EmailField = Email.From(x.Email),
                EncryptedTextField = EncryptedText.FromPlainText(x.TextField, x.EncryptedTextTypeOptions),
                FileField = Nox.Types.File.From((x.FileUrl, x.FileName, x.FileSize)),
                HashedTexField = HashedText.From(x.TextField),
                HtmlField = Html.From(x.HtmlText),
                ImageField = Image.From((x.ImageUrl, x.ImageName, x.ImageSize)),
                InternetDomainField = InternetDomain.From(x.InternetDomain),
                IpAddressField = IpAddress.From(x.IpAddress),
                JsonField = Json.From(x.Json),
                JwtTokenField = JwtToken.From(x.JwtToken),
                LatLongField = LatLong.From(x.Latitude, x.Longitude),
                TranslatedTextField = TranslatedText.From((CultureCode.From(x.CultureCode), x.TranslatedText)),
                MoneyField = Money.From((x.MoneyAmount, (CurrencyCode)Enum.Parse(typeof(CurrencyCode), x.CurrencyCode))),
                LanguageCodeField = LanguageCode.From(x.LanguageCode),
                MacAddressField = MacAddress.From(x.MacAddress),
                MarkdownField = Markdown.From(x.Markdown),
                MonthField = Month.From(x.Month),
                NumberField = Number.From(x.Number, x.NumberTypeOptions ?? new NumberTypeOptions()),
                PercentageField = Percentage.From(x.Percentage),
                TimeZoneCodeField = TimeZoneCode.From(x.TimeZoneCode),
                TemperatureField = Temperature.From(x.Temperature, (TemperatureTypeUnit)Enum.Parse(typeof(TemperatureTypeUnit), x.TemperatureUnit)),
                VolumeField = Volume.From(x.Volume, (VolumeTypeUnit)Enum.Parse(typeof(VolumeTypeUnit), x.VolumeUnit)),
                WeightField = Weight.From(x.Weight, (WeightTypeUnit)Enum.Parse(typeof(WeightTypeUnit), x.WeightUnit)),
                UriField = Nox.Types.Uri.From(x.Uri),
                UrlField = Url.From(x.Url),
                YamlField = Yaml.From(System.IO.File.ReadAllText("SeedData\\data\\" + x.Yaml)),
                YearField = Year.From(x.Year),
                StreetAddressField = StreetAddress.From(new StreetAddressItem
                {
                    StreetNumber = x.StreetAddress.StreetNumber,
                    AddressLine1 = x.StreetAddress.AddressLine1,
                    AddressLine2 = x.StreetAddress.AddressLine2,
                    Route = x.StreetAddress.Route,
                    Locality = x.StreetAddress.Locality,
                    Neighborhood = x.StreetAddress.Neighborhood,
                    AdministrativeArea1 = x.StreetAddress.AdministrativeArea1,
                    PostalCode = x.StreetAddress.PostalCode,
                    CountryId = CountryCode2.From(x.CountryCode2)
                }),
                LengthField = Length.From(x.Volume, (LengthTypeUnit)Enum.Parse(typeof(LengthTypeUnit), x.LengthUnit)),
                PasswordField = Password.From(x.Password),
                NuidField = Nuid.From(x.NuidText),
                ColorField = Color.FromName(x.Color),
                DayOfWeekField = Nox.Types.DayOfWeek.From((int)Enum.Parse(typeof(System.DayOfWeek), x.DayOfTheWeek)),
                DateField = Date.From(x.DateYear, x.DateMonth, x.DateDay),
                TimeField = Time.From(x.TimeHour, x.TimeMinute, x.TimeSecond, x.TimeMillisecond),
                DateTimeDurationField = DateTimeDuration.From(x.DurationTicks),
                DateTimeRangeField = DateTimeRange.From((new System.DateTime(x.DateYear, x.DateMonth, x.DateDay, x.TimeHour, x.TimeMinute, x.TimeSecond, x.TimeMillisecond), new System.DateTime(x.DateYear + 1, x.DateMonth, x.DateDay, x.TimeHour, x.TimeMinute, x.TimeSecond, x.TimeMillisecond))),
                UserField = User.From(x.User),
                PhoneNumberField = PhoneNumber.From(x.PhoneNumber),
                DateTimeField = Nox.Types.DateTime.From(new System.DateTime(x.DateYear, x.DateMonth, x.DateDay, x.TimeHour, x.TimeMinute, x.TimeSecond, x.TimeMillisecond, DateTimeKind.Utc)), 
                CreatedAtUtc = System.DateTime.UtcNow
            };
        }
    }
}