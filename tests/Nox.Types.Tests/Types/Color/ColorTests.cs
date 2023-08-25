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

        color.ToHex().Should().Be("#FFA500");
    }

    [Fact]
    public void Color_Constructor_FromRgba_ReturnsSameValue()
    {
        var color = Nox.Types.Color.From(100, 100, 193, 154);

        color.ToHex().Should().Be("#64C19A");
    }

    [Fact]
    public void Color_Constructor_FromAlphaColor_ReturnsSameValue()
    {
        var colorValue = "#FFF0F8FF";
        var color = Nox.Types.Color.From(colorValue);

        color.ToRgbaString().Should().Be("RGBA(240, 248, 255, 1.00)");
        color.Value.Should().Be(colorValue);
    }

    [Fact]
    public void Color_Constructor_FromSystemDrawingColor_ReturnsSameValue()
    {
        var systemDrawingColor = System.Drawing.Color.FromArgb(255, 255, 255);
        var noxColor = Nox.Types.Color.From(systemDrawingColor);

        var colorBytes = noxColor.ToBytes();

        colorBytes[0].Should().Be(systemDrawingColor.A);
        colorBytes[1].Should().Be(systemDrawingColor.R);
        colorBytes[2].Should().Be(systemDrawingColor.G);
        colorBytes[3].Should().Be(systemDrawingColor.B);
    }

    [Fact]
    public void Color_Constructor_FromHexRgb_ReturnsSameValue()
    {
        var color = Nox.Types.Color.From("#FFC0CB");

        var colorBytes = color.ToBytes();

        colorBytes[0].Should().Be(255);
        colorBytes[1].Should().Be(255);
        colorBytes[2].Should().Be(192);
        colorBytes[3].Should().Be(203);

        color.ToHex().Should().Be("#FFC0CB");
    }

    [Fact]
    public void Color_Constructor_ToString_ReturnsSameValue()
    {
        var color = Nox.Types.Color.From("#FFC0CB");
        color.ToString().Should().Be("#FFC0CB");
        var colorBytes = color.ToBytes();

        colorBytes[0].Should().Be(255);
        colorBytes[1].Should().Be(255);
        colorBytes[2].Should().Be(192);
        colorBytes[3].Should().Be(203);
    }

    [Fact]
    public void Color_Constructor_ToStringName_ReturnsSameValue()
    {
        var beigeSystemColor = System.Drawing.Color.Beige;
        var color = Nox.Types.Color.FromName(beigeSystemColor.Name);
        color.ToString("name").Should().Be(beigeSystemColor.Name);
    }

    [Fact]
    public void Color_Constructor_ToStringHexa_ReturnsSameValue()
    {
        var beigeSystemColor = System.Drawing.Color.Beige;
        var color = Nox.Types.Color.From(beigeSystemColor);
        color.ToString("hexa").Should().Be("#FFF5F5DC");
    }

    [Fact]
    public void Color_Constructor_ToStringHex_ReturnsSameValue()
    {
        var beigeSystemColor = System.Drawing.Color.Beige;
        var color = Nox.Types.Color.From(beigeSystemColor);
        color.ToString("hex").Should().Be("#F5F5DC");
    }

    [Fact]
    public void Color_Constructor_ToStringRgb_ReturnsSameValue()
    {
        var beigeSystemColor = System.Drawing.Color.Beige;
        var color = Nox.Types.Color.From(beigeSystemColor);
        color.ToString("rgb").Should().Be("RGB(245, 245, 220)");
    }

    [Fact]
    public void Color_Constructor_ToStringRgba_ReturnsSameValue()
    {
        var beigeSystemColor = System.Drawing.Color.Beige;
        var color = Nox.Types.Color.From(beigeSystemColor);
        color.ToString("rgba").Should().Be("RGBA(245, 245, 220, 1.00)");
    }

    [Fact]
    public void Color_Equality_Tests()
    {
        var color1 = Nox.Types.Color.From(100, 193, 154, 107);

        var color2 = Nox.Types.Color.From(100, 193, 154, 107);

        Nox.Types.Color.From(1, 2, 3).Should().Be(Nox.Types.Color.From(1, 2, 3));
        color1.Value.Should().Be(color2.Value);
    }

    [Fact]
    public void Color_Equality_WithDifferentConstructor_Tests()
    {
        var color1 = Nox.Types.Color.From(100, 193, 154, 107);

        var color2 = Nox.Types.Color.From(10, 193, 154, 107);

        color1.Value.Should().NotBe(color2.Value);
    }

    [Fact]
    public void Color_ToBytes_Constructor_Tests()
    {
        var color = Nox.Types.Color.From(100, 193, 154, 107);

        var colorBytes = color.ToBytes();

        colorBytes.Length.Should().Be(4);

        colorBytes[0].Should().Be(100);
        colorBytes[1].Should().Be(193);
        colorBytes[2].Should().Be(154);
        colorBytes[3].Should().Be(107);
    }

    [Fact]
    public void Color_When_Constructor_Should_Returns_Empty()
    {
        var emptyColor = new Nox.Types.Color();
        var differentColor = Nox.Types.Color.From(255, 255, 255);
        var colorEmptyString = Nox.Types.Color.From(System.Drawing.Color.Empty);

        //Assert
        emptyColor.Should().Be(Nox.Types.Color.From(0, 0, 0, 0));
        emptyColor.Should().NotBe(differentColor);
        emptyColor.Should().Be(colorEmptyString);
    }

    [Theory]
    [InlineData("88")]
    [InlineData("#ff")]
    [InlineData("#fffff")]
    [InlineData("#1234567")]
    [InlineData("invalid")]
    public void Color_From_InvalidInput_ThrowsException(string color)
    {
        Action comparison = () => Nox.Types.Color.From(color);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Fact]
    public void Color_FromRGB_ReturnsValidName()
    {
        var color = Nox.Types.Color.From(255, 0, 0);

        //Assert
        color.ToString("name").Should().Be("Red");
    }
}

