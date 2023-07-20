using System.Collections.Generic;
using System.Text.RegularExpressions;
using Nox.Solution.Utils;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Nox.Solution.Macros;

public class EnvironmentVariableValueProvider

{
    private readonly IEnvironmentProvider _environmentProvider;

    public EnvironmentVariableValueProvider(IEnvironmentProvider environmentProvider)
    {
        _environmentProvider = environmentProvider;
    }

    public IReadOnlyDictionary<string, string?> Resolve(
        IReadOnlyList<string> variables, 
        IReadOnlyDictionary<string,string>? defaults = null)
    {
        var values = new Dictionary<string, string?> ();

        foreach (var variableName in variables)
        {
            var environmentValue = _environmentProvider.GetEnvironmentVariable(variableName);

            if (string.IsNullOrWhiteSpace(environmentValue) 
                && defaults is not null 
                && defaults.ContainsKey(variableName))
            {
                environmentValue = defaults[variableName];
            }
            values[variableName] = environmentValue;
        }
        return values;
    }
}