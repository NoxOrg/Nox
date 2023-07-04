namespace Nox.Solution.Utils;

/// <summary>
/// Create an indirection to access Environment Variables
/// Do not depend on static instances
/// </summary>
public interface IEnvironmentProvider
{
    string? GetEnvironmentVariable(string variable);
}