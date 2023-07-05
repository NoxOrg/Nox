namespace Nox.Solution.Utils;

internal sealed class EnvironmentProvider : IEnvironmentProvider
{
    public string? GetEnvironmentVariable(string variable)
    {
        return System.Environment.GetEnvironmentVariable(variable);
    }
}