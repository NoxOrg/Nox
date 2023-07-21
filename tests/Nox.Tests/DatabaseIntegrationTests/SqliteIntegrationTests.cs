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
        var areaInSquareMeters = 198_090;
        var areaUnit = AreaTypeUnit.SquareMeter;

        var newItem = new TestEntityForTypes()
        {
            Id = Text.From(text),
            TextTestField = Text.From(text),
            NumberTestField = Number.From(number),
            MoneyTestField = Money.From(money, currencyCode),
            CountryCode2TestField = CountryCode2.From(countryCode2),
            StreetAddressTestField = StreetAddress.From(addressItem),
            AreaTestField = Area.From(areaInSquareMeters, areaUnit, new AreaTypeOptions(){ PersistAs = areaUnit }),
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
        ((double)testEntity.AreaTestField!.ToSquareMeters()).Should().BeApproximately(areaInSquareMeters,0.000099);
        testEntity.AreaTestField!.AreaTypeUnit.Should().Be(areaUnit);
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