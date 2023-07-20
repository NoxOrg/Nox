using Nox.Solution.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YamlDotNet.Serialization;

namespace Nox.Solution;

internal class YamlResolverResult
{
    private string _refResolvedYaml;

    private string? _finalYaml;

    private IList<YamlVariableInfo> _variables;

    public IReadOnlyList<string> Variables(string type) => _variables
        .Where(i => i.Type == type)
        .Select(i => i.Name)
        .Distinct()
        .ToList();

    public string RefResolvedYaml => _refResolvedYaml;

    public YamlResolverResult
        (string refResolvedYaml, IList<YamlVariableInfo> variables)
    {
        _refResolvedYaml = refResolvedYaml;
        _variables = variables;
    }

    public string ReplaceVariables(IDictionary<string, string?> variableValues)
    {
        if (!variableValues.Any()) return _refResolvedYaml;

        var serializer = new SerializerBuilder().Build();

        var sb = new StringBuilder(_refResolvedYaml);

        foreach (var info in _variables.Select(i => i).Reverse())
        {
            var variableValue = variableValues[info.Name];

            if (variableValue is null)
            {
                throw new NoxSolutionConfigurationException($"Variable [{info.Type}.{info.Name}] was not found or resolved.");
            }

            sb.Remove(info.Index, info.Length);
            sb.Insert(info.Index, serializer.Serialize(variableValue));
        }

        _finalYaml = sb.ToString();

        return _finalYaml;
    }

}
