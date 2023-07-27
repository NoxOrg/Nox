using FluentAssertions;

using Nox.Types;

using TestWebApp.Domain;

namespace Nox.Tests.DatabaseIntegrationTests;

public class TestFixture
{
    public TestEntityForTypes CreateTestEntityForTypes()
    {
        var text = "TestTextValue";
        var number = 123;
        var money = 10;
        var currencyCode = CurrencyCode.UAH;
        var countryCode2 = "UA";
        var currencyCode3 = "USD";
        var addressItem = new StreetAddressItem
        {
            AddressLine1 = "AddressLine1",
            CountryId = CountryCode2.From("UA"),
            PostalCode = "61135"
        };
        var date = new DateOnly(2023, 7, 14);
        var languageCode = "en";
        var area = 198_090M;
        var persistUnitAs = AreaTypeUnit.SquareMeter;
        var cultureCode = "de-CH";

        return new TestEntityForTypes()
        {
            Id = Text.From(countryCode2),
            TextTestField = Text.From(text),
            NumberTestField = Number.From(number),
            MoneyTestField = Money.From(money, currencyCode),
            CountryCode2TestField = CountryCode2.From(countryCode2),
            AreaTestField = Area.From(area, new AreaTypeOptions() { Units = AreaTypeUnit.SquareFoot, PersistAs = persistUnitAs }),
            StreetAddressTestField = StreetAddress.From(addressItem),
            CurrencyCode3TestField = CurrencyCode3.From(currencyCode3),
            DateTestField = Date.From(date),
            LanguageCodeTestField = LanguageCode.From(languageCode),
            CultureCodeTestField = CultureCode.From(cultureCode),
        };
    }

    public void AssertTestEntityForTypes(TestEntityForTypes actual)
    {
        var text = "TestTextValue";
        var number = 123;
        var money = 10;
        var currencyCode = CurrencyCode.UAH;
        var countryCode2 = "UA";
        var currencyCode3 = "USD";
        var addressItem = new StreetAddressItem
        {
            AddressLine1 = "AddressLine1",
            CountryId = CountryCode2.From("UA"),
            PostalCode = "61135"
        };
        var date = new DateOnly(2023, 7, 14);
        var languageCode = "en";
        var area = 198_090M;
        var persistUnitAs = AreaTypeUnit.SquareMeter;
        var cultureCode = "de-CH";

        // TODO: make it work without .Value
        actual.Id.Value.Should().Be(countryCode2);
        actual.TextTestField.Value.Should().Be(text);
        actual.NumberTestField.Value.Should().Be(number);
        actual.MoneyTestField!.Value.Amount.Should().Be(money);
        actual.MoneyTestField.Value.CurrencyCode.Should().Be(currencyCode);
        actual.CountryCode2TestField!.Value.Should().Be(countryCode2);
        actual.StreetAddressTestField!.Value.Should().BeEquivalentTo(addressItem);
        actual.AreaTestField!.ToSquareFeet().Should().Be(area);
        actual.AreaTestField!.Unit.Should().Be(persistUnitAs);
        actual.CurrencyCode3TestField!.Value.Should().Be(currencyCode3);
        actual.DateTestField!.Value.Should().Be(date);
        actual.LanguageCodeTestField!.Value.Should().Be(languageCode);
        actual.CultureCodeTestField!.Value.Should().Be(cultureCode);
    }
}
