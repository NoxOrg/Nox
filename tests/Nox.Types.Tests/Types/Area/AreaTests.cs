using FluentAssertions;
using FluentAssertions.Execution;
using System.Globalization;

namespace Nox.Types.Tests.Types;

public class AreaTests
{
    [Fact]
    public void AreaTypeOptions_Constructor_ReturnsDefaultValues()
    {
        var typeOptions = new AreaTypeOptions();

        typeOptions.MinValue.Should().Be(0);
        typeOptions.MaxValue.Should().Be(999_999_999_999_999);
        typeOptions.Unit.Should().Be(AreaTypeUnit.SquareMeter);
    }

    [Fact]
    public void Area_Constructor_ReturnsSameValueAndDefaultUnit()
    {
        var area = Area.From(12.5);

        area.Value.Should().Be(12.5);
        area.Unit.Should().Be(AreaUnit.SquareMeter);
    }

    [Fact]
    public void Area_Constructor_ReturnsRoundedValueAndDefaultUnit()
    {
        var area = Area.From(12.54888020887151);

        area.Value.Should().Be(12.548880);
        area.Unit.Should().Be(AreaUnit.SquareMeter);
    }

    [Fact]
    public void Area_Constructor_WithUnit_ReturnsSameValueAndUnit()
    {
        var area = Area.From(12.5, AreaUnit.SquareMeter);

        area.Value.Should().Be(12.5);
        area.Unit.Should().Be(AreaUnit.SquareMeter);
    }

    [Fact]
    public void Area_Constructor_SpecifyingMaxValue_WithGreaterValueInput_ThrowsException()
    {
        var action = () => Area.From(12.5, AreaUnit.SquareMeter, new AreaTypeOptions { MaxValue = 10 });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Area type as value 12.5 m² is greater than the specified maximum of 10 m².") });
    }

    [Fact]
    public void Area_Constructor_SpecifyingMinValue_WithLesserValueInput_ThrowsException()
    {
        var action = () => Area.From(12.5, AreaUnit.SquareMeter, new AreaTypeOptions { MinValue = 15 });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Area type as value 12.5 m² is lesser than the specified minimum of 15 m².") });
    }

    [Fact]
    public void Area_Constructor_WithUnitInSquareMeters_ReturnsSameValueAndUnit()
    {
        var area = Area.FromSquareMeters(12.5);

        area.Value.Should().Be(12.5);
        area.Unit.Should().Be(AreaUnit.SquareMeter);
    }

    [Fact]
    public void Area_Constructor_WithUnitInSquareMeters_SpecifyingMaxValue_WithGreaterValueInput_ThrowsException()
    {
        var action = () => Area.FromSquareMeters(12.5, new AreaTypeOptions { MaxValue = 10 });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Area type as value 12.5 m² is greater than the specified maximum of 10 m².") });
    }

    [Fact]
    public void Area_Constructor_WithUnitInSquareMeters_SpecifyingMinValue_WithLesserValueInput_ThrowsException()
    {
        var action = () => Area.FromSquareMeters(12.5, new AreaTypeOptions { MinValue = 15 });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Area type as value 12.5 m² is lesser than the specified minimum of 15 m².") });
    }

    [Fact]
    public void Area_Constructor_WithUnitInSquareFeet_ReturnsSameValueAndUnit()
    {
        var area = Area.FromSquareFeet(134.548880);

        area.Value.Should().Be(134.548880);
        area.Unit.Should().Be(AreaUnit.SquareFoot);
    }

    [Fact]
    public void Area_Constructor_WithUnitInSquareFeet_SpecifyingMaxValue_WithGreaterValueInput_ThrowsException()
    {
        var action = () => Area.FromSquareFeet(12.5, new AreaTypeOptions { MaxValue = 1 });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Area type as value 12.5 ft² is greater than the specified maximum of 1 m².") });
    }

    [Fact]
    public void Area_Constructor_WithUnitInSquareFeet_SpecifyingMinValue_WithLesserValueInput_ThrowsException()
    {
        var action = () => Area.FromSquareFeet(12.5, new AreaTypeOptions { MinValue = 1.5 });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Area type as value 12.5 ft² is lesser than the specified minimum of 1.5 m².") });
    }

    [Fact]
    public void Area_Constructor_WithNegativeValueInput_ThrowsException()
    {
        void Test()
        {
            var action = () => Area.From(-12.5);

            action.Should().Throw<TypeValidationException>()
                .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Area type as negative area value -12.5 is not allowed.") });
        }

        TestUtility.RunInInvariantCulture(Test);
    }

