namespace Nox.Types;

public class DateTypeOptions: INoxTypeOptions
{
    public static readonly System.DateTime DefaultMinValue = new System.DateTime(1800, 1, 1);
    public static readonly System.DateTime DefaultMaxValue = new System.DateTime(3000, 12, 31);
    public System.DateTime MinValue { get; set; } = DefaultMinValue;
    public System.DateTime MaxValue { get; set; } = DefaultMaxValue;
}