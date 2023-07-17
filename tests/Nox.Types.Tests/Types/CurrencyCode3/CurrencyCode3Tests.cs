using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class CurrencyCode3Tests
{
    [Theory]
    [ClassData(typeof(CurrencyCode3Data))]
    public void CurrencyCode3_Constructor_ReturnsSameValue_AllCurrencies(string currencyCode3String)
    {
        var currencyCode3 = CurrencyCode3.From(currencyCode3String);

        currencyCode3.Value.Should().Be(currencyCode3String);
    }

    [Fact]
    public void CurrencyCode3_Constructor_WithUnsupportedCurrencyCode3_ThrowsValidationException()
    {
        var action = () => CurrencyCode3.From("ABC");

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox CurrencyCode3 type with unsupported value 'ABC'.") });
    }

    [Fact]
    public void CurrencyCode3_Equality_Tests()
    {
        var currencyCode3_1 = CurrencyCode3.From("USD");

        var currencyCode3_2 = CurrencyCode3.From("USD");

        currencyCode3_1.Should().Be(currencyCode3_2);
    }

    [Fact]
    public void CurrencyCode3_CaseInsensitiveEquality_Tests()
    {
        var currencyCode3_1 = CurrencyCode3.From("usd");

        var currencyCode3_2 = CurrencyCode3.From("USD");

        currencyCode3_1.Should().Be(currencyCode3_2);
    }

    [Fact]
    public void CurrencyCode3_NotEqual_Tests()
    {
        var currencyCode3_1 = CurrencyCode3.From("RWF");

        var currencyCode3_2 = CurrencyCode3.From("SHP");

        currencyCode3_1.Should().NotBe(currencyCode3_2);
    }

    [Fact]
    public void CurrencyCode3_ToString_ReturnsString()
    {
        var currencyCode3 = CurrencyCode3.From("USD");

        currencyCode3.ToString().Should().Be("USD");
    }
}