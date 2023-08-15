using Microsoft.EntityFrameworkCore.Design;
using Nox.Abstractions;
using Nox.Abstractions.Localization;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Localization.DbContext;

public class NoxLocalizationDbContextFactory: INoxLocalizationDbContextFactory
{
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public NoxLocalizationDbContextFactory(
        INoxDatabaseProvider dbProvider,
        INoxClientAssemblyProvider clientAssemblyProvider)
    {
        _dbProvider = dbProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
    }
    
    public NoxLocalizationDbContext CreateContext()
    {
        return new NoxLocalizationDbContext(_dbProvider, _clientAssemblyProvider);
    }

    
}