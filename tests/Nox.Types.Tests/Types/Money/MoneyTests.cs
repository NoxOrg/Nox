using System.Globalization;

namespace Nox.Types.Tests.Types;

public class MoneyTests
{
    [Fact]
    public void Money_DefaultConstructor_InitializedWithDefaultValues()
    {
        // Arrange
        Money money = new Money();

        // Assert
        Assert.Equal(0, money.Amount);
        Assert.Equal("USD", money.CurrencyCode);
        Assert.Equal(CurrencyCode.USD, money.Value.CurrencyCode);
    }

    [Fact]
    public void Money_ParameterizedConstructor_InitializedWithProvidedValues()
    {
        // Arrange
        decimal value = 1000.50m;
        var currency = CurrencyCode.EUR;

        // Act
        var money = Money.From(value, currency);

        // Assert
        Assert.Equal(value, money.Amount);
        Assert.Equal("EUR", money.CurrencyCode);
        Assert.Equal(CurrencyCode.EUR, money.Value.CurrencyCode);
    }

    [Fact]
    public void Money_FromMethod_CreatesMoneyObject()
    {
        // Arrange
        decimal value = 500.75m;
        var currency = CurrencyCode.GBP;

        // Act
        var money = Money.From(value, currency);

        // Assert
        Assert.Equal(value, money.Amount);
        Assert.Equal("GBP", money.CurrencyCode);
        Assert.Equal(CurrencyCode.GBP, money.Value.CurrencyCode);
    }

    [Fact]
    public void Moneys_Should_Equal_When_Their_Value_And_Currency_Same()
    {
        // Arrange
        var money = Money.From(1455453.55m, CurrencyCode.USD);
        var money2 = Money.From(1455453.55m, CurrencyCode.USD);

        // Act
        var result = money.Equals(money2);

        // Assert
        Assert.True(result);
        Assert.Equal(money, money2);
    }

    [Fact]
    public void Moneys_Should_Not_Equal_When_Their_Value_And_Currency_Different()
    {
        // Arrange
        var money = Money.From(1455453.55m, CurrencyCode.USD);
        var money2 = Money.From(1455453.55m, CurrencyCode.TRY);

        var money3 = Money.From(1455453.55m, CurrencyCode.USD);
        var money4 = Money.From(1455453.56m, CurrencyCode.USD);

        // Act
        var result = money.Equals(money2);
        var result2 = money3.Equals(money4);

        // Assert

        Assert.False(result);
        Assert.False(result2);
        Assert.NotEqual(money, money2);
        Assert.NotEqual(money3, money4);
    }

    [Fact]
    public void Money_ToString_ReturnsCurrencyAndAmount()
    {
        var money = Money.From(1455453.55m, CurrencyCode.TRY);

        Assert.Equal("TRY 1455453.55", money.ToString());
    }

    [Fact]
    public void Money_ToString_With_C_Format_ReturnsCurrencySymbolAndAmount()
    {
        void Test()
        {
            var area = Area.FromSquareMeters(12.5);

            Assert.Equal("12.5 m²", area.ToString());

            var money1 = Money.From(1455453.5m, CurrencyCode.ZAR);
            var money2 = Money.From(1455453.5m, CurrencyCode.GBP);

            Assert.Equal("R1,455,453.50", money1.ToString("C", new CultureInfo("en-ZA")));
            Assert.Equal("£1,455,453.50", money2.ToString("C", new CultureInfo("en-GB")));
        }

        TestUtility.RunInInvariantCulture(Test);
    }
}