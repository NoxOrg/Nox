using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class YearTests
{
    [Fact]
    public void Year_Constructor_ReturnsSameValue()
    {
        var testYear = (ushort)1900;

        var number = Year.From(testYear);

        number.Value.Should().Be(testYear);
    }

    [Theory]
    [InlineData((ushort)0)]
    [InlineData((ushort)(100))]
    [InlineData((ushort)(1889))]
    [InlineData((ushort)(1880))]
    public void Year_Constructor_WithValueLess_ThanMinimiunSpecified_ThrowsValidationException(ushort value)
    {
        // Arrange & Act
        var action = () => Year.From(value);

        // Assert
        action.Should().Throw<TypeValidationException>().And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox Year type as value {value} is less than the minimum specified value of 1900") });
    }

    [Theory]
    [InlineData((ushort)3001)]
    [InlineData((ushort)(4001))]
    [InlineData((ushort)(5000))]
    [InlineData((ushort)(9999))]
    public void Year_Constructor_WithValueGreater_ThanMaximunSpecified_ThrowsValidationException(ushort value)
    {
        // Arrange & Act
        var action = () => Year.From(value);

        // Assert
        action.Should().Throw<TypeValidationException>().And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox Year type a value {value} is greater than the maximum specified value of 3000") });
    }

    [Fact]
    public void Year_Equal_Tests()
    {
        // Arrange
        var year1 = Year.From(1900);

        var year2 = Year.From(1900);

        // Assert
        year1.Should().Be(year2);
    }

    [Fact]
    public void Year_NotEqual_Tests()
    {
        // Arrange
        var year1 = Year.From(2000);

        var year2 = Year.From(2002);

        // Assert
        year1.Should().NotBe(year2);
    }


    [Fact]
    public void Year_ToString_ReturnsString()
    {
        // Arrange
        var year = Year.From(1900);
        var year2 = Year.From(1990);

        // Assert
        year.ToString().Should().Be("1900");
        year2.ToString().Should().Be("1990");
    }

    [Fact]
    public void Year_Constructor_SpecifyingAllowFutureOnly_WithPassYearInput_ThrowsException()
    {
        // Arrange
        var yearValue = (ushort)2020;

        // Act 
        var action = () => Year.From(yearValue, new YearTypeOptions { AllowFutureOnly = true });

        // Assert 
        action.Should().Throw<TypeValidationException>().And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox Year type a value 2020 is less than the current year") });
    }

    [Fact]
    public void Year_Constructor_SpecifyingMaxValue_WithGreaterValueInput_ThrowsException()
    {
        // Arrange
        var yearValue = (ushort)1900;

        // Act
        var action = () => Year.From(yearValue, new YearTypeOptions { MaxValue = 10 });

        // Assert 
        action.Should().Throw<TypeValidationException>().And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox Year type a value 1900 is greater than the maximum specified value of 10") });
    }

    [Fact]
    public void Year_Constructor_SpecifyingMinValue_WithLesserValueInput_ThrowsException()
    {
        // Arrange
        var yearValue = (ushort)1;

        // Act
        var action = () => Year.From(yearValue, new YearTypeOptions { MinValue = 50 });

        // Assert 
        action.Should().Throw<TypeValidationException>().And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox Year type as value 1 is less than the minimum specified value of 50") });
    }
}