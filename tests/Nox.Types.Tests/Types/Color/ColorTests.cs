using System.Globalization;
using FluentAssertions;
using Nox.Types.Tests.Types.Color;

namespace Nox.Types.Tests.Types;

public class ColorTests
{
    [Theory]
    [ClassData(typeof(ColorNameTestsDataClass))]
    public void Color_Constructor_ReturnsSameValue_AllColors(string colorName)
    {
        var color = Nox.Types.Color.FromName(colorName);

        color.ToString("name").Should().Be(colorName);
    }

    [Fact]
    public void Color_Constructor_WithoutAlpha_ReturnsSameValue()
    {
        var color = Nox.Types.Color.From(255, 165, 0);

        color.Value.Should().Equal(new byte[] { 255, 255, 165, 0 });
    }

    [Fact]
    public void Color_Constructor_FromRgba_ReturnsSameValue()
    {
        var color = Nox.Types.Color.FromRgba(100, 193, 154, 107);

        color.Value.Should().Equal(new byte[]{100, 193, 154, 107});
    }

    [Fact]
    public void Color_Constructor_FromAlphaColor_ReturnsSameValue()
    {
        var color = Nox.Types.Color.FromAlphaColor("#FFF0F8FF");

        color.Value.Should().Equal(new byte[] {255, 240, 248, 255});
        color.ToHexa().Should().Be("#FFF0F8FF");
    }

    [Fact]
    public void Color_Constructor_FromHexRgb_ReturnsSameValue()
    {
        var color = Nox.Types.Color.FromAlphaColor("#FFC0CB");

        color.Value.Should().Equal( new byte[] {0, 255, 192, 203});
        color.ToHex().Should().Be("#FFC0CB");
    }

    [Fact]
    public void Color_Equality_Tests()
    {
        var color1 = Nox.Types.Color.FromRgba(100, 193, 154, 107);

        var color2 = Nox.Types.Color.FromRgba(100, 193, 154, 107);

        Nox.Types.Color.From(1, 2, 3).Should().Be(Nox.Types.Color.From(1, 2, 3));
        color1.Value.Should().Equal(color2.Value);
    }

    [Fact]
    public void Color_Equality_WithDifferentConstructor_Tests()
    {
        var color1 = Nox.Types.Color.FromRgba(100, 193, 154, 107);

        var color2 = Nox.Types.Color.FromRgba(10, 193, 154, 107);

        color1.Value.Should().NotEqual(color2.Value);
    }

    [Fact]
    public void Color_ToBytes_Contructor_Tests()
    {
        var color = Nox.Types.Color.FromRgba(100, 193, 154, 107);

        var colorBytes = color.ToBytes();

        colorBytes.Length.Should().Be(4);

        colorBytes.ElementAt(0).Should().Be(100);
        colorBytes.ElementAt(1).Should().Be(193);
        colorBytes.ElementAt(2).Should().Be(154);
        colorBytes.ElementAt(3).Should().Be(107);
    }

    [Fact]
    public void Color_When_Constructor_Should_Returns_Empty()
    {
        var emptyColor = new Nox.Types.Color();
        var differentColor = Nox.Types.Color.From(255, 255, 255);
        var rgbaColor = Nox.Types.Color.FromRgba(0, 0, 0, 0);
        var colorEmptyString = ColorConverter.ConvertFromString("", CultureInfo.InvariantCulture);
        
        //Assert
        emptyColor.Should().Be(Nox.Types.Color.Empty);
        emptyColor.Should().NotBe(differentColor);
        rgbaColor.Should().Be(Nox.Types.Color.Empty);
        colorEmptyString.Should().Be(Nox.Types.Color.Empty);
        Nox.Types.Color.Empty.Should().Be(Nox.Types.Color.Empty);
    }
}

