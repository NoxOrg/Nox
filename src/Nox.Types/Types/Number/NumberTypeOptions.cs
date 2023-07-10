namespace Nox.Types;

public class NumberTypeOptions
{
    public static readonly QuantityValue DefaultMinValue = -999999999;
    public static readonly QuantityValue DefaultMaxValue = +999999999;
    public QuantityValue MinValue { get; set; } = DefaultMinValue;
    public QuantityValue MaxValue { get; set; } = DefaultMaxValue;
    public uint DecimalDigits { get; set; } = 0;
}