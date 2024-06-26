using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.EtlTests;

public class SourceFilterTests: IClassFixture<SqlServerIntegrationFixture>
{
    private readonly SqlServerIntegrationFixture _sqlFixture;

    public SourceFilterTests(SqlServerIntegrationFixture sqlFixture)
    {
        _sqlFixture = sqlFixture;
    }
    
    
    [Fact (Skip = "This test can only be run locally if you have a local sql server instance and have created the CountrySource database using ./files/Create_CoutrySource.sql")]
    //[Fact]
    public Task Can_filter_sql_server_query()
    {
        _sqlFixture.Configure("./files/SourceFilter/source-filter.solution.nox.yaml");
        _sqlFixture.Initialize();
        var context = _sqlFixture.ServiceProvider!.GetRequiredService<INoxIntegrationContext>();
        return context.ExecuteIntegrationAsync("SqlToSqlIntegration");
    }
}