    [Fact]
    public void Area_Constructor_WithNaNValueInput_ThrowsException()
    {
        var action = () => Area.From(double.NaN);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox type as value NaN is not allowed.") });
    }

    [Fact]
    public void Area_Constructor_WithPositiveInfinityValueInput_ThrowsException()
    {
        var action = () => Area.From(double.PositiveInfinity);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox type as value Infinity is not allowed.") });
    }

    [Fact]
    public void Area_Constructor_WithNegativeInfinityValueInput_ThrowsException()
    {
        var action = () => Area.From(double.NegativeInfinity);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox type as value Infinity is not allowed.") });
    }

    [Fact]
    public void Area_ToSquareMeters_ReturnsValue()
    {
        var squareMeters = 12.5;

        var area = Area.From(squareMeters);

        area.ToSquareMeters().Should().Be(12.5);
    }

    [Fact]
    public void Area_ToSquareFeet_ReturnsValue()
    {
        var squareMeters = 12.5;

        var area = Area.From(squareMeters);

        area.ToSquareFeet().Should().Be(134.54888);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("pt-PT")]
    public void Area_ValueInSquareMeters_ToString_IsCultureIndepdendent(string culture)
    {
        void Test()
        {
            var area = Area.FromSquareMeters(12.5);
            area.ToString().Should().Be("12.5 m²");
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US", "12.5 m²")]
    [InlineData("pt-PT", "12,5 m²")]
    public void Area_ValueInSquareMeters_ToString_IsCultureDependent(string culture, string expected)
    {
        void Test()
        {
            var area = Area.FromSquareMeters(12.5);
            area.ToString(new CultureInfo(culture)).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("pt-PT")]
    public void Area_ValueInSquareFeet_ToString_IsCultureIndependent(string culture)
    {
        void Test()
        {
            var area = Area.FromSquareFeet(134.548880);
            area.ToString().Should().Be("134.54888 ft²");
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US", "134.54888 ft²")]
    [InlineData("pt-PT", "134,54888 ft²")]
    public void Area_ValueInSquareFeet_ToString_IsCultureDependent(string culture, string expected)
    {
        void Test()
        {
            var area = Area.FromSquareFeet(134.548880);
            area.ToString(new CultureInfo(culture)).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Fact]
    public void Area_Equality_WithSameAreaUnit_Tests()
    {
        var squareMeters = 12.5;

        var area1 = Area.From(squareMeters, AreaUnit.SquareMeter);

        var area2 = Area.From(squareMeters, AreaUnit.SquareMeter);

        AssertAreEquivalent(area1, area2);
    }

    [Fact]
    public void Area_Equality_WithDifferentAreaUnit_Tests()
    {
        var squareMeters = 12.5;
        var area1 = Area.From(squareMeters, AreaUnit.SquareMeter);

        var squareFeetValue = 134.54888; // 12.5 m²
        var area2 = Area.From(squareFeetValue, AreaUnit.SquareFoot);

        AssertAreEquivalent(area1, area2);
    }

    [Fact]
    public void Area_NonEquality_SpecifyingAreaUnit_WithSameUnit_Tests()
    {
        var squareMeters1 = 12.5;
        var area1 = Area.From(squareMeters1, AreaUnit.SquareMeter);

        var squareMeters2 = 13.0;
        var area2 = Area.From(squareMeters2, AreaUnit.SquareMeter);

        AssertAreNotEquivalent(area1, area2);
    }

    [Fact]
    public void Area_NonEquality_SpecifyingAreaUnit_WithDifferentUnit_Tests()
    {
        var squareMeters = 12.5;
        var area1 = Area.From(squareMeters, AreaUnit.SquareMeter);

        var squareFeet = 139.930835; // 13 m²
        var area2 = Area.From(squareFeet, AreaUnit.SquareFoot);

        AssertAreNotEquivalent(area1, area2);
    }

    private static void AssertAreEquivalent(Area expected, Area actual)
    {
        using var scope = new AssertionScope();

        actual.Should().Be(expected);

        expected.Equals(actual).Should().BeTrue();

        actual.Equals(expected).Should().BeTrue();

        (expected == actual).Should().BeTrue();

        (expected != actual).Should().BeFalse();
    }

    private static void AssertAreNotEquivalent(Area expected, Area actual)
    {
        using var scope = new AssertionScope();

        actual.Should().NotBe(expected);

        expected.Equals(actual).Should().BeFalse();

        actual.Equals(expected).Should().BeFalse();

        (expected == actual).Should().BeFalse();

        (expected != actual).Should().BeTrue();
    }
}
