using FluentAssertions;

using Nox.Types;

using System.Text.Json;

using TestWebApp.Domain;

using DayOfWeek = Nox.Types.DayOfWeek;

namespace Nox.Tests.DatabaseIntegrationTests;

public class PostgresIntegrationTests : PostgresTestBase
{
    // [Fact]
    public void GeneratedEntity_Postgres_CanSaveAndReadFields_AllTypes()
    {
        // TODO:
        // array
        // colour
        // databaseNumber
        // collection
        // entity
        // formula
        // image
        // imagePng
        // imageJpg
        // imageSvg
        // object
        // user
        // languageCode
        // yaml
        // uri
        // date
        // dateTimeSchedule
        // html
        // json

        // TODO: commented types

        var text = "TestTextValue";
        var number = 123;
        var money = 10;
        var currencyCode = CurrencyCode.UAH;
        var countryCode2 = "UA";
        var currencyCode3 = "USD";
        var countryCode3 = "UKR";
        var addressItem = new StreetAddressItem
        {
            AddressLine1 = "AddressLine1",
            CountryId = CountryCode2.From(countryCode2),
            PostalCode = "61135"
        };
        var languageCode = "en";
        var year = (ushort)2023;
        var area = 198_090M;
        var areaPersistUnitAs = AreaTypeUnit.SquareMeter;
        var volume = 198d;
        var persistVolumeUnitAs = VolumeTypeUnit.CubicMeter;
        var cultureCode = "de-CH";
        var macAddress = "A1B2C3D4E5F6";
        var url = "http://example.com/";
        var password = "Test123.";
        var dayOfWeek = 1;
        byte month = 7;
        var currencyNumber = (short)970;
        var dateTimeDurationInHours = 30.5;
        var color = new byte[] { 1, 2, 3, 4 };
        var date = new DateOnly(2023, 7, 14);
        var time = new System.TimeOnly(11152500000);
        var percentage = 0.5f;
        var fileName = "MyFile";
        var fileSizeInBytes = 1000000UL;
        var fileUrl = "https://example.com/myfile.pdf";

        var addressJsonPretty = JsonSerializer.Serialize(addressItem, new JsonSerializerOptions { WriteIndented = true });
        var addressJsonMinified = JsonSerializer.Serialize(addressItem, new JsonSerializerOptions { AllowTrailingCommas = false, WriteIndented = false });
        var boolean = true;
        var email = "regus@regusignore.com";
        var switzerlandCitiesCountiesYaml = @"
- Zurich:
    - County: Zurich
    - County: Winterthur
    - County: Baden
- Geneva:
    - County: Geneva
    - County: Lausanne
";

        using var aesAlgorithm = System.Security.Cryptography.Aes.Create();
        var encryptedTextTypeOptions = new EncryptedTextTypeOptions
        {
            PublicKey = Convert.ToBase64String(aesAlgorithm.Key),
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            Iv = Convert.ToBase64String(aesAlgorithm.IV)
        };

        var internetDomain = "nox.org";
        var temperatureFahrenheit = 88;
        var temperaturePersistUnitAs = TemperatureTypeUnit.Celsius;
        var length = 314_598M;
        var persistLengthUnitAs = LengthTypeUnit.Meter;
        var sampleUri = "https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName";
        var latitude = 47.376934;
        var longitude = 8.541287;

        var jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        var weight = 20.58M;
        var persistWeightUnitAs = WeightTypeUnit.Kilogram;

        var distance = 80.481727;
        var persistDistanceUnitAs = DistanceTypeUnit.Kilometer;

        var dateTimeRangeStart = new DateTimeOffset(2023, 4, 12, 0, 0, 0, TimeSpan.FromHours(3));
        var dateTimeRangeEnd = new DateTimeOffset(2023, 7, 10, 0, 0, 0, TimeSpan.FromHours(5));
        var dateTime = System.DateTime.UtcNow;

        var newItem = new TestEntityForTypes()
        {
            Id = Text.From(countryCode2),
            TextTestField = Text.From(text),
            NumberTestField = Number.From(number),
            MoneyTestField = Money.From(money, currencyCode),
            CountryCode2TestField = CountryCode2.From(countryCode2),
            AreaTestField = Area.From(area, new AreaTypeOptions() { Units = AreaTypeUnit.SquareFoot, PersistAs = areaPersistUnitAs }),
            VolumeTestField = Volume.From(volume, new VolumeTypeOptions { Unit = VolumeTypeUnit.CubicMeter, PersistAs = persistVolumeUnitAs }),
            StreetAddressTestField = StreetAddress.From(addressItem),
            CurrencyCode3TestField = CurrencyCode3.From(currencyCode3),
            LanguageCodeTestField = LanguageCode.From(languageCode),
            YearTestField = Year.From(year),
            CultureCodeTestField = CultureCode.From(cultureCode),
            TranslatedTextTestField = TranslatedText.From((CultureCode.From("ur-PK"), "شادی مبارک")),
            CountryCode3TestField = CountryCode3.From(countryCode3),
            CountryNumberTestField = CountryNumber.From(242),
            TimeZoneCodeTestField = TimeZoneCode.From("utc"),
            MacAddressTestField = MacAddress.From(macAddress),
            UrlTestField = Url.From(url),
            HashedTextTestField = HashedText.From(text),
            PasswordTestField = Password.From(password),
            DayOfWeekTestField = DayOfWeek.From(1),
            MonthTestField = Month.From(month),
            CurrencyNumberTestField = CurrencyNumber.From(currencyNumber),
            DateTimeDurationTestField = DateTimeDuration.FromHours(dateTimeDurationInHours),
            TimeTestField = Time.From(time.Ticks),
            JsonTestField = Json.From(addressJsonPretty),
            BooleanTestField = Types.Boolean.From(boolean),
            EmailTestField = Email.From(email),
            YamlTestField = Yaml.From(switzerlandCitiesCountiesYaml),
            TempratureTestField = Temperature.From(temperatureFahrenheit, new TemperatureTypeOptions() { Units = TemperatureTypeUnit.Fahrenheit, PersistAs = temperaturePersistUnitAs }),
            EncryptedTextTestField = EncryptedText.FromPlainText(text, encryptedTextTypeOptions),
            ColorTestField = Color.From(color),
            PercentageTestField = Percentage.From(percentage),
            DateTestField = Date.From(date),
            MarkdownTestField = Markdown.From(text),
            FileTestField = Types.File.From(fileUrl, fileName, fileSizeInBytes),
            InternetDomainTestField = InternetDomain.From(internetDomain),
            LengthTestField = Length.From(length, new LengthTypeOptions() { Units = LengthTypeUnit.Foot, PersistAs = persistLengthUnitAs }),
            JwtTokenTestField = JwtToken.From(jwtToken),
            WeightTestField = Weight.From(weight, new WeightTypeOptions() { Units = WeightTypeUnit.Pound, PersistAs = persistWeightUnitAs }),
            DistanceTestField = Distance.From(distance, new DistanceTypeOptions() { Units = DistanceTypeUnit.Mile, PersistAs = persistDistanceUnitAs }),
            UriTestField = Types.Uri.From(sampleUri),
            GeoCoordTestField = LatLong.From(latitude, longitude),
            DateTimeRangeTestField = DateTimeRange.From(dateTimeRangeStart, dateTimeRangeEnd),
            DateTimeTestField = Types.DateTime.From(dateTime),
        };
        var temperatureCelsius = newItem.TempratureTestField.ToCelsius();
        DbContext.TestEntityForTypes.Add(newItem);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityForTypes.First();

        // TODO: make it work without .Value
        testEntity.Id.Value.Should().Be(countryCode2);
        testEntity.TextTestField.Value.Should().Be(text);
        testEntity.NumberTestField.Value.Should().Be(number);
        testEntity.MoneyTestField!.Value.Amount.Should().Be(money);
        testEntity.MoneyTestField.Value.CurrencyCode.Should().Be(currencyCode);
        testEntity.CountryCode2TestField!.Value.Should().Be(countryCode2);
        testEntity.StreetAddressTestField!.Value.Should().BeEquivalentTo(addressItem);
        testEntity.AreaTestField!.ToSquareFeet().Should().Be(area);
        testEntity.AreaTestField!.Unit.Should().Be(areaPersistUnitAs);
        testEntity.VolumeTestField!.ToCubicMeters().Should().Be(volume);
        testEntity.VolumeTestField!.Unit.Should().Be(persistVolumeUnitAs);
        testEntity.CurrencyCode3TestField!.Value.Should().Be(currencyCode3);
        testEntity.LanguageCodeTestField!.Value.Should().Be(languageCode);
        testEntity.YearTestField!.Value.Should().Be(year);
        testEntity.CultureCodeTestField!.Value.Should().Be(cultureCode);
        testEntity.TranslatedTextTestField!.Value.Phrase.Should().BeEquivalentTo("شادی مبارک");
        testEntity.CountryCode3TestField!.Value.Should().Be(countryCode3);
        testEntity.CountryNumberTestField!.Value.Should().Be(242);
        testEntity.TimeZoneCodeTestField!.Value.Should().Be("UTC");
        testEntity.MacAddressTestField!.Value.Should().Be(macAddress);
        testEntity.UrlTestField!.Value.AbsoluteUri.Should().Be(url);
        testEntity.HashedTextTestField!.HashText.Should().Be(newItem.HashedTextTestField?.HashText);
        testEntity.HashedTextTestField!.Salt.Should().Be(newItem.HashedTextTestField?.Salt);
        testEntity.PasswordTestField!.HashedPassword.Should().Be(newItem.PasswordTestField.HashedPassword);
        testEntity.PasswordTestField!.Salt.Should().Be(newItem.PasswordTestField.Salt);
        testEntity.DayOfWeekTestField!.Value.Should().Be(dayOfWeek);
        testEntity.MonthTestField!.Value.Should().Be(month);
        testEntity.CurrencyNumberTestField!.Value.Should().Be(currencyNumber);
        testEntity.DateTimeDurationTestField!.TotalHours.Should().Be(dateTimeDurationInHours);
        testEntity.TimeTestField!.ToString("hh:mm").Should().Be(time.ToString("hh:mm"));
        testEntity.JsonTestField!.Value.Should().Be(addressJsonMinified);
        testEntity.JsonTestField!.ToString(string.Empty).Should().Be(addressJsonPretty);
        testEntity.JsonTestField!.ToString("p").Should().Be(addressJsonPretty);
        testEntity.JsonTestField!.ToString("m").Should().Be(addressJsonMinified);
        testEntity.BooleanTestField!.Value.Should().Be(boolean);
        testEntity.EmailTestField!.Value.Should().Be(email);
        testEntity.YamlTestField!.Value.Should().BeEquivalentTo(Yaml.From(switzerlandCitiesCountiesYaml).Value);
        testEntity.TempratureTestField!.Value.Should().Be(temperatureCelsius);
        testEntity.TempratureTestField!.ToFahrenheit().Should().Be(temperatureFahrenheit);
        testEntity.TempratureTestField!.Unit.Should().Be(temperaturePersistUnitAs);
        testEntity.EncryptedTextTestField!.DecryptText(encryptedTextTypeOptions).Should().Be(text);
        testEntity.ColorTestField!.Value.Should().Equal(color);
        testEntity.PercentageTestField!.Value.Should().Be(percentage);
        testEntity.DateTestField!.Value.Should().Be(date);
        testEntity.FileTestField!.Value.Url.Should().Be(fileUrl);
        testEntity.FileTestField!.Value.PrettyName.Should().Be(fileName);
        testEntity.FileTestField!.Value.SizeInBytes.Should().Be(fileSizeInBytes);
        testEntity.MarkdownTestField!.Value.Should().Be(text);
        testEntity.InternetDomainTestField!.Value.Should().Be(internetDomain);
        testEntity.LengthTestField!.ToFeet().Should().Be(length);
        testEntity.LengthTestField!.Unit.Should().Be(persistLengthUnitAs);
        testEntity.JwtTokenTestField!.Value.Should().Be(jwtToken);
        testEntity.WeightTestField!.Unit.Should().Be(persistWeightUnitAs);
        testEntity.WeightTestField!.ToPounds().Should().Be(weight);
        testEntity.DistanceTestField!.ToMiles().Should().Be(distance);
        testEntity.DistanceTestField!.Unit.Should().Be(persistDistanceUnitAs);
        testEntity.DatabaseNumberTestField!.Value.Should().BeGreaterThan(0);
        testEntity.UriTestField!.Value.Should().BeEquivalentTo(new System.Uri(sampleUri));
        testEntity.GeoCoordTestField!.Latitude.Should().Be(latitude);
        testEntity.GeoCoordTestField!.Longitude.Should().Be(longitude);
        testEntity.DateTimeRangeTestField!.Start.Should().Be(dateTimeRangeStart);
        testEntity.DateTimeRangeTestField!.End.Should().Be(dateTimeRangeEnd);
        testEntity.DateTimeTestField!.Should().Be(newItem.DateTimeTestField);
    }
}