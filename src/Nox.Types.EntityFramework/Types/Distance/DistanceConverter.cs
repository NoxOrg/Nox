using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class DistanceToKilometerConverter : ValueConverter<Distance, decimal>
{
    public DistanceToKilometerConverter() : base(distance => (decimal)distance.ToKilometers(), distanceValue => Distance.FromDatabase(distanceValue, DistanceTypeUnit.Kilometer)) { }
}
public class DistanceToMilesConverter : ValueConverter<Distance, decimal>
{
    public DistanceToMilesConverter() : base(distance => (decimal)distance.ToMiles(), distanceValue => Distance.FromDatabase(distanceValue, DistanceTypeUnit.Mile)) { }
}
