using System.Reflection;
using Nox.Abstractions;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Azure;

namespace Nox.Secrets;

public class NoxSecretsResolver: INoxSecretsResolver
{
    private readonly IPersistedSecretStore _store;
    private ISecretsResolver? _userSecretsResolver;
    private Solution.Secrets? _secretsConfig;

    public NoxSecretsResolver(IPersistedSecretStore store)
    {
        _store = store;
    }

    public void Configure(Solution.Secrets configuration, Assembly? assemblyWithSecrets = null)
    {
        _secretsConfig = configuration;
        _userSecretsResolver = new UserSecretsResolver(assemblyWithSecrets ?? Assembly.GetExecutingAssembly());
    }

    public IReadOnlyDictionary<string, string?> Resolve(string[] keys)
    {
        if (_secretsConfig == null) throw new NoxSecretsException("Secrets resolver has not been initialized. Please call the ISecretResolver.Initialize method before attempting to resolve any secrets.");
        var result = new Dictionary<string, string?>();
        var orgSecrets = ResolveOrganizationSecrets(keys);
        if (orgSecrets != null && orgSecrets.Any()) SetSecrets(orgSecrets!, result);
        var slnSecrets = ResolveSolutionSecrets(keys);
        if (slnSecrets != null && slnSecrets.Any()) SetSecrets(slnSecrets!, result);
        var userSecrets = _userSecretsResolver!.Resolve(keys);
        if (userSecrets.Any()) SetSecrets(userSecrets, result);
        return result;
    }

    private IReadOnlyDictionary<string, string?>? ResolveOrganizationSecrets(string[] keys)
    {
        if (_secretsConfig!.OrganizationSecretsServer != null)
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
        if (_secretsConfig!.SolutionSecretsServer != null)
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

