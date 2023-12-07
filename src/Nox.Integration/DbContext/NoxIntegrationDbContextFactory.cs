using Nox.Infrastructure;
using Nox.Integration.Abstractions;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Integration;

public class NoxIntegrationDbContextFactory: INoxIntegrationDbContextFactory
{
    private readonly NoxSolution _solution;
    private readonly INoxIntegrationDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public NoxIntegrationDbContextFactory(
        NoxSolution solution,
        INoxIntegrationDatabaseProvider dbProvider,
        INoxClientAssemblyProvider clientAssemblyProvider)
    {
        _solution = solution;
        _dbProvider = dbProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
    }


    public NoxIntegrationDbContext CreateContext()
    {
        return new NoxIntegrationDbContext(_solution, _dbProvider, _clientAssemblyProvider);
    }
}