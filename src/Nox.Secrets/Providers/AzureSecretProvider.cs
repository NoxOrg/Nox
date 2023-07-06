using System.Runtime.CompilerServices;
using Azure.Security.KeyVault.Secrets;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Helpers;

namespace Nox.Secrets.Providers;

public class AzureSecretProvider: ISecretProvider
{
    private readonly Uri _vaultUri;

    public AzureSecretProvider(string vaultUrl)
    {
        if (Uri.IsWellFormedUriString(vaultUrl, UriKind.Absolute))
        {
            _vaultUri = new Uri(vaultUrl);
        }
        else
        {
            throw new Exception("VaultUrl is not a well formed Uri!");
        }
    }

    public int Precedence => 1;

    public async Task<IList<KeyValuePair<string, string>>?> GetSecretsAsync(string[] keys)
    {
        var credential = await CredentialHelper.GetCredentialFromCacheOrBrowser();

        var secrets = new List<KeyValuePair<string, string>>();

        var secretClient = new SecretClient(_vaultUri, credential.Credential);
        try
        {
            foreach (var key in keys)
            {
                try
                {
                    var secret = await secretClient.GetSecretAsync(key.Replace(":", "--").Replace("_", "-"));
                    secrets.Add(new KeyValuePair<string, string>(key, secret.Value.Value ?? ""));
                }
                catch 
                {
                    //Ignore
                }
            }
        }
        catch (Exception ex)
        {
#if NET7_0            
            string InterpolateError()
            {
                var interpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 2);
                interpolatedStringHandler.AppendLiteral("Error loading secrets from vault at '");
                interpolatedStringHandler.AppendFormatted(_vaultUri);
                interpolatedStringHandler.AppendLiteral("'. (");
                interpolatedStringHandler.AppendFormatted(ex.Message);
                interpolatedStringHandler.AppendLiteral(")");
                return interpolatedStringHandler.ToStringAndClear();
            }

            var errorMessage = InterpolateError();
#endif
#if NETSTANDARD2_0
            var errorMessage = string.Format("Error loading secrets from vault at '{0}'. ({1})", _vaultUri, ex.Message);
#endif
            
            throw new Exception(errorMessage);
        }
        return secrets;
    }

    public IList<KeyValuePair<string, string>>? GetSecrets(string[] keys)
    {
        throw new Exception("Asynchronous 'GetSecretsAsync' method must be used for Azure secrets.");
    }
}