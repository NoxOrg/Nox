using System.Dynamic;
using ETLBox.Connection;
using ETLBox.DataFlow.Connectors;
using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;
using Nox.IntegrationTarget.SqlServer;

namespace Nox.Integration.Service.Tests;

public class TargetFactoryTests: IClassFixture<ServiceFixture>
{
    private readonly ServiceFixture _serviceFixture;

    public TargetFactoryTests(ServiceFixture serviceFixture)
    {
        _serviceFixture = serviceFixture;
    }
    
    [Fact]
    public void Can_Resolve_Target_Factory()
    {
        _serviceFixture.Configure("sql-target.solution.nox.yaml");
        var factory = _serviceFixture.ServiceProvider.GetRequiredService<IIntegrationTargetFactory>();
        Assert.NotNull(factory);
    }

    [Fact]
    public void Can_Resolve_SqlServer_Target_From_Factory()
    {
        _serviceFixture.Configure("sql-target.solution.nox.yaml");
        var factory = _serviceFixture.ServiceProvider.GetRequiredService<IIntegrationTargetFactory>();
        var sqlTarget = factory.Create("SqlTarget");
        Assert.NotNull(sqlTarget);
        Assert.IsType<SqlServerIntegrationTarget>(sqlTarget);
        Assert.Equal("SqlTarget", sqlTarget.Name);
        var dataFlowSource = sqlTarget.DataFlowSource();
        Assert.NotNull(dataFlowSource);
        Assert.IsType<DbSource<ExpandoObject>>(dataFlowSource);
        Assert.NotNull(sqlTarget.ConnectionManager);
        Assert.IsType<SqlConnectionManager>(sqlTarget.ConnectionManager);
    }
    
    [Fact]
    public void Can_Resolve_Entity_Target_From_Factory()
    {
        _serviceFixture.Configure("entity-target.solution.nox.yaml");
        var factory = _serviceFixture.ServiceProvider.GetRequiredService<IIntegrationTargetFactory>();
        var entityTarget = factory.Create("EntityTarget");
        Assert.NotNull(entityTarget);
        Assert.IsType<SqlServerIntegrationTarget>(entityTarget);
        var dataFlowSource = entityTarget.DataFlowSource();
        Assert.NotNull(dataFlowSource);
        Assert.IsType<DbSource<ExpandoObject>>(dataFlowSource);
        Assert.NotNull(entityTarget.ConnectionManager);
        Assert.IsType<SqlConnectionManager>(entityTarget.ConnectionManager);
    }

}