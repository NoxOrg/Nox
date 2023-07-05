using System;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="LatLong"/> type and value object. 
/// </summary>
public sealed class LatLong : ValueObject<(double Latitude, double Longitude), LatLong>
{
    public LatLong() { Value = (Latitude: 0, Longitude: 0); } // Null Island

    public double Latitude
    {
        get => Value.Latitude;
        private set => Value = (Latitude: value, Longitude: Value.Longitude);
    }

    public double Longitude
    {
        get => Value.Longitude;
        private set => Value = (Latitude: Value.Latitude, Longitude: value);
    }

    public static LatLong From(double latitude, double longitude)
        => From((latitude,longitude));

    /// <summary>
    /// Validates a <see cref="LatLong"/> object.
    /// </summary>
    /// <returns>true if the <see cref="LatLong"/> value is valid geo coordinate.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value.Latitude > 90 || Value.Latitude < -90)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox LatLong type with latitude {Value.Latitude} as it is not in the range -90 to 90 degrees."));
        }

        if (Value.Longitude > 180 || Value.Longitude < -180)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox LatLong type with longitude {Value.Longitude} as it is not in the range -180 to 180 degrees."));
        }

        return result;
    }

    public override string ToString()
    {
        return $"{Value.Latitude.ToString("0.000000", CultureInfo.InvariantCulture)} {Value.Longitude.ToString("0.000000", CultureInfo.InvariantCulture)}";
    }

    public string ToString(IFormatProvider formatProvider)
    {
        return $"{Value.Latitude.ToString(formatProvider)} {Value.Longitude.ToString(formatProvider)}";
    }

    public string ToString(string format)
    {
        return format.ToLower() switch
        {
            "dms" => ToDmsString(),
            _ => ToString(),
        };
    }

    private string ToDmsString()
    {
        var latDirection = Value.Latitude < 0 ? "S" : "N";
        var lat = ToDegreesMinutesSeconds(Value.Latitude);

        var lonDirection = Value.Longitude < 0 ? "W" : "E";
        var lon = ToDegreesMinutesSeconds(Value.Longitude);

        return  $"{lat.Degrees}°{lat.Minutes:00}'{lat.Seconds:00}.{lat.Milliseconds:####}\" {latDirection} "+
                $"{lon.Degrees}°{lon.Minutes:00}'{lon.Seconds:00}.{lon.Milliseconds:####}\" {lonDirection}";
    }

    private (int Degrees, int Minutes, int Seconds, int Milliseconds) ToDegreesMinutesSeconds(double decimaDegrees)
    {
        decimaDegrees = Math.Abs(decimaDegrees);
        var degrees = (int)Math.Floor(decimaDegrees);

        decimaDegrees -= degrees;
        double totalSeconds = (int)Math.Floor(3600.0 * decimaDegrees);

        var seconds = (int)Math.Floor(totalSeconds % 60);
        var minutes = (int)Math.Floor(totalSeconds / 60.0);

        decimaDegrees = (decimaDegrees * 3600.0) - totalSeconds;
        var milliseconds = (int)(1000.0 * decimaDegrees);

        return (degrees, minutes, seconds, milliseconds);
    }

}



