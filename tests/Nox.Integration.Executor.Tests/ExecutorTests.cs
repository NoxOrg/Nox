using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;

namespace Nox.Integration.Executor.Tests;

public class ExecutorTests: IClassFixture<ServiceFixture>
{
    private readonly ServiceFixture _serviceFixture;

    public ExecutorTests(ServiceFixture serviceFixture)
    {
        _serviceFixture = serviceFixture;
    }

    [Fact]
    public async Task Can_Execute_an_integration()
    {
        var executor = _serviceFixture.ServiceProvider.GetRequiredService<IIntegrationExecutor>();
        var result = await executor.ExecuteAsync("TestIntegration");
        Assert.True(result);
    }
}