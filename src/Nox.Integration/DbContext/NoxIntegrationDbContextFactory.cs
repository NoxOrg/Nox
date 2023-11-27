using Nox.Infrastructure;
using Nox.Integration.Abstractions;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Integration;

public class NoxIntegrationDbContextFactory: INoxIntegrationDbContextFactory
{
    private readonly NoxSolution _solution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public NoxIntegrationDbContextFactory(
        NoxSolution solution,
        INoxDatabaseProvider dbProvider,
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