namespace Nox.Types;

public class AreaTypeOptions
{
    private const double DefaultMinArea = 0;
    private const double DefaultMaxArea = 999_999_999_999_999;
    
    public double MinValue { get; set; } = DefaultMinArea;
    public double MaxValue { get; set; } = DefaultMaxArea;
    public AreaTypeUnit DefaultAreaUnit { get; set; } = AreaTypeUnit.SquareMeter;
}