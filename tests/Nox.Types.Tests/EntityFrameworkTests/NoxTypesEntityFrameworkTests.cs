using FluentAssertions;
using System.Text.Json;
using System.Security.Cryptography;

namespace Nox.Types.Tests.EntityFrameworkTests;

public class NoxTypesEntityFrameworkTests : TestWithSqlite
{
    private const string Sample_Uri = "https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName";
    private const string Sample_Url = "https://www.myregus.com/";
    private readonly (string NuidStringValue, uint NuidValue) NuidDefinition = ("PropertyNamesWithSeparator", 3697780159);
    private const string SwitzerlandCitiesCountiesYaml = @"
- Zurich:
    - County: Zurich
    - County: Winterthur
    - County: Baden
- Geneva:
    - County: Geneva
    - County: Lausanne
- Bern:
    - County: Bern
    - County: Thun
- Basel:
    - County: Basel-City
    - County: Basel-Landschaft
- Lausanne:
    - County: Vaud
- Lucerne:
    - County: Lucerne
- St. Gallen:
    - County: St. Gallen
- Lugano:
    - County: Ticino
";

    [Fact]
    public async Task DatabaseIsAvailableAndCanBeConnectedTo()
    {
        (await DbContext.Database.CanConnectAsync()).Should().BeTrue();
    }

    [Fact]
    public void TableShouldGetCreated()
    {
        DbContext.Countries!.Any().Should().BeFalse();
    }

    [Fact]
    public void Countries_CanRead_LatLong()
    {
        double latitude = 46.802496;
        double longitude = 8.234392;
        var streetAddress = CreateStreetAddress();
        using var aesAlg = Aes.Create();
        var encryptTypeOptions = new EncryptedTextTypeOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = Convert.ToBase64String(aesAlg.Key),
            Iv = Convert.ToBase64String(aesAlg.IV)
        };

        var newItem = new Country()
        {
            Name = Text.From("Switzerland"),
            LatLong = LatLong.From(latitude, longitude),
            Population = Number.From(8_703_654),
            GrossDomesticProduct = Money.From(300, CurrencyCode.CHF),
            CountryCode2 = CountryCode2.From("CH"),
            AreaInSqKm = Area.From(41_290_000),
            CultureCode = CultureCode.From("de-CH"),
            CountryNumber = CountryNumber.From(756),
            MonthOfPeakTourism = Month.From(7),
            DistanceInKm = Distance.From(129.522785),
            InternetDomain = InternetDomain.From("admin.ch"),
            CountryCode3 = CountryCode3.From("CHE"),
            IPAddress = IpAddress.From("102.129.143.255"),
            DateTimeRange = DateTimeRange.From(new DateTimeOffset(2023, 01, 01, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2023, 02, 01, 0, 0, 0, TimeSpan.Zero)),
            LongestHikingTrailInMeters = Length.From(390_000),
            MACAddress = MacAddress.From("AE-D4-32-2C-CF-EF"),
            Flag = Image.From("https://upload.wikimedia.org/wikipedia/commons/thumb/f/f3/Flag_of_Switzerland.svg/320px-Flag_of_Switzerland.svg.png", "Switzerland Flag", 512),
            Date = Date.From(new DateOnly(2023, 11, 25), new()),
            StreetAddress = streetAddress,
            StreetAddressJson = Json.From(JsonSerializer.Serialize(streetAddress)),
            LocalTimeZone = TimeZoneCode.From("CET"),
            Uri = Uri.From(Sample_Uri),
            Url = Url.From(Sample_Url),
            IsLandLocked = Boolean.From(false),
            DateTimeDuration = DateTimeDuration.From(days: 10, 5, 2, 1),
            VolumeInCubicMeters = Volume.From(89_000, VolumeTypeUnit.CubicMeter),
            WeightInKilograms = Weight.From(19_000, WeightTypeUnit.Kilogram),
            Nuid = Nuid.From(NuidDefinition.NuidStringValue),
            HashedText = HashedText.From("Test123."),
            ArabicName = TranslatedText.From((CultureCode.From("ar-SA"), "سوئٹزرلینڈ")),
            CurrentTime = Time.From(07,55,33,250),
            Description = Markdown.From("This a **big country**."),
            PageHtml = Html.From("<html><body>Switzerland Website</body></html>"),
            CitiesCounties = Yaml.From(SwitzerlandCitiesCountiesYaml),
            File = File.From("https://example.com/myfile.pdf", "MyFile", 512),
            PhoneNumber = PhoneNumber.From("+41 848 700 700"),
            GuidUser = User.From(Guid.NewGuid().ToString()),
            EmailUser = User.From("user@iwgplc.ch"),
            StringUser = User.From("stringUser", new UserTypeOptions { ValidEmailFormat=false, ValidGuidFormat= false}),
            InfoEmail = Email.From("info@iwgplc.ch"),
            SecretPassword = EncryptedText.FromPlainText("12345678", encryptTypeOptions),
            AutoId = AutoNumber.FromDatabase(10U),
            Guid = Guid.From(System.Guid.NewGuid()),
            Password = Password.From("Test123."),
            CurrencyNumber = CurrencyNumber.From(999),
            Color = Color.From(255,255,255,0),
            DayOfWeek = DayOfWeek.From(1),
            DateTimeSchedule = DateTimeSchedule.From("0 0 12 ? * 2,3,4,5,6 *"),
        };
        DbContext.Countries!.Add(newItem);
        DbContext.SaveChanges();

