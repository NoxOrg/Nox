using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class YamlConverter: ValueConverter<Yaml, string>
{
    public YamlConverter() : base(text => text.Value, textValue => Yaml.From(textValue)) { }
}