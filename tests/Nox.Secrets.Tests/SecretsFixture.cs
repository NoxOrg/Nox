using Microsoft.Extensions.DependencyInjection;

namespace Nox.Secrets.Tests;

public class SecretsFixture
{
    public IServiceProvider ServiceProvider { get; }

    public SecretsFixture()
    {
        var services = new ServiceCollection();
        services.AddSecretsResolver();
        ServiceProvider = services.BuildServiceProvider();
    }
   
}