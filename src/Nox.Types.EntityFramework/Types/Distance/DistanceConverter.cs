using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DistanceToKilometerConverter : ValueConverter<Distance, double>
{
    public DistanceToKilometerConverter() : base(distance => (double)distance.ToKilometers(), distanceValue => Distance.FromKilometers(distanceValue)) { }
}
public class DistanceToMilesConverter : ValueConverter<Distance, double>
{
    public DistanceToMilesConverter() : base(distance => (double)distance.ToMiles(), distanceValue => Distance.FromMiles(distanceValue)) { }
}
