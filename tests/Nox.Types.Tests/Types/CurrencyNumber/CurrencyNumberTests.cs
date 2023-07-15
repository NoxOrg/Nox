using FluentAssertions;
using System.Globalization;

namespace Nox.Types.Tests.Types;

public class CurrencyNumberTests
{
    [Fact]
    public void CurrencyNumber_DefaultConstructor_InitializedWithDefaultValues()
    {
        var currencyNumber = new CurrencyNumber();

        currencyNumber.Amount.Should().Be(0);
        currencyNumber.CurrencyCode.Should().Be("USD");
        currencyNumber.Value.CurrencyCode.Should().Be(CurrencyCode.USD);
    }

    [Fact]
    public void CurrencyNumber_ParameterizedConstructor_InitializedWithProvidedValues()
    {
        // Arrange
        uint value = 1000;
        var currency = CurrencyCode.EUR;

        // Act
        var currencyNumber = CurrencyNumber.From(value, currency);

        // Assert
        currencyNumber.Amount.Should().Be(value);
        currencyNumber.CurrencyCode.Should().Be("EUR");
        currencyNumber.Value.CurrencyCode.Should().Be(CurrencyCode.EUR);
    }

    [Fact]
    public void CurrencyNumber_FromMethod_CreatesMoneyObject()
    {
        // Arrange
        uint value = 25000U;
        var currency = CurrencyCode.GBP;

        // Act
        var currencyNumber = CurrencyNumber.From(value, currency);

        // Assert
        currencyNumber.Amount.Should().Be(value);
        currencyNumber.CurrencyCode.Should().Be("GBP");
        currencyNumber.Value.CurrencyCode.Should().Be(CurrencyCode.GBP);
    }

    [Fact]
    public void CurrencyNumber_Should_Equal_When_Their_Value_And_Currency_Same()
    {
        // Arrange
        var currencyNumber = CurrencyNumber.From(1550U, CurrencyCode.USD);
        var currencyNumber2 = CurrencyNumber.From(1550U, CurrencyCode.USD);

        // Act
        var result = currencyNumber.Equals(currencyNumber2);

        // Assert
        currencyNumber.Amount.Should().Be(currencyNumber2.Value.Amount);
        result.Should().BeTrue();
    }

    [Fact]
    public void CurrencyNumber_Should_Not_Equal_When_Their_Value_And_Currency_Different()
    {
        // Arrange
        var currencyNumber = CurrencyNumber.From(13200U, CurrencyCode.USD);
        var currencyNumber2 = CurrencyNumber.From(13200U, CurrencyCode.TRY);

        var currencyNumber3 = CurrencyNumber.From(13200U, CurrencyCode.USD);
        var currencyNumber4 = CurrencyNumber.From(13201U, CurrencyCode.USD);

        // Act
        var result = currencyNumber.Equals(currencyNumber2);
        var result2 = currencyNumber3.Equals(currencyNumber4);

        // Assert
        result.Should().BeFalse();
        result2.Should().BeFalse();
        currencyNumber.Should().NotBe(currencyNumber2);
        currencyNumber3.Should().NotBe(currencyNumber4);
    }

    [Fact]
    public void CurrencyNumber_ToString_ReturnsCurrencyAndAmount()
    {
        var currencyNumber = CurrencyNumber.From(20000u, CurrencyCode.BRL);

        currencyNumber.ToString().Should().Be("BRL 20000");
    }

    [Fact]
    public void CurrencyNumber_ToString_With_C_Format_ReturnsCurrencySymbolAndAmount()
    {
        void Test()
        {
            var currencyNumber = CurrencyNumber.From(1455U, CurrencyCode.ZAR);
            var currencyNumber2 = CurrencyNumber.From(1455U, CurrencyCode.GBP);

            currencyNumber.ToString("C", new CultureInfo("en-ZA")).Should().Be("R1,455.00");
            currencyNumber2.ToString("C", new CultureInfo("en-GB")).Should().Be("£1,455.00");
        }

        TestUtility.RunInInvariantCulture(Test);
    }

    [Fact]
    public void CurrencyNumber_ToString_SameCurrency_DifferentCulture_ReturnsSameCurrencySymbol()
    {
        void Test()
        {
            var currencyNumber = CurrencyNumber.From(1455U, CurrencyCode.BRL);

            var resultWithUSCulture = currencyNumber.ToString("C", new CultureInfo("en-US"));
            var resultWithBRCulture = currencyNumber.ToString("C", new CultureInfo("pt-BR"));

            resultWithUSCulture.Should().Be("R$1,455.00");
            resultWithBRCulture.Should().Be("R$1.455,00");
        }

        TestUtility.RunInInvariantCulture(Test);
    }
}