using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using System.Globalization;
using System.Text.Json;
using TestWebApp.Domain;

using DayOfWeek = Nox.Types.DayOfWeek;
using Guid = Nox.Types.Guid;

namespace Nox.Integration.Tests.DatabaseIntegrationTests;

public class SqliteIntegrationTests : SqliteTestBase
{
    [Fact]
    public void GeneratedEntity_Sqlite_CanSaveAndReadFields_AllTypes()
    {
        // TODO:
        // array
        // colour
        // collection
        // entity
        // formula
        // image
        // imagePng
        // imageJpg
        // imageSvg
        // object
        // languageCode
        // yaml
        // uri
        // dateTimeSchedule
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
            CountryId = Enum.Parse<CountryCode>(countryCode2),
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
        var guid = System.Guid.NewGuid();
        var password = "Test123.";
        ushort dayOfWeek = 1;
        byte month = 7;
        var dateTimeDurationInHours = 30.5;
        var year = (ushort)2023;
        var vatNumberValue = "44403198682";
        var vatNumberCountryCode2 = CountryCode.FR;
        var color = new byte[] { 255, 255, 0, 0 };
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
        var phoneNumber = "38761000000";

        var jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        var weight = 20.58M;
        var persistWeightUnitAs = WeightTypeUnit.Kilogram;
        var databaseNumber = 1U;
        var databaseGuid = System.Guid.NewGuid();

        var distance = 80.481727;
        var persistDistanceUnitAs = DistanceTypeUnit.Kilometer;
        var latitude = 47.376934;
        var longitude = 8.541287;

        var dateTimeRangeStart = new DateTimeOffset(2023, 4, 12, 0, 0, 0, TimeSpan.FromHours(3));
        var dateTimeRangeEnd = new DateTimeOffset(2023, 7, 10, 0, 0, 0, TimeSpan.FromHours(5));
        var cronJobExpression = "0 0 12 ? * 2,3,4,5,6 *";

        var html = @"
<html>
    <body>
    Plain text
    <p> Paragraph text </p>
    </body>
</html>";

        var imageUrl = "https://example.com/image.png";
        var imagePrettyName = "Image";
        var imageSizeInBytes = 128;
        var dateTime = new DateTimeOffset(System.DateTime.Now);

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
            UserTestField = User.From(email),
            GuidTestField = Guid.From(guid),
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
            ColorTestField = Color.From(color[0], color[1], color[2], color[3]),
            PercentageTestField = Percentage.From(percentage),
            TemperatureTestField = Temperature.From(temperatureFahrenheit, new TemperatureTypeOptions() { Units = TemperatureTypeUnit.Fahrenheit, PersistAs = temperaturePersistUnitAs }),
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
            DatabaseGuidTestField = DatabaseGuid.FromDatabase(databaseGuid),
            UriTestField = Types.Uri.From(sampleUri),
            GeoCoordTestField = LatLong.From(latitude, longitude),
            DateTimeRangeTestField = DateTimeRange.From(dateTimeRangeStart, dateTimeRangeEnd),
            HtmlTestField = Html.From(html),
            ImageTestField = Image.From(imageUrl, imagePrettyName, imageSizeInBytes),
            PhoneNumberTestField = PhoneNumber.From(phoneNumber),
            DateTimeScheduleTestField = DateTimeSchedule.From(cronJobExpression),
			DateTimeTestField = Types.DateTime.From(dateTime),
        };
        var temperatureCelsius = newItem.TemperatureTestField.ToCelsius();
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
        testEntity.UserTestField!.Value.Should().Be(email);
        testEntity.GuidTestField!.Value.Should().Be(guid);
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
        testEntity.VatNumberTestField!.Value.CountryCode.Should().Be(vatNumberCountryCode2);
        testEntity.ColorTestField!.Value.Should().Be("#FFFF0000");
        testEntity.PercentageTestField!.Value.Should().Be(percentage);
        testEntity.TemperatureTestField!.Value.Should().Be(temperatureCelsius);
        testEntity.TemperatureTestField!.ToFahrenheit().Should().Be(temperatureFahrenheit);
        testEntity.TemperatureTestField!.Unit.Should().Be(temperaturePersistUnitAs);
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
        testEntity.DatabaseGuidTestField!.Value.Should().NotBe(System.Guid.Empty);
        testEntity.UriTestField!.Value.Should().BeEquivalentTo(new System.Uri(sampleUri));
        testEntity.GeoCoordTestField!.Latitude.Should().Be(latitude);
        testEntity.GeoCoordTestField!.Longitude.Should().Be(longitude);
        testEntity.DateTimeRangeTestField!.Start.Should().Be(dateTimeRangeStart);
        testEntity.DateTimeRangeTestField!.End.Should().Be(dateTimeRangeEnd);
        testEntity.DateTimeRangeTestField!.Start.UtcDateTime.Should().Be(dateTimeRangeStart.UtcDateTime);
        testEntity.DateTimeRangeTestField!.End.UtcDateTime.Should().Be(dateTimeRangeEnd.UtcDateTime);
        testEntity.DateTimeRangeTestField!.Start.Subtract(testEntity.DateTimeRangeTestField!.End)
            .Should().Be(dateTimeRangeStart.Subtract(dateTimeRangeEnd));
        testEntity.HtmlTestField!.Value.Should().Be(html);
        testEntity.ImageTestField!.Url.Should().Be(imageUrl);
        testEntity.ImageTestField!.PrettyName.Should().Be(imagePrettyName);
        testEntity.ImageTestField!.SizeInBytes.Should().Be(imageSizeInBytes);
        testEntity.PhoneNumberTestField!.Value.Should().Be(phoneNumber);
        testEntity.DateTimeScheduleTestField!.Value.Should().Be(cronJobExpression);
		testEntity.DateTimeTestField!.ToString().Should().Be(dateTime.ToString(CultureInfo.InvariantCulture));
        testEntity.DateTimeTestField!.Value.Offset.Should().Be(dateTime.Offset);
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

