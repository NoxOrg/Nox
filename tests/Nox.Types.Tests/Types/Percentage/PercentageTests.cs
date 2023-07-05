using FluentAssertions;
using System.Globalization;

namespace Nox.Types.Tests.Types;

public class PercentageTests
{
    [Fact]
    public void Percentage_Constructor_ReturnsSameValue()
    {
        var testPercentage = 0.5f;

        var number = Percentage.From(testPercentage);

        number.Value.Should().Be(testPercentage);
    }

    [Fact]
    public void Percentage_Constructor_ThrowsException_WhenValueExceedsMaxAllowed()
    {
        var testPercentage = 3.2f;

        var action = () => Percentage.From(testPercentage);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Percentage type a value 3.2 is greater than than the maximum specified value of 1") });

    }

    [Fact]
    public void Percentage_Constructor_ThrowsException_WhenValueIsLessThanMinAllowed()
    {
        var testPercentage = -0.3f;

        var action = () => Percentage.From(testPercentage);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Percentage type as value -0.3 is less than than the minimum specified value of 0") });
    }

    [Fact]
    public void Percentage_Constructor_RoundsFloatValues_WhenConstructedWithFloatInput()
    {
        var testPercentage = 0.4f;

        var percentage = Percentage.From(testPercentage);

        percentage.Value.Should().Be(0.4f);
    }

    [Fact]
    public void Percentage_ToString_Returns_Value()
    {
        void Test()
        {
            var pecentageValue = 0.45f;

            var percentage = Percentage.From(pecentageValue);

            var percentageAsString = percentage.ToString();

            Assert.Equal("45%", percentageAsString);
        }

        TestUtility.RunInInvariantCulture(Test);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("pt-PT")]
    public void Percentage_ValueInFloat_ToString_IsCultureIndepdendent(string culture)
    {
        void Test()
        {
            var percentage = Percentage.From(0.25f);
            percentage.ToString().Should().Be("25%");
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US", "0.43%")]
    [InlineData("pt-PT", "0,43%")]
    public void Percentage_ValueInFloat_ToString_IsCultureDependent(string culture, string expected)
    {
        void Test()
        {
            var percentage = Percentage.From(0.43f);
            percentage.ToString(new CultureInfo(culture)).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }
}