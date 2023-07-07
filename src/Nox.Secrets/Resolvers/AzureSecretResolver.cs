using System.Runtime.CompilerServices;
using Azure.Security.KeyVault.Secrets;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Helpers;

namespace Nox.Secrets.Resolvers;

public class AzureSecretResolver: ISecretResolver
{
    private readonly Uri _vaultUri;

    public AzureSecretResolver(string vaultUrl)
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
    
    public async Task ResolveAsync(IDictionary<string, string?> secrets)
    {
        var credential = await CredentialHelper.GetCredentialFromCacheOrBrowser();

        var secretClient = new SecretClient(_vaultUri, credential.Credential);
        try
        {
            foreach (var key in secrets.Keys)
            {
                try
                {
                    var secret = await secretClient.GetSecretAsync(key.Replace(":", "--").Replace("_", "-"));
                    secrets[key] = secret.Value.Value;
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
    }

    public void Resolve(IDictionary<string, string?> secrets)
    {
        throw new Exception("Asynchronous 'ResolveAsync' method must be used for Azure secrets.");
    }

}