using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Nox.Integration.Abstractions;
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

        services.AddSingleton<ILogger<IIntegrationExecutor>, NullLogger<IIntegrationExecutor>>();
        
        services.AddSingleton(noxConfig);

        services.AddIntegration();
        
        _serviceProvider = services.BuildServiceProvider();
    }
}