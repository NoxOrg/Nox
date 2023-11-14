using Nox.Infrastructure;
using Nox.Integration.Tests.DataProviders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using System;
using Testcontainers.MsSql;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.Fixtures;

public class NoxTestMsSqlContainerFixture : NoxTestContainerFixtureBase<MsSqlContainer>
{
    private const string MasterDbName = "master";

    public NoxTestMsSqlContainerFixture()
    {
        _container = new MsSqlBuilder()
            .WithAutoRemove(true)
            .WithCleanUp(true)
            .Build();
    }

    protected override INoxDatabaseProvider GetDatabaseProvider(
        IEnumerable<INoxTypeDatabaseConfigurator> configurators,
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        INoxClientAssemblyProvider clientAssemblyProvider
        )
    {
        return new MsSqlTestProvider(GetConnectionString(), configurators, noxSolutionCodeGeneratorState, clientAssemblyProvider);
    }

    private string GetConnectionString()
    {
        //For development purposes
        //return "Data Source=localhost;TrustServerCertificate=true;Initial Catalog=integrationtests;User ID=sa;password=Developer*123;";
        var connectionString = _container.GetConnectionString();
        if (connectionString.Contains(MasterDbName))
        {
            return connectionString.Replace(MasterDbName, nameof(AppDbContext));
        }

        return connectionString;
    }
}