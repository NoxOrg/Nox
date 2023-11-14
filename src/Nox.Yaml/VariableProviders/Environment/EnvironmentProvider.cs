namespace Nox.Yaml.VariableProviders.Environment;

internal sealed class EnvironmentProvider : IEnvironmentProvider
{
    public string? GetEnvironmentVariable(string variable)
    {
        return System.Environment.GetEnvironmentVariable(variable);
    }
}