        //Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var country = DbContext.Countries?.First();

        country!.LatLong.Latitude.Should().Be(latitude);
        country.LatLong.Longitude.Should().Be(longitude);
    }

    [Fact]
    public void AddedItemShouldGetGeneratedId()
    {
        var streetAddress = CreateStreetAddress();
        var guidUserId = Guid.NewGuid().ToString();
        using var aesAlg = Aes.Create();
        var encryptTypeOptions = new EncryptedTextTypeOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = Convert.ToBase64String(aesAlg.Key),
            Iv = Convert.ToBase64String(aesAlg.IV)
        };
        var dateTime = new DateTimeOffset(2023, 01, 01, 0, 0, 0, 0, TimeSpan.Zero);

        var newItem = new Country()
        {
            Name = Text.From("Switzerland"),
            LatLong = LatLong.From(46.802496, 8.234392),
            Population = Number.From(8_703_654),
            GrossDomesticProduct = Money.From(100, CurrencyCode.CHF, new MoneyTypeOptions() { MaxValue = 101, MinValue = 0 }),
            CountryCode2 = CountryCode2.From("CH"),
            AreaInSqKm = Area.From(41_290_000, AreaTypeUnit.SquareMeter),
            CultureCode = CultureCode.From("de-CH"),
            CountryNumber = CountryNumber.From(756),
            MonthOfPeakTourism = Month.From(7),
            DistanceInKm = Distance.From(129.522785),
            DateTimeRange = DateTimeRange.From(new DateTimeOffset(2023, 01, 01, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2023, 02, 01, 0, 0, 0, TimeSpan.Zero)),
            InternetDomain = InternetDomain.From("admin.ch"),
            CountryCode3 = CountryCode3.From("CHE"),
            IPAddress = IpAddress.From("102.129.143.255"),
            LongestHikingTrailInMeters = Length.From(390_000),
            StreetAddress = streetAddress,
            MACAddress = MacAddress.From("AE-D4-32-2C-CF-EF"),
            Uri = Uri.From(Sample_Uri),
            Url = Url.From(Sample_Url),
            Date = Date.From(new DateOnly(2023, 11, 25), new()),
            Flag = Image.From("https://upload.wikimedia.org/wikipedia/commons/thumb/f/f3/Flag_of_Switzerland.svg/320px-Flag_of_Switzerland.svg.png", "Switzerland Flag", 512),
            LocalTimeZone = TimeZoneCode.From("CET"),
            StreetAddressJson = Json.From(JsonSerializer.Serialize(streetAddress, new JsonSerializerOptions { WriteIndented = true })),
            IsLandLocked = Boolean.From(true),
            ArabicName = TranslatedText.From((CultureCode.From("ar-SA"), "سوئٹزرلینڈ")),
            DateTimeDuration = DateTimeDuration.From(days: 10, 5, 2, 1),
            VolumeInCubicMeters = Volume.From(89_000, VolumeTypeUnit.CubicMeter),
            WeightInKilograms = Weight.From(19_000, WeightTypeUnit.Kilogram),
            Nuid = Nuid.From(NuidDefinition.NuidStringValue),
            HashedText = HashedText.From(("Test123.", "salt")),
            CreateDate = DateTime.From(dateTime),
            CurrentTime = Time.From(11, 35, 50, 375),
            AverageTemperatureInCelsius = Temperature.From(25),
            Description = Markdown.From("This a **big country**."),
            PageHtml = Html.From("<html><body>Switzerland Website</body></html>"),
            CitiesCounties = Yaml.From(SwitzerlandCitiesCountiesYaml),
            File = File.From("https://example.com/myfile.pdf", "MyFile", 512),
            PhoneNumber = PhoneNumber.From("+41 848 700 700"),
            GuidUser = User.From(guidUserId),
            EmailUser = User.From("user@iwgplc.ch"),
            StringUser = User.From("stringUser", new UserTypeOptions { ValidEmailFormat = false, ValidGuidFormat = false }),
            InfoEmail = Email.From("info@iwgplc.ch"),
            SecretPassword = EncryptedText.FromPlainText("12345678", encryptTypeOptions),
            AutoId = AutoNumber.FromDatabase(10U),
            Guid = Guid.From(System.Guid.NewGuid()),
            Password = Password.From("Test123."),
            CurrencyNumber = CurrencyNumber.From(840),
            Color = Color.From(255, 120, 95, 230),
            DayOfWeek = DayOfWeek.From(1),
            DateTimeSchedule = DateTimeSchedule.From("0 0 12 ? * 2,3,4,5,6 *"),
        };
        DbContext.Countries!.Add(newItem);
        DbContext.SaveChanges();

        //Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        Assert.Equal(CountryId.From(1), newItem.Id);

        var item = DbContext.Countries?.First();

        item!.Id.Value.Should().Be(1);
        item.Name.Value.Should().Be("Switzerland");
        item.LatLong.Latitude.Should().Be(46.802496);
        item.LatLong.Longitude.Should().Be(8.234392);
        item.Population?.Value.Should().Be(8_703_654);
        item.GrossDomesticProduct.CurrencyCode.ToString().Should().Be("CHF");
        item.GrossDomesticProduct.Value.CurrencyCode.Should().Be(CurrencyCode.CHF);
        item.GrossDomesticProduct.Amount.Should().Be(100);
        item.CountryCode2.Value.Should().Be("CH");
        item.AreaInSqKm.Value.Should().Be(41_290_000);
        item.AreaInSqKm.Unit.Should().Be(AreaTypeUnit.SquareMeter);
        item.CultureCode.Value.Should().Be("de-CH");
        item.CountryNumber.Value.Should().Be(756);
        item.MonthOfPeakTourism.Value.Should().Be(7);
        item.DistanceInKm.Value.Should().Be(129.522785);
        item.DistanceInKm.Unit.Should().Be(DistanceTypeUnit.Kilometer);
        item.InternetDomain.Value.Should().Be("admin.ch");
        item.CountryCode3.Value.Should().Be("CHE");
        item.IPAddress.Value.Should().Be("102.129.143.255");
        item.DateTimeRange.Start.Should().Be(new DateTimeOffset(2023, 01, 01, 0, 0, 0, 0, TimeSpan.Zero));
        item.DateTimeRange.End.Should().Be(new DateTimeOffset(2023, 02, 01, 0, 0, 0, TimeSpan.Zero));
        item.LongestHikingTrailInMeters.Value.Should().Be(390_000);
        item.LongestHikingTrailInMeters.Unit.Should().Be(LengthTypeUnit.Meter);
        item.MACAddress.Value.Should().Be("AED4322CCFEF");
        item.CurrentTime.Value.Ticks.Should().Be(417503750000);
        item.Date.Value.Should().Be(new DateOnly(2023, 11, 25));
        item.LocalTimeZone.Value.Should().Be("CET");
        item.Uri.Value.AbsoluteUri.Should().Be(Sample_Uri);
        item.Url.Value.AbsoluteUri.Should().Be(Sample_Url);
        item.IsLandLocked.Value.Should().BeTrue();
        item.VolumeInCubicMeters.Value.Should().Be(89_000);
        item.VolumeInCubicMeters.Unit.Should().Be(VolumeTypeUnit.CubicMeter);
        item.Flag.Url.Should().Be("https://upload.wikimedia.org/wikipedia/commons/thumb/f/f3/Flag_of_Switzerland.svg/320px-Flag_of_Switzerland.svg.png");
        item.Flag.PrettyName.Should().Be("Switzerland Flag");
        item.Flag.SizeInBytes.Should().Be(512);
        item.WeightInKilograms.Value.Should().Be(19_000);
        item.WeightInKilograms.Unit.Should().Be(WeightTypeUnit.Kilogram);
        item.HashedText.HashText.Should().Be(newItem.HashedText.HashText);
        item.HashedText.Salt.Should().Be(newItem.HashedText.Salt);
        item.CreateDate!.Value.Should().Be(dateTime);
        item.CreateDate!.Value.Offset.Should().Be(dateTime.Offset);
        item.DateTimeDuration.Value.Should().Be(new TimeSpan(10, 5, 2, 1).Ticks);
        item.Nuid.Value.Should().Be(NuidDefinition.NuidValue);
        Assert.Equal(newItem.Password, item.Password);
        AssertStreetAddress(streetAddress, item.StreetAddress);
        item.StreetAddressJson.Value.Should().Be(JsonSerializer.Serialize(streetAddress));
        item.Description.Value.Should().Be("This a **big country**.");
        item.PageHtml.Value.Should().Be("<html><body>Switzerland Website</body></html>");
        item.AverageTemperatureInCelsius?.Value.Should().Be(newItem.AverageTemperatureInCelsius.Value);
        item.AverageTemperatureInCelsius?.Unit.Should().Be(newItem.AverageTemperatureInCelsius.Unit);
        item.Uri.Value.AbsoluteUri.Should().Be(Sample_Uri);
        item.StreetAddressJson.Value.Should().Be(JsonSerializer.Serialize(streetAddress));
        item.CitiesCounties.Value.Should().Be(SwitzerlandCitiesCountiesYaml);
        item.File.Url.Should().Be("https://example.com/myfile.pdf");
        item.File.PrettyName.Should().Be("MyFile");
        item.File.SizeInBytes.Should().Be(512UL);
        item.PhoneNumber.Value.Should().Be("+41 848 700 700");
        Assert.Equal(JsonSerializer.Serialize(streetAddress), item.StreetAddressJson.Value);
        item.GuidUser.Value.Should().Be(guidUserId);
        item.EmailUser.Value.Should().Be("user@iwgplc.ch");
        item.StringUser.Value.Should().Be("stringUser");
        item.InfoEmail.Value.Should().Be("info@iwgplc.ch");
        item.SecretPassword.DecryptText(encryptTypeOptions).Should().Be("12345678");
        item.AutoId.Value.Should().Be(10U);
        item.CurrencyNumber.Value.Should().Be(840);
        item.Color.ToHex().Should().Be("#785FE6");
        item.DayOfWeek.Value.Should().Be(1);
        item.DateTimeSchedule.Should().Be(newItem.DateTimeSchedule);
    }

    private static StreetAddress CreateStreetAddress()
    {
        return StreetAddress.From(new StreetAddressItem
        {
            StreetNumber = "15",
            AddressLine1 = "AddressLine1",
            AddressLine2 = "AddressLine2",
            Route = "Route",
            Locality = "Locality",
            Neighborhood = "Neighborhood",
            AdministrativeArea1 = "AdministrativeArea1",
            AdministrativeArea2 = "AdministrativeArea2",
            PostalCode = "1234",
            CountryId = CountryCode.CH
        });
    }

    private static void AssertStreetAddress(StreetAddress expectedAddress, StreetAddress actualAddress)
    {
        var expectedAddressValue = expectedAddress.Value;
        var actualAddressValue = actualAddress.Value;

        actualAddressValue.AddressLine1.Should().Be(expectedAddressValue.AddressLine1);
        actualAddressValue.AddressLine2.Should().Be(expectedAddressValue.AddressLine2);
        actualAddressValue.Locality.Should().Be(expectedAddressValue.Locality);
        actualAddressValue.Neighborhood.Should().Be(expectedAddressValue.Neighborhood);
        actualAddressValue.PostalCode.Should().Be(expectedAddressValue.PostalCode);
        actualAddressValue.AdministrativeArea1.Should().Be(expectedAddressValue.AdministrativeArea1);
        actualAddressValue.AdministrativeArea2.Should().Be(expectedAddressValue.AdministrativeArea2);
        actualAddressValue.Route.Should().Be(expectedAddressValue.Route);
        actualAddressValue.StreetNumber.Should().Be(expectedAddressValue.StreetNumber);
        actualAddressValue.CountryId.Should().Be(expectedAddressValue.CountryId);
    }
}