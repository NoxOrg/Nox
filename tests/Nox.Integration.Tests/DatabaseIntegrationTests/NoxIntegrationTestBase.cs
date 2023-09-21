using Nox.Integration.Tests.Fixtures;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.DatabaseIntegrationTests;

public abstract class NoxIntegrationTestBase<TFixture> : IClassFixture<TFixture>
    where TFixture : class, INoxTestDataContextFixture
{
    protected NoxIntegrationTestBase(TFixture fixture)
    {
        DataContext = fixture.DataContext;

        DataContext.Database.EnsureDeleted();
        DataContext.Database.EnsureCreated();
    }

    protected TestWebAppDbContext DataContext { get; }
}