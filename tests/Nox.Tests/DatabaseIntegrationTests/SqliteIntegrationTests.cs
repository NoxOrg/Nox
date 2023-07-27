using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using TestWebApp.Domain;

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
        var persistUnitAs = AreaTypeUnit.SquareMeter;
        var cultureCode = "de-CH";
        var macAddress = "A1B2C3D4E5F6";
        var password = "Test123.";

        var newItem = new TestEntityForTypes()
        {
            Id = Text.From(text),
            TextTestField = Text.From(text),
            NumberTestField = Number.From(number),
            MoneyTestField = Money.From(money, currencyCode),
            CountryCode2TestField = CountryCode2.From(countryCode2),
            AreaTestField = Area.From(area, new AreaTypeOptions() { Units = AreaTypeUnit.SquareFoot, PersistAs = persistUnitAs }),
            StreetAddressTestField = StreetAddress.From(addressItem),
            CurrencyCode3TestField = CurrencyCode3.From(currencyCode3),
            LanguageCodeTestField = LanguageCode.From(languageCode),
            CultureCodeTestField = CultureCode.From(cultureCode),
            TranslatedTextTestField = TranslatedText.From((CultureCode.From("ur-PK"), "شادی مبارک")),
            CountryCode3TestField = CountryCode3.From(countryCode3),
            TimeZoneCodeTestField = TimeZoneCode.From("utc"),
            MacAddressTestField = MacAddress.From(macAddress),
            HashedTextTestField = HashedText.From(text),
            PasswordTestField = Password.From(password),
        };
        DbContext.TestEntityForTypes.Add(newItem);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityForTypes.First();

        // TODO: make it work without .Value
        testEntity.Id.Value.Should().Be(text);
        testEntity.TextTestField.Value.Should().Be(text);
        testEntity.NumberTestField.Value.Should().Be(number);
        testEntity.MoneyTestField!.Value.Amount.Should().Be(money);
        testEntity.MoneyTestField.Value.CurrencyCode.Should().Be(currencyCode);
        testEntity.CountryCode2TestField!.Value.Should().Be(countryCode2);
        testEntity.StreetAddressTestField!.Value.Should().BeEquivalentTo(addressItem);
        testEntity.AreaTestField!.ToSquareFeet().Should().Be(area);
        testEntity.AreaTestField!.Unit.Should().Be(persistUnitAs);
        testEntity.CurrencyCode3TestField!.Value.Should().Be(currencyCode3);
    		testEntity.LanguageCodeTestField!.Value.Should().Be(languageCode);
        testEntity.CultureCodeTestField!.Value.Should().Be(cultureCode);
        testEntity.TranslatedTextTestField!.Value.Phrase.Should().BeEquivalentTo("شادی مبارک");
        testEntity.CountryCode3TestField!.Value.Should().Be(countryCode3);
        testEntity.TimeZoneCodeTestField!.Value.Should().Be("UTC");
        testEntity.MacAddressTestField!.Value.Should().Be(macAddress);
        testEntity.HashedTextTestField!.HashText.Should().Be(newItem.HashedTextTestField?.HashText);
        testEntity.HashedTextTestField!.Salt.Should().Be(newItem.HashedTextTestField?.Salt);
        testEntity.PasswordTestField!.HashedPassword.Should().Be(newItem.PasswordTestField.HashedPassword);
        testEntity.PasswordTestField!.Salt.Should().Be(newItem.PasswordTestField.Salt);
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
}