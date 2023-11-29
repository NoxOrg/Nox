using FluentAssertions;
using FluentAssertions.Execution;
using System.Globalization;

namespace Nox.Types.Tests.Types;

public class DistanceTests
{
    [Fact]
    public void DistanceTypeOptions_Constructor_ReturnsDefaultValues()
    {
        var typeOptions = new DistanceTypeOptions();

        typeOptions.MinValue.Should().Be(0);
        typeOptions.MaxValue.Should().Be(999_999_999_999_999);
        typeOptions.Units.Should().Be(DistanceTypeUnit.Kilometer);
        typeOptions.PersistAs.Should().Be(DistanceTypeUnit.Kilometer);
    }

    [Fact]
    public void Distance_Constructor_ReturnsSameValueAndDefaultUnit()
    {
        var distance = Distance.From(314.159);

        distance.Value.Should().Be(314.159);
        distance.Unit.Should().Be(DistanceTypeUnit.Kilometer);
    }

    [Fact]
    public void Distance_Constructor_WithUnit_ReturnsSameValueAndUnit()
    {
        var distance = Distance.From(195.209, DistanceTypeUnit.Mile);

        distance.Value.Should().Be(195.209);
        distance.Unit.Should().Be(DistanceTypeUnit.Mile);
    }

    [Fact]
    public void Distance_Constructor_SpecifyingMaxValue_WithGreaterValueInput_ThrowsException()
    {
        void Test()
        {
            var action = () =>
                Distance.From(7.5, new DistanceTypeOptions { MaxValue = 5, Units = DistanceTypeUnit.Kilometer });

            action.Should().Throw<NoxTypeValidationException>()
                .And.Errors.Should().BeEquivalentTo(new[]
                {
                    new ValidationFailure("Value",
                        "Could not create a Nox Distance type as value 7.5 km is greater than the specified maximum of 5 km.")
                });
        }

        TestUtility.RunInInvariantCulture(Test);
    }

    [Fact]
    public void Distance_Constructor_SpecifyingMinValue_WithLesserValueInput_ThrowsException()
    {
        void Test()
        {
            var action = () =>
                Distance.From(7.5, new DistanceTypeOptions { MinValue = 10, Units = DistanceTypeUnit.Kilometer });

            action.Should().Throw<NoxTypeValidationException>()
                .And.Errors.Should().BeEquivalentTo(new[]
                {
                    new ValidationFailure("Value",
                        "Could not create a Nox Distance type as value 7.5 km is lesser than the specified minimum of 10 km.")
                });
        }

        TestUtility.RunInInvariantCulture(Test);
    }

