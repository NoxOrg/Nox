namespace Nox.Types.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="LatLong"/> class.
/// </summary>
public static class LatLongExtensions
{
    /// <summary>
    /// Retrieves the corresponding <see cref="TimeZoneCode"/> based on the latitude and longitude values of a <see cref="LatLong"/> object.
    /// </summary>
    /// <param name="latLong">The <see cref="LatLong"/> object containing the latitude and longitude values.</param>
    /// <returns>The <see cref="TimeZoneCode"/> corresponding to the latitude and longitude values.</returns>
    public static TimeZoneCode ToTimeZoneCode(this LatLong latLong)
    {
        return TimeZoneCodeExtensions.From(latLong.Latitude, latLong.Longitude);
    }
}