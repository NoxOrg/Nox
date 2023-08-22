
using System;

namespace Nox.Types;
public class DateTimeTypeOptions : INoxTypeOptions
{
    public static readonly DateTimeOffset DefaultMinValue = DateTimeOffset.MinValue;
    public static readonly DateTimeOffset DefaultMaxValue = DateTimeOffset.MaxValue;
    public DateTimeOffset MinValue { get; set; } = DefaultMinValue;
    public DateTimeOffset MaxValue { get; set; } = DefaultMaxValue;
    public bool AllowFutureOnly { get; set; } = false;
}

