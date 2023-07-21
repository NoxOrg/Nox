using FluentAssertions;
using Nox.Types;
using TestWebApp.Domain;

namespace Nox.Tests.DatabaseIntegrationTests;

public class SqlServerIntegrationTests : SqlServerTestBase
{
    // TODO: uncomment when automated and included into pipeline
    //[Fact]
    public void GeneratedEntity_SqlServer_CanSaveAndReadFields_AllTypes()
    {
        var text = "TestTextValue";
        var number = 123;
        var money = 10;
        var currencyCode = CurrencyCode.UAH;
        var countryCode2 = "UA";
        var macAddress = "A1B2C3D4E5F6";
        var newItem = new TestEntityForTypes()
        {
            Id = Text.From(countryCode2),
            TextTestField = Text.From(text),
            NumberTestField = Number.From(number),
            MoneyTestField = Money.From(money, currencyCode),
            CountryCode2TestField = CountryCode2.From(countryCode2),
            MacAddressTestField = MacAddress.From(macAddress),
        };
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
        testEntity.MacAddressTestField!.Value.Should().Be(macAddress);
    }
}