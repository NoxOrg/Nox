using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Resolvers;
using Nox.Solution;

namespace Nox.Secrets.Tests;

public class AzureTests
{
    //This test can only be run if you have access to the nox-EDA1DB500EBCEB02 key vault with your azure login
    [Fact]
    public void Can_Retrieve_a_secret()
    {
        var services = new ServiceCollection();
        services.AddPersistedSecretStore();
        var svcProvider = services.BuildServiceProvider();

        var secretsServer = new SecretsServer
        {
            Name = "AzureKeyVault",
            Provider = SecretsServerProvider.AzureKeyVault,
            ServerUri = "https://nox-EDA1DB500EBCEB02.vault.azure.net/",
            ValidFor = new SecretsValidFor
            {
                Seconds = 10
            }
        };

        var azureResolver = new AzureSecretsResolver(
            svcProvider.GetRequiredService<IPersistedSecretStore>(),
            secretsServer);
        
        var keys = new string[]
        {
            "test-secret"
        };
       
        var result = azureResolver.Resolve(keys);
        Assert.Single(result);
        Assert.Equal("This is an Organization Secret", result["test-secret"]);
    }
}
