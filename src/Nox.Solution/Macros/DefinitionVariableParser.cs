using System.Collections.Generic;
using System.IO;
using Nox.Solution.Exceptions;
using YamlDotNet.RepresentationModel;

namespace Nox.Solution.Macros;

public class DefinitionVariableParser
{
    public IReadOnlyDictionary<string, string>? Parse(string text)
    {
        var result = new Dictionary<string, string>();
        var source = new StringReader(text);
        var yaml = new YamlStream();
        yaml.Load(source);
        if (yaml.Documents.Count == 0) return null;
        var mappingNode = (YamlMappingNode)yaml.Documents[0].RootNode;
        try
        {
            var variables = mappingNode.Children[new YamlScalarNode("variables")];
            foreach (var variable in (YamlMappingNode)variables)
            {
                result.Add(variable.Key.ToString(), variable.Value.ToString());
            }

            return result;
        }
        catch
        {
            //ignore as there are no variables nodes in the yaml
        }

        return null;
    }
}