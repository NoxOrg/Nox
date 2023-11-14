using System;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class DateTimeRangeTypeOptions : INoxTypeOptions
{
    public static readonly DateTimeOffset DefaultMinStartValue = new DateTimeOffset(1800, 1, 1, 0, 0, 0, TimeSpan.Zero);
    public static readonly DateTimeOffset DefaultMaxEndValue = new DateTimeOffset(3000, 12, 31, 0, 0, 0, TimeSpan.Zero);
    public DateTimeOffset MinStartValue { get; set; } = DefaultMinStartValue;
    public DateTimeOffset MaxEndValue { get; set; } = DefaultMaxEndValue;
}
