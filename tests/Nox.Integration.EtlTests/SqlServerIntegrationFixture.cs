using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nox.Configuration;
using Nox.Infrastructure;
using Nox.Integration.Extensions;
using Nox.Integration.SqlServer;
using Nox.Solution;

namespace Nox.Integration.EtlTests;

public class SqlServerIntegrationFixture
{
    public IServiceProvider? ServiceProvider { get; private set; }
    
    public void Initialize(string yamlFile)
    {
        var services = new ServiceCollection();
        services.AddLogging(configure =>
        {
            configure.AddConsole();
        });

        var solution = new NoxSolutionBuilder()
            .WithFile(yamlFile)
            .Build();

        services.AddSingleton<NoxSolution>(solution);
        services.AddSingleton(new NoxCodeGenConventions(solution));
        services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        
        services.AddNoxIntegrations(opts =>
        {
            opts.WithSqlServerStore();
        });
        ServiceProvider = services.BuildServiceProvider();
        
    }
}