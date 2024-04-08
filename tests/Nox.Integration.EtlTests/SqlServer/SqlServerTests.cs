using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions.Interfaces;

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
}