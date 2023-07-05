using System.Globalization;

namespace Nox.Types.Tests.Types;

public class DistanceTests
{
    [Fact]
    public void Distance_Constructor_ReturnsSameValueAndDefaultUnit()
    {
        var distance = Distance.From(314.159);

        Assert.Equal(314.159, distance.Value);
        Assert.Equal(DistanceTypeUnit.Kilometer, distance.Unit);
    }

    [Fact]
    public void Distance_Constructor_WithUnit_ReturnsSameValueAndUnit()
    {
        var distance = Distance.From(195.209, DistanceTypeUnit.Mile);

        Assert.Equal(195.209, distance.Value);
        Assert.Equal(DistanceTypeUnit.Mile, distance.Unit);
    }

    [Fact]
    public void Distance_Constructor_WithUnitInKilometers_ReturnsSameValueAndUnit()
    {
        var distance = Distance.FromKilometers(314.159);

        Assert.Equal(314.159, distance.Value);
        Assert.Equal(DistanceTypeUnit.Kilometer, distance.Unit);
    }

    [Fact]
    public void Distance_Constructor_WithLatLongAndUnitInKilometers_ReturnsCalculatedValueAndSameUnit()
    {
        var origin = LatLong.From(46.94809, 7.44744);
        var destination = LatLong.From(46.204391, 6.143158);

        var distance = Distance.FromKilometers(origin, destination);

        Assert.Equal(129.522785, distance.Value);
        Assert.Equal(DistanceTypeUnit.Kilometer, distance.Unit);
    }

    [Fact]
    public void Distance_Constructor_WithUnitInMiles_ReturnsSameValueAndUnit()
    {
        var distance = Distance.FromMiles(195.209);

        Assert.Equal(195.209, distance.Value);
        Assert.Equal(DistanceTypeUnit.Mile, distance.Unit);
    }

    [Fact]
    public void Distance_Constructor_WithLatLongAndUnitInMiles_ReturnsCalculatedValueAndSameUnit()
    {
        var origin = LatLong.From(46.94809, 7.44744);
        var destination = LatLong.From(46.204391, 6.143158);

        var distance = Distance.FromMiles(origin, destination);

        Assert.Equal(80.481727, distance.Value);
        Assert.Equal(DistanceTypeUnit.Mile, distance.Unit);
    }

    [Fact]
    public void Distance_Constructor_WithNegativeValueInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Distance.From(-100)
        );

        Assert.Equal("Could not create a Nox Distance type as negative distance value -100 is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Distance_Constructor_WithNaNValueInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Distance.From(double.NaN)
        );

        Assert.Equal("Could not create a Nox type as value NaN is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Distance_Constructor_WithPositiveInfinityValueInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Distance.From(double.PositiveInfinity)
        );

        Assert.Equal("Could not create a Nox type as value Infinity is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Distance_Constructor_WithNegativeInfinityValueInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Distance.From(double.NegativeInfinity)
        );

        Assert.Equal("Could not create a Nox type as value Infinity is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Distance_Constructor_WithWithUnsupportedUnitInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Distance.From(314.159, (DistanceTypeUnit)1001)
        );

        Assert.Equal("Could not create a Nox Distance type as unit 1001 is not supported.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Distance_ToKilometers_ReturnsValueInKilometers()
    {
        var distance = Distance.FromKilometers(314.159);

        Assert.Equal(314.159, distance.ToKilometers());
    }

    [Fact]
    public void Distance_ToMiles_ReturnsValueInMiles()
    {
        var distance = Distance.FromKilometers(314.159);

        Assert.Equal(195.209352, distance.ToMiles());
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("pt-PT")]
    public void Distance_ValueInKilometers_ToString_IsCultureIndepdendent(string culture)
    {
        void Test()
        {
            var distance = Distance.FromKilometers(314.159);
            Assert.Equal("314.159 km", distance.ToString());
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
            Assert.Equal(expected, distance.ToString(new CultureInfo(culture)));
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
            Assert.Equal("195.209 mi", distance.ToString());
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
            Assert.Equal(expected, distance.ToString(new CultureInfo(culture)));
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
        Assert.Equal(expected, actual);

        Assert.True(expected.Equals(actual));

        Assert.True(actual.Equals(expected));

        Assert.True(expected == actual);

        Assert.False(expected != actual);
    }

    private static void AssertAreNotEquivalent(Distance expected, Distance actual)
    {
        Assert.NotEqual(expected, actual);

        Assert.False(expected.Equals(actual));

        Assert.False(actual.Equals(expected));

        Assert.False(expected == actual);

        Assert.True(expected != actual);
    }
}