using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class CurrencyNumberTests
{
    [Theory]
    [ClassData(typeof(CurrencyNumberData))]
    public void CurrencyNumber_Constructor_ReturnsSameValue_AllCurrencies(short currencyNumberCode)
    {
        var currencyNumber = CurrencyNumber.From(currencyNumberCode);

        currencyNumber.Value.Should().Be(currencyNumberCode);
    }

    [Fact]
    public void CurrencyNumber_Constructor_WithUnsupportedCurrencyNumber_ThrowsValidationException()
    {
        var action = () => CurrencyNumber.From(991);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox CurrencyNumber type with unsupported value '991'.") });
    }

    [Fact]
    public void CurrencyNumber_Equality_Tests()
    {
        var currencyNumber_1 = CurrencyNumber.From(784);

        var currencyNumber_2 = CurrencyNumber.From(784);

        currencyNumber_1.Should().Be(currencyNumber_2);
    }

    [Fact]
    public void CurrencyNumber_NotEqual_Tests()
    {
        var currencyNumber_1 = CurrencyNumber.From(784);

        var currencyNumber_2 = CurrencyNumber.From(694);

        currencyNumber_1.Should().NotBe(currencyNumber_2);
    }

    [Fact]
    public void CurrencyNumber_ToString_ReturnsString()
    {
        var currencyNumber = CurrencyNumber.From(986);

        currencyNumber.ToString().Should().Be("BRL");
    }
}