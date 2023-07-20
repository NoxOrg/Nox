using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace Nox.Solution;

internal class NoxSolutionBasicsOnlySerializer
{
    internal static NoxSolutionBasicsOnly Deserialize(string yaml)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .WithNodeTypeResolver(new ReadOnlyCollectionNodeTypeResolver())
            .IgnoreUnmatchedProperties()
            .Build();
    
        return deserializer.Deserialize<NoxSolutionBasicsOnly>(yaml);
    }
}