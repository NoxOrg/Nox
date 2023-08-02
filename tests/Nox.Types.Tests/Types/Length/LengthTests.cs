// ReSharper disable once CheckNamespace
using FluentAssertions;
using FluentAssertions.Execution;
using System.Globalization;

namespace Nox.Types.Tests.Types;

public class LengthTests
{
    [Fact]
    public void LengthTypeOptions_Constructor_ReturnsDefaultValues()
    {
        var typeOptions = new LengthTypeOptions();

        typeOptions.MinValue.Should().Be(0);
        typeOptions.MaxValue.Should().Be(999_999_999_999_999);
        typeOptions.Units.Should().Be(LengthTypeUnit.Meter);
        typeOptions.PersistAs.Should().Be(LengthTypeUnit.Meter);
    }

    [Fact]
    public void Length_Constructor_ReturnsSameValueAndDefaultUnit()
    {
        var length = Length.From(95.755663);

        length.Value.Should().Be(95.755663);
        length.Unit.Should().Be(LengthTypeUnit.Meter);
    }

    [Fact]
    public void Length_Constructor_WithUnit_ReturnsSameValueAndUnit()
    {
        var length = Length.From(314.158999, LengthTypeUnit.Foot);

        length.Value.Should().Be(314.158999);
        length.Unit.Should().Be(LengthTypeUnit.Foot);
    }

    [Fact]
    public void Length_Constructor_SpecifyingMaxValue_WithGreaterValueInput_ThrowsException()
    {
        var action = () => Length.From(7.5, new LengthTypeOptions { MaxValue = 5, Units = LengthTypeUnit.Meter });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value",
                "Could not create a Nox Length type as value 7.5 m is greater than the specified maximum of 5 m.") });
    }

    [Fact]
    public void Length_Constructor_SpecifyingMinValue_WithLesserValueInput_ThrowsException()
    {
        var action = () => Length.From(7.5, new LengthTypeOptions { MinValue = 10, Units = LengthTypeUnit.Meter });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", 
                "Could not create a Nox Length type as value 7.5 m is lesser than the specified minimum of 10 m.") });
    }

    [Fact]
    public void Length_Constructor_WithNegativeValueInput_ThrowsException()
    {
        var action = () => Length.From(-100);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value",
                "Could not create a Nox Length type as negative length value -100 is not allowed.") });
    }

    [Fact]
    public void Length_Constructor_WithNaNValueInput_ThrowsException()
    {
        var action = () => Length.From(double.NaN);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value",
                "Could not create a Nox type as value NaN is not allowed.") });
    }

    [Fact]
    public void Length_Constructor_WithPositiveInfinityValueInput_ThrowsException()
    {
        var action = () => Length.From(double.PositiveInfinity);


        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value",
                "Could not create a Nox type as value Infinity is not allowed.") });
    }

    [Fact]
    public void Length_Constructor_WithNegativeInfinityValueInput_ThrowsException()
    {
        var action = () => Length.From(double.NegativeInfinity);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value",
                "Could not create a Nox type as value Infinity is not allowed.") });
    }

    [Fact]
    public void Length_ToMeters_ReturnsValueInMeters()
    {
        var length = Length.From(95.755663);

        length.ToMeters().Should().Be(95.755663);
    }

    [Fact]
    public void Length_ToFeet_ReturnsValueInFeet()
    {
        var length = Length.From(95.755663);

        length.ToFeet().Should().Be(314.158999);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("pt-PT")]
    public void Length_ValueInMeters_ToString_IsCultureIndepdendent(string culture)
    {
        void Test()
        {
            var length = Length.From(95.755663, LengthTypeUnit.Meter);
            length.ToString().Should().Be("95.755663 m");
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US", "95.755663 m")]
    [InlineData("pt-PT", "95,755663 m")]
    public void Length_ValueInMeters_ToString_IsCultureDependent(string culture, string expected)
    {
        void Test()
        {
            var length = Length.From(95.755663, LengthTypeUnit.Meter);
            length.ToString(new CultureInfo(culture)).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("pt-PT")]
    public void Length_ValueInFeet_ToString_IsCultureIndependent(string culture)
    {
        void Test()
        {
            var length = Length.From(314.158999, LengthTypeUnit.Foot);
            length.ToString().Should().Be("314.158999 ft");
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US", "314.158999 ft")]
    [InlineData("pt-PT", "314,158999 ft")]
    public void Length_ValueInFeet_ToString_IsCultureDependent(string culture, string expected)
    {
        void Test()
        {
            var length = Length.From(314.158999, LengthTypeUnit.Foot);
            length.ToString(new CultureInfo(culture)).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Fact]
    public void Length_Equality_SpecifyingLengthUnit_WithSameUnit_Tests()
    {
        var length1 = Length.From(95.755663, LengthTypeUnit.Meter);

        var length2 = Length.From(95.755663, LengthTypeUnit.Meter);

        AssertAreEquivalent(length1, length2);
    }

    [Fact]
    public void Length_Equality_SpecifyingLengthUnit_WithDifferentUnit_Tests()
    {
        var length1 = Length.From(95.755663, LengthTypeUnit.Meter);

        var length2 = Length.From(314.158999, LengthTypeUnit.Foot);

        AssertAreEquivalent(length1, length2);
    }

    [Fact]
    public void Length_NonEquality_SpecifyingLengthUnit_WithSameUnit_Tests()
    {
        var length1 = Length.From(95.755663, LengthTypeUnit.Meter);

        var length2 = Length.From(314.158999, LengthTypeUnit.Meter);

        AssertAreNotEquivalent(length1, length2);
    }

    [Fact]
    public void Length_NonEquality_SpecifyingLengthUnit_WithDifferentUnit_Tests()
    {
        var length1 = Length.From(95.755663, LengthTypeUnit.Meter);

        var length2 = Length.From(95.755663, LengthTypeUnit.Foot);
        
        AssertAreNotEquivalent(length1, length2);
    }

    private static void AssertAreEquivalent(Length expected, Length actual)
    {
        using var scope = new AssertionScope();

        actual.Should().Be(expected);

        expected.Equals(actual).Should().BeTrue();

        actual.Equals(expected).Should().BeTrue();

        (expected == actual).Should().BeTrue();

        (expected != actual).Should().BeFalse();
    }

    private static void AssertAreNotEquivalent(Length expected, Length actual)
    {
        using var scope = new AssertionScope();

        actual.Should().NotBe(expected);

        expected.Equals(actual).Should().BeFalse();

        actual.Equals(expected).Should().BeFalse();

        (expected == actual).Should().BeFalse();

        (expected != actual).Should().BeTrue();
    }
}
