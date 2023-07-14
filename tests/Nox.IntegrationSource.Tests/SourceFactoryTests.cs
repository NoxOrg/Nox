using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;

namespace Nox.IntegrationSource.Tests;

public class SourceFactoryTests: IClassFixture<ServiceFixture>
{
    private readonly ServiceFixture _serviceFixture;

    public SourceFactoryTests(ServiceFixture serviceFixture)
    {
        _serviceFixture = serviceFixture;
    }
    
    [Fact]
    public void Can_Resolve_Source_Factory()
    {
        var factory = _serviceFixture.ServiceProvider.GetRequiredService<IIntegrationSourceFactory>();
        Assert.NotNull(factory);
    }

    [Fact]
    public void Can_Resolve_Csv_Source_From_Factory()
    {
        var factory = _serviceFixture.ServiceProvider.GetRequiredService<IIntegrationSourceFactory>();
        var csvSource = factory.Create("TestCsvSource");
        Assert.NotNull(csvSource);
    }
    
}