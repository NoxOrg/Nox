using DotNet.Testcontainers.Containers;
using Microsoft.EntityFrameworkCore;
using Nox.Types.EntityFramework.Abstractions;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.Fixtures;

public abstract class NoxTestContainerFixtureBase<TContainer> : IAsyncLifetime, INoxTestFixture
    where TContainer : DockerContainer
{
    protected TContainer _container = default!;

    public DbContextOptions<TestWebAppDbContext> CreateDbOptions()
    {
        var connectionString = GetConnectionString(_container);
        return CreateDbOptions(connectionString);
    }

    public abstract INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurators);

    public Task InitializeAsync()
    {
        return _container.StartAsync();
    }

    public Task DisposeAsync()
    {
        return _container
            .DisposeAsync()
            .AsTask();
    }

    protected abstract DbContextOptions<TestWebAppDbContext> CreateDbOptions(string connectionString);

    protected abstract string GetConnectionString(TContainer container);
}