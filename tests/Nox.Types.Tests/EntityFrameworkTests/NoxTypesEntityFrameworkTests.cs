using FluentAssertions;
using System.Text.Json;

namespace Nox.Types.Tests.EntityFrameworkTests;

public class NoxTypesEntityFrameworkTests : TestWithSqlite
{
    private const string Sample_Uri = "https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName";
    private const string Sample_Url = "https://www.myregus.com/";
    private readonly (string NuidStringValue, uint NuidValue) NuidDefinition = ("PropertyNamesWithSeparator", 3697780159);

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

        var newItem = new Country()
        {
            Name = Text.From("Switzerland"),
            LatLong = LatLong.From(latitude, longitude),
            Population = Number.From(8_703_654),
            GrossDomesticProduct = Money.From(717_341_603_000, CurrencyCode.CHF),
            CountryCode2 = CountryCode2.From("CH"),
            AreaInSqKm = Area.From(41_290_000),
            CultureCode = CultureCode.From("de-CH"),
            CountryNumber = CountryNumber.From(756),
            MonthOfPeakTourism = Month.From(7),
            DistanceInKm = Distance.From(129.522785),
            InternetDomain = InternetDomain.From("admin.ch"),
            CountryCode3 = CountryCode3.From("CHE"),
            IPAddress = IpAddress.From("102.129.143.255"),
            DateTimeRange = DateTimeRange.From(new System.DateTime(2023, 01, 01), new System.DateTime(2023, 02, 01)),
            LongestHikingTrailInMeters = Length.From(390_000),
            MACAddress = MacAddress.From("AE-D4-32-2C-CF-EF"),
            Date = Date.From(new System.DateTime(2023, 11, 25), new()),
            StreetAddress = streetAddress,
            StreetAddressJson = Json.From(JsonSerializer.Serialize(streetAddress)),
            LocalTimeZone = TimeZoneCode.From("CET"),
            Uri = Uri.From(Sample_Uri),
            Url = Url.From(Sample_Url),
            IsLandLocked = Boolean.From(false),
            DateTimeDuration = DateTimeDuration.From(days: 10, 5, 2, 1),
            VolumeInCubicMeters = Volume.FromCubicMeters(89_000),
            WeightInKilograms = Weight.FromKilograms(19_000),
            Nuid = Nuid.From(NuidDefinition.NuidStringValue),
            HashedText = HashedText.From("Test123."),
            ArabicName = TranslatedText.From((CultureCode.From("ar-SA"), "سوئٹزرلینڈ")),
            CurrentTime = Time.From(07,55,33,250)
        };
        DbContext.Countries!.Add(newItem);
        DbContext.SaveChanges();

        //Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var country = DbContext.Countries.First();