        newItem.SecondTestEntityZeroOrManyRelationship.Add(newItem2);
        DbContext.SecondTestEntityZeroOrManies.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityZeroOrManies.Include(x => x.SecondTestEntityZeroOrManyRelationship).First();
        var secondTestEntity = DbContext.SecondTestEntityZeroOrManies.Include(x => x.TestEntityZeroOrManyRelationship).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotEmpty(testEntity.SecondTestEntityZeroOrManyRelationship);
        Assert.NotEmpty(secondTestEntity.TestEntityZeroOrManyRelationship);
        Assert.Equal(testEntity.SecondTestEntityZeroOrManyRelationship[0].Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrManyRelationship[0].Id.Value, textId1);
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

        newItem.SecondTestEntityOneOrManyRelationship.Add(newItem2);
        DbContext.SecondTestEntityOneOrManies.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityOneOrManies.Include(x => x.SecondTestEntityOneOrManyRelationship).First();
        var secondTestEntity = DbContext.SecondTestEntityOneOrManies.Include(x => x.TestEntityOneOrManyRelationship).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotEmpty(testEntity.SecondTestEntityOneOrManyRelationship);
        Assert.NotEmpty(secondTestEntity.TestEntityOneOrManyRelationship);
        Assert.Equal(testEntity.SecondTestEntityOneOrManyRelationship[0].Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityOneOrManyRelationship[0].Id.Value, textId1);
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

