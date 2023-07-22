using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Store.SqlServer;
using Nox.Solution;

namespace Nox.Integration.Service.Tests;

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

        services.AddIntegration(noxConfig.Infrastructure!.Persistence.IntegrationDatabaseServer!, opt =>
        {
            opt.UseSqlServer();
        });
        
        _serviceProvider = services.BuildServiceProvider();
    }
}