using System.Dynamic;
using ETLBox.DataFlow.Connectors;
using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;
using Nox.IntegrationSource.File;

namespace Nox.Integration.Executor.Tests;

public class SourceFactoryTests: IClassFixture<ServiceFixture>
{
    private readonly ServiceFixture _serviceFixture;

    public SourceFactoryTests(ServiceFixture serviceFixture)
    {
        _serviceFixture = serviceFixture;
        _serviceFixture.Configure("csv-source.solution.nox.yaml");
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
        var csvSource = factory.Create("CsvSource");
        Assert.NotNull(csvSource);
        Assert.IsType<CsvIntegrationSource>(csvSource);
        var dataFlowSource = csvSource.DataFlowSource();
        Assert.NotNull(dataFlowSource);
        Assert.IsType<CsvSource<ExpandoObject>>(dataFlowSource);
    }
    
}