using System.Reflection;
using Nox.Secrets;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Azure;
using Nox.Secrets.Exceptions;
using Nox.Secrets.Hashicorp;

namespace Nox;

public class NoxSecretsResolver: INoxSecretsResolver
{
    private readonly IPersistedSecretStore _store;
    private ISecretsResolver? _userSecretsResolver;
    private Solution.Secrets? _secretsConfig;
    private bool _isConfigured = false;

    public NoxSecretsResolver(IPersistedSecretStore store)
    {
        _store = store;
    }

    public void Configure(Solution.Secrets configuration, Assembly? assemblyWithSecrets = null)
    {
        _secretsConfig = configuration;
        _userSecretsResolver = new UserSecretsResolver(assemblyWithSecrets ?? Assembly.GetExecutingAssembly());
        _isConfigured = true;
    }

    public IReadOnlyDictionary<string, string?> Resolve(IReadOnlyList<string> keys)
    {
        if (!_isConfigured) throw new NoxSecretsException("Secrets resolver has not been configured. Please call the Configure method before attempting to resolve any secrets.");
        var result = new Dictionary<string, string?>();
        if (_secretsConfig != null)
        {
            if (_secretsConfig.OrganizationSecretsServer != null)
            {
                var orgSecrets = ResolveOrganizationSecrets(keys);
                if (orgSecrets != null && orgSecrets.Any()) SetSecrets(orgSecrets!, result);    
            }

            if (_secretsConfig.SolutionSecretsServer != null)
            {
                var slnSecrets = ResolveSolutionSecrets(keys);
                if (slnSecrets != null && slnSecrets.Any()) SetSecrets(slnSecrets!, result);
            }
        }
        var userSecrets = _userSecretsResolver!.Resolve(keys);
        if (userSecrets.Any()) SetSecrets(userSecrets, result);
        return result;
    }

    private IReadOnlyDictionary<string, string?>? ResolveOrganizationSecrets(IReadOnlyList<string> keys)
    {
        if (_secretsConfig!.OrganizationSecretsServer != null)
        {
            switch (_secretsConfig.OrganizationSecretsServer.Provider)
            {
                case SecretsServerProvider.AzureKeyVault:
                    var azResolver = new AzureSecretsResolver(_store, _secretsConfig.OrganizationSecretsServer, "org");
                    return azResolver.Resolve(keys);
                case SecretsServerProvider.HashicorpVault:
                    var hcResolver = new HashicorpSecretsResolver(_store, _secretsConfig.OrganizationSecretsServer, "org");
                    return hcResolver.Resolve(keys);
            }
        }

        return null;
    }

    private IReadOnlyDictionary<string, string?>? ResolveSolutionSecrets(IReadOnlyList<string> keys)
    {
        if (_secretsConfig!.SolutionSecretsServer != null)
        {
            switch (_secretsConfig.SolutionSecretsServer.Provider)
            {
                case SecretsServerProvider.AzureKeyVault:
                    var azResolver = new AzureSecretsResolver(_store, _secretsConfig.SolutionSecretsServer, "sln");
                    return azResolver.Resolve(keys);
                case SecretsServerProvider.HashicorpVault:
                    var hcResolver = new HashicorpSecretsResolver(_store, _secretsConfig.SolutionSecretsServer, "sln");
                    return hcResolver.Resolve(keys);
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

