using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class TemperatureTypeOptions
{
    // Database Creation Properties
    public TemperatureTypeUnit PersistAs { get; set; } = TemperatureTypeUnit.Celsius;
    //Creation Properties
    public TemperatureTypeUnit Units { get; set; } = TemperatureTypeUnit.Celsius;
}