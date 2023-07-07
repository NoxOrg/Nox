using System.Runtime.CompilerServices;
using Azure.Security.KeyVault.Secrets;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Helpers;

namespace Nox.Secrets.Providers;

public class AzureSecretsProvider: ISecretsProvider
{
    private readonly Uri _vaultUri;

    public AzureSecretsProvider(string vaultUrl)
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

    public async Task<IReadOnlyDictionary<string, string?>> GetSecretsAsync(string[] keys)
    {
        var result = new Dictionary<string, string?>();
        //todo replace this with credentials from yaml config
        var credential = await CredentialHelper.GetCredentialFromCacheOrBrowser();

        var secretClient = new SecretClient(_vaultUri, credential.Credential);
        try
        {
            foreach (var key in keys)
            {
                try
                {
                    var secret = await secretClient.GetSecretAsync(key.Replace(":", "--").Replace("_", "-"));
                    result[key] = secret.Value.Value;
                }
                catch 
                {
                    //Ignore
                }
            }
        }
        catch (Exception ex)
        {
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
            throw new Exception(errorMessage);
        }

        return result;
    }

    public IReadOnlyDictionary<string, string?> GetSecrets(string[] keys)
    {
        throw new Exception("Asynchronous 'GetSecretsAsync' method must be used for Azure secrets.");
    }

}