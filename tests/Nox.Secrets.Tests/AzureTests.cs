using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets.Abstractions;

namespace Nox.Secrets.Tests;

public class AzureTests
{
    //This test can only be run if you have access to the key vault with your azure login
    // [Fact]
    // public async Task Can_Retrieve_a_secret()
    // {
    //     var services = new ServiceCollection();
    //     services.AddAzureSecretResolver("https://nox-EDA1DB500EBCEB02.vault.azure.net/");
    //     var provider = services.BuildServiceProvider();
    //     var resolver = provider.GetRequiredService<ISecretResolver>();
    //     var secrets = new Dictionary<string, string?>
    //     {
    //         { "test-secret", null }
    //     };
    //     await resolver.ResolveAsync(secrets);
    //     Assert.Single(secrets);
    //     Assert.Equal("This is an Organization Secret", secrets["test-secret"]);
    // }
}