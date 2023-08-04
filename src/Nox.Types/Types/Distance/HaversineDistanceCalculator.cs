using Nox.Types.Common;
using System;

namespace Nox.Types;

internal sealed class HaversineDistanceCalculator : IDistanceCalculator
{
    private const double EarthRadiusInKilometers = 6371.0;

    public double Calculate(LatLong origin, LatLong destination, DistanceTypeUnit unit)
    {
        var distanceInKilometers = CalculateInKilometers(origin, destination);
        var conversion = GetConversionFor(unit);

        return (double)conversion.Calculate(distanceInKilometers);
    }

    private static DistanceConversion GetConversionFor(DistanceTypeUnit unit)
    {
        var distanceUnit = Enumeration.ParseFromName<DistanceUnit>(unit.ToString());
        var conversion = new DistanceConversion(DistanceUnit.Kilometer, distanceUnit);
        return conversion;
    }

    private static double CalculateInKilometers(LatLong origin, LatLong destination)
    {
        // Convert degrees to radians
        var radOrigin = ToRadianCoords(origin);
        var radDestination = ToRadianCoords(destination);

        // Apply Haversine formula

        // Intermediate calculation: Square of the half-chord length between the points' latitudes
        var a = Math.Pow(Math.Sin((radDestination.Latitude - radOrigin.Latitude) / 2), 2) +
            Math.Cos(radOrigin.Latitude) * Math.Cos(radDestination.Latitude) * Math.Pow(Math.Sin((radDestination.Longitude - radOrigin.Longitude) / 2), 2);

        // Intermediate calculation: Angular distance between the two points in radians
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        var distanceInKilometers = EarthRadiusInKilometers * c;
        return distanceInKilometers;
    }

    private static (double Latitude, double Longitude) ToRadianCoords(LatLong coord)
        => (ToRadians(coord.Latitude), ToRadians(coord.Longitude));

    private static double ToRadians(double degrees)
        => degrees * Math.PI / 180;

}
