using Nox.Secrets.Abstractions;
using Nox.Secrets.Providers;
using Nox.Solution;

namespace Nox.Secrets.Resolvers;

public class AzureSecretsResolver
{
    private readonly IPersistedSecretStore _store;
    private readonly SecretsServer _secretsServer;

    public AzureSecretsResolver(IPersistedSecretStore store, SecretsServer secretsServer)
    {
        _store = store;
        _secretsServer = secretsServer;
    }

    public IReadOnlyDictionary<string, string?> Resolve(string[] keys)
    {
        var result = new Dictionary<string, string?>();
        var ttl = TimeSpan.Zero;
        if (_secretsServer.ValidFor != null)
        {
            ttl = new TimeSpan(
                _secretsServer.ValidFor.Days ?? 0, 
                _secretsServer.ValidFor.Hours ?? 0, 
                _secretsServer.ValidFor.Minutes ?? 0, 
                _secretsServer.ValidFor.Seconds ?? 0);    
        }

        if (ttl == TimeSpan.Zero) ttl = new TimeSpan(0, 0, 30, 0);
        
        var resolvedSecrets = new List<KeyValuePair<string, string?>>();
        foreach (var key in keys)
        {
            var cachedSecret = _store.Load(key, ttl); 
            resolvedSecrets.Add(new KeyValuePair<string, string?>(key, cachedSecret));
        }
        
        var unresolvedSecrets = resolvedSecrets.Where(s => string.IsNullOrWhiteSpace(s.Value)).ToList();
        if (unresolvedSecrets.Any())
        {
            switch (_secretsServer.Provider)
            {
                case SecretsServerProvider.AzureKeyVault:
                    var azureVault = new AzureSecretsProvider(_secretsServer.ServerUri);
                    var azureSecrets = azureVault.GetSecretsAsync(unresolvedSecrets.Select(k => k.Key).ToArray()).Result;
                    if (azureSecrets.Any())
                    {
                        resolvedSecrets.AddRange(azureSecrets);
                    }
                    foreach (var azureSecret in azureSecrets)
                    {
                        if (azureSecret.Value != null) _store.Save(azureSecret.Key, azureSecret.Value);
                    }
                    break;
            }
        }

        foreach (var kv in resolvedSecrets)
        {
            result.Add(kv.Key, kv.Value);
        }

        return result;
    }
}