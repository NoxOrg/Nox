// ReSharper disable once CheckNamespace
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class MacAddressTests
{
    [Theory]
    [InlineData("D3:20:77:E1:2D:32")]
    [InlineData("d3:20:77:e1:2d:32")]
    [InlineData("D3-20-77-E1-2D-32")]
    [InlineData("d3-20-77-e1-2d-32")]
    [InlineData("D32077E12D32")]
    [InlineData("d32077e12d32")]
    [InlineData("D320.77E1.2D32")]
    [InlineData("d320.77e1.2d32")]
    [InlineData("D320:77E1:2D32")]
    [InlineData("d320:77e1:2d32")]
    public void From_WithDifferentValidFormats_ReturnsValue(string input)
    {
        var macAddress = MacAddress.From(input);

        macAddress.Value.Should().Be("D32077E12D32");
    }

    [Theory]
    [InlineData(0xD32077E12D32, "D32077E12D32")]
    [InlineData(0xFFFFFFFFFFFF, "FFFFFFFFFFFF")]
    [InlineData(15, "00000000000F")]
    public void From_WithLongInputType_ReturnsValue(ulong input, string expectedResult)
    {
        var macAddress = MacAddress.From(input);

        macAddress.Value.Should().Be(expectedResult);
    }

    [Fact]
    public void From_WithByteArrayInputType_ReturnsValue()
    {
        var macAddress = MacAddress.From(new byte[] { 0xD3, 0x20, 0x77, 0xE1, 0x2D, 0x32 });

        macAddress.Value.Should().Be("D32077E12D32");
    }

    [Theory]
    [InlineData("test")]
    [InlineData("AA AA AA AA AA AA")]    // issue with space separator
    [InlineData("AA-AA-AA-AA-AA-AA-AA")] // too many bytes
    [InlineData("AA-AA-AA-AA-AA")]       // missing bytes
    public void From_WithDifferentInvalidFormats_ThrowsValidationException(string input)
    {
        var action = () => MacAddress.From(input);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox MAC Address type as value {input} is not a valid MAC Address.") });
    }

    [Fact]
    public void From_WithInvalidDataOfLongInputType_ThrowsValidationException()
    {
        var action = () => MacAddress.From(0xFFFFFFFFFFFFF); // too many bytes

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox MAC Address type as value FFFFFFFFFFFFF is not a valid MAC Address.") });
    }

    [Theory]
    [InlineData(new byte[] { 0xFF }, "FF")]                                                  // missing bytes
    [InlineData(new byte[] { 0xD3, 0x20, 0x77, 0xE1, 0x2D, 0x32, 0x32 }, "D32077E12D3232")]  // too many bites
    public void From_WithInvalidDataOfByteArrayInputType_ReturnsValue(byte[] input, string expectedOutput)
    {
        var action = () => MacAddress.From(input);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox MAC Address type as value {expectedOutput} is not a valid MAC Address.") });
    }

    [Theory]
    [InlineData(MacAddressFormat.NoSeparator, "AA1122334455")]
    [InlineData(MacAddressFormat.ByteGroupWithColon, "AA:11:22:33:44:55")]
    [InlineData(MacAddressFormat.ByteGroupWithDash, "AA-11-22-33-44-55")]
    [InlineData(MacAddressFormat.DoubleByteGroupWithColon, "AA11:2233:4455")]
    [InlineData(MacAddressFormat.DoubleByteGroupWithDot, "AA11.2233.4455")]
    public void ToString_WithVariousFormats_ReturnsFormattedString(MacAddressFormat format, string expected)
    {
        var macAddress = MacAddress.From("AA:11:22:33:44:55");

        macAddress.ToString(format).Should().Be(expected);
    }

    [Fact]
    public void ToString_WithoutParameters_ReturnsStringInByteGroupWithColonSeparatorFormat()
    {
        var macAddress = MacAddress.From("AA:11:22:33:44:55");

        macAddress.ToString().Should().Be("AA:11:22:33:44:55");
    }

    [Theory]
    [InlineData("D3:20:77:E1:2D:32", "D3:20:77:E1:2D:32")]
    [InlineData("D3:20:77:E1:2D:32", "d3:20:77:e1:2d:32")]
    [InlineData("D3:20:77:E1:2D:32", "D3-20-77-E1-2D-32")]
    [InlineData("D3:20:77:E1:2D:32", "d3-20-77-e1-2d-32")]
    [InlineData("D3:20:77:E1:2D:32", "D32077E12D32")]
    [InlineData("D3:20:77:E1:2D:32", "d32077e12d32")]
    [InlineData("D3:20:77:E1:2D:32", "D320.77E1.2D32")]
    [InlineData("D3:20:77:E1:2D:32", "d320.77e1.2d32")]
    [InlineData("D3:20:77:E1:2D:32", "D320:77E1:2D32")]
    [InlineData("D3:20:77:E1:2D:32", "d320:77e1:2d32")]
    public void Equality_WithDifferentInputFormats_ShouldBeEquivalent(string macAddressStr1, string macAddressStr2)
    {
        var macAddress1 = MacAddress.From(macAddressStr1);
        var macAddress2 = MacAddress.From(macAddressStr2);

        AssertAreEquivalent(macAddress1, macAddress2);
    }

    [Fact]
    public void NonEquality_WithDifferentAddresses_ShouldNotBeEquivalent()
    {
        var macAddress1 = MacAddress.From("D3:20:77:E1:2D:32");
        var macAddress2 = MacAddress.From("AA:11:22:33:44:55");

        AssertAreNotEquivalent(macAddress1, macAddress2);
    }

    private static void AssertAreEquivalent(MacAddress macAddress1, MacAddress macAddress2)
    {
        macAddress1.Should().Be(macAddress2);

        macAddress1.Equals(macAddress2).Should().BeTrue();

        macAddress2.Equals(macAddress1).Should().BeTrue();

        (macAddress1 == macAddress2).Should().BeTrue();

        (macAddress1 != macAddress2).Should().BeFalse();
    }

    private static void AssertAreNotEquivalent(MacAddress macAddress1, MacAddress macAddress2)
    {
        macAddress1.Should().NotBe(macAddress2);

        macAddress1.Equals(macAddress2).Should().BeFalse();

        macAddress2.Equals(macAddress1).Should().BeFalse();

        (macAddress1 == macAddress2).Should().BeFalse();

        (macAddress1 != macAddress2).Should().BeTrue();
    }
}