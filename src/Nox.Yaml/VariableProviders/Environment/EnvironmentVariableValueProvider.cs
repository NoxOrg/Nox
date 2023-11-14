namespace Nox.Yaml.VariableProviders.Environment;

public sealed class EnvironmentVariableValueProvider 
{
    private readonly IEnvironmentProvider _environmentProvider;

    public EnvironmentVariableValueProvider(IEnvironmentProvider environmentProvider)
    {
        _environmentProvider = environmentProvider;
    }

    public IReadOnlyDictionary<string, string?> Resolve(
        IReadOnlyList<string> variables,
        IReadOnlyDictionary<string, object>? defaults = null)
    {
        var values = new Dictionary<string, string?>(variables.Count);

        foreach (var variableName in variables)
        {
            var environmentValue = _environmentProvider.GetEnvironmentVariable(variableName);

            if (string.IsNullOrWhiteSpace(environmentValue)
                && defaults is not null
                && defaults.ContainsKey(variableName))
            {
                environmentValue = defaults[variableName].ToString();
            }
            values[variableName] = environmentValue;
        }
        return values;
    }
}