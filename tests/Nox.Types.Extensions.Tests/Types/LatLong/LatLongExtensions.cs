using FluentAssertions;

namespace Nox.Types.Extensions.Tests.Types.LatLong;

public class LatLongExtensions
{
    [Theory]
    [InlineData(41.0085, 28.9776, "EUROPE/ISTANBUL")] // İstanbul
    [InlineData(51.5074, -0.1278, "EUROPE/LONDON")] // London
    [InlineData(40.7128, -74.0060, "AMERICA/NEW_YORK")] // New York
    [InlineData(35.6895, 139.6917, "ASIA/TOKYO")] // Tokyo
    public void WhenGettingTimeZoneCode_FromLatLong_ThenReturnsCorrectTimeZoneCode(double lat, double lon, string expectedTimeZone)
    {
        // Arrange
        var latLong = Nox.Types.LatLong.From(lat, lon);
        // Act
        var timeZoneCode = latLong.ToTimeZoneCode();

        // Assert
        timeZoneCode.Value.Should().Be(expectedTimeZone);
    }
}