using Azure.Core;
using Azure.Identity;
using Nox.Abstractions.Configuration;

namespace Nox.Secrets.Azure;

public static class CredentialHelper
{
    private const string TokenCacheName = "NoxLibToken";

    public static async Task<(TokenCredential Credential, AuthenticationRecord AuthenticationRecord)> GetCredentialFromCacheOrBrowser()
    {
        var cacheTokenFile = WellKnownPaths.CacheTokenFile;
        var cacheTokenFolder = Path.GetDirectoryName(cacheTokenFile);

        Directory.CreateDirectory(cacheTokenFolder!);

        InteractiveBrowserCredential credential;
        AuthenticationRecord authRecord;


        if (!File.Exists(cacheTokenFile))
        {
            credential = new InteractiveBrowserCredential(
                new InteractiveBrowserCredentialOptions
                {
                    TokenCachePersistenceOptions = new TokenCachePersistenceOptions
                        { Name = TokenCacheName }
                });

            authRecord = await credential.AuthenticateAsync();

            using var authRecordStream = new FileStream(cacheTokenFile, FileMode.Create, FileAccess.Write);
            await authRecord.SerializeAsync(authRecordStream);
        }
        else
        {
            using var authRecordStream = new FileStream(cacheTokenFile, FileMode.Open, FileAccess.Read);
            authRecord = await AuthenticationRecord.DeserializeAsync(authRecordStream);

            credential = new InteractiveBrowserCredential(
                new InteractiveBrowserCredentialOptions
                {
                    TokenCachePersistenceOptions = new TokenCachePersistenceOptions
                        { Name = TokenCacheName },
                    AuthenticationRecord = authRecord
                }
            );
        }

        return (credential, authRecord);
    }

    public static async Task<string?> GetAzureDevOpsAccessToken()
    {
        var credentials = await GetCredentialFromCacheOrBrowser();
        var scopes = new string[] { "499b84ac-1321-427f-aa17-267ca6975798/.default" };
        var token = await credentials.Credential.GetTokenAsync(new TokenRequestContext(scopes), CancellationToken.None);
        return token.Token;
    }
}