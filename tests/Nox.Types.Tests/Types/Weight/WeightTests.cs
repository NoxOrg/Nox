// ReSharper disable once CheckNamespace
using FluentAssertions;
using FluentAssertions.Execution;

using System.Globalization;

namespace Nox.Types.Tests.Types;

public class WeightTests
{
    [Fact]
    public void WeightTypeOptions_Constructor_ReturnsDefaultValues()
    {
        var typeOptions = new WeightTypeOptions();

        typeOptions.MinValue.Should().Be(0);
        typeOptions.MaxValue.Should().Be(999_999_999_999_999);
        typeOptions.Units.Should().Be(WeightTypeUnit.Kilogram);
        typeOptions.PersistAs.Should().Be(WeightTypeUnit.Kilogram);
    }

    [Fact]
    public void Weight_Constructor_ReturnsSameValueAndDefaultUnit()
    {
        var weight = Weight.From(104.55);

        weight.Value.Should().Be(104.55);
        weight.Unit.Should().Be(WeightTypeUnit.Kilogram);
    }

    [Fact]
    public void Weight_Constructor_WithUnit_ReturnsSameValueAndUnit()
    {
        var weight = Weight.From(230.493295, WeightTypeUnit.Pound);

        weight.Value.Should().Be(230.493295);
        weight.Unit.Should().Be(WeightTypeUnit.Pound);
    }

    [Fact]
    public void Distance_Constructor_SpecifyingMaxValue_WithGreaterValueInput_ThrowsException()
    {
        void Test()
        {
            var action = () =>
                Weight.From(7.5, new WeightTypeOptions { MaxValue = 5, Units = WeightTypeUnit.Kilogram });

            action.Should().Throw<TypeValidationException>()
                .And.Errors.Should().BeEquivalentTo(new[]
                {
                    new ValidationFailure("Value",
                        "Could not create a Nox Weight type as value 7.5 kg is greater than the specified maximum of 5 kg.")
                });
        }

        TestUtility.RunInInvariantCulture(Test);
    }

    [Fact]
    public void Weight_Constructor_SpecifyingMinValue_WithLesserValueInput_ThrowsException()
    {
        void Test()
        {
            var action = () =>
                Weight.From(7.5, new WeightTypeOptions { MinValue = 10, Units = WeightTypeUnit.Kilogram });

            action.Should().Throw<TypeValidationException>()
                .And.Errors.Should().BeEquivalentTo(new[]
                {
                    new ValidationFailure("Value",
                        "Could not create a Nox Weight type as value 7.5 kg is lesser than the specified minimum of 10 kg.")
                });
        }

        TestUtility.RunInInvariantCulture(Test);
    }

    [Fact]
    public void Weight_Constructor_WithNegativeValueInput_ThrowsException()
    {
        var action = () => Weight.From(-100);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Weight type as negative weight value -100 is not allowed.") });
    }

    [Fact]
    public void Weight_Constructor_WithNaNValueInput_ThrowsException()
    {
        var action = () => Weight.From(double.NaN);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox type as value NaN is not allowed.") });
    }

    [Fact]
    public void Weight_Constructor_WithPositiveInfinityValueInput_ThrowsException()
    {
        var action = () => Weight.From(double.PositiveInfinity);


        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox type as value Infinity is not allowed.") });
    }

    [Fact]
    public void Weight_Constructor_WithNegativeInfinityValueInput_ThrowsException()
    {
        var action = () => Weight.From(double.NegativeInfinity);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox type as value Infinity is not allowed.") });
    }

    [Fact]
    public void Weight_ToKilograms_ReturnsValueInKilograms()
    {
        var weight = Weight.From(104.55);

        weight.ToKilograms().Should().Be(104.55);
    }

    [Fact]
    public void Weight_ToPounds_ReturnsValueInPounds()
    {
        var weight = Weight.From(104.55);

        weight.ToPounds().Should().Be(230.493295);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("pt-PT")]
    public void Weight_ValueInKilograms_ToString_IsCultureIndepdendent(string culture)
    {
        void Test()
        {
            var weight = Weight.From(104.55, WeightTypeUnit.Kilogram);
            weight.ToString().Should().Be("104.55 kg");
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US", "104.55 kg")]
    [InlineData("pt-PT", "104,55 kg")]
    public void Weight_ValueInKilograms_ToString_IsCultureDependent(string culture, string expected)
    {
        void Test()
        {
            var weight = Weight.From(104.55, WeightTypeUnit.Kilogram);
            weight.ToString(new CultureInfo(culture)).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("pt-PT")]
    public void Weight_ValueInPounds_ToString_IsCultureIndependent(string culture)
    {
        void Test()
        {
            var weight = Weight.From(230.493295, WeightTypeUnit.Pound);
            weight.ToString().Should().Be("230.493295 lb");
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US", "230.493295 lb")]
    [InlineData("pt-PT", "230,493295 lb")]
    public void Weight_ValueInPounds_ToString_IsCultureDependent(string culture, string expected)
    {
        void Test()
        {
            var weight = Weight.From(230.493295, WeightTypeUnit.Pound);
            weight.ToString(new CultureInfo(culture)).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Fact]
    public void Weight_Equality_SpecifyingWeightUnit_WithSameUnit_Tests()
    {
        var weight1 = Weight.From(104.55, WeightTypeUnit.Kilogram);

        var weight2 = Weight.From(104.55, WeightTypeUnit.Kilogram);

        AssertAreEquivalent(weight1, weight2);
    }

    [Fact]
    public void Weight_Equality_SpecifyingWeightUnit_WithDifferentUnit_Tests()
    {
        var weight1 = Weight.From(104.55, WeightTypeUnit.Kilogram);

        var weight2 = Weight.From(230.493295, WeightTypeUnit.Pound);

        AssertAreEquivalent(weight1, weight2);
    }

    [Fact]
    public void Weight_NonEquality_SpecifyingWeightUnit_WithSameUnit_Tests()
    {
        var weight1 = Weight.From(104.55, WeightTypeUnit.Kilogram);

        var weight2 = Weight.From(230.493295, WeightTypeUnit.Kilogram);

        AssertAreNotEquivalent(weight1, weight2);
    }

    [Fact]
    public void Weight_NonEquality_SpecifyingWeightUnit_WithDifferentUnit_Tests()
    {
        var weight1 = Weight.From(104.55, WeightTypeUnit.Kilogram);

        var weight2 = Weight.From(104.55, WeightTypeUnit.Pound);

        AssertAreNotEquivalent(weight1, weight2);
    }

    private static void AssertAreEquivalent(Weight expected, Weight actual)
    {
        using (new AssertionScope())
        {
            expected.Equals(actual).Should().BeTrue();

            actual.Equals(expected).Should().BeTrue();

            (expected == actual).Should().BeTrue();

            (expected != actual).Should().BeFalse();
        }
    }

    private static void AssertAreNotEquivalent(Weight expected, Weight actual)
    {
        using (new AssertionScope())
        {
            expected.Equals(actual).Should().BeFalse();

            actual.Equals(expected).Should().BeFalse();

            (expected == actual).Should().BeFalse();

            (expected != actual).Should().BeTrue();
        }
    }
}
