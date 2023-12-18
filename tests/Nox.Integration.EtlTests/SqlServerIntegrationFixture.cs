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
    public IServiceCollection? Services { get; private set; } 
    
    public void Configure(string yamlFile)
    {
        Services = new ServiceCollection();
        Services.AddLogging(configure =>
        {
            configure.AddConsole();
        });

        var solution = new NoxSolutionBuilder()
            .WithFile(yamlFile)
            .Build();

        Services.AddSingleton<NoxSolution>(solution);
        Services.AddSingleton(new NoxCodeGenConventions(solution));
        Services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        
        Services.AddNoxIntegrations(opts =>
        {
            opts.WithSqlServerStore();
        });
        Services.AddNoxMediatR(Assembly.GetExecutingAssembly());
    }

    public void Initialize()
    {
        ServiceProvider = Services!.BuildServiceProvider();
    }
}