using Microsoft.Extensions.Logging;
using Nox.Integration.Tests.Fixtures;
using TestWebApp.Infrastructure.Persistence;
using Xunit.Abstractions;

namespace Nox.Integration.Tests.DatabaseIntegrationTests;

public abstract class NoxIntegrationContainerTestBase<TFixture> : IClassFixture<TFixture>
    where TFixture : class, INoxTestDataContextFixture
{
    protected NoxIntegrationContainerTestBase(TFixture fixture)
    {
        DataContext = fixture.DataContext;

        DataContext.Database.EnsureDeleted();
        DataContext.Database.EnsureCreated();
    }

    protected TestWebAppDbContext DataContext { get; }
}