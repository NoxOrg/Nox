using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;
using Nox.Integration.Extensions;

namespace Nox.Integration.EtlTests;

public class JsonFileTests: IClassFixture<SqlServerIntegrationFixture>
{
    private readonly SqlServerIntegrationFixture _sqlFixture;
    
    public JsonFileTests(SqlServerIntegrationFixture sqlFixture)
    {
        _sqlFixture = sqlFixture;
    }

    
    //[Fact (Skip = "This test can only be run locally if you have a local sql server instance and have created the CountrySource database using ./files/Create_CountrySource.sql")]
    [Fact]
    public async Task Can_integrate_json_to_sql_table()
    {
        _sqlFixture.Configure("./files/JsonSource/json-source.solution.nox.yaml");
        _sqlFixture.Services!.RegisterTransformHandler<TestNoxCustomTransformHandler>();
        _sqlFixture.Initialize();
        
        var context = _sqlFixture.ServiceProvider!.GetRequiredService<INoxIntegrationContext>();
        await context.ExecuteIntegrationAsync("JsonToSqlIntegration");
    }
}