
namespace Nox.Types;

public class DayOfWeekTypeOptions : INoxTypeOptions
{
    public static readonly int DefaultMinValue= 1;
    public static readonly int DefaultMaxValue = 6;
    public int MinValue { get; set; } = DefaultMinValue;
    public int MaxValue { get; set; } = DefaultMaxValue;
}
