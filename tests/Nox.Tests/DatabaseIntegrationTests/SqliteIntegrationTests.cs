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
        var area = 198_090M;
        var persistAreaUnitAs = AreaTypeUnit.SquareMeter;
        var volume = 198d;
        var persistVolumeUnitAs = VolumeTypeUnit.CubicMeter;
        var cultureCode = "de-CH";
        var macAddress = "A1B2C3D4E5F6";
        var url = "http://example.com/";
        var password = "Test123.";
        var dayOfWeek = 1;
        byte month = 7;
        var dateTimeDurationInHours = 30.5;
        var year = (ushort)2023;
        var vatNumberValue = "44403198682";
        var vatNumberCountryCode2 = CountryCode2.From("FR");
        var color = new byte[] { 1, 2, 3, 4 };
        var date = new DateOnly(2023, 7, 14);
        var time = new System.TimeOnly(11152500000);
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
        var sampleUri = "https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName";

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
        var latitude = 47.376934;
        var longitude = 8.541287;

        var dateTimeRangeStart = new DateTimeOffset(2023, 4, 12, 0, 0, 0, TimeSpan.FromHours(3));
        var dateTimeRangeEnd = new DateTimeOffset(2023, 7, 10, 0, 0, 0, TimeSpan.FromHours(5));

        var newItem = new TestEntityForTypes()
        {
            Id = Text.From(countryCode2),
            TextTestField = Text.From(text),
            NumberTestField = Number.From(number),
            MoneyTestField = Money.From(money, currencyCode),
            CountryCode2TestField = CountryCode2.From(countryCode2),
            AreaTestField = Area.From(area, new AreaTypeOptions() { Units = AreaTypeUnit.SquareFoot, PersistAs = persistAreaUnitAs }),
            VolumeTestField = Volume.From(volume, new VolumeTypeOptions { Unit = VolumeTypeUnit.CubicMeter, PersistAs = persistVolumeUnitAs }),
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
            UrlTestField = Url.From(url),
            HashedTextTestField = HashedText.From(text),
            PasswordTestField = Password.From(password),
            DayOfWeekTestField = DayOfWeek.From(1),
            MonthTestField = Month.From(month),
            DateTimeDurationTestField = DateTimeDuration.FromHours(dateTimeDurationInHours),
            TimeTestField = Time.From(time.Ticks),
            CurrencyNumberTestField = CurrencyNumber.From(970),
            JsonTestField = Json.From(addressJsonPretty),
            YearTestField = Year.From(year),
            BooleanTestField = Types.Boolean.From(boolean),
            EmailTestField = Email.From(email),
            YamlTestField = Yaml.From(switzerlandCitiesCountiesYaml),
            VatNumberTestField = VatNumber.From(vatNumberValue, vatNumberCountryCode2),
            ColorTestField = Color.From(color),
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
            UriTestField = Types.Uri.From(sampleUri),
            GeoCoordTestField = LatLong.From(latitude, longitude),
            DateTimeRangeTestField = DateTimeRange.From(dateTimeRangeStart, dateTimeRangeEnd),
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
        testEntity.VolumeTestField!.ToCubicMeters().Should().Be(volume);
        testEntity.VolumeTestField!.Unit.Should().Be(persistVolumeUnitAs);
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
        testEntity.UrlTestField!.Value.AbsoluteUri.Should().Be(url);
        testEntity.HashedTextTestField!.HashText.Should().Be(newItem.HashedTextTestField?.HashText);
        testEntity.HashedTextTestField!.Salt.Should().Be(newItem.HashedTextTestField?.Salt);
        testEntity.PasswordTestField!.HashedPassword.Should().Be(newItem.PasswordTestField.HashedPassword);
        testEntity.PasswordTestField!.Salt.Should().Be(newItem.PasswordTestField.Salt);
        testEntity.DayOfWeekTestField!.Value.Should().Be(dayOfWeek);
        testEntity.MonthTestField!.Value.Should().Be(month);
        testEntity.DateTimeDurationTestField!.TotalHours.Should().Be(dateTimeDurationInHours);
        testEntity.TimeTestField!.ToString("hh:mm").Should().Be(time.ToString("hh:mm"));
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
        testEntity.ColorTestField!.Value.Should().Equal(color);
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
        testEntity.UriTestField!.Value.Should().BeEquivalentTo(new System.Uri(sampleUri));
        testEntity.GeoCoordTestField!.Latitude.Should().Be(latitude);
        testEntity.GeoCoordTestField!.Longitude.Should().Be(longitude);
        testEntity.DateTimeRangeTestField!.Start.Should().Be(dateTimeRangeStart);
        testEntity.DateTimeRangeTestField!.End.Should().Be(dateTimeRangeEnd);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ZeroOrMany_ZeroOrMany()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var textId2 = "TestTextValue2";

        var newItem = new TestEntityZeroOrMany()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        DbContext.TestEntityZeroOrManies.Add(newItem);
        DbContext.SaveChanges();

        var newItem2 = new SecondTestEntityZeroOrMany()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(text),
        };

        newItem.SecondTestEntityZeroOrManies.Add(newItem2);
        DbContext.SecondTestEntityZeroOrManies.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityZeroOrManies.Include(x => x.SecondTestEntityZeroOrManies).First();
        var secondTestEntity = DbContext.SecondTestEntityZeroOrManies.Include(x => x.TestEntityZeroOrManies).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotEmpty(testEntity.SecondTestEntityZeroOrManies);
        Assert.NotEmpty(secondTestEntity.TestEntityZeroOrManies);
        Assert.Equal(testEntity.SecondTestEntityZeroOrManies[0].Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrManies[0].Id.Value, textId1);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_OneOrMany_OneOrMany()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var textId2 = "TestTextValue2";

        var newItem = new TestEntityOneOrMany()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        DbContext.TestEntityOneOrManies.Add(newItem);
        DbContext.SaveChanges();

        var newItem2 = new SecondTestEntityOneOrMany()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(text),
        };

        newItem.SecondTestEntityOneOrManies.Add(newItem2);
        DbContext.SecondTestEntityOneOrManies.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityOneOrManies.Include(x => x.SecondTestEntityOneOrManies).First();
        var secondTestEntity = DbContext.SecondTestEntityOneOrManies.Include(x => x.TestEntityOneOrManies).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotEmpty(testEntity.SecondTestEntityOneOrManies);
        Assert.NotEmpty(secondTestEntity.TestEntityOneOrManies);
        Assert.Equal(testEntity.SecondTestEntityOneOrManies[0].Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityOneOrManies[0].Id.Value, textId1);
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
        Assert.Equal(testEntity.SecondTestEntityExactlyOne.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityExactlyOne.Id.Value, textId1);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ZeroOrOne_ZeroOrOne()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var textId2 = "TestTextValue2";

        var newItem = new TestEntityZeroOrOne()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityZeroOrOne()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(text),
        };

        newItem.SecondTestEntityZeroOrOne = newItem2;
        newItem2.TestEntityZeroOrOne = newItem;
        DbContext.TestEntityZeroOrOnes.Add(newItem);
        DbContext.SecondTestEntityZeroOrOnes.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityZeroOrOnes.Include(x => x.SecondTestEntityZeroOrOne).First();
        var secondTestEntity = DbContext.SecondTestEntityZeroOrOnes.Include(x => x.TestEntityZeroOrOne).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.SecondTestEntityZeroOrOne);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrOne);
        Assert.Equal(testEntity.SecondTestEntityZeroOrOne.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrOne.Id.Value, textId1);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ZeroOrOne_ZeroOrMany()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var textId2 = "TestTextValue2";

        var newItem = new TestEntityZeroOrOneToZeroOrMany()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new TestEntityZeroOrManyToZeroOrOne()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(text),
        };

        newItem.TestEntityZeroOrManyToZeroOrOne = newItem2;
        newItem2.TestEntityZeroOrOneToZeroOrMany.Add(newItem);
        DbContext.TestEntityZeroOrOneToZeroOrManies.Add(newItem);
        DbContext.TestEntityZeroOrManyToZeroOrOnes.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityZeroOrOneToZeroOrManies.Include(x => x.TestEntityZeroOrManyToZeroOrOne).First();
        var secondTestEntity = DbContext.TestEntityZeroOrManyToZeroOrOnes.Include(x => x.TestEntityZeroOrOneToZeroOrManies).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityZeroOrManyToZeroOrOne);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrOneToZeroOrManies);
        Assert.Equal(testEntity.TestEntityZeroOrManyToZeroOrOne.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrOneToZeroOrManies[0].Id.Value, textId1);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ZeroOrOne_OneOrMany()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var textId2 = "TestTextValue2";

        var newItem = new TestEntityZeroOrOneToOneOrMany()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new TestEntityOneOrManyToZeroOrOne()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(text),
        };

        newItem.TestEntityOneOrManyToZeroOrOne = newItem2;
        newItem2.TestEntityZeroOrOneToOneOrManies.Add(newItem);
        DbContext.TestEntityZeroOrOneToOneOrManies.Add(newItem);
        DbContext.TestEntityOneOrManyToZeroOrOnes.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityZeroOrOneToOneOrManies.Include(x => x.TestEntityOneOrManyToZeroOrOne).First();
        var secondTestEntity = DbContext.TestEntityOneOrManyToZeroOrOnes.Include(x => x.TestEntityZeroOrOneToOneOrManies).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityOneOrManyToZeroOrOne);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrOneToOneOrManies);
        Assert.Equal(testEntity.TestEntityOneOrManyToZeroOrOne.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrOneToOneOrManies[0].Id.Value, textId1);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ZeroOrOne_ExactlyOne()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var textId2 = "TestTextValue2";

        var newItem = new TestEntityZeroOrOneToExactlyOne()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new TestEntityExactlyOneToZeroOrOne()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(text),
        };

        newItem.TestEntityExactlyOneToZeroOrOne = newItem2;
        newItem2.TestEntityZeroOrOneToExactlyOne = newItem;
        DbContext.TestEntityZeroOrOneToExactlyOnes.Add(newItem);
        DbContext.TestEntityExactlyOneToZeroOrOnes.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityZeroOrOneToExactlyOnes.Include(x => x.TestEntityExactlyOneToZeroOrOne).First();
        var secondTestEntity = DbContext.TestEntityExactlyOneToZeroOrOnes.Include(x => x.TestEntityZeroOrOneToExactlyOne).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityExactlyOneToZeroOrOne);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrOneToExactlyOne);
        Assert.Equal(testEntity.TestEntityExactlyOneToZeroOrOne.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrOneToExactlyOne.Id.Value, textId1);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_OneOrMany_ExactlyOne()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var textId2 = "TestTextValue2";

        var newItem = new TestEntityExactlyOneToOneOrMany()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new TestEntityOneOrManyToExactlyOne()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(text),
        };

        newItem.TestEntityOneOrManyToExactlyOne = newItem2;
        newItem2.TestEntityExactlyOneToOneOrManies.Add(newItem);
        DbContext.TestEntityExactlyOneToOneOrManies.Add(newItem);
        DbContext.TestEntityOneOrManyToExactlyOnes.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityExactlyOneToOneOrManies.Include(x => x.TestEntityOneOrManyToExactlyOne).First();
        var secondTestEntity = DbContext.TestEntityOneOrManyToExactlyOnes.Include(x => x.TestEntityExactlyOneToOneOrManies).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityOneOrManyToExactlyOne);
        Assert.NotNull(secondTestEntity.TestEntityExactlyOneToOneOrManies);
        Assert.Equal(testEntity.TestEntityOneOrManyToExactlyOne.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityExactlyOneToOneOrManies[0].Id.Value, textId1);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ExactlyOne_ZeroOrMany()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var textId2 = "TestTextValue2";

        var newItem2 = new TestEntityExactlyOneToZeroOrMany()
        {
            Id = Text.From(textId2),
            TextTestField = Text.From(text),
        };
        var newItem = new TestEntityZeroOrManyToExactlyOne()
        {
            Id = Text.From(textId1),
            TextTestField2 = Text.From(text),
        };

        newItem.TestEntityExactlyOneToZeroOrManies.Add(newItem2);
        newItem2.TestEntityZeroOrManyToExactlyOne = newItem;
        DbContext.TestEntityZeroOrManyToExactlyOnes.Add(newItem);
        DbContext.TestEntityExactlyOneToZeroOrManies.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityZeroOrManyToExactlyOnes.Include(x => x.TestEntityExactlyOneToZeroOrManies).First();
        var secondTestEntity = DbContext.TestEntityExactlyOneToZeroOrManies.Include(x => x.TestEntityZeroOrManyToExactlyOne).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityExactlyOneToZeroOrManies);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrManyToExactlyOne);
        Assert.Equal(testEntity.TestEntityExactlyOneToZeroOrManies[0].Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrManyToExactlyOne.Id.Value, textId1);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ZeroOrMany_OneOrMany()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var textId2 = "TestTextValue2";

        var newItem = new TestEntityZeroOrManyToOneOrMany()
        {
            Id = Text.From(textId1),
            TextTestField2 = Text.From(text),
        };

        var newItem2 = new TestEntityOneOrManyToZeroOrMany()
        {
            Id = Text.From(textId2),
            TextTestField = Text.From(text),
        };

        newItem.TestEntityOneOrManyToZeroOrManies.Add(newItem2);
        newItem2.TestEntityZeroOrManyToOneOrManies.Add(newItem);
        DbContext.TestEntityZeroOrManyToOneOrManies.Add(newItem);
        DbContext.TestEntityOneOrManyToZeroOrManies.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityZeroOrManyToOneOrManies.Include(x => x.TestEntityOneOrManyToZeroOrManies).First();
        var secondTestEntity = DbContext.TestEntityOneOrManyToZeroOrManies.Include(x => x.TestEntityZeroOrManyToOneOrManies).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotEmpty(testEntity.TestEntityOneOrManyToZeroOrManies);
        Assert.NotEmpty(secondTestEntity.TestEntityZeroOrManyToOneOrManies);
        Assert.Equal(testEntity.TestEntityOneOrManyToZeroOrManies[0].Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrManyToOneOrManies[0].Id.Value, textId1);
    }
}