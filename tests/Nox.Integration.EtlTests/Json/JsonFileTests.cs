using ETLBox.DataFlow;
using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Adapters.Json;
using Nox.Integration.Adapters.SqlServer;
using Nox.Integration.Extensions;

namespace Nox.Integration.EtlTests.Json;

public class JsonFileTests: IClassFixture<SqlServerIntegrationFixture>
{
    private readonly SqlServerIntegrationFixture _sqlFixture;
    
    public JsonFileTests(SqlServerIntegrationFixture sqlFixture)
    {
        _sqlFixture = sqlFixture;
    }

    
    [Fact (Skip = "This test can only be run locally if you have a local sql server instance and have created the CountrySource database using ./files/Create_CountrySource.sql")]
    //[Fact]
    public async Task Can_integrate_json_to_sql_table()
    {
        _sqlFixture.Configure("./Json/files/JsonToSql/json-sql.solution.nox.yaml");
        _sqlFixture.Services!.RegisterIntegrationTransform<JsonToSqlTransform>();
        _sqlFixture.Initialize();
        
        var context = _sqlFixture.ServiceProvider!.GetRequiredService<INoxIntegrationContext>();
        await context.ExecuteIntegrationAsync("JsonToSqlIntegration");
    }

    
    [Fact (Skip = "This test can only be run locally if you have a local sql server instance and have created the CountrySource database using ./files/Create_CountrySource.sql")]
    //[Fact]
    public async Task Can_Execute_Json_To_Sql_Table()
    {
        var targetAdapter = new SqlServerTargetAdapter<TargetDto>("data source=LocalHost;user id=sa; password=Developer*123; database=TestTargetDb; pooling=false;encrypt=false", 
            null, null, tableName: "JsonToSql");
        
        var sourceAdapter = new JsonFileSourceAdapter<SourceDto>("CountryMaster.json", "./Json/files/");

        var source = sourceAdapter.DataFlowSource;

        var idCols = new List<string> { "Id" };
        var compCols = new List<string> { "CreateDate", "EditDate" };

        var target = targetAdapter.TableTarget!
                .WithMergeFields(idCols, compCols);
        
        var rowTransform = new RowTransformation<SourceDto, TargetDto>(record => (TargetDto)new JsonToSqlTransform().Invoke(record));
        var metricsTarget = targetAdapter.MetricsTarget;
        
        source
            .LinkTo<TargetDto>(rowTransform)
            .LinkTo(target)
            .LinkTo(metricsTarget);

        await Network.ExecuteAsync(source);
    }
}