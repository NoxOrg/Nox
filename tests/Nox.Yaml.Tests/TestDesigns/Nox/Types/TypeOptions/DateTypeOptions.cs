using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class DateTypeOptions : INoxTypeOptions
{
    public static readonly DateTime DefaultMinValue = new DateTime(1800, 1, 1);
    public static readonly DateTime DefaultMaxValue = new DateTime(3000, 12, 31);
    public DateTime MinValue { get; set; } = DefaultMinValue;
    public DateTime MaxValue { get; set; } = DefaultMaxValue;
}