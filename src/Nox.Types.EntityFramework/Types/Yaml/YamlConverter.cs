using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
/// Converts a <see cref="Yaml"/> to and from a <see cref="string"/> for Entity Framework.
/// </summary>
public class YamlConverter : ValueConverter<Yaml, string>
{
    public YamlConverter() : base(yaml => yaml.Value,
        yamlValue => Yaml.FromDatabase(yamlValue)) { }
}