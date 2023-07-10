using System.Reflection;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets.Abstractions;
using Nox.Solution;

namespace Nox.Secrets.Tests;

public class AzureTests
{
    //This test can only be run if you have access to the key vault with your azure login
    [Fact]
    public void Can_Retrieve_a_secret()
    {
        var services = new ServiceCollection();
        services.AddPersistedSecretStore();

        var secretsConfig = new Solution.Secrets
        {
            OrganizationSecretsServer = new SecretsServer
            {
                Name = "AzureKeyVault",
                Provider = SecretsServerProvider.AzureKeyVault,
                ServerUri = "https://nox-EDA1DB500EBCEB02.vault.azure.net/",
                ValidFor = new SecretsValidFor
                {
                    Seconds = 10
                }    
            }
        };

        services.AddSingleton<ISecretsResolver, SecretsResolver>(provider =>
        {
            var persistedSecretStore = provider.GetRequiredService<IPersistedSecretStore>();

            return new SecretsResolver(persistedSecretStore, secretsConfig, Assembly.GetExecutingAssembly());
        });
        
        
        var provider = services.BuildServiceProvider();
        var resolver = provider.GetRequiredService<ISecretsResolver>();
        var keys = new string[]
        {
            "test-secret"
        };
       
        var result = resolver.Resolve(keys);
        Assert.Single(result);
        Assert.Equal("This is an Organization Secret", result["test-secret"]);
    }
}
