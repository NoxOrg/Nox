using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class DayOfWeekTests
{
    [Fact]
    public void DayOfWeek_Constructor_ReturnsSameValue()
    {
        var testDayOfWeek = 1;

        var number = DayOfWeek.From(testDayOfWeek);

        number.Value.Should().Be(testDayOfWeek);
    }

    [Theory]
    [InlineData(-6)]
    [InlineData((-1))]
    [InlineData((-4))]
    public void DayOfWeek_Constructor_WithValueLess_ThanMinimiunSpecified_ThrowsValidationException(int value)
    {
        // Arrange & Act
        var action = () => DayOfWeek.From(value);

        // Assert
        action.Should().Throw<TypeValidationException>().And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox DayOfWeek type as value {value} is less than the minimum specified value of 0") });
    }

    [Theory]
    [InlineData(7)]
    [InlineData(10)]
    [InlineData(20)]
    public void DayOfWeek_Constructor_WithValueGreater_ThanMaximunSpecified_ThrowsValidationException(int value)
    {
        // Arrange & Act
        var action = () => DayOfWeek.From(value);

        // Assert
        action.Should().Throw<TypeValidationException>().And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox DayOfWeek type a value {value} is greater than the maximum specified value of 6") });
    }

    [Fact]
    public void DayOfWeek_Equal_Tests()
    {
        // Arrange
        var dayOfWeek1 = DayOfWeek.From(1);

        var DayOfWeek2 = DayOfWeek.From(1);

        // Assert
        dayOfWeek1.Should().Be(DayOfWeek2);
    }

    [Fact]
    public void DayOfWeek_NotEqual_Tests()
    {
        // Arrange
        var DayOfWeek1 = DayOfWeek.From(1);

        var DayOfWeek2 = DayOfWeek.From(2);

        // Assert
        DayOfWeek1.Should().NotBe(DayOfWeek2);
    }


    [Fact]
    public void DayOfWeek_ToString_ReturnsString()
    {
        // Arrange
        var dayOfWeek = DayOfWeek.From(1);
        var dayOfWeek2 = DayOfWeek.From(2);

        // Assert
        dayOfWeek.ToString().Should().Be("Monday");
        dayOfWeek2.ToString().Should().Be("Tuesday");
    }
}
