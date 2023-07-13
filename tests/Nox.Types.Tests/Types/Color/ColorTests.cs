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
    public void Color_Constructor_WithouthAlpha_ReturnsSameValue()
    {
        var color = Nox.Types.Color.From(255, 165, 0);

        color.Value.Should().Be((0, 255, 165, 0));
    }

    [Fact]
    public void Color_Constructor_FromRgba_ReturnsSameValue()
    {
        var color = Nox.Types.Color.FromRgba(100, 193, 154, 107);

        color.Value.Should().Be((100, 193, 154, 107));
    }

    [Fact]
    public void Color_Constructor_FromAlphaColor_ReturnsSameValue()
    {
        var color = Nox.Types.Color.FromAlphaColor("#FFF0F8FF");

        color.Value.Should().Be((255, 240, 248, 255));
        color.ToHex().Should().Be("#FFF0F8FF");
    }

    [Fact]
    public void Color_Equality_Tests()
    {
        var color1 = Nox.Types.Color.FromRgba(100, 193, 154, 107);

        var color2 = Nox.Types.Color.FromRgba(100, 193, 154, 107);

        color1.Value.Should().Be(color2.Value);
    }

    [Fact]
    public void Color_Equality_WithDifferentContructor_Tests()
    {
        var color1 = Nox.Types.Color.FromRgba(100, 193, 154, 107);

        var color2 = Nox.Types.Color.FromRgba(10, 193, 154, 107);

        color1.Value.Should().NotBe(color2.Value);
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

}

