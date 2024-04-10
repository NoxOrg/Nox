using System.Dynamic;
using ETLBox.DataFlow;
using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Adapters.SqlServer;
using Nox.Integration.EtlTests.Json;

namespace Nox.Integration.EtlTests.SqlServer;

public class SqlServerTests: IClassFixture<SqlServerIntegrationFixture>
{
    private readonly SqlServerIntegrationFixture _sqlFixture;

    public SqlServerTests(SqlServerIntegrationFixture sqlFixture)
    {
        _sqlFixture = sqlFixture;
    }

    
    [Fact (Skip = "This test can only be run locally if you have a local sql server instance and have created the CountrySource database using ./files/Create_CountrySource.sql")]
    //[Fact]
    public async Task Can_Execute_a_Sql_to_Sql_integration()
    {
        _sqlFixture.Configure("./SqlServer/files/Minimal/minimal.solution.nox.yaml");
        _sqlFixture.Initialize();
        var context = _sqlFixture.ServiceProvider!.GetRequiredService<INoxIntegrationContext>();
        await context.ExecuteIntegrationAsync("SqlToSqlIntegration");
    }

    [Fact]
    public async Task Can_Do_Sql_to_Sql()
    {
        var sourceAdapter = new SqlServerQuerySourceAdapter("SELECT CountryId AS Id, Name, Population, CreateDate, EditDate, NEWID() AS Etag FROM CountryMaster", 5, 
            "data source=LocalHost;user id=sa; password=Developer*123; database=CountrySource; pooling=false;encrypt=false");
        
        var targetAdapter = new SqlServerTableTargetAdapter("data source=LocalHost;user id=sa; password=Developer*123; database=TestTargetDb; pooling=false;encrypt=false", 
            null, null, tableName: "SqlToSql");
        
        var source = sourceAdapter.DataFlowSource;

        var idCols = new List<string> { "Id" };
        var compCols = new List<string> { "CreateDate", "EditDate" };

        var target = targetAdapter.TableTarget!
            .WithMergeFields(idCols, compCols);
        
        var metricsTarget = targetAdapter.MetricsTarget;
        
        source
            .LinkTo(target)
            .LinkTo(metricsTarget);

        await Network.ExecuteAsync(source);
    }
}