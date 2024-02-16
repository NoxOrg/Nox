using FluentAssertions;
using Nox.Reference;
using Nox.Reference.Data.World;

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
        using var worldContext = new WorldContext();
        // Act
        var referenceTimeZone = worldContext.GetTimeZonesQuery().FirstOrDefault(tz=> tz.Code ==timeZone)!;
        var timeZoneCode = referenceTimeZone.GetTimeZoneCode();

        // Assert
        timeZoneCode.Should().NotBeNull();
        timeZoneCode.Value.Should().Be(referenceTimeZone.Code.ToUpperInvariant());
    }
    
    
    [Theory]
    [InlineData(41.0085, 28.9776, "EUROPE/ISTANBUL")] // İstanbul
    [InlineData(51.5074, -0.1278, "EUROPE/LONDON")] // London
    [InlineData(40.7128, -74.0060, "AMERICA/NEW_YORK")] // New York
    [InlineData(35.6895, 139.6917, "ASIA/TOKYO")] // Tokyo
    public void WhenGettingTimeZoneCode_FromLatLong_ThenReturnsCorrectTimeZoneCode(double lat, double lon, string expectedTimeZone)
    {
        
        // Arrange & Act
        var timeZoneCode = TimeZoneCodeExtensions.From(lat, lon);

        // Assert
        timeZoneCode.Value.Should().Be(expectedTimeZone);
    }
    
}