using System;

namespace Nox.Types;

public class DateTimeRangeTypeOptions : INoxTypeOptions
{
    public static readonly System.DateTimeOffset DefaultMinStartValue = new DateTimeOffset(1800, 1, 1, 0, 0, 0, TimeSpan.Zero);
    public static readonly System.DateTimeOffset DefaultMaxEndValue = new DateTimeOffset(3000, 12, 31, 0, 0, 0, TimeSpan.Zero);
    public System.DateTimeOffset MinStartValue { get; set; } = DefaultMinStartValue;
    public System.DateTimeOffset MaxEndValue { get; set; } = DefaultMaxEndValue;
}
