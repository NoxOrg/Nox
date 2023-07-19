using FluentAssertions;
using Nox.Types;
using TestDatabaseWebApp.Domain;

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
        // autoNumber
        // collection
        // entity
        // file
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
        // dateTimeDuration
        // dateTimeSchedule
        // html
        // json
        // time
        // translatedText
        // markdown
        // jwtToken

        // TODO: commented types

        var text = "TestTextValue";
        var number = 123;
        var money = 10;
        var currencyCode = CurrencyCode.UAH;
        var countryCode2 = "UA";
        var addressItem = new StreetAddressItem
        {
            AddressLine1 = "AddressLine1",
            CountryId = CountryCode2.From("UA"),
            PostalCode = "61135"
        };

        var newItem = new TestEntity()
        {
            Id = Text.From(text),
            TextTestField = Text.From(text),
            NumberTestField = Number.From(number),
            MoneyTestField = Money.From(money, currencyCode),
            CountryCode2TestField = CountryCode2.From(countryCode2),
            StreetAddressTestField = StreetAddress.From(addressItem)
        };
        DbContext.TestEntities.Add(newItem);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntities.First();

        // TODO: make it work without .Value
        testEntity.Id.Value.Should().Be(text);
        testEntity.TextTestField.Value.Should().Be(text);
        testEntity.NumberTestField.Value.Should().Be(number);
        testEntity.MoneyTestField!.Value.Amount.Should().Be(money);
        testEntity.MoneyTestField.Value.CurrencyCode.Should().Be(currencyCode);
        testEntity.CountryCode2TestField!.Value.Should().Be(countryCode2);
        testEntity.StreetAddressTestField!.Value.Should().BeEquivalentTo(addressItem);
    }
}