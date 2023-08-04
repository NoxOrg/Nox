// Generated

using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Nox.Localization.Tests;

public partial class TestDbContext : NoxDbContext
{
    public TestDbContext(
            DbContextOptions<TestDbContext> options,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider
        ) : base(noxSolution, databaseProvider, clientAssemblyProvider)
    { }
}