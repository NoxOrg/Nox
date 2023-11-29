using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nox.Configuration;
using Nox.Infrastructure;
using Nox.Integration.Abstractions;
using Nox.Integration.Extensions;
using Nox.Integration.Services;
using Nox.Integration.SqlServer;
using Nox.Solution;

namespace Nox.Integration.EtlTests;

public class CoreTests
{
// #if DEBUG
//     [Fact (Skip = "This test can only be run locally if you have a loal sql server instance and have created the CountrySource database using ./files/Create_CoutrySource.sql")]
// #else
//     [Fact]
// #endif  
    [Fact]    
    public async Task Can_Execute_an_Integration_From_Yaml_Definition()
    {
        var services = new ServiceCollection();
        services.AddLogging(configure =>
        {
            configure.AddConsole();
        });

        var solution = new NoxSolutionBuilder()
            .WithFile("./files/test_integration.solution.nox.yaml")
            .Build();

        services.AddSingleton<NoxSolution>(solution);
        services.AddSingleton(new NoxCodeGenConventions(solution));
        services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        
        services.AddNoxIntegrations(opts =>
        {
            opts.WithSqlServerStore();
        });
        var provider = services.BuildServiceProvider();
        var context = provider.GetRequiredService<INoxIntegrationContext>();
        await context.ExecuteIntegrationAsync("SqlToSqlIntegration");
    }
}