using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Nox.Integration.Abstractions;
using Nox.Solution;

namespace Nox.Integration.Executor.Tests;

public class ServiceFixture
{
    public IServiceProvider ServiceProvider { get; }

    public ServiceFixture()
    {
        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile("./files/csv.solution.nox.yaml")
            .Build();
        
        var services = new ServiceCollection();

        services.AddSingleton<ILogger<IIntegrationExecutor>, NullLogger<IIntegrationExecutor>>();
        
        services.AddSingleton(noxConfig);

        services.AddIntegration();
        
        ServiceProvider = services.BuildServiceProvider();
    }
}