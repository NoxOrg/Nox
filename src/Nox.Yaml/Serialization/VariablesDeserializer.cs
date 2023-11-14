using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using Nox.Yaml.Parser;

namespace Nox.Yaml.Serialization;

internal class VariablesDeserializer
{
    internal static T Deserialize<T>(string yaml)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .WithNodeTypeResolver(new ReadOnlyCollectionNodeTypeResolver())
            .IgnoreUnmatchedProperties()
            .Build();

        return deserializer.Deserialize<T>(yaml);
    }
}