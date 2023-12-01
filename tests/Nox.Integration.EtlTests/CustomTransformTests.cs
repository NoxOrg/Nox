using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Extensions;
using Nox.Integration.SqlServer;
using Nox.Solution;

namespace Nox.Integration.EtlTests;

public class CustomTransformTests
{
    [Fact (Skip = "This test can only be run locally if you have a local sql server instance and have created the CountrySource database using ./files/Create_CoutrySource.sql")]
    public async Task Can_Execute_an_integration_using_custom_transform()
    {
        var services = new ServiceCollection();
        services.AddLogging(configure => { configure.AddConsole(); });

        var solution = new NoxSolutionBuilder()
            .WithFile("./files/CustomHandler/custom.solution.nox.yaml")
            .Build();
        services
            .AddSingleton(solution)
            .AddNoxIntegrations(opts =>
            {
                opts.WithSqlServerStore();
            })
            .RegisterTransformHandler(typeof(TestNoxCustomTransformHandler))
            .RegisterTransformHandler(typeof(AnotherNoxCustomTransformHandler));
        var provider = services.BuildServiceProvider();
        var context = provider.GetRequiredService<INoxIntegrationContext>();
        await context.ExecuteIntegrationAsync("SqlToSqlCustomIntegration");
    }
}