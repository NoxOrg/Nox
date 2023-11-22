using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Solution;

namespace Nox.Integration.EtlTests;

public class CustomTransformTests
{
#if DEBUG
    [Fact]
#else
    [Fact (Skip = "This test can only be run locally if you have a loal sql server instance and have created the CountrySource database using ./files/Create_CoutrySource.sql")]
#endif
    public async Task Can_Execute_an_integration_using_custom_transform()
    {
        var services = new ServiceCollection();
        services.AddLogging(configure => { configure.AddConsole(); });

        var solution = new NoxSolutionBuilder()
            .WithFile("./files/custom_integration.solution.nox.yaml")
            .Build();
        services
            .AddSingleton(solution)
            .AddNoxIntegrations(solution)
            .RegisterTransformHandler(typeof(TestNoxCustomTransformHandler))
            .RegisterTransformHandler(typeof(AnotherNoxCustomTransformHandler));
        var provider = services.BuildServiceProvider();
        var context = provider.GetRequiredService<INoxIntegrationContext>();
        var result = await context.ExecuteIntegrationAsync("SqlToSqlCustomIntegration");
        Assert.True(result);
    }
}