using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;

namespace Nox.Integration.EtlTests;

public class CoreTests: IClassFixture<SqlServerIntegrationFixture>
{
    private readonly SqlServerIntegrationFixture _sqlFixture;

    public CoreTests(SqlServerIntegrationFixture sqlFixture)
    {
        _sqlFixture = sqlFixture;
    }

    
    [Fact (Skip = "This test can only be run locally if you have a local sql server instance and have created the CountrySource database using ./files/Create_CountrySource.sql")]
    //[Fact]
    public async Task Can_Execute_an_Integration_From_Yaml_Definition()
    {
        _sqlFixture.Configure("./files/Minimal/minimal.solution.nox.yaml");
        _sqlFixture.Initialize();
        var context = _sqlFixture.ServiceProvider!.GetRequiredService<INoxIntegrationContext>();
        await context.ExecuteIntegrationAsync("SqlToSqlIntegration");
    }
}