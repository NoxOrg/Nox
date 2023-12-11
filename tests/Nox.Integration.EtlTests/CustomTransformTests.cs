using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;
using Nox.Integration.Extensions;

namespace Nox.Integration.EtlTests;

public class CustomTransformTests: IClassFixture<SqlServerIntegrationFixture>
{
    private readonly SqlServerIntegrationFixture _sqlFixture;

    public CustomTransformTests(SqlServerIntegrationFixture sqlFixture)
    {
        _sqlFixture = sqlFixture;
    }

    
    [Fact (Skip = "This test can only be run locally if you have a local sql server instance and have created the CountrySource database using ./files/Create_CountrySource.sql")]
    //[Fact]
    public async Task Can_Execute_an_integration_using_custom_transform()
    {
        _sqlFixture.Configure("./files/CustomHandler/custom.solution.nox.yaml");
        _sqlFixture.Services!.RegisterTransformHandler<TestNoxCustomTransformHandler>();
        _sqlFixture.Services!.RegisterTransformHandler<AnotherNoxCustomTransformHandler>();
        _sqlFixture.Initialize();
        
        var context = _sqlFixture.ServiceProvider!.GetRequiredService<INoxIntegrationContext>();
        await context.ExecuteIntegrationAsync("SqlToSqlCustomIntegration");
    }
}