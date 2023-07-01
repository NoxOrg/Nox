using FluentAssertions;
using Nox.Types;
using NoxSourceGeneratorTests.DatabaseTests;
using SampleWebApp.Domain;
using System.Linq;
using Xunit;

namespace Nox.Generator.Test.DatabaseTests;

public class EntityFrameworkTests : SqliteTestBase
{
    [Fact]
    public void GeneratedEntity_CanSaveAndReadFields_AllTypes()
    {
        var name = "TestName";
        var formalName = "TestFormalName";
        var alphaCode2 = "UA";
        var alphaCode3 = "UKR";
        var numbericCode = 123;
        var latitude = 46.802496;
        var longitude = 8.234392;
        var testCapital = "TestCapital";
        var testDenonym = "TestDenonym";
        var testDialingCode = "+380";
        var geoRegion = "Europe";
        var geoSubRegion = "East Europe";
        var geoWorldRegion = "North";
        var population = 40000;
        var topLevelDomain = ".ua";
        var area = 100_000;
        var boolean = true;
        var countryCode3 = "UKR";
        short countryNumber = 804;

        var newItem = new Country()
        {
            Id = CountryId.From(Text.From(alphaCode2)),
            AlphaCode3 = Text.From(alphaCode3),
            Name = Text.From(name),
            FormalName = Text.From(formalName),
            NumericCode = Number.From(numbericCode),
            DialingCodes = Text.From(testDialingCode),
            Capital = Text.From(testCapital),
            Demonym = Text.From(testDenonym),
            GeoCoord = LatLong.From(latitude, longitude),
            GeoRegion = Text.From(geoRegion),
            GeoSubRegion = Text.From(geoSubRegion),
            GeoWorldRegion = Text.From(geoWorldRegion),
            Population = Number.From(population),
            TopLevelDomains = Text.From(topLevelDomain),
            AreaTestField = Area.From(area),
            BooleanTestField = boolean,
            AlphaCode2 = CountryCode2.From(alphaCode2),
            CountryCode3TestField = CountryCode3.From(countryCode3),
            CountryNumberTestField = CountryNumber.From(countryNumber)
        };
        DbContext.Countries.Add(newItem);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var country = DbContext.Countries.First();

        // TODO: make it work without .Value
        country.Id.Value.Value.Should().Be(alphaCode2);
        country.Name.Value.Should().Be(name);
        country.FormalName.Value.Should().Be(formalName);
        country.AlphaCode3.Value.Should().Be(alphaCode3);
        country.AlphaCode2.Value.Should().Be(alphaCode2);
        country.NumericCode.Value.Should().Be(numbericCode);
        country.DialingCodes.Value.Should().Be(testDialingCode);
        country.Capital.Value.Should().Be(testCapital);
        country.Demonym.Value.Should().Be(testDenonym);
        country.GeoRegion.Value.Should().Be(geoRegion);
        country.GeoSubRegion.Value.Should().Be(geoSubRegion);
        country.GeoWorldRegion.Value.Should().Be(geoWorldRegion);
        country.Population.Value.Should().Be(population);
        country.TopLevelDomains.Value.Should().Be(topLevelDomain);
        country.GeoCoord.Latitude.Should().Be(latitude);
        country.GeoCoord.Longitude.Should().Be(longitude);
        country.AreaTestField.Value.Should().Be(area);
        country.BooleanTestField.Should().Be(boolean);
        country.CountryCode3TestField.Value.Should().Be(countryCode3);
        country.CountryNumberTestField.Value.Should().Be(countryNumber);
    }
}
