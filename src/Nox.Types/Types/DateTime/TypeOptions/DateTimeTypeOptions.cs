
namespace Nox.Types;
public class DateTimeTypeOptions
{
    public static readonly System.DateTime DefaultMinValue = System.DateTime.MinValue;
    public static readonly System.DateTime DefaultMaxValue = System.DateTime.MaxValue;
    public System.DateTime MinValue { get; set; } = DefaultMinValue;
    public System.DateTime MaxValue { get; set; } = DefaultMaxValue;
    public bool AllowFutureOnly { get; set; } = true;
}

