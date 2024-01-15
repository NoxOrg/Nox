using FluentAssertions;

namespace Nox.Types.Extensions.Tests.Types;

public class MoneyExtensionsTests : WorldTestBase
{
    [Theory]
    [InlineData("EUR", "Euro", "EUR", "978", "€")]
    [InlineData("GBP", "British Pound", "GBP", "826", "£")]
    [InlineData("USD", "US Dollar", "USD", "840", "$")]
    public void WhenGettingReferenceCurrency_WithValidCurrencyCode_ThenReturnsCurrency(string currencyId, string currencyName, string currencyIsoCode, string currencyIsoNumber, string currencySymbol)
    {
        // Arrange
        // Act
        var currency = Money.From(1000, Enum.Parse<CurrencyCode>(currencyIsoCode)).GetReferenceCurrency();

        // Assert
        currency.Should().NotBeNull();
        currency.Id.Should().Be(currencyId);
        currency.Name.Should().Be(currencyName);
        currency.IsoCode.Should().Be(currencyIsoCode);
        currency.IsoNumber.Should().Be(currencyIsoNumber);
        currency.Symbol.Should().Be(currencySymbol);
    }
}