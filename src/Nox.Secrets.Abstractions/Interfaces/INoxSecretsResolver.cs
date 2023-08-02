using System.Reflection;

namespace Nox.Secrets.Abstractions;

public interface INoxSecretsResolver
{
    void Configure(Solution.Secrets configuration, Assembly? assemblyWithSecrets = null);
    
    IReadOnlyDictionary<string, string?> Resolve(IReadOnlyList<string> keys);
}