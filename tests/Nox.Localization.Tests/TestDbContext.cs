using Microsoft.EntityFrameworkCore;
using Nox.Localization.DbContext;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Localization.Tests;

public class TestDbContext: NoxLocalizationDbContext
{
    public TestDbContext(
        DbContextOptions<TestDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider,
        INoxClientAssemblyProvider clientAssemblyProvider): base(noxSolution, databaseProvider, clientAssemblyProvider)
    {
        
    }
}