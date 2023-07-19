using Nox.Abstractions;
using Nox.Secrets.Abstractions;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;

namespace Nox.Secrets.Hashicorp;

public class HashicorpSecretsProvider: ISecretsProvider
{
    private readonly IVaultClient _client;
    private readonly string _path;
    
    /// <summary>
    /// Create a new instance of a Hashicorp secrets provider 
    /// </summary>
    /// <param name="vaultUri">the uri to connect to the Hashicorp vault</param>
    /// <param name="token">The security token needed to successfully connect to the vault</param>
    /// <param name="path">The name of the key vault to operate on</param>
    public HashicorpSecretsProvider(string vaultUri, string token, string path)
    {
        _path = path;
        var authMethod = new TokenAuthMethodInfo(token);
        var vaultClientSettings = new VaultClientSettings(vaultUri, authMethod);
        _client = new VaultClient(vaultClientSettings);
    }
    
    
    public async Task<IReadOnlyDictionary<string, string?>> GetSecretsAsync(string[] keys)
    {
        var result = new Dictionary<string, string?>();
        var secrets = await _client.V1.Secrets.KeyValue.V2.ReadSecretAsync(_path, mountPoint: "secret");

        foreach (var key in keys)
        {
            if (secrets.Data.Data.TryGetValue(key, out var value))
            {
                var secret = value.ToString();
                result.Add(key, secret);
            }
        }
        return result;
    }

    public IReadOnlyDictionary<string, string?>? GetSecrets(string[] keys)
    {
        throw new Exception("Asynchronous 'GetSecretsAsync' method must be used for Hashicorp secrets.");
    }
}