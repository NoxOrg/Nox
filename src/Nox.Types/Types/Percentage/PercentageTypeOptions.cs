namespace Nox.Types;
public class PercentageTypeOptions
{
    public static readonly float DefaultMinValue = 0;
    public static readonly float DefaultMaxValue = 1;
    public float MinValue { get; set; } = DefaultMinValue;
    public float MaxValue { get; set; } = DefaultMaxValue;

    public int Digits { get; set; } = 2;
}
