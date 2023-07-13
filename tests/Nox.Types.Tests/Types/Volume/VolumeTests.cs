// ReSharper disable once CheckNamespace
using FluentAssertions;
using System.Globalization;

namespace Nox.Types.Tests.Types;

public class VolumeTests
{
    [Fact]
    public void Volume_Constructor_ReturnsSameValueAndDefaultUnit()
    {
        var volume = Volume.From(27.1828);

        volume.Value.Should().Be(27.1828);
        volume.Unit.Should().Be(VolumeUnit.CubicMeter);
    }

    [Fact]
    public void Volume_Constructor_ReturnsRoundedValueAndDefaultUnit()
    {
        var volume = Volume.From(27.18281828459045);

        volume.Value.Should().Be(27.182818);
        volume.Unit.Should().Be(VolumeUnit.CubicMeter);
    }

    [Fact]
    public void Volume_Constructor_WithUnit_ReturnsSameValueAndUnit()
    {
        var volume = Volume.From(27.1828, VolumeUnit.CubicMeter);

        volume.Value.Should().Be(27.1828);
        volume.Unit.Should().Be(VolumeUnit.CubicMeter);
    }

    [Fact]
    public void Volume_Constructor_WithUnitInCubicMeters_ReturnsSameValueAndUnit()
    {
        var volume = Volume.FromCubicMeters(27.1828);

        volume.Value.Should().Be(27.1828);
        volume.Unit.Should().Be(VolumeUnit.CubicMeter);
    }

    [Fact]
    public void Volume_Constructor_WithUnitInCubicFeet_ReturnsSameValueAndUnit()
    {
        var volume = Volume.FromCubicFeet(959.951522);

        volume.Value.Should().Be(959.951522);
        volume.Unit.Should().Be(VolumeUnit.CubicFoot);
    }

    [Fact]
    public void Volume_Constructor_WithNegativeValueInput_ThrowsException()
    {
        var action = () => Volume.From(-27.1828);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Volume type as negative volume value -27.1828 is not allowed.") });
    }

    [Fact]
    public void Volume_Constructor_WithNaNValueInput_ThrowsException()
    {
        var action = () => Volume.From(double.NaN);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox type as value NaN is not allowed.") });
    }

    [Fact]
    public void Volume_Constructor_WithPositiveInfinityValueInput_ThrowsException()
    {
        var action = () => Volume.From(double.PositiveInfinity);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox type as value Infinity is not allowed.") });
    }

    [Fact]
    public void Volume_Constructor_WithNegativeInfinityValueInput_ThrowsException()
    {
        var action = () => Volume.From(double.NegativeInfinity);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox type as value Infinity is not allowed.") });
    }

    [Fact]
    public void Volume_ToCubicMeters_ReturnsValue()
    {
        var volume = Volume.From(27.1828);

        volume.ToCubicMeters().Should().Be(27.1828);
    }

    [Fact]
    public void Volume_ToCubicFeet_ReturnsValue()
    {
        var volume = Volume.From(27.1828);

        volume.ToCubicFeet().Should().Be(959.951522);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("pt-PT")]
    public void Volume_ValueInCubicMeters_ToString_IsCultureIndepdendent(string culture)
    {
        void Test()
        {
            var volume = Volume.FromCubicMeters(27.1828);
            volume.ToString().Should().Be("27.1828 m³");
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US", "27.1828 m³")]
    [InlineData("pt-PT", "27,1828 m³")]
    public void Volume_ValueInCubicMeters_ToString_IsCultureDependent(string culture, string expected)
    {
        void Test()
        {
            var volume = Volume.FromCubicMeters(27.1828);
            volume.ToString(new CultureInfo(culture)).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("pt-PT")]
    public void Volume_ValueInCubicFeet_ToString_IsCultureIndependent(string culture)
    {
        void Test()
        {
            var volume = Volume.FromCubicFeet(959.951522);
            volume.ToString().Should().Be("959.951522 ft³");
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US", "959.951522 ft³")]
    [InlineData("pt-PT", "959,951522 ft³")]
    public void Volume_ValueInCubicFeet_ToString_IsCultureDependent(string culture, string expected)
    {
        void Test()
        {
            var volume = Volume.FromCubicFeet(959.951522);
            volume.ToString(new CultureInfo(culture)).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Fact]
    public void Volume_Equality_WithSameVolumeUnit_Tests()
    {
        var volume1 = Volume.From(27.1828, VolumeUnit.CubicMeter);

        var volume2 = Volume.From(27.1828, VolumeUnit.CubicMeter);

        AssertAreEquivalent(volume1, volume2);
    }

    [Fact]
    public void Volume_Equality_WithDifferentVolumeUnit_Tests()
    {
        var volume1 = Volume.From(27.1828, VolumeUnit.CubicMeter);

        var volume2 = Volume.From(959.951522, VolumeUnit.CubicFoot);

        AssertAreEquivalent(volume1, volume2);
    }

    [Fact]
    public void Volume_NonEquality_SpecifyingVolumeUnit_WithSameUnit_Tests()
    {
        var volume1 = Volume.From(27.1828, VolumeUnit.CubicMeter);

        var volume2 = Volume.From(959.951522, VolumeUnit.CubicMeter);

        AssertAreNotEquivalent(volume1, volume2);
    }

    [Fact]
    public void Volume_NonEquality_SpecifyingVolumeUnit_WithDifferentUnit_Tests()
    {
        var volume1 = Volume.From(27.1828, VolumeUnit.CubicMeter);

        var volume2 = Volume.From(27.1828, VolumeUnit.CubicFoot);

        AssertAreNotEquivalent(volume1, volume2);
    }

    private static void AssertAreEquivalent(Volume expected, Volume actual)
    {
        actual.Should().Be(expected);

        expected.Equals(actual).Should().BeTrue();

        actual.Equals(expected).Should().BeTrue();

        (expected == actual).Should().BeTrue();

        (expected != actual).Should().BeFalse();
    }

    private static void AssertAreNotEquivalent(Volume expected, Volume actual)
    {
        actual.Should().NotBe(expected);

        expected.Equals(actual).Should().BeFalse();

        actual.Equals(expected).Should().BeFalse();

        (expected == actual).Should().BeFalse();

        (expected != actual).Should().BeTrue();
    }
}