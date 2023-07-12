using Nox.Abstractions;
using Nox.Secrets.Abstractions;
using Nox.Solution;

namespace Nox.Secrets.Azure;

public class AzureSecretsResolver: ISecretsResolver
{
    private readonly IPersistedSecretStore _store;
    private readonly SecretsServer _secretsServer;
    private readonly string _storePrefix;

    public AzureSecretsResolver(IPersistedSecretStore store, SecretsServer secretsServer, string? storePrefix = null)
    {
        if (secretsServer.Provider != SecretsServerProvider.AzureKeyVault) throw new NoxSecretsException("Azure secrets resolver can only be instantiated if provider is set to AzureKeyVault");
        _store = store;
        _storePrefix = "";
        if (!string.IsNullOrWhiteSpace(storePrefix)) _storePrefix = storePrefix + '.';
        _secretsServer = secretsServer;
    }

    public IReadOnlyDictionary<string, string?> Resolve(string[] keys)
    {
        var unresolvedKeys = new List<string>();
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
            var cachedSecret = _store.Load($"{_storePrefix}{key}", ttl);
            if (!string.IsNullOrWhiteSpace(cachedSecret))
            {
                resolvedSecrets.Add(new KeyValuePair<string, string?>(key, cachedSecret));
            }
            else
            {
                unresolvedKeys.Add(key);
            }
        }
        
        if (unresolvedKeys.Any())
        {
            switch (_secretsServer.Provider)
            {
                case SecretsServerProvider.AzureKeyVault:
                    try
                    {
                        var azureVault = new AzureSecretsProvider(_secretsServer.ServerUri);
                        var secrets = azureVault.GetSecretsAsync(unresolvedKeys.ToArray()).Result;
                        if (secrets.Any())
                        {
                            resolvedSecrets.AddRange(secrets);
                        }

                        foreach (var secret in secrets)
                        {
                            if (secret.Value != null) _store.Save($"{_storePrefix}{secret.Key}", secret.Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new NoxSecretsException("Unable to retrieve secrets from the Azure vault, are you connected to the internet and is the vault available?", ex);                        
                    }

                    break;
            }
        }
        return resolvedSecrets.ToDictionary(k => k.Key, v => v.Value);
    }
}