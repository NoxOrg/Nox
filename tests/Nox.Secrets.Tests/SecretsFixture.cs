using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets.Abstractions;
using Nox.Solution;

namespace Nox.Secrets.Tests;

public class SecretsFixture
{
    public IServiceProvider ServiceProvider { get; }

    public SecretsFixture()
    {
        var services = new ServiceCollection();
        services.AddPersistedSecretStore();

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

        services.AddSingleton<ISecretsResolver, SecretsResolver>(provider =>
        {
            var persistedSecretStore = provider.GetRequiredService<IPersistedSecretStore>();

            return new SecretsResolver(persistedSecretStore, secretsConfig, Assembly.GetExecutingAssembly());
        });
        
        
        ServiceProvider = services.BuildServiceProvider();
    }
}