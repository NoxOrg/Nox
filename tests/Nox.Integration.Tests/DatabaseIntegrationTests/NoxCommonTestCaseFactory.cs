using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Nox.Integration.Tests.Fixtures;
using Nox.Types;
using System;
using System.Text.Json;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;
using DateTime = Nox.Types.DateTime;
using DayOfWeek = Nox.Types.DayOfWeek;
using Guid = Nox.Types.Guid;

namespace Nox.Integration.Tests.DatabaseIntegrationTests;

public class NoxCommonTestCaseFactory
{
    private readonly INoxTestDataContextFixture _dbContextFixture;

    public NoxCommonTestCaseFactory(INoxTestDataContextFixture dbContextFixture)
    {
        _dbContextFixture = dbContextFixture;
    }

    private AppDbContext DataContext => (AppDbContext)_dbContextFixture.DataContext;

    public void GenerateEntityCanSaveAndReadFieldsAllTypes(bool supportDateTimeOffset = true)
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
        // cultureCode
        // languageCode
        // yaml
        // uri
        // dateTimeSchedule
        // json

        // TODO: commented types

        var text = "TX";
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
        var currencyNumber = (short)970;
        var vatNumberValue = "44403198682";
        var vatNumberCountryCode2 = CountryCode.FR;
        var color = new byte[] { 255, 255, 0, 0 };
        var date = new DateOnly(2023, 7, 14);
        var time = new System.TimeOnly(11152500000);
        var fileName = "MyFile";
        var fileSizeInBytes = 1000000UL;
        var fileUrl = "https://example.com/myfile.pdf";

        using var aesAlgorithm = System.Security.Cryptography.Aes.Create();
        var encryptedTextTypeOptions = new EncryptedTextTypeOptions
        {
            PublicKey = Convert.ToBase64String(aesAlgorithm.Key),
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            Iv = Convert.ToBase64String(aesAlgorithm.IV)
        };

        var addressJsonPretty = JsonSerializer.Serialize(addressItem, new JsonSerializerOptions { WriteIndented = true });
        var addressJsonMinified = JsonSerializer.Serialize(addressItem, new JsonSerializerOptions { AllowTrailingCommas = false, WriteIndented = false });
        var year = (ushort)2023;
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
        var percentage = 0.5f;
        var latitude = 47.376934;
        var longitude = 8.541287;

        var temperatureFahrenheit = 88;
        var temperaturePersistUnitAs = TemperatureTypeUnit.Celsius;

        var length = 314_598M;
        var persistLengthUnitAs = LengthTypeUnit.Meter;
        var sampleUri = "https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName";
        var phoneNumber = "38761000000";
        var dateTime = new DateTimeOffset(2023, 4, 12, 0, 0, 0, TimeSpan.FromHours(3));

        var jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        var weight = 20.58M;
        var persistWeightUnitAs = WeightTypeUnit.Kilogram;