        country.LatLong.Latitude.Should().Be(latitude);
        country.LatLong.Longitude.Should().Be(longitude);
    }

    [Fact]
    public void AddedItemShouldGetGeneratedId()
    {
        var streetAddress = CreateStreetAddress();
        var newItem = new Country()
        {
            Name = Text.From("Switzerland"),
            LatLong = LatLong.From(46.802496, 8.234392),
            Population = Number.From(8_703_654),
            GrossDomesticProduct = Money.From(717_341_603_000, CurrencyCode.CHF),
            CountryCode2 = CountryCode2.From("CH"),
            AreaInSqKm = Area.From(41_290_000),
            CultureCode = CultureCode.From("de-CH"),
            CountryNumber = CountryNumber.From(756),
            MonthOfPeakTourism = Month.From(7),
            DistanceInKm = Distance.From(129.522785),
            DateTimeRange = DateTimeRange.From(new System.DateTime(2023, 01, 01), new System.DateTime(2023, 02, 01)),
            InternetDomain = InternetDomain.From("admin.ch"),
            CountryCode3 = CountryCode3.From("CHE"),
            IPAddress = IpAddress.From("102.129.143.255"),
            LongestHikingTrailInMeters = Length.From(390_000),
            StreetAddress = streetAddress,
            MACAddress = MacAddress.From("AE-D4-32-2C-CF-EF"),
            Uri = Uri.From(Sample_Uri),
            Url = Url.From(Sample_Url),
            Date = Date.From(new System.DateTime(2023, 11, 25), new()),
            LocalTimeZone = TimeZoneCode.From("CET"),
            StreetAddressJson = Json.From(JsonSerializer.Serialize(streetAddress, new JsonSerializerOptions { WriteIndented = true })),
            IsLandLocked = Boolean.From(true),
            ArabicName = TranslatedText.From((CultureCode.From("ar-SA"), "سوئٹزرلینڈ")),
            DateTimeDuration = DateTimeDuration.From(days: 10, 5, 2, 1),
            VolumeInCubicMeters = Volume.FromCubicMeters(89_000),
            WeightInKilograms = Weight.FromKilograms(19_000),
            Nuid = Nuid.From(NuidDefinition.NuidStringValue),
            HashedText = HashedText.From(("Test123.", "salt")),
            CreateDate = DateTime.From(new System.DateTime(2023, 01, 01)),
            CurrentTime = Time.From(11,35,50,375),
            AverageTemperatureInCelsius = Temperature.FromCelsius(25)
        };
        DbContext.Countries!.Add(newItem);
        DbContext.SaveChanges();

        //Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        Assert.Equal(CountryId.From(1), newItem.Id);

        var item = DbContext.Countries.First();

        item.Id.Value.Should().Be(1);
        item.Name.Value.Should().Be("Switzerland");
        item.LatLong.Latitude.Should().Be(46.802496);
        item.LatLong.Longitude.Should().Be(8.234392);
        item.Population?.Value.Should().Be(8_703_654);
        item.GrossDomesticProduct.CurrencyCode.Should().Be("CHF");
        item.GrossDomesticProduct.Value.CurrencyCode.Should().Be(CurrencyCode.CHF);
        item.GrossDomesticProduct.Amount.Should().Be(717_341_603_000);
        item.CountryCode2.Value.Should().Be("CH");
        item.AreaInSqKm.Value.Should().Be(41_290_000);
        item.AreaInSqKm.Unit.Should().Be(AreaUnit.SquareMeter);
        item.CultureCode.Value.Should().Be("de-CH");
        item.CountryNumber.Value.Should().Be(756);
        item.MonthOfPeakTourism.Value.Should().Be(7);
        item.DistanceInKm.Value.Should().Be(129.522785);
        item.DistanceInKm.Unit.Should().Be(DistanceUnit.Kilometer);
        item.InternetDomain.Value.Should().Be("admin.ch");
        item.CountryCode3.Value.Should().Be("CHE");
        item.IPAddress.Value.Should().Be("102.129.143.255");
        item.DateTimeRange.Start.Should().Be(new System.DateTime(2023, 01, 01));
        item.DateTimeRange.End.Should().Be(new System.DateTime(2023, 02, 01));
        item.LongestHikingTrailInMeters.Value.Should().Be(390_000);
        item.LongestHikingTrailInMeters.Unit.Should().Be(LengthUnit.Meter);
        item.MACAddress.Value.Should().Be("AED4322CCFEF");
        item.CurrentTime.Value.Ticks.Should().Be(417503750000);
        item.Date.Value.Should().Be(new System.DateTime(2023, 11, 25).Date);
        item.LocalTimeZone.Value.Should().Be("CET");
        item.Uri.Value.AbsoluteUri.Should().Be(Sample_Uri);
        item.Url.Value.AbsoluteUri.Should().Be(Sample_Url);
        item.IsLandLocked.Value.Should().BeTrue();
        item.VolumeInCubicMeters.Value.Should().Be(89_000);
        item.VolumeInCubicMeters.Unit.Should().Be(VolumeUnit.CubicMeter);
        Assert.Equal(19_000, item.WeightInKilograms.Value);
        item.WeightInKilograms.Unit.Should().Be(WeightUnit.Kilogram);
        item.HashedText.HashText.Should().Be(newItem.HashedText.HashText);
        item.HashedText.Salt.Should().Be(newItem.HashedText.Salt);
        item.CreateDate.Should().Be(DateTime.From(new System.DateTime(2023, 01, 01)));
        item.DateTimeDuration.Value.Should().Be(new TimeSpan(10, 5, 2, 1));
        item.Nuid.Value.Should().Be(NuidDefinition.NuidValue);
        Assert.Equal(newItem.AverageTemperatureInCelsius.Value, item.AverageTemperatureInCelsius?.Value);
        Assert.Equal(newItem.AverageTemperatureInCelsius.Unit, item.AverageTemperatureInCelsius?.Unit);
        Assert.Equal(Sample_Uri, item.Uri.Value.AbsoluteUri);
        AssertStreetAddress(streetAddress, item.StreetAddress);
        Assert.Equal(JsonSerializer.Serialize(streetAddress), item.StreetAddressJson.Value);
    }

    private static StreetAddress CreateStreetAddress()
    {
        return StreetAddress.From(new StreetAddressItem
        {
            StreetNumber = 15,
            AddressLine1 = "AddressLine1",
            AddressLine2 = "AddressLine2",
            Route = "Route",
            Locality = "Locality",
            Neighborhood = "Neighborhood",
            AdministrativeArea1 = "AdministrativeArea1",
            AdministrativeArea2 = "AdministrativeArea2",
            PostalCode = "1234",
            CountryId = CountryCode2.From("CH")
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
        actualAddressValue.CountryId.Value.Should().Be(expectedAddressValue.CountryId.Value);
    }
}