using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class YearTypeOptions : INoxTypeOptions
{
    public static readonly ushort DefaultMinValue = 1900;
    public static readonly ushort DefaultMaxValue = 3000;
    public ushort MinValue { get; set; } = DefaultMinValue;
    public ushort MaxValue { get; set; } = DefaultMaxValue;
    public bool AllowFutureOnly { get; set; } = false;
}