        newItem.SecondTestEntityExactlyOneRelationship = newItem2;
        newItem2.TestEntityExactlyOneRelationship = newItem;
        DbContext.TestEntityExactlyOnes.Add(newItem);
        DbContext.SecondTestEntityExactlyOnes.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityExactlyOnes.Include(x => x.SecondTestEntityExactlyOneRelationship).First();
        var secondTestEntity = DbContext.SecondTestEntityExactlyOnes.Include(x => x.TestEntityExactlyOneRelationship).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.SecondTestEntityExactlyOneRelationship);
        Assert.NotNull(secondTestEntity.TestEntityExactlyOneRelationship);
        Assert.Equal(testEntity.SecondTestEntityExactlyOneRelationship.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityExactlyOneRelationship.Id.Value, textId1);
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

        newItem.SecondTestEntityZeroOrOneRelationship = newItem2;
        newItem2.TestEntityZeroOrOneRelationship = newItem;
        DbContext.TestEntityZeroOrOnes.Add(newItem);
        DbContext.SecondTestEntityZeroOrOnes.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityZeroOrOnes.Include(x => x.SecondTestEntityZeroOrOneRelationship).First();
        var secondTestEntity = DbContext.SecondTestEntityZeroOrOnes.Include(x => x.TestEntityZeroOrOneRelationship).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.SecondTestEntityZeroOrOneRelationship);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrOneRelationship);
        Assert.Equal(testEntity.SecondTestEntityZeroOrOneRelationship.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrOneRelationship.Id.Value, textId1);
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
        var secondTestEntity = DbContext.TestEntityZeroOrManyToZeroOrOnes.Include(x => x.TestEntityZeroOrOneToZeroOrMany).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityZeroOrManyToZeroOrOne);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrOneToZeroOrMany);
        Assert.Equal(testEntity.TestEntityZeroOrManyToZeroOrOne.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrOneToZeroOrMany[0].Id.Value, textId1);
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
        newItem2.TestEntityZeroOrOneToOneOrMany.Add(newItem);
        DbContext.TestEntityZeroOrOneToOneOrManies.Add(newItem);
        DbContext.TestEntityOneOrManyToZeroOrOnes.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityZeroOrOneToOneOrManies.Include(x => x.TestEntityOneOrManyToZeroOrOne).First();
        var secondTestEntity = DbContext.TestEntityOneOrManyToZeroOrOnes.Include(x => x.TestEntityZeroOrOneToOneOrMany).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityOneOrManyToZeroOrOne);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrOneToOneOrMany);
        Assert.Equal(testEntity.TestEntityOneOrManyToZeroOrOne.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrOneToOneOrMany[0].Id.Value, textId1);
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
        newItem2.TestEntityExactlyOneToOneOrMany.Add(newItem);
        DbContext.TestEntityExactlyOneToOneOrManies.Add(newItem);
        DbContext.TestEntityOneOrManyToExactlyOnes.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityExactlyOneToOneOrManies.Include(x => x.TestEntityOneOrManyToExactlyOne).First();
        var secondTestEntity = DbContext.TestEntityOneOrManyToExactlyOnes.Include(x => x.TestEntityExactlyOneToOneOrMany).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityOneOrManyToExactlyOne);
        Assert.NotNull(secondTestEntity.TestEntityExactlyOneToOneOrMany);
        Assert.Equal(testEntity.TestEntityOneOrManyToExactlyOne.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityExactlyOneToOneOrMany[0].Id.Value, textId1);
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

        newItem.TestEntityExactlyOneToZeroOrMany.Add(newItem2);
        newItem2.TestEntityZeroOrManyToExactlyOne = newItem;
        DbContext.TestEntityZeroOrManyToExactlyOnes.Add(newItem);
        DbContext.TestEntityExactlyOneToZeroOrManies.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityZeroOrManyToExactlyOnes.Include(x => x.TestEntityExactlyOneToZeroOrMany).First();
        var secondTestEntity = DbContext.TestEntityExactlyOneToZeroOrManies.Include(x => x.TestEntityZeroOrManyToExactlyOne).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityExactlyOneToZeroOrMany);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrManyToExactlyOne);
        Assert.Equal(testEntity.TestEntityExactlyOneToZeroOrMany[0].Id.Value, textId2);
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

        newItem.TestEntityOneOrManyToZeroOrMany.Add(newItem2);
        newItem2.TestEntityZeroOrManyToOneOrMany.Add(newItem);
        DbContext.TestEntityZeroOrManyToOneOrManies.Add(newItem);
        DbContext.TestEntityOneOrManyToZeroOrManies.Add(newItem2);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityZeroOrManyToOneOrManies.Include(x => x.TestEntityOneOrManyToZeroOrMany).First();
        var secondTestEntity = DbContext.TestEntityOneOrManyToZeroOrManies.Include(x => x.TestEntityZeroOrManyToOneOrMany).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotEmpty(testEntity.TestEntityOneOrManyToZeroOrMany);
        Assert.NotEmpty(secondTestEntity.TestEntityZeroOrManyToOneOrMany);
        Assert.Equal(testEntity.TestEntityOneOrManyToZeroOrMany[0].Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrManyToOneOrMany[0].Id.Value, textId1);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_Owned_ZeroOrMany_ZeroOrMany()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var textId2 = "TestTextValue2";

        var newItem = new TestEntityOwnedRelationshipZeroOrMany()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityOwnedRelationshipZeroOrMany()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(text),
        };

        newItem.SecondTestEntityOwnedRelationshipZeroOrManies.Add(newItem2);
        DbContext.TestEntityOwnedRelationshipZeroOrManies.Add(newItem);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityOwnedRelationshipZeroOrManies.Include(x => x.SecondTestEntityOwnedRelationshipZeroOrManies).First();
        var secondTestEntity = testEntity.SecondTestEntityOwnedRelationshipZeroOrManies[0];

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotEmpty(testEntity.SecondTestEntityOwnedRelationshipZeroOrManies);
        Assert.Equal(testEntity.SecondTestEntityOwnedRelationshipZeroOrManies[0].Id.Value, textId2);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_Owned_OneOrMany_OneOrMany()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var textId2 = "TestTextValue2";

        var newItem = new TestEntityOwnedRelationshipOneOrMany()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityOwnedRelationshipOneOrMany()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(text),
        };

        newItem.SecondTestEntityOwnedRelationshipOneOrMany.Add(newItem2);
        DbContext.TestEntityOwnedRelationshipOneOrManies.Add(newItem);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityOwnedRelationshipOneOrManies.Include(x => x.SecondTestEntityOwnedRelationshipOneOrManies).First();
        var secondTestEntity = testEntity.SecondTestEntityOwnedRelationshipOneOrManies[0];

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotEmpty(testEntity.SecondTestEntityOwnedRelationshipOneOrManies);
        Assert.Equal(testEntity.SecondTestEntityOwnedRelationshipOneOrManies[0].Id.Value, textId2);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_Owned_ExactlyOne_ExactlyOne()
    {
        var text = "TestTextValue";
        var text2 = "TestTextValue2";
        var textId1 = "TestTextValue1";

        var newItem = new TestEntityOwnedRelationshipExactlyOne()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityOwnedRelationshipExactlyOne()
        {
            TextTestField2 = Text.From(text2),
        };

        newItem.SecondTestEntityOwnedRelationshipExactlyOne = newItem2;
        DbContext.TestEntityOwnedRelationshipExactlyOnes.Add(newItem);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityOwnedRelationshipExactlyOnes.Include(x => x.SecondTestEntityOwnedRelationshipExactlyOne).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.NotNull(testEntity.SecondTestEntityOwnedRelationshipExactlyOne);
        Assert.Equal(testEntity.SecondTestEntityOwnedRelationshipExactlyOne.TextTestField2.Value, text2);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_Owned_ZeroOrOne_ZeroOrOne()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var text2 = "TestTextValue2";

        var newItem = new TestEntityOwnedRelationshipZeroOrOne()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityOwnedRelationshipZeroOrOne()
        {
            TextTestField2 = Text.From(text2),
        };

        newItem.SecondTestEntityOwnedRelationshipZeroOrOne = newItem2;
        DbContext.TestEntityOwnedRelationshipZeroOrOnes.Add(newItem);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityOwnedRelationshipZeroOrOnes.Include(x => x.SecondTestEntityOwnedRelationshipZeroOrOne).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.NotNull(testEntity.SecondTestEntityOwnedRelationshipZeroOrOne);
        Assert.Equal(testEntity.SecondTestEntityOwnedRelationshipZeroOrOne.TextTestField2.Value, text2);
    }
