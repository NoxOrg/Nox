namespace Nox.Types;

internal interface IDistanceCalculator
{
    double Calculate(LatLong origin, LatLong destination);
}
