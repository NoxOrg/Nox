namespace Nox.Types;

public class DistanceTypeOptions
{
    private const double DefaultMinDistance = 0;
    private const double DefaultMaxDistance = 999_999_999_999_999;

    // Validation Properties
    public double MinValue { get; set; } = DefaultMinDistance;
    public double MaxValue { get; set; } = DefaultMaxDistance;

    //Creation Properties
    public DistanceTypeUnit Units { get; set; } = DistanceTypeUnit.Kilometer;
    
    // Database Creation Properties
    public DistanceTypeUnit PersistAs { get; set; } = DistanceTypeUnit.Kilometer;
}