// ReSharper disable once CheckNamespace

using FluentAssertions;
using System.Globalization;

namespace Nox.Types.Tests.Types;

public class VolumeTests
{
    [Fact]
    public void VolumeTypeOptions_Constructor_ReturnsDefaultValues()
    {
        var typeOptions = new VolumeTypeOptions();

        typeOptions.MinValue.Should().Be(0);
        typeOptions.MaxValue.Should().Be(999_999_999_999_999);
        typeOptions.Unit.Should().Be(VolumeTypeUnit.CubicMeter);
        typeOptions.PersistAs.Should().Be(VolumeTypeUnit.CubicMeter);
    }

    [Fact]
    public void Volume_Constructor_ReturnsSameValueAndDefaultUnit()
    {
        var volume = Volume.From(27.1828);

        volume.Value.Should().Be(27.1828);
        volume.Unit.Should().Be(VolumeTypeUnit.CubicMeter);
    }

    [Fact]
    public void Volume_Constructor_ReturnsRoundedValueAndDefaultUnit()
    {
        var volume = Volume.From(27.18281828459045);

        volume.Value.Should().Be(27.182818);
        volume.Unit.Should().Be(VolumeTypeUnit.CubicMeter);
    }

    [Fact]
    public void Volume_Constructor_WithUnit_ReturnsSameValueAndUnit()
    {
        var volume = Volume.From(27.1828, VolumeUnit.CubicFoot);

        volume.Value.Should().Be(27.1828);
        volume.Unit.Should().Be(VolumeTypeUnit.CubicFoot);
    }

    [Fact]
    public void Volume_Constructor_WithUnitInCubicMeters_ReturnsSameValueAndUnit()
    {
        var volume = Volume.From(27.1828, VolumeTypeUnit.CubicFoot);

        volume.Value.Should().Be(27.1828);
        volume.Unit.Should().Be(VolumeTypeUnit.CubicFoot);
    }

    [Fact]
    public void Volume_Constructor_WithUnitInCubicFeet_ReturnsSameValueAndUnit()
    {
        var volume = Volume.From(959.951522, VolumeTypeUnit.CubicFoot);

        volume.Value.Should().Be(959.951522);
        volume.Unit.Should().Be(VolumeTypeUnit.CubicFoot);
    }

    [Fact]
    public void Volume_Constructor_WithNegativeValueInput_ThrowsException()
    {
        var action = () => Volume.From(-28);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Volume type as negative value -28 is not allowed.") });
    }

    [Fact]
    public void Volume_Constructor_WithNaNValueInput_ThrowsException()
    {
        var action = () => Volume.From(double.NaN);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[]
                { new ValidationFailure("Value", "Could not create a Nox Volume type as negative value NaN is not allowed.") });
    }

    [Fact]
    public void Volume_Constructor_WithPositiveInfinityValueInput_ThrowsException()
    {
        var action = () => Volume.From(double.PositiveInfinity);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[]
                { new ValidationFailure("Value", "Could not create a Nox Volume type as value Infinity is not allowed.") });
    }

    [Fact]
    public void Volume_Constructor_WithNegativeInfinityValueInput_ThrowsException()
    {
        var action = () => Volume.From(double.NegativeInfinity);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[]
                { new ValidationFailure("Value", "Could not create a Nox Volume type as value Infinity is not allowed.") });
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
    public void Volume_ValueInCubicMeters_ToString_IsCultureIndependent(string culture)
    {
        void Test()
        {
            var volume = Volume.From(27.1828, VolumeTypeUnit.CubicMeter);
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
            var volume = Volume.From(27.1828, VolumeTypeUnit.CubicMeter);
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
            var volume = Volume.From(959.951522, VolumeTypeUnit.CubicFoot);
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
            var volume = Volume.From(959.951522, VolumeTypeUnit.CubicFoot);
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

    [Fact]
    public void Volume_SpecifyingMaxValue_WithGreaterValueInput_ThrowsException()
    {
        var action = () => Volume.From(7.5, new VolumeTypeOptions { MaxValue = 5, Unit = VolumeTypeUnit.CubicMeter });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value",
                "Could not create a Nox Volume type as value 7.5 m³ is greater than the specified maximum of 5 m³.")
            });
    }

    [Fact]
    public void Volume_SpecifyingMinValue_WithLesserValueInput_ThrowsException()
    {
        var action = () => Volume.From(7.5, new VolumeTypeOptions { MinValue = 10, Unit = VolumeTypeUnit.CubicMeter });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value",
                "Could not create a Nox Volume type as value 7.5 m³ is lesser than the specified minimum of 10 m³.") });
    }
}