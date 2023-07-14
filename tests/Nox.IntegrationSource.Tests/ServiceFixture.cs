using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Executor;
using Nox.IntegrationSource.File;

namespace Nox.IntegrationSource.Tests;

public class ServiceFixture
{
    public IServiceProvider ServiceProvider { get; }

    public ServiceFixture()
    {
        var services = new ServiceCollection();
        services
            .AddCsvIntegrationSource()
            .AddIntegrationSourceFactory();
        
        ServiceProvider = services.BuildServiceProvider();
    }
}