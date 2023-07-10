using System.Reflection;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Providers;
using Nox.Secrets.Resolvers;
using Nox.Solution;

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
        var orgSecrets = ResolveOrganizationSecrets(keys);
        if (orgSecrets != null) SetSecrets(orgSecrets!, result);
        var slnSecrets = ResolveSolutionSecrets(keys);
        if (slnSecrets != null) SetSecrets(slnSecrets!, result);
        var userSecrets = _userSecretsProvider!.GetSecrets(keys);
        if (userSecrets != null) SetSecrets(userSecrets, result);
        return result;
    }

    private IReadOnlyDictionary<string, string?>? ResolveOrganizationSecrets(string[] keys)
    {
        if (_secretsConfig.OrganizationSecretsServer != null)
        {
            switch (_secretsConfig.OrganizationSecretsServer.Provider)
            {
                case SecretsServerProvider.AzureKeyVault:
                    var azResolver = new AzureSecretsResolver(_store, _secretsConfig.OrganizationSecretsServer, "org");
                    return azResolver.Resolve(keys);
            }
        }

        return null;
    }

    private IReadOnlyDictionary<string, string?>? ResolveSolutionSecrets(string[] keys)
    {
        if (_secretsConfig.SolutionSecretsServer != null)
        {
            switch (_secretsConfig.SolutionSecretsServer.Provider)
            {
                case SecretsServerProvider.AzureKeyVault:
                    var azResolver = new AzureSecretsResolver(_store, _secretsConfig.SolutionSecretsServer, "sln");
                    return azResolver.Resolve(keys);
            }
        }

        return null;
    }

    private void SetSecrets(IReadOnlyDictionary<string, string?> source, IDictionary<string, string?> target)
    {
        foreach (var sourceSecret in source)
        {
            if (target.ContainsKey(sourceSecret.Key))
            {
                target[sourceSecret.Key] = sourceSecret.Value;
            }
            else
            {
                target.Add(sourceSecret.Key, sourceSecret.Value);
            }
        }
    }
    
}

