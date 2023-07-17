using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Nox.Integration.Abstractions;
using Nox.Integration.Service;
using Nox.Solution;

namespace Nox.Integration.Executor.Tests;

public class ServiceFixture
{
    private IServiceProvider? _serviceProvider;

    public IServiceProvider ServiceProvider => _serviceProvider!;

    public void Configure(string noxDefinitionFilename)
    {
        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile($"./files/{noxDefinitionFilename}")
            .Build();
        
        var services = new ServiceCollection();

        services.AddLogging();
        
        services.AddSingleton(noxConfig);

        services.AddIntegration(noxConfig.Infrastructure!.Persistence.IntegrationDatabaseServer!);
        
        _serviceProvider = services.BuildServiceProvider();
    }
}