namespace Nox.Types;

public class AreaTypeOptions
{
    private const double DefaultMinArea = 0;
    private const double DefaultMaxArea = 999_999_999_999_999;
    
    // Validation Properties
    public double MinValue { get; set; } = DefaultMinArea;
    public double MaxValue { get; set; } = DefaultMaxArea;

    // Creation Properties
    public AreaTypeUnit Units { get; set; } = AreaTypeUnit.SquareMeter;

    // Database Creation Properties
    public AreaTypeUnit PersistAs { get; set; } = AreaTypeUnit.SquareMeter;
}


public class LengthTypeOptions
{
    private const double DefaultMinLength = 0;
    private const double DefaultMaxLength = 999_999_999_999_999;

    // Validation Properties
    public double MinValue { get; set; } = DefaultMinLength;
    public double MaxValue { get; set; } = DefaultMaxLength;

    // Creation Properties
    public LengthTypeUnit Units { get; set; } = LengthTypeUnit.Meter;

    // Database Creation Properties
    public LengthTypeUnit PersistAs { get; set; } = LengthTypeUnit.Meter;
}