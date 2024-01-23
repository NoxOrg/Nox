using FluentAssertions;
using Nox.Reference;

namespace Nox.Types.Extensions.Tests.Types.TimeZoneCode;

public class TimeZoneCodeExtensionsTests: WorldTestBase
{
    [Theory]
    [InlineData("GMT")]
    [InlineData("UTC")]
    [InlineData("EET")]
    [InlineData("Turkey")]
    [InlineData("Europe/Kiev")]
    [InlineData("Europe/Istanbul")]
    public void WhenGettingReferenceTimeZone_WithValidTimeZoneCode_ThenReturnsTimeZone(string timeZoneCode)
    {
        // Arrange
        // Act
        var referenceTimeZone = Nox.Types.TimeZoneCode.From(timeZoneCode).GetReferenceTimeZone();

        // Assert
        referenceTimeZone.Should().NotBeNull();
        referenceTimeZone.Code.Should().Be(timeZoneCode);
    }
    
    [Theory]
    [InlineData("GMT")]
    [InlineData("UTC")]
    [InlineData("EET")]
    [InlineData("Turkey")]
    [InlineData("Europe/Kiev")]
    [InlineData("Europe/Istanbul")]
    public void WhenGettingTimeZoneCode_WithValidReferenceTimeZone_ThenReturnsTimeZoneCode(string timeZone)
    {
        // Arrange
        // Act
        var referenceTimeZone = World.TimeZones.FirstOrDefault(tz=> tz.Code ==timeZone)!;
        var timeZoneCode = referenceTimeZone.GetTimeZoneCode();

        // Assert
        timeZoneCode.Should().NotBeNull();
        timeZoneCode.Value.Should().Be(referenceTimeZone.Code.ToUpperInvariant());
    }
    
}