    [Fact]
    public void Distance_Constructor_WithNegativeValueInput_ThrowsException()
    {
        var action = () => Distance.From(-100);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value",
                "Could not create a Nox Distance type as negative distance value -100 is not allowed.") });
    }

    [Fact]
    public void Distance_Constructor_WithNaNValueInput_ThrowsException()
    {
        var action = () => Distance.From(double.NaN);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value",
                "Could not create a Nox type as value NaN is not allowed.") });
    }

    [Fact]
    public void Distance_Constructor_WithPositiveInfinityValueInput_ThrowsException()
    {
        var action = () => Distance.From(double.PositiveInfinity);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value",
                "Could not create a Nox type as value Infinity is not allowed.") });
    }

    [Fact]
    public void Distance_Constructor_WithNegativeInfinityValueInput_ThrowsException()
    {
        var action = () => Distance.From(double.NegativeInfinity);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value",
                "Could not create a Nox type as value Infinity is not allowed.") });
    }

    [Fact]
    public void Distance_Constructor_WithLatLong_ReturnsCalculatedValueAndDefaultUnit()
    {
        var origin = LatLong.From(46.94809, 7.44744);
        var destination = LatLong.From(46.204391, 6.143158);

        var distance = Distance.From(origin, destination);

        distance.Value.Should().Be(129.522785);
        distance.Unit.Should().Be(DistanceTypeUnit.Kilometer);
    }

    [Fact]
    public void Distance_Constructor_WithLatLongAndUnit_ReturnsCalculatedValueAndSameUnit()
    {
        var origin = LatLong.From(46.94809, 7.44744);
        var destination = LatLong.From(46.204391, 6.143158);

        var distance = Distance.From(origin, destination, DistanceTypeUnit.Mile);

        distance.Value.Should().Be(80.481727);
        distance.Unit.Should().Be(DistanceTypeUnit.Mile);
    }

    [Fact]
    public void Distance_Constructor_SpecifyingMaxValue_WithGreaterValueLatLongInput_ThrowsException()
    {
        void Test()
        {
            var origin = LatLong.From(46.94809, 7.44744);
            var destination = LatLong.From(46.204391, 6.143158);

            var action = () => Distance.From(origin, destination,
                new DistanceTypeOptions { MaxValue = 100, Units = DistanceTypeUnit.Kilometer });

            action.Should().Throw<NoxTypeValidationException>()
                .And.Errors.Should().BeEquivalentTo(new[]
                {
                    new ValidationFailure("Value",
                        "Could not create a Nox Distance type as value 129.522785 km is greater than the specified maximum of 100 km.")
                });
        }

        TestUtility.RunInInvariantCulture(Test);
    }

    [Fact]
    public void Distance_Constructor_SpecifyingMinValue_WithLesserValueLatLongInput_ThrowsException()
    {
        void Test()
        {
            var origin = LatLong.From(46.94809, 7.44744);
            var destination = LatLong.From(46.204391, 6.143158);

            var action = () => Distance.From(origin, destination,
                new DistanceTypeOptions { MinValue = 150, Units = DistanceTypeUnit.Kilometer });

            action.Should().Throw<NoxTypeValidationException>()
                .And.Errors.Should().BeEquivalentTo(new[]
                {
                    new ValidationFailure("Value",
                        "Could not create a Nox Distance type as value 129.522785 km is lesser than the specified minimum of 150 km.")
                });
        }

        TestUtility.RunInInvariantCulture(Test);
    }

    [Fact]
    public void Distance_ToKilometers_ReturnsValueInKilometers()
    {
        var distance = Distance.From(314.159);

        distance.ToKilometers().Should().Be(314.159);
    }

    [Fact]
    public void Distance_ToMiles_ReturnsValueInMiles()
    {
        var distance = Distance.From(314.159);

        distance.ToMiles().Should().Be(195.209352);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("pt-PT")]
    public void Distance_ValueInKilometers_ToString_IsCultureIndepdendent(string culture)
    {
        void Test()
        {
            var distance = Distance.From(314.159, DistanceTypeUnit.Kilometer);
            distance.ToString().Should().Be("314.159 km");
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US", "314.159 km")]
    [InlineData("pt-PT", "314,159 km")]
    public void Distance_ValueInKilometers_ToString_IsCultureDependent(string culture, string expected)
    {
        void Test()
        {
            var distance = Distance.From(314.159, DistanceTypeUnit.Kilometer);
            distance.ToString(new CultureInfo(culture)).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("pt-PT")]
    public void Distance_ValueInMiles_ToString_IsCultureIndependent(string culture)
    {
        void Test()
        {
            var distance = Distance.From(195.209, DistanceTypeUnit.Mile);
            distance.ToString().Should().Be("195.209 mi");
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US", "195.209 mi")]
    [InlineData("pt-PT", "195,209 mi")]
    public void Distance_ValueInMiles_ToString_IsCultureDependent(string culture, string expected)
    {
        void Test()
        {
            var distance = Distance.From(195.209, DistanceTypeUnit.Mile);
            distance.ToString(new CultureInfo(culture)).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Fact]
    public void Distance_Equality_SpecifyingDistanceUnit_WithSameUnit_Tests()
    {
        var distance1 = Distance.From(314.159, DistanceTypeUnit.Kilometer);

        var distance2 = Distance.From(314.159, DistanceTypeUnit.Kilometer);

        AssertAreEquivalent(distance1, distance2);
    }

    [Fact]
    public void Distance_Equality_SpecifyingDistanceUnit_WithDifferentUnit_Tests()
    {
        var distance1 = Distance.From(314.159, DistanceTypeUnit.Kilometer);

        var distance2 = Distance.From(195.209352, DistanceTypeUnit.Mile);

        AssertAreEquivalent(distance1, distance2);
    }

    [Fact]
    public void Distance_NonEquality_SpecifyingDistanceUnit_WithSameUnit_Tests()
    {
        var distance1 = Distance.From(314.159, DistanceTypeUnit.Kilometer);

        var distance2 = Distance.From(195.209352, DistanceTypeUnit.Kilometer);

        AssertAreNotEquivalent(distance1, distance2);
    }

    [Fact]
    public void Distance_NonEquality_SpecifyingDistanceUnit_WithDifferentUnit_Tests()
    {
        var distance1 = Distance.From(314.159, DistanceTypeUnit.Kilometer);

        var distance2 = Distance.From(314.159, DistanceTypeUnit.Mile);

        AssertAreNotEquivalent(distance1, distance2);
    }

    private static void AssertAreEquivalent(Distance expected, Distance actual)
    {
        using var scope = new AssertionScope();

        actual.Should().Be(expected);

        expected.Equals(actual).Should().BeTrue();

        actual.Equals(expected).Should().BeTrue();

        (expected == actual).Should().BeTrue();

        (expected != actual).Should().BeFalse();
    }

    private static void AssertAreNotEquivalent(Distance expected, Distance actual)
    {
        using var scope = new AssertionScope();

        actual.Should().NotBe(expected);

        expected.Equals(actual).Should().BeFalse();

        actual.Equals(expected).Should().BeFalse();

        (expected == actual).Should().BeFalse();

        (expected != actual).Should().BeTrue();
    }
}
