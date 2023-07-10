using System.Reflection;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Providers;
using Nox.Secrets.Resolvers;

namespace Nox.Secrets;

public class SecretsResolver: ISecretsResolver
{
    private readonly ISecretsProvider? _userSecretsProvider;
    private readonly IPersistedSecretStore _store;
    private readonly Solution.Secrets _secretsConfig;

    public SecretsResolver(IPersistedSecretStore store, Solution.Secrets secretsConfig, Assembly executingAssembly)
    {
        _store = store;
        _userSecretsProvider = new UserSecretsProvider(executingAssembly);
        _secretsConfig = secretsConfig;
    }

    public IReadOnlyDictionary<string, string?> Resolve(string[] keys)
    {
        var result = new Dictionary<string, string?>();
        foreach (var key in keys)
        {
            result.Add(key, null);
        }
        
        ResolveUserSecrets(result);                        
        
        
        return result;
    }

    private void ResolveUserSecrets(IDictionary<string, string?> secrets)
    {
        var resolved = _userSecretsProvider!.GetSecrets(secrets.Keys.ToArray());
        
        foreach (var resolvedSecret in resolved)
        {
            secrets[resolvedSecret.Key] = resolvedSecret.Value;
        }
    }

    private void ResolveOrganizationSecrets(IDictionary<string, string?> secrets)
    {
        if (_secretsConfig.OrganizationSecretsServer != null)
        {
            switch (_secretsConfig.OrganizationSecretsServer.Provider)
            {
                case SecretsServerProvider.AzureKeyVault:
                    
                    break;
            }
        }
    }
    
    
}

