namespace Nox.Types;

public interface INoxMeasurementTypeOptions : INoxTypeOptions
{
    public double MinValue { get; set; }
    public double MaxValue { get; set; }
    public AreaTypeUnit Unit { get; set; }
}

public class AreaTypeOptions : INoxMeasurementTypeOptions
{
    private const double DefaultMinArea = 0;
    private const double DefaultMaxArea = 510_072_000_000_000; // Earth's surface area
    private const AreaTypeUnit DefaultAreaUnit = AreaTypeUnit.SquareMeter;

    public double MinValue { get; set; } = DefaultMinArea;
    public double MaxValue { get; set; } = DefaultMaxArea;
    public AreaTypeUnit Unit { get; set; } = DefaultAreaUnit;
}