<<<<<<< HEAD
    
    [Fact]
    public void UniqueConstraints_SameValue_ShouldThrowException()
    {
        const string countryCode2 = "UA";
        const string secondCountryCode2 = "TR";
        const string thirdCountryCode2 = "DE";
        const string currencyCode3 = "USD";
        const string secondCurrencyCode3 = "TRY";
        const int number = 123;
        const int secondNumber = 456;
        var testEntity1 = new TestEntityForUniqueConstraints()
        {
            Id = Text.From(countryCode2),
            TextField = Text.From("TestTextValue"),
            NumberField = Number.From(123),
            UniqueNumberField = Number.From(number),
            UniqueCountryCode = CountryCode2.From(countryCode2),
            UniqueCurrencyCode = CurrencyCode3.From(currencyCode3),
        };
        
        var testEntityWithSameUniqueNumber = new TestEntityForUniqueConstraints()
        {
            Id = Text.From(secondCountryCode2),
            TextField = Text.From("TestTextValue"),
            NumberField = Number.From(123),
            UniqueNumberField = Number.From(number),
            UniqueCountryCode = CountryCode2.From(secondCountryCode2),
            UniqueCurrencyCode = CurrencyCode3.From(secondCurrencyCode3),
        };
        
        var testEntityWithSameUniqueCountryCodeAndCurrencyCode = new TestEntityForUniqueConstraints()
        {
            Id = Text.From(thirdCountryCode2),
            TextField = Text.From("TestTextValue"),
            NumberField = Number.From(123),
            UniqueNumberField = Number.From(secondNumber),
            UniqueCountryCode = CountryCode2.From(countryCode2),
            UniqueCurrencyCode = CurrencyCode3.From(currencyCode3),
        };
        
        DbContext.TestEntityForUniqueConstraints.Add(testEntity1);
        DbContext.SaveChanges();
        
        DbContext.TestEntityForUniqueConstraints.Add(testEntityWithSameUniqueNumber);
        //save should throw exception
        Action act = () => DbContext.SaveChanges();
        act.Should().Throw<DbUpdateException>();
        
        
        DbContext.TestEntityForUniqueConstraints.Add(testEntityWithSameUniqueCountryCodeAndCurrencyCode);
        //save should throw exception
        Action act2 = () => DbContext.SaveChanges();
        act2.Should().Throw<DbUpdateException>();
=======

    [Fact]
    public void GeneratedRelationship_Sqlite_TwoRelationshipsToTheSameEntityOneToOne()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var text2 = "TestTextValue2";
        var text3 = "TestTextValue3";

        var newItem = new TestEntityTwoRelationshipsOneToOne()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityTwoRelationshipsOneToOne()
        {
            Id = Text.From(text2),
            TextTestField2 = Text.From(text2),
        };
        var newItem3 = new SecondTestEntityTwoRelationshipsOneToOne()
        {
            Id = Text.From(text3),
            TextTestField2 = Text.From(text3),
        };

        newItem.TestRelationshipOne = newItem2;
        newItem.TestRelationshipTwo = newItem3;
        DbContext.TestEntityTwoRelationshipsOneToOnes.Add(newItem);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityTwoRelationshipsOneToOnes.Include(x => x.TestRelationshipOne).Include(x => x.TestRelationshipTwo).First();
        var testEntity2 = DbContext.SecondTestEntityTwoRelationshipsOneToOnes.Include(x => x.TestRelationshipOneOnOtherSide).First();
        var testEntity3 = DbContext.SecondTestEntityTwoRelationshipsOneToOnes.Include(x => x.TestRelationshipTwoOnOtherSide).Skip(1).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.NotNull(testEntity.TestRelationshipOne);
        Assert.NotNull(testEntity.TestRelationshipTwo);
        Assert.Equal(testEntity2.Id.Value, text2);
        Assert.Equal(testEntity3.Id.Value, text3);
        Assert.NotNull(testEntity2.TestRelationshipOneOnOtherSide);
        Assert.NotNull(testEntity3.TestRelationshipTwoOnOtherSide);
        Assert.Equal(testEntity.TestRelationshipOne.Id.Value, text2);
        Assert.Equal(testEntity.TestRelationshipTwo.Id.Value, text3);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_TwoRelationshipsToTheSameEntityManyToMany()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var text2 = "TestTextValue2";
        var text3 = "TestTextValue3";

        var newItem = new TestEntityTwoRelationshipsManyToMany()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityTwoRelationshipsManyToMany()
        {
            Id = Text.From(text2),
            TextTestField2 = Text.From(text2),
        };
        var newItem3 = new SecondTestEntityTwoRelationshipsManyToMany()
        {
            Id = Text.From(text3),
            TextTestField2 = Text.From(text3),
        };

        newItem.TestRelationshipOne.Add(newItem2);
        newItem.TestRelationshipTwo.Add(newItem3);
        DbContext.TestEntityTwoRelationshipsManyToManies.Add(newItem);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityTwoRelationshipsManyToManies.Include(x => x.TestRelationshipOne).Include(x => x.TestRelationshipTwo).First();
        var testEntity2 = DbContext.SecondTestEntityTwoRelationshipsManyToManies.Include(x => x.TestRelationshipOneOnOtherSide).First();
        var testEntity3 = DbContext.SecondTestEntityTwoRelationshipsManyToManies.Include(x => x.TestRelationshipTwoOnOtherSide).Skip(1).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.NotNull(testEntity.TestRelationshipOne);
        Assert.NotNull(testEntity.TestRelationshipTwo);
        Assert.Equal(testEntity2.Id.Value, text2);
        Assert.Equal(testEntity3.Id.Value, text3);
        Assert.NotNull(testEntity2.TestRelationshipOneOnOtherSide);
        Assert.NotNull(testEntity3.TestRelationshipTwoOnOtherSide);
        Assert.Equal(testEntity.TestRelationshipOne[0].Id.Value, text2);
        Assert.Equal(testEntity.TestRelationshipTwo[0].Id.Value, text3);
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_TwoRelationshipsToTheSameEntityOneToMany()
    {
        var text = "TestTextValue";
        var textId1 = "TestTextValue1";
        var text2 = "TestTextValue2";
        var text3 = "TestTextValue3";

        var newItem = new TestEntityTwoRelationshipsOneToMany()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityTwoRelationshipsOneToMany()
        {
            Id = Text.From(text2),
            TextTestField2 = Text.From(text2),
        };
        var newItem3 = new SecondTestEntityTwoRelationshipsOneToMany()
        {
            Id = Text.From(text3),
            TextTestField2 = Text.From(text3),
        };

        newItem.TestRelationshipOne.Add(newItem2);
        newItem.TestRelationshipTwo.Add(newItem3);
        DbContext.TestEntityTwoRelationshipsOneToManies.Add(newItem);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityTwoRelationshipsOneToManies.Include(x => x.TestRelationshipOne).Include(x => x.TestRelationshipTwo).First();
        var testEntity2 = DbContext.SecondTestEntityTwoRelationshipsOneToManies.Include(x => x.TestRelationshipOneOnOtherSide).First();
        var testEntity3 = DbContext.SecondTestEntityTwoRelationshipsOneToManies.Include(x => x.TestRelationshipTwoOnOtherSide).Skip(1).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.NotNull(testEntity.TestRelationshipOne);
        Assert.NotNull(testEntity.TestRelationshipTwo);
        Assert.Equal(testEntity2.Id.Value, text2);
        Assert.Equal(testEntity3.Id.Value, text3);
        Assert.NotNull(testEntity2.TestRelationshipOneOnOtherSide);
        Assert.NotNull(testEntity3.TestRelationshipTwoOnOtherSide);
        Assert.Equal(testEntity.TestRelationshipOne[0].Id.Value, text2);
        Assert.Equal(testEntity.TestRelationshipTwo[0].Id.Value, text3);
>>>>>>> main
    }
}