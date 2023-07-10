using System.Reflection;

namespace Nox.Secrets.Abstractions;

public interface ISecretsResolver
{
    void Configure(Solution.Secrets configuration, Assembly? assemblyWithSecrets = null);
    
    IReadOnlyDictionary<string, string?> Resolve(string[] keys);
}