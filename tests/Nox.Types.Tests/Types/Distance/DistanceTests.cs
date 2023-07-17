using FluentAssertions;
using System.Globalization;

namespace Nox.Types.Tests.Types;

public class DistanceTests
{
    [Fact]
    public void Distance_Constructor_ReturnsSameValueAndDefaultUnit()
    {
        var distance = Distance.From(314.159);

        distance.Value.Should().Be(314.159);
        distance.Unit.Should().Be(DistanceUnit.Kilometer);
    }

    [Fact]
    public void Distance_Constructor_WithUnit_ReturnsSameValueAndUnit()
    {
        var distance = Distance.From(195.209, DistanceUnit.Mile);

        distance.Value.Should().Be(195.209);
        distance.Unit.Should().Be(DistanceUnit.Mile);
    }

    [Fact]
    public void Distance_Constructor_WithUnitInKilometers_ReturnsSameValueAndUnit()
    {
        var distance = Distance.FromKilometers(314.159);

        distance.Value.Should().Be(314.159);
        distance.Unit.Should().Be(DistanceUnit.Kilometer);
    }

    [Fact]
    public void Distance_Constructor_WithLatLongAndUnitInKilometers_ReturnsCalculatedValueAndSameUnit()
    {
        var origin = LatLong.From(46.94809, 7.44744);
        var destination = LatLong.From(46.204391, 6.143158);

        var distance = Distance.FromKilometers(origin, destination);

        distance.Value.Should().Be(129.522785);
        distance.Unit.Should().Be(DistanceUnit.Kilometer);
    }

    [Fact]
    public void Distance_Constructor_WithUnitInMiles_ReturnsSameValueAndUnit()
    {
        var distance = Distance.FromMiles(195.209);

        distance.Value.Should().Be(195.209);
        distance.Unit.Should().Be(DistanceUnit.Mile);
    }

    [Fact]
    public void Distance_Constructor_WithLatLongAndUnitInMiles_ReturnsCalculatedValueAndSameUnit()
    {
        var origin = LatLong.From(46.94809, 7.44744);
        var destination = LatLong.From(46.204391, 6.143158);

        var distance = Distance.FromMiles(origin, destination);

        distance.Value.Should().Be(80.481727);
        distance.Unit.Should().Be(DistanceUnit.Mile);
    }

    [Fact]
    public void Distance_Constructor_WithNegativeValueInput_ThrowsException()
    {
        var action = () => Distance.From(-100);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Distance type as negative distance value -100 is not allowed.") });
    }

    [Fact]
    public void Distance_Constructor_WithNaNValueInput_ThrowsException()
    {
        var action = () => Distance.From(double.NaN);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox type as value NaN is not allowed.") });
    }

    [Fact]
    public void Distance_Constructor_WithPositiveInfinityValueInput_ThrowsException()
    {
        var action = () => Distance.From(double.PositiveInfinity);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox type as value Infinity is not allowed.") });
    }

    [Fact]
    public void Distance_Constructor_WithNegativeInfinityValueInput_ThrowsException()
    {
        var action = () => Distance.From(double.NegativeInfinity);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox type as value Infinity is not allowed.") });
    }

    [Fact]
    public void Distance_ToKilometers_ReturnsValueInKilometers()
    {
        var distance = Distance.FromKilometers(314.159);

        distance.ToKilometers().Should().Be(314.159);
    }

    [Fact]
    public void Distance_ToMiles_ReturnsValueInMiles()
    {
        var distance = Distance.FromKilometers(314.159);

        distance.ToMiles().Should().Be(195.209352);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("pt-PT")]
    public void Distance_ValueInKilometers_ToString_IsCultureIndepdendent(string culture)
    {
        void Test()
        {
            var distance = Distance.FromKilometers(314.159);
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
            var distance = Distance.FromKilometers(314.159);
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
            var distance = Distance.FromMiles(195.209);
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
            var distance = Distance.FromMiles(195.209);
            distance.ToString(new CultureInfo(culture)).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Fact]
    public void Distance_Equality_SpecifyingDistanceUnit_WithSameUnit_Tests()
    {
        var distance1 = Distance.FromKilometers(314.159);

        var distance2 = Distance.FromKilometers(314.159);

        AssertAreEquivalent(distance1, distance2);
    }

    [Fact]
    public void Distance_Equality_SpecifyingDistanceUnit_WithDifferentUnit_Tests()
    {
        var distance1 = Distance.FromKilometers(314.159);

        var distance2 = Distance.FromMiles(195.209352);

        AssertAreEquivalent(distance1, distance2);
    }

    [Fact]
    public void Distance_NonEquality_SpecifyingDistanceUnit_WithSameUnit_Tests()
    {
        var distance1 = Distance.FromKilometers(314.159);

        var distance2 = Distance.FromKilometers(195.209352);

        AssertAreNotEquivalent(distance1, distance2);
    }

    [Fact]
    public void Distance_NonEquality_SpecifyingDistanceUnit_WithDifferentUnit_Tests()
    {
        var distance1 = Distance.FromKilometers(314.159);

        var distance2 = Distance.FromMiles(314.159);

        AssertAreNotEquivalent(distance1, distance2);
    }

    private static void AssertAreEquivalent(Distance expected, Distance actual)
    {
        actual.Should().Be(expected);

        expected.Equals(actual).Should().BeTrue();

        actual.Equals(expected).Should().BeTrue();

        (expected == actual).Should().BeTrue();

        (expected != actual).Should().BeFalse();
    }

    private static void AssertAreNotEquivalent(Distance expected, Distance actual)
    {
        actual.Should().NotBe(expected);

        expected.Equals(actual).Should().BeFalse();

        actual.Equals(expected).Should().BeFalse();

        (expected == actual).Should().BeFalse();

        (expected != actual).Should().BeTrue();
    }
}
