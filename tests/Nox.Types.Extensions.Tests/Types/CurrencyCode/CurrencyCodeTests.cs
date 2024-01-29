using FluentAssertions;
using Nox.Reference;

namespace Nox.Types.Extensions.Tests.Types;

public class CurrencyCodeTests : WorldTestBase
{
    [Theory]
    [InlineData("EUR", "Euro", "EUR", "978", "€")]
    [InlineData("GBP", "British Pound", "GBP", "826", "£")]
    [InlineData("USD", "US Dollar", "USD", "840", "$")]
    public void WhenGettingReferenceCurrency_WithValidCurrencyCode_ThenReturnsCurrency(string currencyId, string currencyName, string currencyIsoCode, string currencyIsoNumber, string currencySymbol)
    {
        // Arrange
        var currencyCode = Enum.Parse<CurrencyCode>(currencyIsoCode);

        // Act
        var referenceCurrency = currencyCode.GetReferenceCurrency();

        // Assert
        referenceCurrency.Should().NotBeNull();
        referenceCurrency.Id.Should().Be(currencyId);
        referenceCurrency.Name.Should().Be(currencyName);
        referenceCurrency.IsoCode.Should().Be(currencyIsoCode);
        referenceCurrency.IsoNumber.Should().Be(currencyIsoNumber);
        referenceCurrency.Symbol.Should().Be(currencySymbol);
    }

    [Theory]
    [InlineData("EUR", "Euro", "EUR", "978", "€")]
    [InlineData("GBP", "British Pound", "GBP", "826", "£")]
    [InlineData("USD", "US Dollar", "USD", "840", "$")]
    public void WhenGettingReferenceCurrency_WithValidCurrencyCode3_ThenReturnsCurrency(string currencyId, string currencyName, string currencyIsoCode, string currencyIsoNumber, string currencySymbol)
    {
        // Arrange
        var currencyCode3 = CurrencyCode3.From(currencyIsoCode);

        // Act
        var referenceCurrency = currencyCode3.GetReferenceCurrency();

        // Assert
        referenceCurrency.Should().NotBeNull();
        referenceCurrency.Id.Should().Be(currencyId);
        referenceCurrency.Name.Should().Be(currencyName);
        referenceCurrency.IsoCode.Should().Be(currencyIsoCode);
        referenceCurrency.IsoNumber.Should().Be(currencyIsoNumber);
        referenceCurrency.Symbol.Should().Be(currencySymbol);
    }

    [Theory]
    [InlineData("EUR", "Euro", "EUR", "978", "€")]
    [InlineData("GBP", "British Pound", "GBP", "826", "£")]
    [InlineData("USD", "US Dollar", "USD", "840", "$")]
    public void WhenGettingReferenceCurrency_WithMoneyWithValidCurrencyCode_ThenReturnsCurrency(string currencyId, string currencyName, string currencyIsoCode, string currencyIsoNumber, string currencySymbol)
    {
        // Arrange
        var money = Money.From(1000, Enum.Parse<CurrencyCode>(currencyIsoCode));

        // Act
        var referenceCurrency = money.GetReferenceCurrency();

        // Assert
        referenceCurrency.Should().NotBeNull();
        referenceCurrency.Id.Should().Be(currencyId);
        referenceCurrency.Name.Should().Be(currencyName);
        referenceCurrency.IsoCode.Should().Be(currencyIsoCode);
        referenceCurrency.IsoNumber.Should().Be(currencyIsoNumber);
        referenceCurrency.Symbol.Should().Be(currencySymbol);
    }

    [Fact(Skip = "There are 29 missing Nox.Reference.Currency")]
    public void WhenGettingReferenceCurrency_FromAllCurrencyCodes_Success()
    {
        // Arrange
        foreach (var currencyCode in Enum.GetValues<CurrencyCode>())
        {
            var currencyIsoCode = currencyCode.ToString();

            // Act
            var referenceCurrency = CurrencyCode3.From(currencyIsoCode).GetReferenceCurrency();

            // Assert
            referenceCurrency.Should().NotBeNull();
            referenceCurrency.IsoCode.Should().Be(currencyIsoCode);
        }
    }

    [Theory]
    [InlineData("EUR")]
    [InlineData("GBP")]
    [InlineData("USD")]
    public void WhenGettingCurrencyCode_WithValidReferenceCurrency_ThenReturnsCurrencyCode(string currencyIsoCode)
    {
        // Arrange
        var referenceCurrency = World.Currencies.GetByIsoCode(currencyIsoCode);

        // Act
        var currencyCode = referenceCurrency!.GetCurrencyCode();

        // Assert
        currencyCode.Should().Be(Enum.Parse<CurrencyCode>(currencyIsoCode));
    }

    [Theory]
    [InlineData("EUR")]
    [InlineData("GBP")]
    [InlineData("USD")]
    public void WhenGettingCurrencyCode3_WithValidReferenceCurrency_ThenReturnsCurrencyCode3(string currencyIsoCode)
    {
        // Arrange
        var referenceCurrency = World.Currencies.GetByIsoCode(currencyIsoCode);

        // Act
        var currencyCode3 = referenceCurrency!.GetCurrencyCode3();

        // Assert
        currencyCode3.Should().NotBeNull();
        currencyCode3.Should().Be(CurrencyCode3.From(currencyIsoCode));
    }

    [Fact]
    public void WhenGettingCurrencyCode3_FromAllReferenceCurrencies_Success()
    {
        // These don't have numeric codes.
        var skippedCurrencies = new[] { "BTC", "TVD", "XBT" }; 

        // Arrange
        foreach (var currency in World.Currencies)
        {
            if (skippedCurrencies.Contains(currency.Id))
                continue;

            // Act
            var currencyCode3 = currency.GetCurrencyCode3();

            // Assert
            currencyCode3.Should().NotBeNull();
        }
    }
}