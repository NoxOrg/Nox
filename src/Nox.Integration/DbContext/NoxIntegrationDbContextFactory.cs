using Nox.Infrastructure;
using Nox.Integration.Abstractions;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Integration;

public class NoxIntegrationDbContextFactory: INoxIntegrationDbContextFactory
{
    private readonly NoxSolution _solution;
    private readonly INoxDatabaseProviderResolver _databaseProviderResolver;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public NoxIntegrationDbContextFactory(
        NoxSolution solution,
        INoxDatabaseProviderResolver databaseProviderResolver,
        INoxClientAssemblyProvider clientAssemblyProvider)
    {
        _solution = solution;
        _databaseProviderResolver = databaseProviderResolver;
        _clientAssemblyProvider = clientAssemblyProvider;
    }


    public NoxIntegrationDbContext CreateContext()
    {
        var dbProvider = _databaseProviderResolver.Resolve(NoxDataStoreType.IntegrationStore);
        return new NoxIntegrationDbContext(_solution, dbProvider, _clientAssemblyProvider);
    }
}