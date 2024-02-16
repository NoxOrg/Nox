using GeoTimeZone;
using Nox.Reference;
using Nox.Reference.Data.World;

namespace Nox.Types.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="TimeZoneCode"/> class.
/// </summary>
public static class TimeZoneCodeExtensions
{
    /// <summary>
    /// Gets the reference <see cref="TimeZoneCode"/> based on the provided <see cref="TimeZoneCode"/>.
    /// </summary>
    /// <param name="timeZoneCode">The <see cref="TimeZoneCode"/> to get the reference <see cref="TimeZoneCode"/> for.</param>
    /// <returns>The reference <see cref="TimeZoneCode"/>.</returns>    
    public static Reference.TimeZone GetReferenceTimeZone(this TimeZoneCode timeZoneCode)
    {
        using var worldContext = new WorldContext();
        return worldContext.GetTimeZonesQuery().GetById(timeZoneCode.Value)!;
    }

    /// <summary>
    /// Gets the TimeZoneCode associated with the given Reference.TimeZone object.
    /// </summary>
    /// <param name="referenceTimeZone">The Reference.TimeZone object.</param>
    /// <returns>The TimeZoneCode object.</returns>
    public static TimeZoneCode GetTimeZoneCode(this Reference.TimeZone referenceTimeZone)
    {
        return TimeZoneCode.From(referenceTimeZone.Code);
    }

    /// <summary>
    /// Converts latitude and longitude coordinates to a <see cref="TimeZoneCode"/> value.
    /// </summary>
    /// <param name="lat">The latitude coordinate.</param>
    /// <param name="lon">The longitude coordinate.</param>
    /// <returns>The <see cref="TimeZoneCode"/> value corresponding to the given coordinates.</returns>
    public static TimeZoneCode From(double lat, double lon)
    {
        string timeZone = TimeZoneLookup.GetTimeZone(lat, lon).Result;
        return TimeZoneCode.From(timeZone);
    }
}