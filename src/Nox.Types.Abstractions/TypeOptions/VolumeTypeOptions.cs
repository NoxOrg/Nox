namespace Nox.Types;

public class VolumeTypeOptions
{
    private const double DefaultMinVolume = 0;
    private const double DefaultMaxVolume = 999_999_999_999_999;
    
    // Validation Properties
    public double MinValue { get; set; } = DefaultMinVolume;
    public double MaxValue { get; set; } = DefaultMaxVolume;

    // Creation Properties
    public VolumeTypeUnit Units { get; set; } = VolumeTypeUnit.CubicMeter;

    // Database Creation Properties
    public VolumeTypeUnit PersistAs { get; set; } = VolumeTypeUnit.CubicMeter;
}
