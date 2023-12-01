using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Hashicorp;
using Nox.Solution;

namespace Nox.Secrets.Tests;

public class HashicorpTests
{
    [Fact (Skip = "This test can only be run if you have access to the Azure nox-EDA1DB500EBCEB02 key vault with your azure login")]
    public void Can_Retrieve_a_secret()
    {
        var services = new ServiceCollection();
        services.AddPersistedSecretStore();
        var svcProvider = services.BuildServiceProvider();

        var secretsServer = new SecretsServer
        {
            Name = "org-vault",
            Provider = SecretsServerProvider.HashicorpVault,
            ServerUri = "http://localhost:8300",
            Password = "root",
            ValidFor = new SecretsValidFor
            {
                Seconds = 10
            }
        };

        var resolver = new HashicorpSecretsResolver(
            svcProvider.GetRequiredService<IPersistedSecretStore>(),
            secretsServer);
        
        var keys = new string[]
        {
            "org-only-secret"
        };
       
        var result = resolver.Resolve(keys);
        Assert.Single(result);
        Assert.Equal("This is an organization only secret", result["org-only-secret"]);
    }
}