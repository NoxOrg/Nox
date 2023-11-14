using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class WeightTypeOptions : INoxTypeOptions
{
    private const double DefaultMinWeight = 0;
    private const double DefaultMaxWeight = 999_999_999_999_999;

    // Validation Properties
    public double MinValue { get; set; } = DefaultMinWeight;
    public double MaxValue { get; set; } = DefaultMaxWeight;

    // Creation Properties
    public WeightTypeUnit Units { get; set; } = WeightTypeUnit.Kilogram;

    // Database Creation Properties
    public WeightTypeUnit PersistAs { get; set; } = WeightTypeUnit.Kilogram;
}