        var distance = 80.481727;
        var persistDistanceUnitAs = DistanceTypeUnit.Kilometer;

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
            CurrencyNumberTestField = CurrencyNumber.From(currencyNumber),
            JsonTestField = Types.Json.From(addressJsonPretty),
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
            UriTestField = Types.Uri.From(sampleUri),
            GeoCoordTestField = LatLong.From(latitude, longitude),
            DateTimeRangeTestField = DateTimeRange.From(dateTimeRangeStart, dateTimeRangeEnd),
            HtmlTestField = Html.From(html),
            ImageTestField = Image.From(imageUrl, imagePrettyName, imageSizeInBytes),
            PhoneNumberTestField = PhoneNumber.From(phoneNumber),
            DateTimeTestField = DateTime.From(dateTime),
            DateTimeScheduleTestField = DateTimeSchedule.From(cronJobExpression),
        };
        var temperatureCelsius = newItem.TemperatureTestField.ToCelsius();
        DataContext.TestEntityForTypes.Add(newItem);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityForTypes.First();

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
        testEntity.CurrencyNumberTestField!.Value.Should().Be(currencyNumber);
        testEntity.JsonTestField!.Value.Should().Be(addressJsonMinified);
        testEntity.JsonTestField!.ToString(string.Empty).Should().Be(addressJsonPretty);
        testEntity.JsonTestField!.ToString("p").Should().Be(addressJsonPretty);
        testEntity.JsonTestField!.ToString("m").Should().Be(addressJsonMinified);
        testEntity.YearTestField!.Value.Should().Be(year);
        testEntity.BooleanTestField!.Value.Should().Be(boolean);
        testEntity.EmailTestField!.Value.Should().Be(email);
        testEntity.YamlTestField!.Value.Should().BeEquivalentTo(switzerlandCitiesCountiesYaml);
        testEntity.VatNumberTestField!.Value.Number.Should().Be(vatNumberValue);
        testEntity.VatNumberTestField!.Value.CountryCode.Should().Be(vatNumberCountryCode2);
        testEntity.ColorTestField!.Value.Should().Be("#FFFF0000");
        testEntity.PercentageTestField!.Value.Should().Be(percentage);
        testEntity.YamlTestField!.Value.Should().BeEquivalentTo(Yaml.From(switzerlandCitiesCountiesYaml).Value);
        testEntity.TemperatureTestField!.Value.Should().Be(temperatureCelsius);
        testEntity.TemperatureTestField!.ToFahrenheit().Should().Be(temperatureFahrenheit);
        testEntity.TemperatureTestField!.Unit.Should().Be(temperaturePersistUnitAs);
        testEntity.EncryptedTextTestField!.DecryptText(encryptedTextTypeOptions).Should().Be(text);
        testEntity.DateTestField!.Value.Should().Be(date);
        testEntity.FileTestField!.Value.Url.Should().Be(fileUrl);
        testEntity.FileTestField!.Value.PrettyName.Should().Be(fileName);
        testEntity.FileTestField!.Value.SizeInBytes.Should().Be(fileSizeInBytes);
        testEntity.MarkdownTestField!.Value.Should().Be(text);
        testEntity.InternetDomainTestField!.Value.Should().BeEquivalentTo(internetDomain);
        testEntity.LengthTestField!.ToFeet().Should().Be(length);
        testEntity.WeightTestField!.Unit.Should().Be(persistWeightUnitAs);
        testEntity.LengthTestField!.Unit.Should().Be(persistLengthUnitAs);
        testEntity.JwtTokenTestField!.Value.Should().Be(jwtToken);
        testEntity.WeightTestField!.Unit.Should().Be(persistWeightUnitAs);
        testEntity.WeightTestField!.ToPounds().Should().Be(weight);
        testEntity.DistanceTestField!.ToMiles().Should().Be(distance);
        testEntity.DistanceTestField!.Unit.Should().Be(persistDistanceUnitAs);
        testEntity.AutoNumberTestField!.Value.Should().BeGreaterThan(0);
        testEntity.UriTestField!.Value.Should().BeEquivalentTo(new System.Uri(sampleUri));
        testEntity.GeoCoordTestField!.Latitude.Should().Be(latitude);
        testEntity.GeoCoordTestField!.Longitude.Should().Be(longitude);

        if (supportDateTimeOffset)
        {
            testEntity.DateTimeRangeTestField!.Start.Should().Be(dateTimeRangeStart);
            testEntity.DateTimeRangeTestField!.End.Should().Be(dateTimeRangeEnd);
            testEntity.DateTimeRangeTestField!.Start.ToString().Should().Be(dateTimeRangeStart.ToString());
            testEntity.DateTimeRangeTestField!.End.ToString().Should().Be(dateTimeRangeEnd.ToString());
            testEntity.DateTimeRangeTestField!.Start.Offset.Should().Be(dateTimeRangeStart.Offset);
            testEntity.DateTimeRangeTestField!.End.Offset.Should().Be(dateTimeRangeEnd.Offset);
        }
        else
        {
            testEntity.DateTimeRangeTestField!.Start.UtcDateTime.Should().Be(dateTimeRangeStart.UtcDateTime);
            testEntity.DateTimeRangeTestField!.End.UtcDateTime.Should().Be(dateTimeRangeEnd.UtcDateTime);
            testEntity.DateTimeRangeTestField!.Start.UtcDateTime.ToString().Should().Be(dateTimeRangeStart.UtcDateTime.ToString());
            testEntity.DateTimeRangeTestField!.End.UtcDateTime.ToString().Should().Be(dateTimeRangeEnd.UtcDateTime.ToString());
            testEntity.DateTimeRangeTestField!.Start.Offset.Should().Be(TimeSpan.Zero);
            testEntity.DateTimeRangeTestField!.End.Offset.Should().Be(TimeSpan.Zero);
        }

        testEntity.HtmlTestField!.Value.Should().Be(html);
        testEntity.ImageTestField!.Url.Should().Be(imageUrl);
        testEntity.ImageTestField!.PrettyName.Should().Be(imagePrettyName);
        testEntity.ImageTestField!.SizeInBytes.Should().Be(imageSizeInBytes);
        testEntity.PhoneNumberTestField!.Value.Should().Be(phoneNumber);
        testEntity.DateTimeScheduleTestField!.Value.Should().Be(cronJobExpression);
        testEntity.DateTimeTestField!.Value.Should().Be(dateTime);
    }

    public void GeneratedRelationshipZeroOrMany()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

        var newItem = new TestEntityZeroOrMany()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        DataContext.TestEntityZeroOrManies.Add(newItem);
        DataContext.SaveChanges();

        var newItem2 = new SecondTestEntityZeroOrMany()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(text),
        };

        newItem.SecondTestEntityZeroOrManyRelationship.Add(newItem2);
        DataContext.SecondTestEntityZeroOrManies.Add(newItem2);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityZeroOrManies.Include(x => x.SecondTestEntityZeroOrManyRelationship).First();
        var secondTestEntity = DataContext.SecondTestEntityZeroOrManies.Include(x => x.TestEntityZeroOrManyRelationship).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotEmpty(testEntity.SecondTestEntityZeroOrManyRelationship);
        Assert.NotEmpty(secondTestEntity.TestEntityZeroOrManyRelationship);
        Assert.Equal(testEntity.SecondTestEntityZeroOrManyRelationship[0].Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrManyRelationship[0].Id.Value, textId1);
    }

    public void GeneratedRelationshipOneOrMany()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

        var newItem = new TestEntityOneOrMany()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        DataContext.TestEntityOneOrManies.Add(newItem);
        DataContext.SaveChanges();

        var newItem2 = new SecondTestEntityOneOrMany()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(text),
        };

        newItem.SecondTestEntityOneOrManyRelationship.Add(newItem2);
        DataContext.SecondTestEntityOneOrManies.Add(newItem2);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityOneOrManies.Include(x => x.SecondTestEntityOneOrManyRelationship).First();
        var secondTestEntity = DataContext.SecondTestEntityOneOrManies.Include(x => x.TestEntityOneOrManyRelationship).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotEmpty(testEntity.SecondTestEntityOneOrManyRelationship);
        Assert.NotEmpty(secondTestEntity.TestEntityOneOrManyRelationship);
        Assert.Equal(testEntity.SecondTestEntityOneOrManyRelationship[0].Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityOneOrManyRelationship[0].Id.Value, textId1);
    }

    public void GeneratedRelationshipExactlyOne()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

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

        newItem.SecondTestEntityExactlyOneRelationshipId = newItem2.Id;
        DataContext.TestEntityExactlyOnes.Add(newItem);
        DataContext.SecondTestEntityExactlyOnes.Add(newItem2);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityExactlyOnes.Include(x => x.SecondTestEntityExactlyOneRelationship).First();
        var secondTestEntity = DataContext.SecondTestEntityExactlyOnes.Include(x => x.TestEntityExactlyOneRelationship).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.SecondTestEntityExactlyOneRelationship);
        Assert.NotNull(secondTestEntity.TestEntityExactlyOneRelationship);
        Assert.Equal(testEntity.SecondTestEntityExactlyOneRelationship.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityExactlyOneRelationship.Id.Value, textId1);
    }

    public void GeneratedRelationshipZeroOrOne()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

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

        newItem.SecondTestEntityZeroOrOneRelationshipId = newItem2.Id;
        DataContext.TestEntityZeroOrOnes.Add(newItem);
        DataContext.SecondTestEntityZeroOrOnes.Add(newItem2);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityZeroOrOnes.Include(x => x.SecondTestEntityZeroOrOneRelationship).First();
        var secondTestEntity = DataContext.SecondTestEntityZeroOrOnes.Include(x => x.TestEntityZeroOrOneRelationship).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.SecondTestEntityZeroOrOneRelationship);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrOneRelationship);
        Assert.Equal(testEntity.SecondTestEntityZeroOrOneRelationship.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrOneRelationship.Id.Value, textId1);
    }

    public void GeneratedRelationshipZeroOrOneZeroOrMany()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

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

        newItem.TestEntityZeroOrManyToZeroOrOneId = newItem2.Id;
        newItem2.TestEntityZeroOrOneToZeroOrMany.Add(newItem);
        DataContext.TestEntityZeroOrOneToZeroOrManies.Add(newItem);
        DataContext.TestEntityZeroOrManyToZeroOrOnes.Add(newItem2);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityZeroOrOneToZeroOrManies.Include(x => x.TestEntityZeroOrManyToZeroOrOne).First();
        var secondTestEntity = DataContext.TestEntityZeroOrManyToZeroOrOnes.Include(x => x.TestEntityZeroOrOneToZeroOrMany).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityZeroOrManyToZeroOrOne);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrOneToZeroOrMany);
        Assert.Equal(testEntity.TestEntityZeroOrManyToZeroOrOne.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrOneToZeroOrMany[0].Id.Value, textId1);
    }

    public void GeneratedRelationshipZeroOrOneOneOrMany()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

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

        newItem.TestEntityOneOrManyToZeroOrOneId = newItem2.Id;
        newItem2.TestEntityZeroOrOneToOneOrMany.Add(newItem);
        DataContext.TestEntityZeroOrOneToOneOrManies.Add(newItem);
        DataContext.TestEntityOneOrManyToZeroOrOnes.Add(newItem2);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityZeroOrOneToOneOrManies.Include(x => x.TestEntityOneOrManyToZeroOrOne).First();
        var secondTestEntity = DataContext.TestEntityOneOrManyToZeroOrOnes.Include(x => x.TestEntityZeroOrOneToOneOrMany).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityOneOrManyToZeroOrOne);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrOneToOneOrMany);
        Assert.Equal(testEntity.TestEntityOneOrManyToZeroOrOne.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrOneToOneOrMany[0].Id.Value, textId1);
    }

    public void GeneratedRelationshipZeroOrOneExactlyOne()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

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

        newItem2.TestEntityZeroOrOneToExactlyOneId = newItem.Id;
        DataContext.TestEntityZeroOrOneToExactlyOnes.Add(newItem);
        DataContext.TestEntityExactlyOneToZeroOrOnes.Add(newItem2);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityZeroOrOneToExactlyOnes.Include(x => x.TestEntityExactlyOneToZeroOrOne).First();
        var secondTestEntity = DataContext.TestEntityExactlyOneToZeroOrOnes.Include(x => x.TestEntityZeroOrOneToExactlyOne).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityExactlyOneToZeroOrOne);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrOneToExactlyOne);
        Assert.Equal(testEntity.TestEntityExactlyOneToZeroOrOne.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrOneToExactlyOne.Id.Value, textId1);
    }

    public void GeneratedRelationshipOneOrManyExactlyOne()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

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

        newItem.TestEntityOneOrManyToExactlyOneId = newItem2.Id;
        newItem2.TestEntityExactlyOneToOneOrMany.Add(newItem);
        DataContext.TestEntityExactlyOneToOneOrManies.Add(newItem);
        DataContext.TestEntityOneOrManyToExactlyOnes.Add(newItem2);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityExactlyOneToOneOrManies.Include(x => x.TestEntityOneOrManyToExactlyOne).First();
        var secondTestEntity = DataContext.TestEntityOneOrManyToExactlyOnes.Include(x => x.TestEntityExactlyOneToOneOrMany).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityOneOrManyToExactlyOne);
        Assert.NotNull(secondTestEntity.TestEntityExactlyOneToOneOrMany);
        Assert.Equal(testEntity.TestEntityOneOrManyToExactlyOne.Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityExactlyOneToOneOrMany[0].Id.Value, textId1);
    }

    public void GeneratedRelationshipExactlyOneZeroOrMany()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

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
        newItem2.TestEntityZeroOrManyToExactlyOneId = newItem.Id;
        DataContext.TestEntityZeroOrManyToExactlyOnes.Add(newItem);
        DataContext.TestEntityExactlyOneToZeroOrManies.Add(newItem2);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityZeroOrManyToExactlyOnes.Include(x => x.TestEntityExactlyOneToZeroOrMany).First();
        var secondTestEntity = DataContext.TestEntityExactlyOneToZeroOrManies.Include(x => x.TestEntityZeroOrManyToExactlyOne).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotNull(testEntity.TestEntityExactlyOneToZeroOrMany);
        Assert.NotNull(secondTestEntity.TestEntityZeroOrManyToExactlyOne);
        Assert.Equal(testEntity.TestEntityExactlyOneToZeroOrMany[0].Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrManyToExactlyOne.Id.Value, textId1);
    }

    public void GeneratedRelationshipZeroOrManyOneOrMany()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

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
        DataContext.TestEntityZeroOrManyToOneOrManies.Add(newItem);
        DataContext.TestEntityOneOrManyToZeroOrManies.Add(newItem2);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityZeroOrManyToOneOrManies.Include(x => x.TestEntityOneOrManyToZeroOrMany).First();
        var secondTestEntity = DataContext.TestEntityOneOrManyToZeroOrManies.Include(x => x.TestEntityZeroOrManyToOneOrMany).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotEmpty(testEntity.TestEntityOneOrManyToZeroOrMany);
        Assert.NotEmpty(secondTestEntity.TestEntityZeroOrManyToOneOrMany);
        Assert.Equal(testEntity.TestEntityOneOrManyToZeroOrMany[0].Id.Value, textId2);
        Assert.Equal(secondTestEntity.TestEntityZeroOrManyToOneOrMany[0].Id.Value, textId1);
    }

    public void GeneratedRelationshipZeroOrManyZeroOrMany()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

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

        newItem.SecondTestEntityOwnedRelationshipZeroOrMany.Add(newItem2);
        DataContext.TestEntityOwnedRelationshipZeroOrManies.Add(newItem);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityOwnedRelationshipZeroOrManies.Include(x => x.SecondTestEntityOwnedRelationshipZeroOrMany).First();
        var secondTestEntity = testEntity.SecondTestEntityOwnedRelationshipZeroOrMany[0];

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotEmpty(testEntity.SecondTestEntityOwnedRelationshipZeroOrMany);
        Assert.Equal(testEntity.SecondTestEntityOwnedRelationshipZeroOrMany[0].Id.Value, textId2);
    }

    public void GeneratedRelationshipOwnedOneOrManyOneOrMany()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

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
        DataContext.TestEntityOwnedRelationshipOneOrManies.Add(newItem);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityOwnedRelationshipOneOrManies.Include(x => x.SecondTestEntityOwnedRelationshipOneOrMany).First();
        var secondTestEntity = testEntity.SecondTestEntityOwnedRelationshipOneOrMany[0];

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(secondTestEntity.Id.Value, textId2);
        Assert.NotEmpty(testEntity.SecondTestEntityOwnedRelationshipOneOrMany);
        Assert.Equal(testEntity.SecondTestEntityOwnedRelationshipOneOrMany[0].Id.Value, textId2);
    }

    public void GeneratedRelationshipOwnedExactlyOneExactlyOne()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

        var newItem = new TestEntityOwnedRelationshipExactlyOne()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityOwnedRelationshipExactlyOne()
        {
            TextTestField2 = Text.From(textId2),
        };

        newItem.CreateRefToSecondTestEntityOwnedRelationshipExactlyOne(newItem2);
        DataContext.TestEntityOwnedRelationshipExactlyOnes.Add(newItem);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityOwnedRelationshipExactlyOnes.Include(x => x.SecondTestEntityOwnedRelationshipExactlyOne).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.NotNull(testEntity.SecondTestEntityOwnedRelationshipExactlyOne);
        Assert.Equal(testEntity.SecondTestEntityOwnedRelationshipExactlyOne.TextTestField2.Value, textId2);
    }

    public void GeneratedRelationshipOwnedZeroOrOneZeroOrOne()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";

        var newItem = new TestEntityOwnedRelationshipZeroOrOne()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityOwnedRelationshipZeroOrOne()
        {
            TextTestField2 = Text.From(textId2),
        };

        newItem.CreateRefToSecondTestEntityOwnedRelationshipZeroOrOne(newItem2);
        DataContext.TestEntityOwnedRelationshipZeroOrOnes.Add(newItem);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityOwnedRelationshipZeroOrOnes.Include(x => x.SecondTestEntityOwnedRelationshipZeroOrOne).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.NotNull(testEntity.SecondTestEntityOwnedRelationshipZeroOrOne);
        Assert.Equal(testEntity.SecondTestEntityOwnedRelationshipZeroOrOne.TextTestField2.Value, textId2);
    }

    public void UniqueConstraintsSameValueShouldThrowException()
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

        DataContext.TestEntityForUniqueConstraints.Add(testEntity1);
        DataContext.SaveChanges();

        DataContext.TestEntityForUniqueConstraints.Add(testEntityWithSameUniqueNumber);
        //save should throw exception
        Action act = () => DataContext.SaveChanges();
        act.Should().Throw<DbUpdateException>();

        DataContext.TestEntityForUniqueConstraints.Add(testEntityWithSameUniqueCountryCodeAndCurrencyCode);
        //save should throw exception
        Action act2 = () => DataContext.SaveChanges();
        act2.Should().Throw<DbUpdateException>();
    }

    public void GeneratedRelationshipTwoRelationshipsToTheSameEntityOneToOne()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";
        var textId3 = "T3";

        var newItem = new TestEntityTwoRelationshipsOneToOne()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityTwoRelationshipsOneToOne()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(textId2),
        };
        var newItem3 = new SecondTestEntityTwoRelationshipsOneToOne()
        {
            Id = Text.From(textId3),
            TextTestField2 = Text.From(textId3),
        };

        newItem.TestRelationshipOneId = newItem2.Id;
        newItem.TestRelationshipTwoId = newItem3.Id;
        DataContext.SecondTestEntityTwoRelationshipsOneToOnes.Add(newItem3);
        DataContext.SecondTestEntityTwoRelationshipsOneToOnes.Add(newItem2);
        DataContext.TestEntityTwoRelationshipsOneToOnes.Add(newItem);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityTwoRelationshipsOneToOnes.Include(x => x.TestRelationshipOne).Include(x => x.TestRelationshipTwo).First();
        var testEntity2 = DataContext.SecondTestEntityTwoRelationshipsOneToOnes.Include(x => x.TestRelationshipOneOnOtherSide).First();
        var testEntity3 = DataContext.SecondTestEntityTwoRelationshipsOneToOnes.Include(x => x.TestRelationshipTwoOnOtherSide).Skip(1).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.NotNull(testEntity.TestRelationshipOne);
        Assert.NotNull(testEntity.TestRelationshipTwo);
        Assert.Equal(testEntity2.Id.Value, textId2);
        Assert.Equal(testEntity3.Id.Value, textId3);
        Assert.NotNull(testEntity2.TestRelationshipOneOnOtherSide);
        Assert.NotNull(testEntity3.TestRelationshipTwoOnOtherSide);
        Assert.Equal(testEntity.TestRelationshipOne.Id.Value, textId2);
        Assert.Equal(testEntity.TestRelationshipTwo.Id.Value, textId3);
    }

    public void GeneratedRelationshipTwoRelationshipsToTheSameEntityManyToMany()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";
        var textId3 = "T3";

        var newItem = new TestEntityTwoRelationshipsManyToMany()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityTwoRelationshipsManyToMany()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(textId2),
        };
        var newItem3 = new SecondTestEntityTwoRelationshipsManyToMany()
        {
            Id = Text.From(textId3),
            TextTestField2 = Text.From(textId3),
        };

        newItem.TestRelationshipOne.Add(newItem2);
        newItem.TestRelationshipTwo.Add(newItem3);
        DataContext.TestEntityTwoRelationshipsManyToManies.Add(newItem);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityTwoRelationshipsManyToManies.Include(x => x.TestRelationshipOne).Include(x => x.TestRelationshipTwo).First();
        var testEntity2 = DataContext.SecondTestEntityTwoRelationshipsManyToManies.Include(x => x.TestRelationshipOneOnOtherSide).First();
        var testEntity3 = DataContext.SecondTestEntityTwoRelationshipsManyToManies.Include(x => x.TestRelationshipTwoOnOtherSide).Skip(1).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.NotNull(testEntity.TestRelationshipOne);
        Assert.NotNull(testEntity.TestRelationshipTwo);
        Assert.Equal(testEntity2.Id.Value, textId2);
        Assert.Equal(testEntity3.Id.Value, textId3);
        Assert.NotNull(testEntity2.TestRelationshipOneOnOtherSide);
        Assert.NotNull(testEntity3.TestRelationshipTwoOnOtherSide);
        Assert.Equal(testEntity.TestRelationshipOne[0].Id.Value, textId2);
        Assert.Equal(testEntity.TestRelationshipTwo[0].Id.Value, textId3);
    }

    public void GeneratedRelationshipTwoRelationshipsToTheSameEntityOneToMany()
    {
        var text = "TX";
        var textId1 = "T1";
        var textId2 = "T2";
        var textId3 = "T3";

        var newItem = new TestEntityTwoRelationshipsOneToMany()
        {
            Id = Text.From(textId1),
            TextTestField = Text.From(text),
        };
        var newItem2 = new SecondTestEntityTwoRelationshipsOneToMany()
        {
            Id = Text.From(textId2),
            TextTestField2 = Text.From(textId2),
        };
        var newItem3 = new SecondTestEntityTwoRelationshipsOneToMany()
        {
            Id = Text.From(textId3),
            TextTestField2 = Text.From(textId3),
        };

        newItem.TestRelationshipOne.Add(newItem2);
        newItem.TestRelationshipTwo.Add(newItem3);
        DataContext.TestEntityTwoRelationshipsOneToManies.Add(newItem);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityTwoRelationshipsOneToManies.Include(x => x.TestRelationshipOne).Include(x => x.TestRelationshipTwo).First();
        var testEntity2 = DataContext.SecondTestEntityTwoRelationshipsOneToManies.Include(x => x.TestRelationshipOneOnOtherSide).First();
        var testEntity3 = DataContext.SecondTestEntityTwoRelationshipsOneToManies.Include(x => x.TestRelationshipTwoOnOtherSide).Skip(1).First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.NotNull(testEntity.TestRelationshipOne);
        Assert.NotNull(testEntity.TestRelationshipTwo);
        Assert.Equal(testEntity2.Id.Value, textId2);
        Assert.Equal(testEntity3.Id.Value, textId3);
        Assert.NotNull(testEntity2.TestRelationshipOneOnOtherSide);
        Assert.NotNull(testEntity3.TestRelationshipTwoOnOtherSide);
        Assert.Equal(testEntity.TestRelationshipOne[0].Id.Value, textId2);
        Assert.Equal(testEntity.TestRelationshipTwo[0].Id.Value, textId3);
    }

    public void LocalizedEntitiesBeingGenerated()
    {
        var text = "TX";
        var textId1 = "T1";
        var culture = "en-US";

        var newItem = new TestEntityLocalizationLocalized()
        {
            Id = Text.From(textId1),
            TextFieldToLocalize = Text.From(text),
            CultureCode = CultureCode.From(culture)
        };

        DataContext.TestEntityLocalizationsLocalized.Add(newItem);
        DataContext.SaveChanges();

        // Force the recreation of DataContext and ensure we have fresh data from database
        _dbContextFixture.RefreshDbContext();

        var testEntity = DataContext.TestEntityLocalizationsLocalized.First();

        Assert.Equal(testEntity.Id.Value, textId1);
        Assert.Equal(testEntity.TextFieldToLocalize.Value, text);
        Assert.Equal(testEntity.CultureCode.Value, culture);
    }
}