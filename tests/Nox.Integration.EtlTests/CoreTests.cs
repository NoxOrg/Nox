using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nox.Configuration;
using Nox.Infrastructure;
using Nox.Integration.Abstractions;
using Nox.Integration.Extensions;
using Nox.Integration.Services;
using Nox.Integration.SqlServer;
using Nox.Solution;

namespace Nox.Integration.EtlTests;

public class CoreTests: IClassFixture<SqlServerIntegrationFixture>
{
    private readonly SqlServerIntegrationFixture _sqlFixture;

    public CoreTests(SqlServerIntegrationFixture sqlFixture)
    {
        _sqlFixture = sqlFixture;
    }

    
    [Fact (Skip = "This test can only be run locally if you have a local sql server instance and have created the CountrySource database using ./files/Create_CountrySource.sql")]
    public Task Can_Execute_an_Integration_From_Yaml_Definition()
    {
        _sqlFixture.Initialize("./files/Minimal/minimal.solution.nox.yaml");
        var context = _sqlFixture.ServiceProvider!.GetRequiredService<INoxIntegrationContext>();
        return context.ExecuteIntegrationAsync("SqlToSqlIntegration");
    }
}