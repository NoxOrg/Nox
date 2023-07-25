using FluentAssertions;
using Nox.Types;
using TestWebApp.Domain;
using DayOfWeek = Nox.Types.DayOfWeek;

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
        var areaInSquareMeters = 198_090;
        var areaUnit = AreaTypeUnit.SquareMeter;
        var dayOfWeek = 1;

        var newItem = new TestEntityForTypes()
        {
            Id = Text.From(countryCode2),
            TextTestField = Text.From(text),
            NumberTestField = Number.From(number),
            MoneyTestField = Money.From(money, currencyCode),
            CountryCode2TestField = CountryCode2.From(countryCode2),
            DayOfWeekTestField = DayOfWeek.From(1),
            //AreaTestField = Area.FromSquareMeters(areaInSquareMeters),
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
        testEntity.AreaTestField!.Value.Should().Be(areaInSquareMeters);
        testEntity.AreaTestField!.Unit.Should().Be(areaUnit);
        testEntity.DayOfWeekTestField!.Value.Should().Be(dayOfWeek);
    }
}