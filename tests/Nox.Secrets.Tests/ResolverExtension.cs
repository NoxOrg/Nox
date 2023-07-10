using System.Reflection;
using Nox.Secrets.Abstractions;
using Nox.Solution;

namespace Nox.Secrets.Tests;

public static class ResolverExtension
{
    public static void ConfigureForTest(this ISecretsResolver resolver)
    {
        var secretsConfig = new Solution.Secrets
        {
            OrganizationSecretsServer = new SecretsServer
            {
                Name = "OrgKeyVault",
                Provider = SecretsServerProvider.AzureKeyVault,
                ServerUri = "https://nox-EDA1DB500EBCEB02.vault.azure.net/",
                ValidFor = new SecretsValidFor
                {
                    Seconds = 30
                }    
            },
            SolutionSecretsServer = new SecretsServer
            {
                Name = "SlnKeyVault",
                Provider = SecretsServerProvider.AzureKeyVault,
                ServerUri = "https://we-key-nox-test.vault.azure.net",
                ValidFor = new SecretsValidFor
                {
                    Seconds = 30
                }
            }
        };
        resolver.Configure(secretsConfig, Assembly.GetCallingAssembly());
    }
}