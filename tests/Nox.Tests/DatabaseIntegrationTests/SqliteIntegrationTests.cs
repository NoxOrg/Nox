using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using System.Text.Json;
using TestWebApp.Domain;
using DayOfWeek = Nox.Types.DayOfWeek;

namespace Nox.Tests.DatabaseIntegrationTests;

public class SqliteIntegrationTests : SqliteTestBase
{
    [Fact]
    public void GeneratedEntity_Sqlite_CanSaveAndReadFields_AllTypes()
    {
        // TODO:
        // array
        // color
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
        // cultureCode
        // languageCode
        // yaml
        // uri
        // url
        // date
        // dateTimeSchedule
        // html
        // json
        // time
        // translatedText
        // jwtToken

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
        var area = 198_090M;
        var persistAreaUnitAs = AreaTypeUnit.SquareMeter;
        var cultureCode = "de-CH";
        var macAddress = "A1B2C3D4E5F6";
        var password = "Test123.";
        var dayOfWeek = 1;
        byte month = 7;
        var dateTimeDurationInHours = 30.5;
        var year = (ushort)2023;
        var vatNumberValue = "44403198682";
        var vatNumberCountryCode2 = CountryCode2.From("FR");
        var date = new DateOnly(2023, 7, 14);
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
        var internetDomain = "nox.org";
        

        var length = 314_598M;
        var percentage = 0.5f;
        var persistLengthUnitAs = LengthTypeUnit.Meter;

        using var aesAlgorithm = System.Security.Cryptography.Aes.Create();
        var encryptedTextTypeOptions = new EncryptedTextTypeOptions
        {
            PublicKey = Convert.ToBase64String(aesAlgorithm.Key),
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            Iv = Convert.ToBase64String(aesAlgorithm.IV)
        };

        var temperatureFahrenheit = 88;
        var temperaturePersistUnitAs = TemperatureTypeUnit.Celsius;

        var jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        var weight = 20.58M;
        var persistWeightUnitAs = WeightTypeUnit.Kilogram;
        var databaseNumber = 1U;

        var distance = 80.481727;
        var persistDistanceUnitAs = DistanceTypeUnit.Kilometer;

        var newItem = new TestEntityForTypes()
        {
            Id = Text.From(countryCode2),
            TextTestField = Text.From(text),
            NumberTestField = Number.From(number),
            MoneyTestField = Money.From(money, currencyCode),
            CountryCode2TestField = CountryCode2.From(countryCode2),
            AreaTestField = Area.From(area, new AreaTypeOptions() { Units = AreaTypeUnit.SquareFoot, PersistAs = persistAreaUnitAs }),
            StreetAddressTestField = StreetAddress.From(addressItem),
            CurrencyCode3TestField = CurrencyCode3.From(currencyCode3),
            IpAddressV4TestField = IpAddress.From("192.168.12.100"),
            IpAddressV6TestField = IpAddress.From("2001:0db8:3c4d:0015:0000:0000:1a2f:1a2b"),
            LanguageCodeTestField = LanguageCode.From(languageCode),
            CultureCodeTestField = CultureCode.From(cultureCode),
            TranslatedTextTestField = TranslatedText.From((CultureCode.From("ur-PK"), "شادی مبارک")),
            CountryCode3TestField = CountryCode3.From(countryCode3),
            CountryNumberTestField = CountryNumber.From(242),
            TimeZoneCodeTestField = TimeZoneCode.From("utc"),
            MacAddressTestField = MacAddress.From(macAddress),
            HashedTextTestField = HashedText.From(text),
            PasswordTestField = Password.From(password),
            DayOfWeekTestField = DayOfWeek.From(1),
            MonthTestField = Month.From(month),
            DateTimeDurationTestField = DateTimeDuration.FromHours(dateTimeDurationInHours),
            CurrencyNumberTestField = CurrencyNumber.From(970),
            JsonTestField = Json.From(addressJsonPretty),
            YearTestField = Year.From(year),
            BooleanTestField = Types.Boolean.From(boolean),
            EmailTestField = Email.From(email),
            YamlTestField = Yaml.From(switzerlandCitiesCountiesYaml),
            VatNumberTestField = VatNumber.From(vatNumberValue, vatNumberCountryCode2),
            PercentageTestField = Percentage.From(percentage),
            TempratureTestField = Temperature.From(temperatureFahrenheit, new TemperatureTypeOptions() { Units = TemperatureTypeUnit.Fahrenheit, PersistAs = temperaturePersistUnitAs }),
            EncryptedTextTestField = EncryptedText.FromPlainText(text, encryptedTextTypeOptions),
            DateTestField = Date.From(date),
            FileTestField = Types.File.From(fileUrl, fileName, fileSizeInBytes),
            MarkdownTestField = Markdown.From(text),
            InternetDomainTestField = InternetDomain.From(internetDomain),
            LengthTestField = Length.From(length, new LengthTypeOptions() { Units = LengthTypeUnit.Foot, PersistAs = persistLengthUnitAs }),
            JwtTokenTestField = JwtToken.From(jwtToken),
            WeightTestField = Weight.From(weight, new WeightTypeOptions() { Units = WeightTypeUnit.Pound, PersistAs = persistWeightUnitAs }),
            DistanceTestField = Distance.From(distance, new DistanceTypeOptions() { Units = DistanceTypeUnit.Mile, PersistAs = persistDistanceUnitAs }),
            DatabaseNumberTestField = DatabaseNumber.FromDatabase(databaseNumber), //SQLite supports AutoIncrement only for column of type INTEGER PRIMARY KEY  https://www.sqlite.org/autoinc.html
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
        testEntity.AreaTestField!.Unit.Should().Be(persistAreaUnitAs);
        testEntity.CurrencyCode3TestField!.Value.Should().Be(currencyCode3);
        testEntity.IpAddressV4TestField!.Value.Should().Be("192.168.12.100");
        testEntity.IpAddressV6TestField!.Value.Should().Be("2001:db8:3c4d:15::1a2f:1a2b");
        testEntity.LanguageCodeTestField!.Value.Should().Be(languageCode);
        testEntity.CultureCodeTestField!.Value.Should().Be(cultureCode);
        testEntity.TranslatedTextTestField!.Value.Phrase.Should().BeEquivalentTo("شادی مبارک");
        testEntity.CountryCode3TestField!.Value.Should().Be(countryCode3);
        testEntity.CountryNumberTestField!.Value.Should().Be(242);
        testEntity.TimeZoneCodeTestField!.Value.Should().Be("UTC");
        testEntity.MacAddressTestField!.Value.Should().Be(macAddress);
        testEntity.HashedTextTestField!.HashText.Should().Be(newItem.HashedTextTestField?.HashText);
        testEntity.HashedTextTestField!.Salt.Should().Be(newItem.HashedTextTestField?.Salt);
        testEntity.PasswordTestField!.HashedPassword.Should().Be(newItem.PasswordTestField.HashedPassword);
        testEntity.PasswordTestField!.Salt.Should().Be(newItem.PasswordTestField.Salt);
        testEntity.DayOfWeekTestField!.Value.Should().Be(dayOfWeek);
        testEntity.MonthTestField!.Value.Should().Be(month);
        testEntity.DateTimeDurationTestField!.TotalHours.Should().Be(dateTimeDurationInHours);
        testEntity.CurrencyNumberTestField!.Value.Should().Be(970);
        testEntity.JsonTestField!.Value.Should().Be(addressJsonMinified);
        testEntity.JsonTestField!.ToString(string.Empty).Should().Be(addressJsonPretty);
        testEntity.JsonTestField!.ToString("p").Should().Be(addressJsonPretty);
        testEntity.JsonTestField!.ToString("m").Should().Be(addressJsonMinified);
        testEntity.YearTestField!.Value.Should().Be(year);
        testEntity.BooleanTestField!.Value.Should().Be(boolean);
        testEntity.EmailTestField!.Value.Should().Be(email);
        testEntity.YamlTestField!.Value.Should().BeEquivalentTo(Yaml.From(switzerlandCitiesCountiesYaml).Value);
        testEntity.VatNumberTestField!.Value.Number.Should().Be(vatNumberValue);
        testEntity.VatNumberTestField!.Value.CountryCode2.Should().Be(vatNumberCountryCode2);
        testEntity.PercentageTestField!.Value.Should().Be(percentage);
        testEntity.TempratureTestField!.Value.Should().Be(temperatureCelsius);
        testEntity.TempratureTestField!.ToFahrenheit().Should().Be(temperatureFahrenheit);
        testEntity.TempratureTestField!.Unit.Should().Be(temperaturePersistUnitAs);
        testEntity.EncryptedTextTestField!.DecryptText(encryptedTextTypeOptions).Should().Be(text);
        testEntity.DateTestField!.Value.Should().Be(date);
        testEntity.FileTestField!.Value.Url.Should().Be(fileUrl);
        testEntity.FileTestField!.Value.PrettyName.Should().Be(fileName);
        testEntity.FileTestField!.Value.SizeInBytes.Should().Be(fileSizeInBytes);
        testEntity.MarkdownTestField!.Value.Should().Be(text);
        testEntity.InternetDomainTestField!.Value.Should().Be(internetDomain);
        testEntity.LengthTestField!.Unit.Should().Be(persistLengthUnitAs);
        testEntity.LengthTestField!.ToFeet().Should().Be(length);
        testEntity.JwtTokenTestField!.Value.Should().Be(jwtToken);
        testEntity.WeightTestField!.Unit.Should().Be(persistWeightUnitAs);
        testEntity.WeightTestField!.ToPounds().Should().Be(weight);
        testEntity.DistanceTestField!.ToMiles().Should().Be(distance);
        testEntity.DistanceTestField!.Unit.Should().Be(persistDistanceUnitAs);
        testEntity.DatabaseNumberTestField!.Value.Should().BeGreaterThan(0);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ZeroOrMany_OneOrMany()
    {
        var text = "TestTextValue";

        var newItem = new TestEntity()
        {
            Id = Text.From(text),
            TextTestField = Text.From(text),
        };
        DbContext.TestEntities.Add(newItem);
        DbContext.SaveChanges();

        var newItem2 = new SecondTestEntity()
        {
            Id = Text.From(text),
            TextTestField2 = Text.From(text),
        };

        newItem.SecondTestEntities.Add(newItem2);
        DbContext.SecondTestEntities.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntities.Include(x => x.SecondTestEntities).First();
        var secondTestEntity = DbContext.SecondTestEntities.Include(x => x.TestEntities).First();

        Assert.NotEmpty(testEntity.SecondTestEntities);
        Assert.NotEmpty(secondTestEntity.TestEntities);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_OneOrMany_OneOrMany()
    {
        var text = "TestTextValue";

        var newItem = new TestEntityOneOrMany()
        {
            Id = Text.From(text),
            TextTestField = Text.From(text),
        };
        DbContext.TestEntityOneOrManies.Add(newItem);
        DbContext.SaveChanges();

        var newItem2 = new SecondTestEntityOneOrMany()
        {
            Id = Text.From(text),
            TextTestField2 = Text.From(text),
        };

        newItem.SecondTestEntityOneOrManies.Add(newItem2);
        DbContext.SecondTestEntityOneOrManies.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityOneOrManies.Include(x => x.SecondTestEntityOneOrManies).First();
        var secondTestEntity = DbContext.SecondTestEntityOneOrManies.Include(x => x.TestEntityOneOrManies).First();

        Assert.NotEmpty(testEntity.SecondTestEntityOneOrManies);
        Assert.NotEmpty(secondTestEntity.TestEntityOneOrManies);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ExactlyOne_ExactlyOne()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var textId2 = "TestTextValue2";

        var newItem = new TestEntityExactlyOne()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityExactlyOne()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(text),
        };

        newItem.SecondTestEntityExactlyOne = newItem2;
        newItem.SecondTestEntityExactlyOneId = newItem2.Id;
        newItem2.TestEntityExactlyOne = newItem;
        DbContext.TestEntityExactlyOnes.Add(newItem);
        DbContext.SecondTestEntityExactlyOnes.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityExactlyOnes.Include(x => x.SecondTestEntityExactlyOne).First();
        var secondTestEntity = DbContext.SecondTestEntityExactlyOnes.Include(x => x.TestEntityExactlyOne).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.SecondTestEntityExactlyOne);
        Assert.NotNull(secondTestEntity.TestEntityExactlyOne);
    }
}